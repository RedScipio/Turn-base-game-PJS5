
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

        public PLAYER_PILOT(PLAYER_PILOT playerPilot) : base(playerPilot._pRobot.Clone(), playerPilot._vFuelsReserve, playerPilot._vRepairKitsReserve)
        {
            _vActionResults = new List<int> { };
        }

        public override IPILOT Clone()
        {
            return new PLAYER_PILOT(this);
        }

        public override List<int> PlayTurnAuto(IROBOT enemyRobot, bool showIndications = true)
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

        public override void PlayTurn(IROBOT enemyRobot, MAIN_MENU iChoice = MAIN_MENU.Error, int iRes = -1, int iChoiceTarget = -1, int iHitRate = -1)
        {
            throw new NotImplementedException();
        }
    }
}
