using PILOT;
using System.Collections.Generic;

namespace PJS5_CSharp.Sources.Pilot.Bot
{
    public class BOT_PILOT : IPILOT
    {
        private readonly IComportement _comportement;

        public BOT_PILOT(Sources.Robot.Robot pRobot, List<int> vFuelsReserve, List<int> vRepairKitsReserve, IComportement comportement) : base(pRobot, vFuelsReserve, vRepairKitsReserve)
        {
            _comportement = comportement;
        }

        override
        public void PlayTurn(Sources.Robot.Robot ennemiRobot)
        {
            _comportement.PlayTurn(_pRobot, ennemiRobot);
        }
    }
}
