﻿using Battle;
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

        public DumbBotPilot(DumbBotPilot dumbBotPilot) : base(dumbBotPilot._pRobot.Clone(), dumbBotPilot._vFuelsReserve, dumbBotPilot._vRepairKitsReserve)
        {
        }

        public override IPILOT Clone()
        {
            return new DumbBotPilot(this);
        }

        public override void PlayTurn(IROBOT enemyRobot, MAIN_MENU iChoice = MAIN_MENU.Error, int iRes = -1, int iChoiceTarget = -1, int iHitRate = -1)
        {
            Console.WriteLine("DumbBot attacks");
            for (int i=0; i<this.GetRobot().GetWeapons().Count; i++)
            {
                if (this.IsWeaponUsable(i))
                {
                    this.GetRobot().DealDamage(enemyRobot, i, TARGET_TYPE.FURNACE);
                }
            }
        }

        public override List<int> PlayTurnAuto(IROBOT enemyRobot, bool showIndications = true)
        {
            if (showIndications)
                Console.WriteLine("DumbBot attacks");
            
            for (int i = 0; i < this.GetRobot().GetWeapons().Count; i++)
            {
                if (this.IsWeaponUsable(i))
                {
                    return new List<int>(this.GetRobot().DealDamage(enemyRobot, i, TARGET_TYPE.FURNACE));
                }
            }

            return new List<int>();
        }
    }
}
