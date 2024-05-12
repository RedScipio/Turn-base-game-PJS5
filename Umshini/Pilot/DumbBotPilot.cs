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
            Console.WriteLine("DumbBot attacks");
            for (int i=0; i<this.GetRobot().GetWeapons().Count; i++)
            {
                if (this.IsWeaponUsable(i))
                {
                    this.GetRobot().DealDamage(ennemiRobot, i, TARGET_TYPE.FURNACE);
                }
            }
        }

        public override List<int> PlayTurnAuto(IROBOT ennemyRobot)
        {
            Console.WriteLine("DumbBot attacks");
            for (int i = 0; i < this.GetRobot().GetWeapons().Count; i++)
            {
                if (this.IsWeaponUsable(i))
                {
                    return new List<int>(this.GetRobot().DealDamage(ennemyRobot, i, TARGET_TYPE.FURNACE));
                }
            }

            return new List<int>();
        }
    }
}
