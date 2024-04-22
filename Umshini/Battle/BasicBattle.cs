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
        }
        
        // Joue un round, un tour par joueur
        public override List<int> PlayRound()
        {
            List<int> lResult = new List<int>();

            for (int i = 0; i<this._lPilots.Count; i++)
            {
                lResult.AddRange(this.PlayTurn(i));
            }

            return lResult;
        }

        // Joue le tour d'un joueur
        public override List<int> PlayTurn(int iPilot)
        {
            int iChoice;
            bool bDontLoop = false;
            IPILOT currentPilot = this._lPilots[iPilot];
            List<int> actions = new List<int>();

            /*
             * Si c'est bien un bot,
             * procéder au PlayTurnAuto()
             */
            if (currentPilot.IsBotPilot()) 
            {
                return currentPilot.PlayTurnAuto();
            }

            do
            {
                iChoice = GUI.MainMenu();

                switch (iChoice)
                {
                    case 0: // Attack
                        {
                            int iEnnemy = (iPilot == 0) ? 1 : 0;

                            bDontLoop = Attack(currentPilot, this._lPilots[iEnnemy]);
                            break;
                        }
                    case 1: // Repair
                        {
                            Repair(currentPilot);
                            break;
                        }
                    case 2: // Refuel
                        {
                            Refuel(currentPilot);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            } 
            // FirstChoice is used in case no option are valid in the selected menu
            while (!currentPilot.FirstChoiceIsValid(iChoice) && bDontLoop);

            return actions;
        }

        
        private bool Attack(IPILOT currentPilot, IPILOT ennemyPilot)
        {
            int iChoiceWeapon;

            do
            {
                iChoiceWeapon = GUI.WeaponMenu(currentPilot);
            }
            while (!currentPilot.IsWeaponUsable(iChoiceWeapon) && iChoiceWeapon != int.MinValue);

            currentPilot.Attack(iChoiceWeapon, ennemyPilot);
            return false;
        }

        private void Repair(IPILOT currentPilot)
        {
            int iChoice;
            do
            {
                iChoice = GUI.RepairMenu(currentPilot);
            }
            while (!currentPilot.Repair(iChoice));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentPilot"> the pilot selected to refuel his robot </param>
        private void Refuel(IPILOT currentPilot)
        {
            int iChoice;
            do
            {
                iChoice = GUI.FuelMenu(currentPilot);
            }
            while (!currentPilot.Refuel(iChoice));

            currentPilot.GetRobot().Refuel(currentPilot.GetFuelsReserve()[iChoice].GetValue());
            currentPilot.GetFuelsReserve()[iChoice].decrNumberItems();
            
            
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
                        catch (ArgumentOutOfRangeException e)
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
