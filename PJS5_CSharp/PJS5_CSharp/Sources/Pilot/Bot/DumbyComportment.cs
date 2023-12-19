using System;
using PJS5_CSharp.Sources.Robot;

namespace PJS5_CSharp.Sources.Pilot.Bot
{
    class DumbyComportment : IComportement
    {
        public void PlayTurn(Sources.Robot.Robot robotBot, Sources.Robot.Robot robotPlayer)
        {
            if (robotBot.WeaponIsUsable(WEAPON_SIDE.LEFT_WEAPON))
            {
                robotPlayer.DealDamage(robotPlayer, WEAPON_SIDE.LEFT_WEAPON, (int)Sources.Robot.PARTS_TYPE.FURNACE);
            }
            else if (robotBot.WeaponIsUsable(WEAPON_SIDE.RIGHT_WEAPON))
            {
                robotPlayer.DealDamage(robotPlayer, WEAPON_SIDE.RIGHT_WEAPON, (int)Sources.Robot.PARTS_TYPE.FURNACE);
            }
            //robotPlayer.DealDamage(robotPlayer, null, Robot.FURNACE);
            Console.WriteLine("Play bot");
        }
    }
}
