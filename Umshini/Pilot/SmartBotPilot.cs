using Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilot
{
    internal class SmartBotPilot: BotPilot
    { 
        public SmartBotPilot(IROBOT pRobot, List<ICONSUMABLE> vFuelsReserve, List<ICONSUMABLE> vRepairKitsReserve) : base(pRobot, vFuelsReserve, vRepairKitsReserve)
        {
        }

        /**
         *  ennemyRobot : Ennei du bot, robot du joueur
         */


        public override void PlayTurn(IROBOT ennemiRobot, MAIN_MENU iChoice = MAIN_MENU.Error, int iRes = -1, int iChoiceTarget = -1, int iHitRate = -1)
        {
            int life = this.GetRobot().GetFurnaceLife();

            int maxDegatPossibleEnnemy = System.Math.Max(ennemiRobot.GetWeaponDamage(0), ennemiRobot.GetWeaponDamage(1));
            int nbToursSurviePossible = life / maxDegatPossibleEnnemy; // Vérifier en cas de restes

            int maxDegatPossibleBot = System.Math.Max(this.GetRobot().GetWeaponDamage(0), ennemiRobot.GetWeaponDamage(1));
            int nbToursSurviePossibleEnnemy = life / maxDegatPossibleBot; // Vérifier en cas de restes


            // Si mes espoirs de victoires sont supérieurs aux siennes, j'attaque
            if (nbToursSurviePossible >= nbToursSurviePossibleEnnemy)
            {
                UsingPowerfulWeapon(ennemiRobot);
                return;
            }

            // Si je risque surtout de mourir, je tente de me soigner
            else
            {
                List<ICONSUMABLE> listKits = this.GetRepairKitsReserve();

                // Si je peux me soigner
                if (listKits.Count > 0)
                {
                    SoinOptimal(listKits);
                    return;
                }
            }
        }


        private void UsingPowerfulWeapon(IROBOT ennemy)
        {
            int averageLeftWeapon = GetRobot().GetWeaponDamage(0) * GetRobot().GetWeaponHitChance(0);
            int averageRightWeapon = GetRobot().GetWeaponDamage(1) * GetRobot().GetWeaponHitChance(1);

            if (averageLeftWeapon > averageRightWeapon)
            {
                GetRobot().DealDamage(ennemy, (int)WEAPON_SIDE.LEFT_WEAPON, PARTS_TYPES.FURNACE);
                return;
            }

            GetRobot().DealDamage(ennemy, (int)WEAPON_SIDE.RIGHT_WEAPON, PARTS_TYPES.FURNACE);
            return;
        }

        private void SoinOptimal(List<ICONSUMABLE> listKits)
        {
            listKits.Sort();

            List<ICONSUMABLE> listKitsOptmum = listKits.Where(n => n.GetValue() > 30).ToList();

            ICONSUMABLE kitUtilise;

            // Je prend le soin de la meilleure valeur optimale
            if (listKitsOptmum.Count == 1)
            {
                kitUtilise = listKitsOptmum[0];
            }
            else
            {
                kitUtilise = listKits[-1];
            }

            GetRobot().RepairRobotLifePoint(kitUtilise.GetValue(), PARTS_TYPES.FURNACE);

            return;
        }
    }
}
