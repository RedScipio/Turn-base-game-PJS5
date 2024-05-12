using Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilot
{
    public class SmartBotPilot: BotPilot
    { 
        public SmartBotPilot(IROBOT pRobot, List<ICONSUMABLES> vFuelsReserve, List<ICONSUMABLES> vRepairKitsReserve) : base(pRobot, vFuelsReserve, vRepairKitsReserve)
        {
        }

        public override void PlayTurn(IROBOT ennemy, MAIN_MENU iChoice = MAIN_MENU.Error, int iRes = -1, int iChoiceTarget = -1, int iHitRate = -1)
        {
            if (this.ShouldIRepareMyFurnace(ennemy))
            {
                Console.WriteLine("Bot devrait réparer son fourneau !");

                if (this.PuisJeMeReparer())
                {
                    Console.WriteLine("Bot se répare !");
                    //this.JeMeRepare();
                }
                else
                {
                    Console.WriteLine("Bot ne peut pas réparer son fourneau, il utilise sa meilleure arme !");
                    this.UseBestWeapon(ennemy);
                }
            }

            else
            {
                Console.WriteLine("Le fourneau de Bot ne nécessite pas encore d'attention.");

                if (this.PuisJeManquerDeCarburantAuProchainTour())
                {
                    Console.WriteLine("Bot risque de manquer de carburant au tour prochain !");

                    if (this.PuisJeMeRechargerEnCarburant())
                    {
                        Console.WriteLine("Bot se recharge en carburant !");
                        this.JeMeRechargeEnCarburant();
                    }
                    else
                    {
                        Console.WriteLine("Bot ne peut pas se recharger en carburant, il utilise sa meilleure arme !");
                        this.UseBestWeapon(ennemy);
                    }
                }
                else
                {
                    Console.WriteLine("Bot a encore largement assez de carburant !");
                    if (this.IsThermalWeaponWorthIt(ennemy))
                    {
                        Console.WriteLine("Bot utilise sa meilleure arme thermique !");
                        int iThermicWeapon = GetBestThermicWeapon();
                        this.GetRobot().DealDamage(ennemy, iThermicWeapon, TARGET_TYPE.FURNACE);
                    }
                    else
                    {
                        Console.WriteLine("Bot utilise sa meilleure arme non thermique !");
                        this.UseBestWeapon(ennemy);
                    }
                }
            }
        }

        public override List<int> PlayTurnAuto(IROBOT ennemyRobot)
        {
            this.PlayTurn(ennemyRobot); return null;
        }

        /// <summary>
        /// Vérifie si le robot peut se recharger suffisament
        /// </summary>
        /// <returns>true si le robot peut se recharger suffisement, false sinon</returns>
        /// <developer>CME</developer>
        private bool PuisJeMeRechargerEnCarburant()
        {
            int minimumFuel = this.MaxConsommation();

            return this.GetFuelsReserve().Where(n => minimumFuel <= n.GetValue()).ToList().Count > 0;
        }

        /// <summary>
        /// Recharge le robot en carburant
        /// </summary>
        /// <developper>CME</developper>
        private void JeMeRechargeEnCarburant()
        {
            int minFuel = this.MaxConsommation();
            int maxAcceptable = APILOT.MAX_FUEL - minFuel;

            List<ICONSUMABLES> l = this.GetFuelsReserve();

            int iChoice = -1;

            for (int i = 0; i < l.Count; i++)
            {
                if (minFuel <= l[i].GetValue() && l[i].GetValue() <= maxAcceptable)
                {
                    iChoice = i;
                    break;
                }

                else if (minFuel <= l[i].GetValue() && iChoice == -1)
                {
                    iChoice = i;
                    break;
                }
            }

            if (iChoice != -1)
            {
                this.GetRobot().Refuel(iChoice);
            }
        }

        /// <summary>
        /// Vérifie si oui ou non je dispose encore de kits de réparations
        /// </summary>
        /// <developer>CME</developer>
        private bool PuisJeMeReparer()
        {
            if (this.GetRepairKitsReserve().Count > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Retourne l'index de la meilleure arme (degats/précision)
        /// </summary>
        /// <returns>-1 si pas d'arme utilisable, index de l'arme sinon</returns>
        /// <developer>CME</developer>
        private int GetBestWeapon()
        {
            List<IWEAPON> l =  this.GetRobot().GetWeapons();

            IWEAPON bestWeapon = null;
            int iBestWeapon = -1;

            for (int i=0; i<l.Count; i++)
            {
                IWEAPON w = l[i];

                /*
                 * Si l'arme dans la boucle est utilisable, et que son ratio dégats/précision est mieux que
                 * l'arme stockée dans bestWeapon (ou qu'elle est vide), la remplacer dans bestWeapon
                 */
                if (this.IsWeaponUsable(i) && (bestWeapon == null || bestWeapon.GetDamage() * bestWeapon.GetAccuracy() < 
                    w.GetDamage() * w.GetAccuracy()))
                {
                    bestWeapon = w;
                    iBestWeapon = i;
                }
            }

            return iBestWeapon;
        }

        /// <summary>
        /// Retourne l'index de la meilleure arme thermique
        /// </summary>
        /// <returns>-1 si pas d'arme thermique utilisable, index de l'arme thermique sinon</returns>
        /// <developer>CME</developer>
        private int GetBestThermicWeapon()
        {
            List<IWEAPON> l = this.GetRobot().GetWeapons();

            int iBestWeapon = -1;
            IWEAPON bestWeapon = null;

            for (int i = 0; i < l.Count; i++)
            {
                IWEAPON w = l[i];

                /*
                 * Si l'arme thermique dans la boucle est utilisable, et que son ratio dégats/précision est mieux que
                 * l'arme stockée dans bestWeapon (ou qu'elle est vide), la remplacer dans bestWeapon
                 */
                if (this.IsWeaponUsable(i) && w.TypeIs() == WEAPONS_TYPES.THERMAL &&
                    (bestWeapon == null || bestWeapon.GetDamage() * bestWeapon.GetAccuracy() < w.GetDamage() * w.GetAccuracy()))
                {
                    bestWeapon = w;
                    iBestWeapon = i;
                }
            }

            return iBestWeapon;
        }

        /// <summary>
        /// Indique s'il vaut mieux utiliser une arme thermique ou non
        /// </summary>
        /// <param name="ennemy"></param>
        /// <returns>true si l'arme thermique est préférable, false sinon</returns>
        /// <developer>CME</developer>
        private bool IsThermalWeaponWorthIt(IROBOT ennemy)
        {
            // Inutile si l'ennemi n'a plus de carburant
            if (ennemy.GetFuel() == 0)
            {
                return false;
            }

            //Vérifier la présense d'une arme thermique
            bool haveAThermicalWeapon = false;
            IWEAPON weapon = null;
            int iWeapon = 0;

            foreach (IWEAPON w in this.GetRobot().GetWeapons())
            {
                if (w.TypeIs() == WEAPONS_TYPES.THERMAL && this.IsWeaponUsable(iWeapon++))
                {
                    haveAThermicalWeapon = true;
                    weapon = w;
                    break;
                }
            }

            //Si pas d'arme thermique, impossible d'en utiliser
            if (!haveAThermicalWeapon)
            {
                return false;
            }

            //Calculer le rapport de consommation
            float rapportConsommation = ennemy.GetFuel() / weapon.GetPowerConsumption();
            
            //Obtention de la meilleure arme non thermique
            int iBestWeapon = this.GetBestWeapon();

            //Si aucune arme non thermique sélectionnée, on ne peut utiliser qu'une arme thermique
            if (iBestWeapon < 0) return true;

            //Calculer le rapport de dégats
            IWEAPON bestWeapon = this.GetRobot().GetWeapons()[iBestWeapon];
            float rapportDegats = ennemy.GetFurnaceLife() / (bestWeapon.GetDamage()/bestWeapon.GetAccuracy());

            //Retourner le rapport
            return rapportConsommation > rapportDegats;
        }

        /// <summary>
        /// Indique si le robot risque de se faire détruire au prochain coup
        /// </summary>
        /// <param name="ennemy">Player</param>
        /// <returns>true si le rique est vrai, false sinon</returns>
        /// <developper>CME</developper>
        private bool ShouldIRepareMyFurnace(IROBOT ennemy)
        {
            // Get the most powerful weapon of the ennemy
            IWEAPON weapon = null;
            foreach (IWEAPON w in ennemy.GetWeapons())
            {
                if (weapon == null || weapon.GetDamage() < w.GetDamage())
                {
                    weapon = w;
                }
            }

            return weapon != null && this.GetRobot().GetFurnaceLife() <= weapon.GetDamage();
        }

        /// <summary>
        /// Indique s'il sera impossible d'utiliser la meilleure arme 2 fois de suite
        /// </summary>
        /// <developper>CME</developper>
        private bool PuisJeManquerDeCarburantAuProchainTour()
        {
            // Le joueur a une arme thermique

            // Le robot a une arme qui peut augmenter sa consommation

            // Je manque de carburant ssi mon arme favorite consomme entre 1 et 2 fois
            // la quantité actuelle de fuel
            if (this.GetRobot().GetFuel() == 0) return true;

            int iWeapon = this.GetBestWeapon();

            if (iWeapon == -1) return false;

            int consumptionWarning = this.GetRobot().GetWeapons()[iWeapon].GetPowerConsumption() * 2;

            return this.GetRobot().GetFuel() < consumptionWarning;
        }

        /// <summary>
        /// Utilise l'arme ayant le meilleur ration dégats/précision disponible
        /// </summary>
        /// <param name="ennemy">Robot ennemi (joueur)</param>
        /// <developer>CME</developer>
        private void UseBestWeapon(IROBOT ennemy)
        {
            int iWeapon = this.GetBestWeapon();

            if (iWeapon != -1)
                this.GetRobot().DealDamage(ennemy, iWeapon, TARGET_TYPE.FURNACE);
        }

        /// <summary>
        /// Retourne la consommation de l'arme non brisée la plus gourmande en fuel
        /// </summary>
        /// <returns></returns>
        private int MaxConsommation()
        {
            int maxConso = 0;

            // Le robot a une arme qui peut augmenter sa consommation
            foreach (IWEAPON w in this.GetRobot().GetWeapons())
            {
                if (!w.IsBroken() && maxConso < w.GetPowerConsumption())
                    maxConso = w.GetPowerConsumption();
            }

            return maxConso;
        }
    }
}
