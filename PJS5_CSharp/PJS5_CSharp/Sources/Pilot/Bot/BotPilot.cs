using PILOT;
using PJS5_CSharp.Sources.Robot;
using System;
using System.Collections.Generic;

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
            if (_pRobot.WeaponIsUsable(WEAPON_SIDE.LEFT_WEAPON))
            {
                ennemiRobot.DealDamage(ennemiRobot, WEAPON_SIDE.LEFT_WEAPON, (int) Robot.PARTS_TYPE.FURNACE);
            }
            else if (_pRobot.WeaponIsUsable(WEAPON_SIDE.RIGHT_WEAPON))
            {
                ennemiRobot.DealDamage(ennemiRobot, WEAPON_SIDE.RIGHT_WEAPON, (int) Robot.PARTS_TYPE.FURNACE);
            }
            //ennemiRobot.DealDamage(ennemiRobot, null, Robot.FURNACE);
            Console.WriteLine("Play bot");
        }
    }
}
