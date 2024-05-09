using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Battle
{
    public class BASIC_BATTLE : ABATTLE

    {
        public BASIC_BATTLE(IPILOT pilot1, IPILOT pilot2) : base(pilot1, pilot2)
        {
        }

        public void PlayBattle()
        {
            List<int> lResult = new List<int>();

            // Tant que aucun des 2 robots n'est détruit
            while (!_lPilots[0].IsFurnaceBroken() && !_lPilots[1].IsFurnaceBroken())
            {
                lResult.AddRange(PlayRound());
            }

            //GUI.GameOver();
        }
        
        // Joue un round, un tour par joueur
        public override List<int> PlayRound()
        {
            List<int> lResult = new List<int>();

            for (int i = 0; i<this._lPilots.Count; i++)
            {
                GUI.ShowStatus(_lPilots[0], _lPilots[1]);
                lResult.AddRange(this.PlayTurn(i));
            }

            return lResult;
        }

        // Joue le tour d'un joueur
        public override List<int> PlayTurn(int iPilot, MAIN_MENU eChoiceMenu = MAIN_MENU.Error, int iRes = -1, int iTargetPart = -1)
        {
            MAIN_MENU iChoice;
            bool bStopLoop;
            IPILOT currentPilot = this._lPilots[iPilot];
            int iEnnemy = (iPilot == 0) ? 1 : 0;
            IROBOT ennemyRobot = this._lPilots[iEnnemy].GetRobot();
            List<int> actions = new List<int>();

            /*
             * Si c'est bien un bot,
             * procéder au PlayTurnAuto()
             */
            if (currentPilot.IsBotPilot()) 
            {
                return currentPilot.PlayTurnAuto(ennemyRobot);
            }

            do
            {
                iChoice = GUI.MainMenu((int)eChoiceMenu);
                actions.Add((int)iChoice);

                switch (iChoice)
                {
                    case MAIN_MENU.Attack: // Attack
                        {
                            bStopLoop = Attack(currentPilot, ennemyRobot, actions, iRes, iTargetPart);
                            break;
                        }
                    case MAIN_MENU.Repairs: // Repair
                        {
                            bStopLoop = Repair(currentPilot, actions, iRes, iTargetPart);
                            break;
                        }
                    case MAIN_MENU.Furnace: // Refuel
                        {
                            bStopLoop = Refuel(currentPilot, actions, iRes);
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
            while (!currentPilot.FirstChoiceIsValid(iChoice) || bStopLoop == false);

            return actions;
        }

        
        private bool Attack(IPILOT currentPilot, IROBOT ennemyRobot, List<int> lInputActions, int iWeapon = -1, int iTargetPart = -1)
        {
            WEAPON_MENU eChoiceWeapon;
            TARGET_MENU eChoicePart;

            do
            {
                eChoiceWeapon = GUI.WeaponMenu(currentPilot, iWeapon);
                if (eChoiceWeapon == WEAPON_MENU.Back) return false;
            }
            while (!currentPilot.IsWeaponUsable((int) eChoiceWeapon));

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
            catch(NotImplementedException e)
            {
                return false;
            }

            lInputActions.Add((int)eChoiceTargetType);

            return currentPilot.Attack(iChoiceWeapon, ennemyRobot, eChoiceTargetType, lInputActions);
        }
        /// <summary>
        /// Choose the repair kit to repair the selected part
        /// </summary>
        /// <param name="currentPilot"></param>
        /// <returns>True </returns>
        private bool Repair(IPILOT currentPilot, List<int> lInputActions, int iRes = -1, int iTargetPart = -1)
        {
            REPAIRS_MENU eChoice;
            TARGET_MENU eChoicePart;
            do
            {
                eChoice = GUI.RepairMenu(currentPilot, iRes);

                if (eChoice == REPAIRS_MENU.Error)
                {
                    GUI.WrongEntry();
                }
                else if (eChoice == REPAIRS_MENU.Back)
                {
                    return false;
                }
            }
            while (eChoice == REPAIRS_MENU.Error);

            lInputActions.Add((int)eChoice);
            do
            {
                eChoicePart = GUI.TargetMenu(iTargetPart);
                if (eChoicePart == TARGET_MENU.Back)
                {
                    return false;
                }
                else if(eChoicePart == TARGET_MENU.Error)
                {
                    GUI.WrongEntry();
                }
            } while (eChoicePart == TARGET_MENU.Error);

            TARGET_TYPE eChoiceTargetType = GUI.ConvertTargetType(eChoicePart);
            lInputActions.Add((int)eChoiceTargetType);
            return currentPilot.Repair(eChoice, eChoiceTargetType, lInputActions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentPilot"> the pilot selected to refuel his robot </param>
        private bool Refuel(IPILOT currentPilot, List<int> lInputActions, int iRes)
        {
            FUEL_MENU iChoice;
            do
            {
                iChoice = GUI.FuelMenu(currentPilot, iRes);

                if (iChoice == FUEL_MENU.Error)
                {
                    GUI.WrongEntry();
                }

                if(iChoice == FUEL_MENU.Back)
                {
                    return false;
                }

            } while (!currentPilot.Refuel((int)iChoice, lInputActions));

            lInputActions.Add((int)iChoice);

            return true;
        }

        private bool TargetPartIsBroken(IPILOT pilot)
        {
            int iChoice = GUI.TargetPartMenu();
            bool bLoop = true;
            bool result = true; //obligation d'initialiser

            do
            {
                if (iChoice == int.MinValue)
                {
                    return true;
                }

                switch (iChoice)
                {
                    case 0:
                        result = pilot.IsLegsBroken();
                        bLoop = false;
                        break;
                    case 1:
                        result = pilot.IsFurnaceBroken();
                        bLoop = false;
                        break;
                    default:
                        try
                        {
                            result = pilot.IsWeaponBroken(iChoice);
                            bLoop = false;
                        }
                        catch
                        {
                            GUI.WeaponOutOfRange();
                        }
                        break;
                }
            } while (bLoop);

            return result;
        }
    }
}
