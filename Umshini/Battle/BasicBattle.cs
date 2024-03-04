using System;
using System.Collections.Generic;
using System.Linq;
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
                    // Attack
                    case 0:
                        {
                            do
                            {
                                = GUI.AttackMenu();
                            }
                            while !currentPilot.Attack())
                            break;
                        }
                    case 1:
                        {
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            } 
            while (!currentPilot.FirstChoice(iChoice));

            
        }
    }
}
