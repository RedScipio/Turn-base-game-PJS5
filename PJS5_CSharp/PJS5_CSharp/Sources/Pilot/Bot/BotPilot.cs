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

        override
        public void PlayTurn(Robot.Robot ennemiRobot)
        {
            if (_pRobot.WeaponIsUsable(ARMED_ARM_TYPE.LEFT_WEAPON))
            {
                ennemiRobot.DealDamage(ennemiRobot, ARMED_ARM_TYPE.LEFT_WEAPON, Robot.PARTS_TYPE.FURNACE);
            }
            else if (_pRobot.WeaponIsUsable(ARMED_ARM_TYPE.RIGHT_WEAPON))
            {
                ennemiRobot.DealDamage(ennemiRobot, ARMED_ARM_TYPE.RIGHT_WEAPON, Robot.PARTS_TYPE.FURNACE);
            }
            //ennemiRobot.DealDamage(ennemiRobot, null, Robot.FURNACE);
            Console.WriteLine("Play bot");
        }
    }
}
