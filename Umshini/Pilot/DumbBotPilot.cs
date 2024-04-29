using Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilot
{
    public class DumbBotPilot : BotPilot
    {
        public DumbBotPilot(IROBOT pRobot, List<ICONSUMABLES> vFuelsReserve, List<ICONSUMABLES> vRepairKitsReserve) : base(pRobot, vFuelsReserve, vRepairKitsReserve)
        {
        }

        public override void PlayTurn(IROBOT ennemiRobot, MAIN_MENU iChoice = MAIN_MENU.Error, int iRes = -1, int iChoiceTarget = -1, int iHitRate = -1)
        {
            Console.WriteLine("DumbBot attaque");
            if (this.GetRobot().WeaponIsUsable((int)WEAPON_SIDE.LEFT_WEAPON))
            {
                this.GetRobot().DealDamage(ennemiRobot, (int)WEAPON_SIDE.LEFT_WEAPON, PARTS_TYPES.FURNACE);
            }

            else if (this.GetRobot().WeaponIsUsable((int)WEAPON_SIDE.RIGHT_WEAPON))
            {
                this.GetRobot().DealDamage(ennemiRobot, (int)WEAPON_SIDE.RIGHT_WEAPON, PARTS_TYPES.FURNACE);
            }
        }

        public override List<int> PlayTurnAuto(IROBOT ennemyRobot)
        {
            Console.WriteLine("DumbBot attaque");
            if (this.GetRobot().WeaponIsUsable((int)WEAPON_SIDE.LEFT_WEAPON))
            {
                return new List<int>(this.GetRobot().DealDamage(ennemyRobot, (int)WEAPON_SIDE.LEFT_WEAPON, PARTS_TYPES.FURNACE));
            }

            else if (this.GetRobot().WeaponIsUsable((int)WEAPON_SIDE.RIGHT_WEAPON))
            {
                return new List<int>(this.GetRobot().DealDamage(ennemyRobot, (int)WEAPON_SIDE.RIGHT_WEAPON, PARTS_TYPES.FURNACE));
            }

            else
            {
                return new List<int>();
            }
        }
    }
}
