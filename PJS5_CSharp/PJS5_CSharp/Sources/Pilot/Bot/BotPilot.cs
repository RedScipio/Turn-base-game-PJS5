using PILOT;
using System.Collections.Generic;
using System.Linq;

namespace PJS5_CSharp.Sources.Pilot.Bot
{
    public abstract class BOT_PILOT : IPILOT
    {

        public BOT_PILOT(Sources.Robot.Robot pRobot, List<int> vFuelsReserve, List<int> vRepairKitsReserve) : base(pRobot, vFuelsReserve, vRepairKitsReserve)
        {
        }

    }
}
