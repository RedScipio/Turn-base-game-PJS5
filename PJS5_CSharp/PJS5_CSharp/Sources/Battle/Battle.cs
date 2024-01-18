

using PILOT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace PJS5_CSharp.Sources.Battle
{
    public class Battle
    {
        private IPILOT[] _tPilot;

        public Battle(IPILOT pPlayer, IPILOT pBot)
        {
            _tPilot = new IPILOT[] { pPlayer, pBot };
        }

        public void BattleWithConsoleGui()
        {
            int iTurn = 0;
            //trying to make  dictionary for getting your structure.

            var turn = new Dictionary<int, Dictionary<IPILOT, List<int>>>();

            String sSavefile = Console.ReadLine();
            while (!BattleIsOver())
            {
                iTurn++;
                Dictionary<IPILOT, List<int>> dict = new Dictionary<IPILOT, List<int>>();
                for (int iPilot = 0; iPilot < 2; iPilot++)
                {
                    
                    GUI.Gui.ShowStatus(_tPilot[0].GetRobot(), _tPilot[1].GetRobot());
                    _tPilot[iPilot].PlayTurn(_tPilot[1 - iPilot].GetRobot());
                    if (_tPilot[1 - iPilot].RobotIsDestroy())
                    {
                        // Handle robot destruction
                    }
                    dict.Add(_tPilot[1 - iPilot], _tPilot[1 - iPilot].GetInputsResults());
                }
                turn.Add(iTurn, dict);
            }
            
            Console.ReadLine();
            
        }

        public bool BattleIsOver()
        {
            return _tPilot[0].RobotIsDestroy() || _tPilot[1].RobotIsDestroy();
        }

        public IPILOT GetPlayerPilot()
        {
            return _tPilot[0];
        }

        public IPILOT GetBotPilot()
        {
            return _tPilot[1];
        }
    }


}
