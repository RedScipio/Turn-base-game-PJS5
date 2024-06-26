using Battle;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private BASIC_BATTLE _basicBattle;
        private List<Lever> _lLever = new List<Lever> { };
        private List<int> _lActions = new List<int> { };

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
        }
        protected void lever_LabelClick(object sender, EventArgs eventLever)
        {
            Lever lever = (Lever)sender;
            string sAction = lever.SelectedAction.Replace("- ", "");

            List<string> lStringLabels = new List<string> { };
            lStringLabels.Clear();

            int iColumnLever = generalLayout.GetCellPosition(_lLever.Last()).Column;

            switch (iColumnLever)
            {
                case 0:
                    {
                        _lActions.Clear();

                        switch (sAction)
                        {
                            case "Attack":
                                {

                                    lStringLabels.Add("Use Left Weapon");
                                    lStringLabels.Add("Use Right Weapon");

                                    _lActions.Add((int)MAIN_MENU.Attack);

                                    break;
                                }

                            case "Repair":
                                {
                                    lStringLabels.Add("Light Armor");
                                    lStringLabels.Add("Heavy Armor");
                                    lStringLabels.Add("Repair Kits");
                                    lStringLabels.Add("Full Kits");

                                    _lActions.Add((int)MAIN_MENU.Repairs);

                                    break;
                                }
                            case "Refuel":
                                {
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
                                        _lActions.Add((int)WEAPON_MENU.Left_Weapon);
                                        break;
                                    }
                                case "Use Right Weapon":
                                    {
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

                        return;
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
