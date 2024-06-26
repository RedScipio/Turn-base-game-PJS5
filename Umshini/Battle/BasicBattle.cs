using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
namespace Battle
{
    public class BASIC_BATTLE : ABATTLE

    {
        public BASIC_BATTLE(IPILOT pilot1, IPILOT pilot2) : base(pilot1, pilot2)
        {
            _currentPilot = this._lPilots[0];
        }

        public override bool IsOver()
        {
            return _lPilots[0].IsFurnaceBroken() || _lPilots[1].IsFurnaceBroken();
        }

        public void PlayBattle()
        {

            List<int> lResult = new List<int>();

            // As long as neither robot is destroyed
            while (IsOver() == false)
            {
                lResult.AddRange(PlayRound());
            }



            //GUI.GameOver();
        }

        /// <summary>
        /// Plays one round, one turn per robot
        /// </summary>
        /// <returns>The list of actions taken</returns>
        /// <developer>CME</developer>
        public override List<int> PlayRound()
        {
            List<int> lResult = new List<int>();

            for (int i = 0; i < this._lPilots.Count; i++)
            {
                GUI.ShowStatus(_lPilots[0], _lPilots[1]);
                lResult.AddRange(this.PlayTurn(i));
            }

            return lResult;
        }

        /// <summary>
        /// Play the turn of a robot
        /// </summary>
        /// <param name="iPilot"></param>
        /// <param name="eChoiceMenu"></param>
        /// <param name="iRes"></param>
        /// <param name="iTargetPart"></param>
        /// <returns>The list of actions taken</returns>
        public override List<int> PlayTurn(int iPilot, MAIN_MENU eChoiceMenu = MAIN_MENU.Error, int iRes = -1, int iTargetPart = -1)
        {
            MAIN_MENU iChoice;
            bool bStopLoop;
            _currentPilot = this._lPilots[iPilot];
            int iEnnemy = (iPilot == 0) ? 1 : 0;
            IROBOT enemyRobot = this._lPilots[iEnnemy].GetRobot();
            List<int> actions = new List<int>();

            /*
             * If it's a bot pilot,
             * proceed with PlayTurnAuto()
             */
            if (_currentPilot.IsBotPilot())
            {
                return _currentPilot.PlayTurnAuto(enemyRobot);
            }

            do
            {
                iChoice = GUI.MainMenu((int)eChoiceMenu);
                actions.Add((int)iChoice);

                switch (iChoice)
                {
                    case MAIN_MENU.Attack: // Attack
                        {
                            bStopLoop = Attack(_currentPilot, enemyRobot, actions, iRes, iTargetPart);
                            break;
                        }
                    case MAIN_MENU.Repairs: // Repair
                        {
                            bStopLoop = Repair(_currentPilot, actions, iRes, iTargetPart);
                            break;
                        }
                    case MAIN_MENU.Furnace: // Refuel
                        {
                            bStopLoop = Refuel(_currentPilot, actions, iRes);
                            break;
                        }
                    default:
                        {
                            GUI.WrongEntry();
                            bStopLoop = false;
                            break;
                        }
                }
            }
            // FirstChoice is used in case no option are valid in the selected menu
            while (!_currentPilot.FirstChoiceIsValid(iChoice) || bStopLoop == false);

            return actions;
        }


        private bool Attack(IPILOT _currentPilot, IROBOT enemyRobot, List<int> lInputActions, int iWeapon = -1, int iTargetPart = -1)
        {
            WEAPON_MENU eChoiceWeapon;
            TARGET_MENU eChoicePart;

            do
            {
                eChoiceWeapon = GUI.WeaponMenu(_currentPilot, iWeapon);
                if (eChoiceWeapon == WEAPON_MENU.Back) return false;
            }
            while (!_currentPilot.IsWeaponUsable((int)eChoiceWeapon));

            do
            {
                eChoicePart = GUI.TargetMenu(iTargetPart);
                if (eChoicePart == TARGET_MENU.Back) return false;
            } while (eChoicePart == TARGET_MENU.Error);

            int iChoiceWeapon;

            TARGET_TYPE eChoiceTargetType;

            if (eChoiceWeapon == WEAPON_MENU.Left_Weapon)
            {
                iChoiceWeapon = 0;
            }
            else
            {
                iChoiceWeapon = 1;
            }

            lInputActions.Add(iChoiceWeapon);

            try
            {
                eChoiceTargetType = GUI.ConvertTargetType(eChoicePart);
            }
            catch (NotImplementedException e)
            {
                return false;
            }

            lInputActions.Add((int)eChoiceTargetType);

            return _currentPilot.Attack(iChoiceWeapon, enemyRobot, eChoiceTargetType, lInputActions);
        }
        /// <summary>
        /// Choose the repair kit to repair the selected part
        /// </summary>
        /// <param name="_currentPilot"></param>
        /// <returns>true if the robot has been repaired, false otherwise</returns>
        private bool Repair(IPILOT _currentPilot, List<int> lInputActions, int iRes = -1, int iTargetPart = -1)
        {
            REPAIRS_MENU eChoiceRepairMenu;
            TARGET_MENU eChoicePart;
            do
            {
                eChoiceRepairMenu = GUI.RepairMenu(_currentPilot, iRes);

                if (eChoiceRepairMenu == REPAIRS_MENU.Error)
                {
                    GUI.WrongEntry();
                }
                else if (eChoiceRepairMenu == REPAIRS_MENU.Back)
                {
                    return false;
                }
            }
            while (eChoiceRepairMenu == REPAIRS_MENU.Error);

            REPAIRS_TYPE eChoiceRepairType = GUI.ConvertRepairType(eChoiceRepairMenu);

            lInputActions.Add((int)eChoiceRepairType);

            TARGET_TYPE eChoiceTargetType;
            bool isReparationPossible = false;
            do
            {
                eChoicePart = GUI.TargetMenu(iTargetPart);
                if (eChoicePart == TARGET_MENU.Back)
                {
                    return false;
                }
                else if (eChoicePart == TARGET_MENU.Error)
                {
                    GUI.WrongEntry();
                }
                else
                {
                    eChoiceTargetType = GUI.ConvertTargetType(eChoicePart);
                    lInputActions.Add((int)eChoiceTargetType);

                    if (!_currentPilot.Repair(eChoiceRepairType, eChoiceTargetType, lInputActions))
                    {
                        GUI.RepairImpossible();
                        isReparationPossible = false;
                    }
                    else
                    {
                        isReparationPossible = true;
                    }
                }
            } while (eChoicePart == TARGET_MENU.Error || !isReparationPossible);

            return true;
        }

        /// <summary>
        /// Refuel the robot
        /// </summary>
        /// <param name="_currentPilot"> the pilot selected to refuel his robot </param>
        private bool Refuel(IPILOT _currentPilot, List<int> lInputActions, int iRes)
        {
            FUEL_MENU iChoice;
            do
            {
                iChoice = GUI.FuelMenu(_currentPilot, iRes);

                if (iChoice == FUEL_MENU.Error)
                {
                    GUI.WrongEntry();
                }

                else if (iChoice == FUEL_MENU.Back)
                {
                    return false;
                }

                else if (_currentPilot.GetRobot().GetFuel() == _currentPilot.GetRobot().GetMaxFuel())
                {
                    GUI.AlreadyFullOfFuel();
                    return false;
                }

            } while (!_currentPilot.Refuel(GUI.ConvertFuelType(iChoice), lInputActions));

            lInputActions.Add((int)iChoice);

            return true;
        }
    }
}
