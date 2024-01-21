using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJS5_CSharp.Sources.Pilot.Bot
{
    public class FactoryBot
    {
        public enum TypeBot
        {
            Dumb,
            Smart,
        }

        private FactoryBot() { }

        public static BOT_PILOT Build(Sources.Robot.Robot pRobot, List<int> vFuelsReserve, List<int> vRepairKitsReserve, TypeBot type)
        {
            switch (type)
            {
                case TypeBot.Dumb:
                    return new DumbBotPilot(pRobot, vFuelsReserve, vRepairKitsReserve);

                case TypeBot.Smart:
                    return new SmartBotPilot(pRobot, vFuelsReserve, vRepairKitsReserve);

                default :
                    return null;
            }
        }
    }
}
