
using System.Collections.Generic;
using System;
using System.Linq;
using Battle;

namespace Pilot
{
    public class PLAYER_PILOT : APILOT
    {

        private readonly List<int> _vActionResults;

        public PLAYER_PILOT(IROBOT pRobot, List<ICONSUMABLES> vFuelsReserve, List<ICONSUMABLES> vRepairKitsReserve) : base(pRobot, vFuelsReserve, vRepairKitsReserve)
        {
            _vActionResults = new List<int> { };
        }

        public override List<int> PlayTurnAuto(IROBOT ennemyRobot)
        {
            throw new NotImplementedException();
        }

        public List<int> GetActionResults()
        {
            return _vActionResults;
        }

        public override bool IsBotPilot()
        {
            return false;
        }

        public override void PlayTurn(IROBOT ennemyRobot, MAIN_MENU iChoice = MAIN_MENU.Error, int iRes = -1, int iChoiceTarget = -1, int iHitRate = -1)
        {
            throw new NotImplementedException();
        }
    }
}
