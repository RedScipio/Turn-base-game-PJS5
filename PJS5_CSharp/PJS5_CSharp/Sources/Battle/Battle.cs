
using PILOT;
using PJS5_CSharp.Sources.Pilot;
using System.Text.Json.Serialization;

namespace PJS5_CSharp.Sources.Battle
{
    public class Battle
    {
        [JsonInclude]
        private IPILOT[] _tPilot;

        public Battle(IPILOT pPlayer, IPILOT pBot)
        {
            _tPilot = new IPILOT[] { pPlayer, pBot };
        }

        public void BattleWithConsoleGui()
        {
            int iTurn = 0;
            //trying to make a dictionary for getting your structure.
            while (!BattleIsOver())
            {
                for (int iPilot = 0; iPilot < 2; iPilot++)
                {
                    GUI.Gui.ShowStatus(_tPilot[0].GetRobot(), _tPilot[1].GetRobot());
                    _tPilot[iPilot].PlayTurn(_tPilot[1 - iPilot].GetRobot());
                    if (_tPilot[1 - iPilot].RobotIsDestroy())
                    {
                        // Handle robot destruction
                    }
                }
            }
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
