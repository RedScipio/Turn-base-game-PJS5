using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
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
        private string FileName;
        private string TrackName;
        private int volume = 10; //volume entre 0 et 1000
        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);
        private List<Lever> _lLever = new List<Lever> { };

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

        public BasicBattleForm()
        {
            InitializeComponent();
            SetDoubleBuffered(generalLayout);
            SetDoubleBuffered(tableLayoutPanel1);
            SetDoubleBuffered(tableLayoutPanel2);
            leverMainMenu.LabelClick += new EventHandler(lever_LabelClick);

            _lLever.Add(leverMainMenu);
            FileName = "D:\\Umshini\\Ressources\\MusicMix.wav";
            TrackName = "MusicMix";
            MusicSoundPlayer.Play(FileName, TrackName);
        }






        protected void lever_LabelClick(object sender, EventArgs eventLever)
        {
            FileName = "D:\\Umshini\\Ressources\\SoundEffect\\Collect\\collect-2.wav";
            TrackName = "collect-2";
            MusicSoundPlayer.Play(FileName,TrackName);     
            Lever lever = (Lever)sender;
            string sAction = lever.SelectedAction.Replace("- ", "");

            List<string> lStringLabels = new List<string> { };
            lStringLabels.Clear();

            int iColumnLever = generalLayout.GetCellPosition(_lLever.Last()).Column;

            switch (iColumnLever)
            {
                case 0:
                    {
                        switch (sAction)
                        {
                            case "Attack":
                                {

                                    lStringLabels.Add("Left Weapon");
                                    lStringLabels.Add("Right Weapon");

                                    break;
                                }

                            case "Repair":
                                {
                                    lStringLabels.Add("Light Armor");
                                    lStringLabels.Add("Heavy Armor");
                                    lStringLabels.Add("Repair Kits");
                                    lStringLabels.Add("Full Kits");

                                    break;
                                }
                            case "Refuel":
                                {
                                    lStringLabels.Add("Wood");
                                    lStringLabels.Add("Charcoal");
                                    lStringLabels.Add("Coal");
                                    lStringLabels.Add("Compact Coal");

                                    break;
                                }
                        }

                        break;
                    }

                case 1:
                    {
                        switch (sAction)
                        {
                            case "Left Weapon":
                            case "Right Weapon":
                            case "Light Armor":
                            case "Heavy Armor":
                            case "Repair Kits":
                            case "Full Kits":
                                {
                                    lStringLabels.Add("Left Weapon");
                                    lStringLabels.Add("Right Weapon");
                                    lStringLabels.Add("Legs");
                                    lStringLabels.Add("Furnace");

                                    break;
                                }
                            case "Wood":
                            case "Charcoal":
                            case "Coal":
                            case "Compact Coal":
                                {
                                    return;
                                }
                        }

                        break;
                    }

                case 2:
                    {
                        switch (sAction)
                        {
                            case "Left Weapon":
                            case "Right Weapon":
                            case "Legs":
                            case "Furnace":
                                {
                                    return;
                                }
                        }

                        break;
                    }
            }

            CreateNewLever(lStringLabels);
        }

        protected void lever_BackClick(object sender, EventArgs eventLever)
        {
            if (this.generalLayout != null)
            {
                _lLever.RemoveAt(_lLever.Count - 1);
                _lLever.Last().Enabled = true;
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



        private void BasicBattleForm_Load(object sender, EventArgs e)
        {

        }


        private void BasicBattleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StartingForm sf = new StartingForm();
            sf.setIsFirstTime();
            sf.Visible = true;
        }
    }
}
