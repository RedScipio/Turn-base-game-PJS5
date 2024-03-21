using Umshini;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilot
{
    public abstract class BotPilot: APILOT
    {
        public BotPilot(IROBOT pRobot, List<ICONSUMABLE> vFuelsReserve, List<ICONSUMABLE> vRepairKitsReserve) : base(pRobot, vFuelsReserve, vRepairKitsReserve)
        {

        }

        public override bool IsBotPilot()
        {
            return true;
        }
    }
}
