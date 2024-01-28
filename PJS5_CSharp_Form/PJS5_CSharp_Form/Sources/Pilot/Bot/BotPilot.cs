using PILOT;
using PJS5_CSharp.Sources.Robot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJS5_CSharp.Sources.Pilot.Bot
{
    public class BOT_PILOT : IPILOT
    {
        public BOT_PILOT(Robot.Robot pRobot, List<int> vFuelsReserve, List<int> vRepairKitsReserve) : base(pRobot, vFuelsReserve, vRepairKitsReserve)
        {
        }

        public List<int> GetFuelsReserve()
        {
            throw new NotImplementedException();
        }

        public List<int> GetRepairKitsReserve()
        {
            throw new NotImplementedException();
        }

        override
        public void PlayTurn(Robot.Robot ennemiRobot)
        {
            Console.WriteLine("BotPilot.cs PlayTurn()");
        }


    }
}
