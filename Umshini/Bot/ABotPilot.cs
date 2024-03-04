using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Battle;
using Pilot;

namespace Bot
{
    public class ABotPilot : APILOT
    {
        public ABotPilot(IROBOT pRobot, List<int> vFuelsReserve, List<int> vRepairKitsReserve) : base(pRobot, vFuelsReserve, vRepairKitsReserve)
        {
        }
    }
}
