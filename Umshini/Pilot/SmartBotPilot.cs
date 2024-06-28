using Battle;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pilot
{
    public class SmartBotPilot: BotPilot
    { 
        public SmartBotPilot(IROBOT pRobot, List<ICONSUMABLES> vFuelsReserve, List<ICONSUMABLES> vRepairKitsReserve) : base(pRobot, vFuelsReserve, vRepairKitsReserve)
        {
        }

        public override void PlayTurn(IROBOT enemy, MAIN_MENU iChoice = MAIN_MENU.Error, int iRes = -1, int iChoiceTarget = -1, int iHitRate = -1)
        {

        }

        public SmartBotPilot(SmartBotPilot smartBotPilot) : base(smartBotPilot._pRobot.Clone(), smartBotPilot._vFuelsReserve, smartBotPilot._vRepairKitsReserve)
        {
        }

        public override IPILOT Clone()
        {
            return new SmartBotPilot(this);
        }

        public override List<int> PlayTurnAuto(IROBOT enemy, bool showIndications = true)
        {
            if (this.ShouldIRepairMyFurnace(enemy))
            {
                if (showIndications)
                    Console.WriteLine("Bot should repair its furnace !");

                if (this.CanIBeRepair())
                {
                    if (showIndications)
                        Console.WriteLine("Bot repairs itself !");
                    return this.IRepairMe();
                }
                else
                {
                    if (showIndications)
                        Console.WriteLine("Bot can't repair its furnace, so it uses its best weapon !");
                    return this.UseBestWeapon(enemy);
                }
            }

            else
            {
                if (showIndications)
                    Console.WriteLine("Bot's furnace doesn't need any attention yet.");

                if (this.CanIRunOutOfFuelNextRoundAround())
                {
                    if (showIndications)
                        Console.WriteLine("Bot risks running out of fuel next round !");

                    if (this.CanIRechargeInFuel())
                    {
                        if (showIndications)
                            Console.WriteLine("Bot recharges with fuel !");
                        return this.IFuelRecharge();
                    }
                    else
                    {
                        if (showIndications)
                            Console.WriteLine("Bot can't refuel, so it uses its best weapon!");
                        return this.UseBestWeapon(enemy);
                    }
                }
                else
                {
                    if (showIndications)
                        Console.WriteLine("Bot still has plenty of fuel !");
                    if (this.IsThermalWeaponWorthIt(enemy))
                    {
                        if (showIndications)
                            Console.WriteLine("Bot uses its best thermal weapon !");
                        int iThermicWeapon = GetBestThermicWeapon();
                        this.GetRobot().DealDamage(enemy, iThermicWeapon, TARGET_TYPE.FURNACE);
                        return new List<int> { (int)MAIN_MENU.Attack, iThermicWeapon, (int)TARGET_TYPE.FURNACE };
                    }
                    else
                    {
                        if (showIndications)
                            Console.WriteLine("Bot uses its best no-thermal weapon !");
                        return this.UseBestWeapon(enemy);
                    }
                }
            }
        }

        private protected List<int> IRepairMe()
        {
            //IROBOT r = this.GetRobot();
            //int pvToRepair = r.GetFurnaceMaxLife() + r.GetFurnaceMaxArmor() - r.GetFurnaceLife() - r.GetFurnaceArmor();

            for (int i = 0; i < this.GetRepairKitsReserve().Count(); i++)
            {
                if (this.Repair((REPAIRS_TYPE)i, TARGET_TYPE.FURNACE, new List<int> { i, (int)TARGET_TYPE.FURNACE }));
                new List<int> { (int)MAIN_MENU.Repairs, i, (int)TARGET_TYPE.FURNACE };
            }

            return new List<int> { (int)MAIN_MENU.Repairs };
        }

        /// <summary>
        /// Checks whether the bot can recharge sufficiently
        /// </summary>
        /// <returns>true if the robot can recharge sufficiently, false otherwise</returns>
        /// <developer>CME</developer>
        private protected bool CanIRechargeInFuel()
        {
            int minimumFuel = this.MaxConsumption();

            return this.GetFuelsReserve().Where(n => minimumFuel <= n.GetValue()).ToList().Count > 0;
        }

        /// <summary>
        /// Refuels the bot
        /// </summary>
        /// <developper>CME</developper>
        private protected List<int> IFuelRecharge()
        {
            int minFuel = this.MaxConsumption();
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

            return new List<int>() { (int)MAIN_MENU.Furnace, iChoice };
        }

        /// <summary>
        /// Check whether or not I still have repair kits available
        /// </summary>
        /// <developer>CME</developer>
        private protected bool CanIBeRepair()
        {
            if (this.GetRepairKitsReserve().Count > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the index of the best weapon (degats/precision)
        /// </summary>
        /// <returns>-1 if no weapon usable, weapon index otherwise</returns>
        /// <developer>CME</developer>
        private protected int GetBestWeapon()
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
        /// Return the index of the best heat weapon
        /// </summary>
        /// <returns>-1 if no thermal weapon usable, heat weapon index otherwise</returns>
        /// <developer>CME</developer>
        private protected int GetBestThermicWeapon()
        {
            List<IWEAPON> l = this.GetRobot().GetWeapons();

            int iBestWeapon = -1;
            IWEAPON bestWeapon = null;

            for (int i = 0; i < l.Count; i++)
            {
                IWEAPON w = l[i];

                /*
                 * If the thermal weapon in the loop is usable, and its damage/accuracy ratio is better than
                 * the weapon stored in bestWeapon (or is empty), replace it in bestWeapon
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
        /// Indicates whether or not to use a thermal weapon
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns>true if thermal weapon is preferred, false otherwise</returns>
        /// <developer>CME</developer>
        private protected bool IsThermalWeaponWorthIt(IROBOT enemy)
        {
            // Useless if the enemy is out of fuel
            if (enemy.GetFuel() == 0)
            {
                return false;
            }

            // Checking the presence of a thermal weapon
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

            // If no thermal weapon, impossible to use
            if (!haveAThermicalWeapon)
            {
                return false;
            }

            // Calculate the consumption ratio
            float rapportConsommation = enemy.GetFuel() / weapon.GetPowerConsumption();

            // Getting the best non-thermal weapon
            int iBestWeapon = this.GetBestWeapon();
             
            // If no non-thermal weapon is selected, only one thermal weapon can be used
            if (iBestWeapon < 0) return true;

            // Calculate the damage ratio
            float damageRatio;
            IWEAPON bestWeapon = this.GetRobot().GetWeapons()[iBestWeapon];

            try
            {
                if (bestWeapon.GetAccuracy() == 0 || bestWeapon.GetDamage() == 0)
                    damageRatio = 0;
                else
                    damageRatio = enemy.GetFurnaceLife() / (bestWeapon.GetDamage() / bestWeapon.GetAccuracy());
            }
            catch
            {
                damageRatio = 0;
            }

            // Return the ratio
            return rapportConsommation > damageRatio;
        }

        /// <summary>
        /// Indicates whether the robot will be destroyed on the next round
        /// </summary>
        /// <param name="enemy">Player</param>
        /// <returns>true if the risk is true, false otherwise</returns>
        /// <developer>CME</developer>
        private protected bool ShouldIRepairMyFurnace(IROBOT enemy)
        {
            // Get the most powerful weapon of the enemy
            IWEAPON weapon = null;
            foreach (IWEAPON w in enemy.GetWeapons())
            {
                if (weapon == null || weapon.GetDamage() < w.GetDamage())
                {
                    weapon = w;
                }
            }

            return weapon != null && this.GetRobot().GetFurnaceLife() <= weapon.GetDamage() && weapon.GetDamage() < this.GetRobot().GetFurnaceMaxLife();
        }

        /// <summary>
        /// Indicates whether it will be impossible to use the best weapon 2 times in a row
        /// </summary>
        /// <developer>CME</developer>
        private protected bool CanIRunOutOfFuelNextRoundAround()
        {
            if (this.GetRobot().GetFuel() == 0) return true;

            int iWeapon = this.GetBestWeapon();

            if (iWeapon == -1) return false;

            int consumptionWarning = this.GetRobot().GetWeapons()[iWeapon].GetPowerConsumption() * 2;

            return this.GetRobot().GetFuel() < consumptionWarning;
        }

        /// <summary>
        /// Use the weapon with the best available damage/accuracy ratio
        /// </summary>
        /// <param name="enemy">Enemy robot (player)</param>
        /// <developer>CME</developer>
        private protected List<int> UseBestWeapon(IROBOT enemy)
        {
            int iWeapon = this.GetBestWeapon();

            if (iWeapon != -1)
            {
                this.GetRobot().DealDamage(enemy, iWeapon, TARGET_TYPE.FURNACE);
                return new List<int> { (int)MAIN_MENU.Attack, iWeapon, (int) TARGET_TYPE.FURNACE };
            }
            
            return new List<int> { -1 };
        }

        /// <summary>
        /// Returns the consumption of the most fuel-hungry unbroken weapon
        /// </summary>
        /// <developer>CME</developer>
        private protected int MaxConsumption()
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
