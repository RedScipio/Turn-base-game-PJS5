using Battle;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace UGUI
{

    /// <summary>
    /// Form use to show a Basic Battle to the user
    /// </summary>
    /// <authors> MBL, DTR</authors>
    /// <date> 25-06-2024 </date>
    /// 
    public partial class BasicBattleForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        private string _fileName;
        private string _trackName;
        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);
        private BASIC_BATTLE _basicBattle;

        private List<Lever> _lLever = new List<Lever> { };
        private List<int> _lActions = new List<int> { };
        private string _baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        #region .. Double Buffered function ..
        public static void SetDoubleBuffered(Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }
        #endregion

        #region .. code for Flucuring ..
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }
        #endregion

        public BasicBattleForm(BASIC_BATTLE basicBattle)
        {
            InitializeComponent();
            SetDoubleBuffered(generalLayout);
            SetDoubleBuffered(tableLayoutPanel1);
            SetDoubleBuffered(tableLayoutPanel2);
            leverMainMenu.LabelClick += new EventHandler(lever_LabelClick);
            _lLever.Add(leverMainMenu);

            _basicBattle = basicBattle;

            string relativePath = "..\\..\\..\\..\\Ressources\\MusicMix.wav";
            _fileName = Path.GetFullPath(Path.Combine(_baseDirectory, relativePath));
            _trackName = "MusicMix";
            MusicSoundPlayer.Play(_fileName, _trackName);
            informationPanel.Hide();
        }

        public async void Shake(int iRobotChoice = 1)//1=player 2=robot
        {
            var original = playerRobotPicturebox.Location;
            var rnd = new Random(1337);
            const int shake_amplitude = 5;
            if (iRobotChoice == 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    playerRobotPicturebox.Invalidate();
                    playerRobotPicturebox.Location = new Point(original.X + rnd.Next(-shake_amplitude, shake_amplitude), original.Y + rnd.Next(-shake_amplitude, shake_amplitude));
                    playerRobotPicturebox.Invalidate();
                    await Task.Delay(20);
                    playerRobotPicturebox.Invalidate();
                }
            }
            else {
                original = enemyRobot.Location;
                for (int i = 0; i < 10; i++)
                {
                    enemyRobot.Invalidate();
                    enemyRobot.Location = new Point(original.X + rnd.Next(-shake_amplitude, shake_amplitude), original.Y + rnd.Next(-shake_amplitude, shake_amplitude));
                    enemyRobot.Invalidate();
                    await Task.Delay(20);
                    enemyRobot.Invalidate();
                }
            }

        }

        public void SetRoundedCorners(Panel panel, int borderRadius)
        {
            panel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width, panel.Height, borderRadius, borderRadius));
        }

        public async void WriteInformation(string content)
        {
            informationPanel.Show();
            infoLabel.Text = "";
            infoLabel.Text = content;
            AlignInfoLabel();
            await Task.Delay(3000);
            informationPanel.Hide();
        }

        protected void PlayRound()
        {
            foreach (Lever lever in _lLever)
            {
                lever.Hide();
            }

            _lLever.Clear();
            _lLever.Add(leverMainMenu);
            _lLever.Last().Enabled = true;

            BetweenTurn();

            GUI.ShowStatus(_basicBattle.Pilots[0], _basicBattle.Pilots[1]);

            PlayTurnBot();
            BetweenTurn();

            foreach (Lever lever in _lLever)
            {
                lever.Show();
            }
        }

        protected void BetweenTurn()
        {
            ShowStatus();

            if(_basicBattle.IsOver())
            {
                StartingForm sf = new StartingForm(_basicBattle.Pilots[0].GetRobot());
                Visible = false;
                sf.Visible = true;
            }
        }

        public System.Drawing.Color GetStatusColor(int life, int maxLife, int armor, int maxArmor)
        {
            if (life == 0)
            {
                return System.Drawing.Color.Red;
            }
            else if (life < maxLife)
            {
                return System.Drawing.Color.Orange;
            }
            else if (armor < maxArmor)
            {
                return System.Drawing.Color.Yellow;
            }
            return System.Drawing.Color.Gray; // Default color if none of the conditions match
        }

        protected void ShowStatus()
        {
            IROBOT robotPlayer = _basicBattle.Pilots[0].GetRobot();


            fuelBar2.Percentage = robotPlayer.GetFuel();
            scoreStatus2.RightArmColor = GetStatusColor(robotPlayer.GetRightWeaponLife(), robotPlayer.GetRightWeaponMaxLife(), robotPlayer.GetRightWeaponArmor(), robotPlayer.GetRightWeaponMaxArmor());
            scoreStatus2.LeftArmColor = GetStatusColor(robotPlayer.GetLeftWeaponLife(), robotPlayer.GetLeftWeaponMaxLife(), robotPlayer.GetLeftWeaponArmor(), robotPlayer.GetLeftWeaponMaxArmor());
            scoreStatus2.FurnaceColor = GetStatusColor(robotPlayer.GetFurnaceLife(), robotPlayer.GetFurnaceMaxLife(), robotPlayer.GetFurnaceArmor(), robotPlayer.GetFurnaceMaxArmor());
            scoreStatus2.LegsColor = GetStatusColor(robotPlayer.GetLegsLife(), robotPlayer.GetLegsMaxLife(), robotPlayer.GetLegsArmor(), robotPlayer.GetLegsMaxArmor());

            IROBOT robotEnnemi = _basicBattle.Pilots[1].GetRobot();
            fuelBar1.Percentage = robotEnnemi.GetFuel();
            scoreStatus4.RightArmColor = GetStatusColor(robotEnnemi.GetRightWeaponLife(), robotEnnemi.GetRightWeaponMaxLife(), robotEnnemi.GetRightWeaponArmor(), robotEnnemi.GetRightWeaponMaxArmor());
            scoreStatus4.LeftArmColor = GetStatusColor(robotEnnemi.GetLeftWeaponLife(), robotEnnemi.GetLeftWeaponMaxLife(), robotEnnemi.GetLeftWeaponArmor(), robotEnnemi.GetLeftWeaponMaxArmor());
            scoreStatus4.FurnaceColor = GetStatusColor(robotEnnemi.GetFurnaceLife(), robotEnnemi.GetFurnaceMaxLife(), robotEnnemi.GetFurnaceArmor(), robotEnnemi.GetFurnaceMaxArmor());
            scoreStatus4.LegsColor = GetStatusColor(robotEnnemi.GetLegsLife(), robotEnnemi.GetLegsMaxLife(), robotEnnemi.GetLegsArmor(), robotEnnemi.GetLegsMaxArmor());

            return;
        }

        protected void PlayTurnBot()
        {
            return;
        }

        protected void lever_LabelClick(object sender, EventArgs eventLever)
        {
            string relativePath = "..\\..\\..\\..\\Ressources\\SoundEffect\\Collect\\collect-2.wav";
            _fileName = Path.GetFullPath(Path.Combine(_baseDirectory, relativePath));
            _trackName = "collect-2";
            MusicSoundPlayer.Play(_fileName, _trackName);

            Lever lever = (Lever)sender;
            string sAction = lever.SelectedAction.Replace("- ", "");

            List<string> lStringLabels = new List<string> { };
            lStringLabels.Clear();

            int iColumnLever = generalLayout.GetCellPosition(_lLever.Last()).Column;

            bool bCreateLever = true;

            switch (iColumnLever)
            {
                case 0:
                    {
                        _lActions.Clear();

                        switch (sAction)
                        {
                            case "Attack":
                                {
                                    if (_basicBattle.CurrentPilot.IsWeaponUsable(0) == false && _basicBattle.CurrentPilot.IsWeaponUsable(1) == false )
                                    {
                                        bCreateLever = false;
                                        WriteInformation("No usable weapons");

                                        break;
                                    }

                                    lStringLabels.Add("Use Left Weapon");
                                    lStringLabels.Add("Use Right Weapon");

                                    _lActions.Add((int)MAIN_MENU.Attack);

                                    break;
                                }

                            case "Repair":
                                {
                                    if (_basicBattle.CurrentPilot.IsWeaponBroken(0) == false && _basicBattle.CurrentPilot.IsWeaponBroken(1) == false && _basicBattle.CurrentPilot.IsFurnaceBroken() == false && _basicBattle.CurrentPilot.IsLegsBroken() == false)
                                    {
                                        bCreateLever = false;
                                        WriteInformation("Already in a perfect state");

                                        break;
                                    }

                                    lStringLabels.Add("Light Armor");
                                    lStringLabels.Add("Heavy Armor");
                                    lStringLabels.Add("Repair Kits");
                                    lStringLabels.Add("Full Kits");

                                    _lActions.Add((int)MAIN_MENU.Repairs);

                                    break;
                                }
                            case "Refuel":
                                {
                                    if (_basicBattle.CurrentPilot.GetRobot().GetFuel() == _basicBattle.CurrentPilot.GetRobot().GetMaxFuel())
                                    {
                                        bCreateLever = false;
                                        WriteInformation("Already full of fuel");

                                        break;
                                    }

                                    lStringLabels.Add("Wood");
                                    lStringLabels.Add("Charcoal");
                                    lStringLabels.Add("Coal");
                                    lStringLabels.Add("Compact Coal");

                                    _lActions.Add((int)MAIN_MENU.Furnace);

                                    break;
                                }
                        }

                        break;
                    }

                case 1:
                    {
                        if (_lActions[0] == (int)MAIN_MENU.Furnace)
                        {
                            int iSecondChoice = -1;

                            switch (sAction)
                            {
                                case "Wood":
                                    {
                                        iSecondChoice = (int)FUEL_MENU.Wood;
                                        break;
                                    }
                                case "Charcoal":
                                    {
                                        iSecondChoice = (int)FUEL_MENU.Charcoal;
                                        break;
                                    }
                                case "Coal":
                                    {
                                        iSecondChoice = (int)FUEL_MENU.Coal;
                                        break;
                                    }
                                case "Compact Coal":
                                    {
                                        iSecondChoice = (int)FUEL_MENU.Compact_Coal;
                                        break;
                                    }
                            }

                            _basicBattle.PlayTurn(0, (MAIN_MENU)_lActions[0], iSecondChoice);
                            PlayRound();
                            return;
                        }

                        if (_lActions[0] == (int)MAIN_MENU.Attack || _lActions[0] == (int)MAIN_MENU.Repairs)
                        {
                            lStringLabels.Add("Left Weapon");
                            lStringLabels.Add("Right Weapon");
                            lStringLabels.Add("Legs");
                            lStringLabels.Add("Furnace");

                            int iFirstAction = _lActions[0];
                            _lActions.Clear();
                            _lActions.Add(iFirstAction);

                            switch (sAction)
                            {
                                case "Use Left Weapon":
                                    {
                                        if (_basicBattle.CurrentPilot.IsWeaponUsable(0) == false)
                                        {
                                            bCreateLever = false;
                                            WriteInformation("The left weapon cannot be used");

                                            break;
                                        }

                                        _lActions.Add((int)WEAPON_MENU.Left_Weapon);
                                        break;
                                    }
                                case "Use Right Weapon":
                                    {
                                        if (_basicBattle.CurrentPilot.IsWeaponUsable(1) == false)
                                        {
                                            bCreateLever = false;
                                            WriteInformation("The right weapon cannot be used");

                                            break;
                                        }

                                        _lActions.Add((int)WEAPON_MENU.Right_Weapon);
                                        break;
                                    }
                                case "Light Armor":
                                    {
                                        _lActions.Add((int)REPAIRS_MENU.Light_Armor);
                                        break;
                                    }
                                case "Heavy Armor":
                                    {
                                        _lActions.Add((int)REPAIRS_MENU.Heavy_Armor);
                                        break;
                                    }
                                case "Repair Kits":
                                    {
                                        _lActions.Add((int)REPAIRS_MENU.Repair_Kits);
                                        break;
                                    }
                                case "Full Kits":
                                    {
                                        _lActions.Add((int)REPAIRS_MENU.Full_Kits);
                                        break;
                                    }
                            }
                        }

                        break;
                    }

                case 2:
                    {
                        int iThirdChoice = -1;

                        switch (sAction)
                        {
                            case "Left Weapon":
                                {
                                    iThirdChoice = (int)TARGET_MENU.Left_Weapon;
                                    break;
                                }
                            case "Right Weapon":
                                {
                                    iThirdChoice = (int)TARGET_MENU.Right_Weapon;
                                    break;
                                }
                            case "Legs":
                                {
                                    iThirdChoice = (int)TARGET_MENU.Legs;
                                    break;
                                }
                            case "Furnace":
                                {
                                    iThirdChoice = (int)TARGET_MENU.Furnace;
                                    break;
                                }
                        }

                        _basicBattle.PlayTurn(0, (MAIN_MENU)_lActions[0], _lActions[1], iThirdChoice);
                        PlayRound();
                        return;
                    }
            }

            if (bCreateLever)
            {
                CreateNewLever(lStringLabels);
                informationPanel.Hide();
            }
        }

        protected void lever_BackClick(object sender, EventArgs eventLever)
        {
            if (this.generalLayout != null)
            {
                _lLever.RemoveAt(_lLever.Count - 1);
                _lLever.Last().Enabled = true;
                informationPanel.Hide();
            }
        }

        private void CreateNewLever(List<string> lLabelsText)
        {
            Lever newLever = new Lever(lLabelsText);

            if (this.generalLayout != null)
            {
                TableLayoutPanelCellPosition posLayoutLever = generalLayout.GetCellPosition(_lLever.Last());
                this.generalLayout.Controls.Add(newLever, posLayoutLever.Column + 1, posLayoutLever.Row);
            }

            newLever.LabelClick += new EventHandler(lever_LabelClick);
            newLever.BackClick += new EventHandler(lever_BackClick);
            newLever.Dock = DockStyle.Fill;
            newLever.Margin = leverMainMenu.Margin;
            _lLever.Last().Enabled = false;
            _lLever.Add(newLever);
        }

        private void BasicBattleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StartingForm sf = new StartingForm(null);
            sf.setIsFirstTime();
            sf.Visible = true;
        }


        private void informationPanel_Click(object sender, EventArgs e)
        {
            informationPanel.Hide();
        }
        public void AlignInfoLabel()
        {
            int x = (informationPanel.Size.Width - infoLabel.Size.Width) / 2;
            int y = (informationPanel.Size.Height - infoLabel.Size.Height) / 2;
            infoLabel.Location = new Point(x, y);
            SetRoundedCorners(informationPanel, 5);
        }
        private void informationPanel_SizeChanged(object sender, EventArgs e)
        {
            AlignInfoLabel();
        }

        private void infoLabel_TextChanged(object sender, EventArgs e)
        {
            AlignInfoLabel();
        }
    }
}
