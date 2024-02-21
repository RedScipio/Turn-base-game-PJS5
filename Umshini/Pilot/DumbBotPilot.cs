using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilot
{
    internal class DumbBotPilot: BotPilot
    {
        public DumbBotPilot(IROBOT pRobot, List<ICONSUMABLE> vFuelsReserve, List<ICONSUMABLE> vRepairKitsReserve) : base(pRobot, vFuelsReserve, vRepairKitsReserve)
        {
        }

        public override void PlayTurn(IROBOT ennemiRobot, int iChoice = -1, int iRes = -1, int iChoiceTarget = -1, int iHitRate = -1)
        {
            if (this.GetRobot().WeaponIsUsable(WEAPON_SIDE.LEFT_WEAPON))
            {
                this.GetRobot().DealDamage(ennemiRobot, WEAPON_SIDE.LEFT_WEAPON, PARTS_TYPE.FURNACE);
            }

            else if (this.GetRobot().WeaponIsUsable(WEAPON_SIDE.RIGHT_WEAPON))
            {
                this.GetRobot().DealDamage(ennemiRobot, WEAPON_SIDE.RIGHT_WEAPON, PARTS_TYPE.FURNACE);
            }
        }
    }
}
