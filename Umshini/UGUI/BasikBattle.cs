//using Newtonsoft.Json.Linq;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Runtime.CompilerServices;
//using System.Windows.Forms;

//namespace Battle
//{
//    public partial class BasikBattle : Form
//    {
//        private BASIC_BATTLE _basicBattle;

//        public BasikBattle(IPILOT pilot1, IPILOT pilot2)
//        {
//            InitializeComponent();
//            _basicBattle = new BASIC_BATTLE(this, pilot1, pilot2);
//        }

//        private void BasikBattle_Load(object sender, EventArgs e)
//        {
//            // Initialize form components and settings
//        }

//        public void PlayBattle()
//        {
//            List<int> lResult = new List<int>();

//            // As long as neither robot is destroyed
//            while (!_basicBattle.Pilots[0].IsFurnaceBroken() && !_basicBattle.Pilots[1].IsFurnaceBroken())
//            {
//                lResult.AddRange(PlayRound());
//            }

//            // GUI.GameOver();
//        }

//        public List<int> PlayRound()
//        {
//            List<int> lResult = new List<int>();

//            for (int i = 0; i < _basicBattle.Pilots.Count; i++)
//            {
//                GUI.ShowStatus(_basicBattle.Pilots[0], _basicBattle.Pilots[1]);
                
//                lResult.AddRange(PlayTurn(i));
//            }

//            return lResult;
//        }

//        public void ShowStatus(IPILOT pPlayer, IPILOT pBot)
//        {
//            IROBOT playerRobot = pPlayer.GetRobot();
//            IROBOT botRobot = pBot.GetRobot();
//            if (botRobot.GetRightWeaponLife() == 0)
//            {
//                scoreStatus2.RightArmColor = Color.Red;
//            }
//            if (botRobot.GetLeftWeaponLife() == 0)
//            {
//                scoreStatus2.LeftArmColor = Color.Red;
//            }
//            if (botRobot.GetFurnaceLife() == 0)
//            {
//                scoreStatus2.FurnaceColor = Color.Red;
//            }
//            if (botRobot.GetLegsLife() == 0)
//            {
//                scoreStatus2.LegsColor = Color.Red;
//            }
//        }

//        public List<int> PlayTurn(int iPilot, MAIN_MENU eChoiceMenu = MAIN_MENU.Error, int iRes = -1, int iTargetPart = -1)
//        {
//            MAIN_MENU iChoice;
//            bool bStopLoop;
//            IPILOT currentPilot = _basicBattle.Pilots[iPilot];
//            int iEnnemy = (iPilot == 0) ? 1 : 0;
//            IROBOT enemyRobot = _basicBattle.Pilots[iEnnemy].GetRobot();
//            List<int> actions = new List<int>();

//            if (currentPilot.IsBotPilot())
//            {
//                return currentPilot.PlayTurnAuto(enemyRobot);
//            }

//            do
//            {
//                iChoice = GUI.MainMenu((int)eChoiceMenu);
//                actions.Add((int)iChoice);

//                switch (iChoice)
//                {
//                    case MAIN_MENU.Attack:
//                        bStopLoop = Attack(currentPilot, enemyRobot, actions, iRes, iTargetPart);
//                        break;
//                    case MAIN_MENU.Repairs:
//                        bStopLoop = Repair(currentPilot, actions, iRes, iTargetPart);
//                        break;
//                    case MAIN_MENU.Furnace:
//                        bStopLoop = Refuel(currentPilot, actions, iRes);
//                        break;
//                    default:
//                        GUI.WrongEntry();
//                        bStopLoop = false;
//                        break;
//                }
//            } while (!currentPilot.FirstChoiceIsValid(iChoice) || !bStopLoop);

//            return actions;
//        }

//        public bool Attack(IPILOT currentPilot, IROBOT enemyRobot, List<int> lInputActions, int iWeapon = -1, int iTargetPart = -1)
//        {
//            WEAPON_MENU eChoiceWeapon;
//            TARGET_MENU eChoicePart;

//            do
//            {
//                eChoiceWeapon = GUI.WeaponMenu(currentPilot, iWeapon);
//                if (eChoiceWeapon == WEAPON_MENU.Back) return false;
//            } while (!currentPilot.IsWeaponUsable((int)eChoiceWeapon));

//            do
//            {
//                eChoicePart = GUI.TargetMenu(iTargetPart);
//                if (eChoicePart == TARGET_MENU.Back) return false;
//            } while (eChoicePart == TARGET_MENU.Error);

//            int iChoiceWeapon = eChoiceWeapon == WEAPON_MENU.Left_Weapon ? 0 : 1;

//            lInputActions.Add(iChoiceWeapon);

//            TARGET_TYPE eChoiceTargetType;
//            try
//            {
//                eChoiceTargetType = GUI.ConvertTargetType(eChoicePart);
//            }
//            catch (NotImplementedException)
//            {
//                return false;
//            }

//            lInputActions.Add((int)eChoiceTargetType);

//            return currentPilot.Attack(iChoiceWeapon, enemyRobot, eChoiceTargetType, lInputActions);
//        }

//        public bool Repair(IPILOT currentPilot, List<int> lInputActions, int iRes = -1, int iTargetPart = -1)
//        {
//            REPAIRS_MENU eChoiceRepairMenu;
//            TARGET_MENU eChoicePart;
//            do
//            {
//                eChoiceRepairMenu = GUI.RepairMenu(currentPilot, iRes);

//                if (eChoiceRepairMenu == REPAIRS_MENU.Error)
//                {
//                    GUI.WrongEntry();
//                }
//                else if (eChoiceRepairMenu == REPAIRS_MENU.Back)
//                {
//                    return false;
//                }
//            } while (eChoiceRepairMenu == REPAIRS_MENU.Error);

//            REPAIRS_TYPE eChoiceRepairType = GUI.ConvertRepairType(eChoiceRepairMenu);

//            lInputActions.Add((int)eChoiceRepairType);

//            TARGET_TYPE eChoiceTargetType;
//            bool isReparationPossible = false;
//            do
//            {
//                eChoicePart = GUI.TargetMenu(iTargetPart);
//                if (eChoicePart == TARGET_MENU.Back)
//                {
//                    return false;
//                }
//                else if (eChoicePart == TARGET_MENU.Error)
//                {
//                    GUI.WrongEntry();
//                }
//                else
//                {
//                    eChoiceTargetType = GUI.ConvertTargetType(eChoicePart);
//                    lInputActions.Add((int)eChoiceTargetType);

//                    if (!currentPilot.Repair(eChoiceRepairType, eChoiceTargetType, lInputActions))
//                    {
//                        GUI.RepairImpossible();
//                        isReparationPossible = false;
//                    }
//                    else
//                    {
//                        isReparationPossible = true;
//                    }
//                }
//            } while (eChoicePart == TARGET_MENU.Error || !isReparationPossible);

//            return true;
//        }

//        public bool Refuel(IPILOT currentPilot, List<int> lInputActions, int iRes)
//        {
//            FUEL_MENU iChoice;
//            do
//            {
//                iChoice = GUI.FuelMenu(currentPilot, iRes);

//                if (iChoice == FUEL_MENU.Error)
//                {
//                    GUI.WrongEntry();
//                }
//                else if (iChoice == FUEL_MENU.Back)
//                {
//                    return false;
//                }
//                else if (currentPilot.GetRobot().GetFuel() == currentPilot.GetRobot().GetMaxFuel())
//                {
//                    GUI.AlreadyFullOfFuel();
//                    return false;
//                }
//            } while (!currentPilot.Refuel(GUI.ConvertFuelType(iChoice), lInputActions));

//            lInputActions.Add((int)iChoice);

//            return true;
//        }


//    }
//}
