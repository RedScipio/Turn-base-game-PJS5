
using PILOT;
using PJS5_CSharp.Sources.Pilot;
using PJS5_CSharp_Form;
using System.Windows.Forms;

namespace PJS5_CSharp.Sources.Battle
{
    public class Battle
    {
        public IPILOT[] _tPilot;

        public Battle(IPILOT pPlayer, IPILOT pBot)
        {
            _tPilot = new IPILOT[] { pPlayer, pBot };
        }
/*        public void BattleWithConsoleGui()
        {
            CombatForm combatForm = new CombatForm();
            while (!BattleIsOver())
            {
                for (int iPilot = 0; iPilot < 2; iPilot++)
                {
                    combatForm.ShowStatus(_tPilot[0].GetRobot(), _tPilot[1].GetRobot());
                    _tPilot[iPilot].PlayTurn(_tPilot[1 - iPilot].GetRobot());
                    if (_tPilot[1 - iPilot].RobotIsDestroy())
                    {
                        // Handle robot destruction
                    }
                }
            }
        }*/

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
