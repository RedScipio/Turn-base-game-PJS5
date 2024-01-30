using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJS5_CSharp.Sources.Pilot.Bot
{
    internal class DumbBotPilot : BOT_PILOT
    {
        public DumbBotPilot(Robot.Robot pRobot, List<int> vFuelsReserve, List<int> vRepairKitsReserve) : base(pRobot, vFuelsReserve, vRepairKitsReserve)
        {
        }

        public override void PlayTurn(Robot.Robot ennemiRobot, int iChoice = -1, int iRes = -1, int iChoiceTarget = -1, int iHitRate = -1)
        {
            if (this.GetRobot().WeaponIsUsable(Robot.WEAPON_SIDE.LEFT_WEAPON))
            {
                this.GetRobot().DealDamage(ennemiRobot, Robot.WEAPON_SIDE.LEFT_WEAPON, Robot.PARTS_TYPE.FURNACE);
            }

            else if (this.GetRobot().WeaponIsUsable(Robot.WEAPON_SIDE.RIGHT_WEAPON))
            {
                this.GetRobot().DealDamage(ennemiRobot, Robot.WEAPON_SIDE.RIGHT_WEAPON, Robot.PARTS_TYPE.FURNACE);
            }
        }
    }
}
