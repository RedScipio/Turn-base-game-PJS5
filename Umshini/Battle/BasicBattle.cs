using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Umshini;

namespace Battle
{
    public class BASIC_BATTLE : ABATTLE

    {
        public BASIC_BATTLE(IPILOT pilot1, IPILOT pilot2) : base(pilot1, pilot2)
        {
        }

        public void PlayBattle()
        {

        }

        public override List<int> PlayRound()
        {
            List<int> lResult = new List<int>();

            for (int i = 0; i<this._lPilots.Count; i++)
            {
                lResult = this.PlayTurn(i);
            }

            return lResult;
        }

        public override List<int> PlayTurn(int iPilot)
        {
            int iChoice;
            bool bLoop = true;
            IPILOT currentPilot = this._lPilots[iPilot];

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

                            bLoop = Attack(currentPilot, this._lPilots[iEnnemy]);
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
            while (!currentPilot.FirstChoice(iChoice) && bLoop);
        }

        private bool Attack(IPILOT currentPilot, IPILOT ennemyPilot)
        {
            bool bMainLoop = true;
            int iChoiceWeapon;

            do
            {
                iChoiceWeapon = GUI.WeaponMenu();

                if (iChoiceWeapon == int.MinValue)
                {
                    return true;
                }


            }
            while (!currentPilot.IsWeaponUsable(iChoiceWeapon));

            return bMainLoop;
        }

        private void Repair(IPILOT currentPilot)
        {
            int iChoice;
            do
            {
                iChoice = GUI.RepairkMenu();
            }
            while (!currentPilot.Repair(iChoice));
        }

        private void Refuel(IPILOT currentPilot)
        {
            int iChoice;
            do
            {
                iChoice = GUI.RefuelMenu();
            }
            while (!currentPilot.Refuel(iChoice));
        }

        private bool TargetPartIsBroken(IPILOT pilot)
        {
            int iChoice = GUI.TargetPartMenu();
            bool bLoop;

            do
            {
                if (iChoice == int.MinValue)
                {
                    return true;
                }

                switch (iChoice)
                {
                    case 0:
                        bLoop = pilot.IsLegsBroken();
                        break;
                    case 1:
                        bLoop = pilot.IsFurnaceBroken();
                        break;
                    default:
                        try
                        {
                            bLoop = pilot.IsWeaponBroken(iChoice);
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            GUI.WeaponOutOfRange();
                            bLoop = true;
                        }
                        break;
                }
            } while (!bLoop);
        }
    }

}
