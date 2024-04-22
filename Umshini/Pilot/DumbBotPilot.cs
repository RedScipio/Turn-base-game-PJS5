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

        public override void PlayTurn(IROBOT ennemiRobot, int iChoice = -1, int iRes = -1, int iChoiceTarget = -1, int iHitRate = -1)
        {
            if (this.GetRobot().WeaponIsUsable((int)WEAPON_SIDE.LEFT_WEAPON))
            {
                this.GetRobot().DealDamage(ennemiRobot, (int)WEAPON_SIDE.LEFT_WEAPON, PARTS_TYPES.FURNACE);
            }

            else if (this.GetRobot().WeaponIsUsable((int)WEAPON_SIDE.RIGHT_WEAPON))
            {
                this.GetRobot().DealDamage(ennemiRobot, (int)WEAPON_SIDE.RIGHT_WEAPON, PARTS_TYPES.FURNACE);
            }
        }
    }
}
