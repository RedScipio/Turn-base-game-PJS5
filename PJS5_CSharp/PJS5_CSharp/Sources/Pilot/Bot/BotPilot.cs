using PILOT;
using System.Collections.Generic;
using System.Linq;

namespace PJS5_CSharp.Sources.Pilot.Bot
{
    public class BOT_PILOT : IPILOT
    {

        public BOT_PILOT(Sources.Robot.Robot pRobot, List<int> vFuelsReserve, List<int> vRepairKitsReserve) : base(pRobot, vFuelsReserve, vRepairKitsReserve)
        {
        }

        /**
         *  ennemyRobot : Ennei du bot, robot du joueur
         *
         */
        public override void PlayTurn(Sources.Robot.Robot ennemiRobot)
        {
            const int life = 300;

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
                    soinOptimal(listKits);
                    return;
                }
            }
        }


        private void UsingPowerfulWeapon(Sources.Robot.Robot ennemy){
            int averageLeftWeapon = GetRobot().GetLeftWeaponDamage() * GetRobot().GetLeftWeaponHitChance();
            int averageRightWeapon = GetRobot().GetRightWeaponDamage() * GetRobot().GetRightWeaponHitChance();
        
            if (averageLeftWeapon > averageRightWeapon)
            {
                //!!!
                GetRobot().DealDamage(ennemy, Robot.WEAPON_SIDE.LEFT_WEAPON, 2);
                return;
            }

            //!!!
            GetRobot().DealDamage(ennemy, Robot.WEAPON_SIDE.RIGHT_WEAPON, 2);
            return;
        }

        private void soinOptimal(List<int> listKits)
        {
            listKits.Sort();

            List<int> listKitsOptmum = listKits.Where(n => n > 30).ToList();

            int kitUtilise;

            // Je prend le soin de la meilleure valeur optimale
            if (listKitsOptmum.Count > 0)
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
