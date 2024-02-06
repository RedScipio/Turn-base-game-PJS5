using System;
using System.Collections.Generic;
using System.Linq;

namespace PJS5_CSharp.Sources.Pilot.Bot
{
    internal class SmartBotPilot : BOT_PILOT
    {
        public SmartBotPilot(Robot.Robot pRobot, List<int> vFuelsReserve, List<int> vRepairKitsReserve) : base(pRobot, vFuelsReserve, vRepairKitsReserve)
        {
        }

        /**
         *  ennemyRobot : Ennei du bot, robot du joueur
         */
        public override void PlayTurn(Sources.Robot.Robot ennemiRobot, int iChoice = -1, int iRes = -1, int iChoiceTarget = -1, int iHitRate = -1)
        {
            int life = this.GetRobot().GetFurnaceLife();

            int maxDegatPossibleEnnemy = System.Math.Max(ennemiRobot.GetLeftWeaponDamage(), ennemiRobot.GetRightWeaponDamage());
            int nbToursSurviePossible = life / maxDegatPossibleEnnemy; // Vérifier en cas de restes

            int maxDegatPossibleBot = System.Math.Max(this.GetRobot().GetLeftWeaponDamage(), ennemiRobot.GetRightWeaponDamage());
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
                List<int> listKits = this.GetRepairKitsReserve();

                // Si je peux me soigner
                if (listKits.Count > 0)
                {
                    SoinOptimal(listKits);
                    return;
                }
            }
        }


        private void UsingPowerfulWeapon(Sources.Robot.Robot ennemy)
        {
            int averageLeftWeapon = GetRobot().GetLeftWeaponDamage() * GetRobot().GetLeftWeaponHitChance();
            int averageRightWeapon = GetRobot().GetRightWeaponDamage() * GetRobot().GetRightWeaponHitChance();

            if (averageLeftWeapon > averageRightWeapon)
            {
                GetRobot().DealDamage(ennemy, Robot.WEAPON_SIDE.LEFT_WEAPON, Robot.PARTS_TYPE.FURNACE);
                return;
            }

            GetRobot().DealDamage(ennemy, Robot.WEAPON_SIDE.RIGHT_WEAPON, Robot.PARTS_TYPE.FURNACE);
            return;
        }

        private void SoinOptimal(List<int> listKits)
        {
            listKits.Sort();

            List<int> listKitsOptmum = listKits.Where(n => n > 30).ToList();

            int kitUtilise;

            // Je prend le soin de la meilleure valeur optimale
            if (listKitsOptmum.Count ==  1)
            {
                kitUtilise = listKitsOptmum[0];
            }
            else
            {
                kitUtilise = listKits[-1];
            }

            GetRobot().RepairRobotLifePoint(kitUtilise, Robot.PARTS_TYPE.FURNACE);

            return;
        }
    }
}
