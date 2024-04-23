
using System;
//using Umshini;
using System.Collections.Generic;

namespace Battle
{    
    public enum MAIN_MENU
    {
        Error = -1,
        Attack = 1,
        Repairs = 2,
        Furnace = 3,
    }

    public enum TARGET_MENU
    {
        Error = -1,
        Back = 0,
        Left_Weapon = 1,
        Right_Weapon = 2,
        Legs = 3,
        Furnace = 4,
    }

    public enum REPAIRS_MENU
    {
        Error = -1,
        Back = 0,
        Light_Armor = 1,
        Heavy_Armor = 2,
        Repair_Kits = 3,
        Full_Kits = 4,
    }

    public enum WEAPON_MENU
    {
        Error = -1,
        Back = 0,
        Left_Weapon = 1,
        Right_Weapon = 2,
    }

    public enum FUEL_MENU
    {
        Error = -1,
        Back = 0,
        Wood = 1,
        Charcoal = 2,
        Coal = 3,
        Compact_Coal = 4,
    }

    public static class GUI
    {

        /*public void ShowStatus(IROBOT pPlayer, IROBOT pBot)
        {
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|                  Robots                  |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|>-     Player     -<||>-     Ennemi     -<|");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("| Furnace armor: " + pPlayer.GetFurnaceArmor() + "/" + pPlayer.GetFurnaceMaxArmor() + " || Furnace armor: " + pBot.GetFurnaceArmor() + "/" + pBot.GetFurnaceMaxArmor() + " |");
            Console.WriteLine("| Furnace life: " + pPlayer.GetFurnaceLife() + "/" + pPlayer.GetFurnaceMaxLife() + "  || Furnace life: " + pBot.GetFurnaceLife() + "/" + pBot.GetFurnaceMaxLife() + "  |");
            Console.WriteLine("|>- - - - - - - - - -<>- - - - - - - - - -<|");
            Console.WriteLine("| Legs armor: " + pPlayer.GetLegsArmor() + "/" + pPlayer.GetLegsMaxArmor() + "    || Legs armor: " + pBot.GetLegsArmor() + "/" + pBot.GetLegsMaxArmor() + "    |");
            Console.WriteLine("| Legs remains: " + pPlayer.GetLegsLife() + "/" + pPlayer.GetLegsMaxLife() + "  || Legs remains: " + pBot.GetLegsLife() + "/" + pBot.GetLegsMaxLife() + "  |");
            Console.WriteLine("|>- - - - - - - - - -<>- - - - - - - - - -<|");
            Console.WriteLine("| WeaponL armor: " + pPlayer.GetLeftWeaponArmor() + "/" + pPlayer.GetLeftWeaponMaxArmor() + " || WeaponL armor: " + pBot.GetLeftWeaponArmor() + "/" + pBot.GetLeftWeaponMaxArmor() + " |");
            Console.WriteLine("| WeaponL life: " + pPlayer.GetLeftWeaponLife() + "/" + pPlayer.GetLeftWeaponMaxLife() + "  || WeaponL life: " + pBot.GetLeftWeaponLife() + "/" + pBot.GetLeftWeaponMaxLife() + "  |");
            Console.WriteLine("|>- - - - - - - - - -<>- - - - - - - - - -<|");
            Console.WriteLine("| WeaponR armor: " + pPlayer.GetRightWeaponArmor() + "/" + pPlayer.GetRightWeaponMaxArmor() + " || WeaponR armor: " + pBot.GetRightWeaponArmor() + "/" + pBot.GetRightWeaponMaxArmor() + " |");
            Console.WriteLine("| WeaponR life: " + pPlayer.GetRightWeaponLife() + "/" + pPlayer.GetRightWeaponMaxLife() + "  || WeaponR life: " + pBot.GetRightWeaponLife() + "/" + pBot.GetRightWeaponMaxLife() + "  |");
            Console.WriteLine("|===================-<>-===================|");
            int iPlayerFuel = pPlayer.GetFuel();
            Console.Write("|    Fuel: " + iPlayerFuel + "/100");
            if (iPlayerFuel < 100)
            {
                Console.Write(" ");
            }
            int iBotFuel = pBot.GetFuel();
            Console.Write("   ||    Fuel: " + iBotFuel + "/100");
            if (iBotFuel < 100)
            {
                Console.Write(" ");
            }
            Console.WriteLine("   |");
            Console.WriteLine("|====================--====================|");
        }*/

        public static MAIN_MENU MainMenu(int resultat = -1)
        {
            int iResult = 0;
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|                Main  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|  " + (int)MAIN_MENU.Attack + "-Attack  ||  " + (int)MAIN_MENU.Repairs + "-Repairs  ||  " + (int)MAIN_MENU.Furnace + "-Furnace  |");
            Console.WriteLine("|===================-<>-===================|");
            Console.Write("| Tap the number of the desired action : ");
            if (resultat == -1)
            {
                try
                {
                    iResult = Convert.ToInt32(Console.ReadLine());
                }
                catch {
                    return MAIN_MENU.Error;
                }
            }
            Console.WriteLine(" |");
            Console.WriteLine("|====================--====================|");

            switch (iResult)
            {
                case (int)MAIN_MENU.Attack:
                    return MAIN_MENU.Attack;
                case (int)MAIN_MENU.Repairs:
                    return MAIN_MENU.Repairs;
                case (int)MAIN_MENU.Furnace:
                    return MAIN_MENU.Furnace;
                default:
                    return MAIN_MENU.Error;
            }
        }

        public static TARGET_MENU TargetMenu(int res = -1)
        {
            int iResult;
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|              Target  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|    " + (int)TARGET_MENU.Left_Weapon + "-Left Weapon   ||   " + (int)TARGET_MENU.Right_Weapon + "-Right Weapon   |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|       " + (int)TARGET_MENU.Legs + "-Legs       ||     " + (int)TARGET_MENU.Furnace + "-Furnace      |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|                    ||       " + (int)TARGET_MENU.Back + "-Back       |");
            Console.WriteLine("|===================-<>-===================|");
            Console.Write("| Select the target part : ");
            if (res == -1)
            {
                try
                {
                    iResult = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    return TARGET_MENU.Error;
                }
            }
            else
            {
                iResult = res;
            }
            Console.WriteLine("               |");
            Console.WriteLine("|====================--====================|");

            switch (iResult)
            {
                case (int) TARGET_MENU.Left_Weapon:
                    return TARGET_MENU.Left_Weapon;
                case (int) TARGET_MENU.Right_Weapon:
                    return TARGET_MENU.Right_Weapon;
                case (int) TARGET_MENU.Legs:
                    return TARGET_MENU.Legs;
                case (int) TARGET_MENU.Back:
                    return TARGET_MENU.Back;
                case (int) TARGET_MENU.Furnace:
                    return TARGET_MENU.Furnace;
                default:
                    return TARGET_MENU.Error;
            }
        }

        public static REPAIRS_MENU RepairMenu(IPILOT pPilot, int res = -1)
        {
            int iResult;
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|                Kits  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            List<ICONSUMABLE> vRepairKitsReserve = pPilot.GetRepairKitsReserve();
            ICONSUMABLE iLightArmor = vRepairKitsReserve[0];
            Console.Write("| " + (int)REPAIRS_MENU.Light_Armor + "-Light armor: x" + iLightArmor.GetValue());
            if (iLightArmor.GetValue() < 10)
            {
                Console.Write(" ");
            }
            ICONSUMABLE iHeavyKits = vRepairKitsReserve[1];
            Console.Write(" || " + (int)REPAIRS_MENU.Heavy_Armor + "-Heavy armor: x" + iHeavyKits.GetValue());
            if (iHeavyKits.GetValue() < 10)
            {
                Console.Write(" ");
            }
            Console.WriteLine(" |");
            Console.WriteLine("|      Armor: 1      ||      Armor: 3      |");
            Console.WriteLine("|===================-<>-===================|");
            ICONSUMABLE iRepairKits = vRepairKitsReserve[2];
            Console.Write("| " + (int)REPAIRS_MENU.Repair_Kits + "-Repair kits: x" + iRepairKits.GetValue());
            if (iRepairKits.GetValue() < 10)
            {
                Console.Write(" ");
            }
            ICONSUMABLE iFullKits = vRepairKitsReserve[3];
            Console.Write(" ||  " + (int)REPAIRS_MENU.Full_Kits + "-Full kits: x" + iFullKits.GetValue());
            if (iFullKits.GetValue() < 10)
            {
                Console.Write(" ");
            }
            Console.WriteLine("  |");
            Console.WriteLine("|   Life Points: 1   ||   Life Points: 3   |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|                    ||       0-Back       |");
            Console.WriteLine("|===================-<>-===================|");
            Console.Write("| Select your kit type : ");
            if (res == -1)
            {
                try
                {
                    iResult = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    return REPAIRS_MENU.Error;
                }
            }
            else
            {
                iResult = res;
            }
            Console.WriteLine("                 |");
            Console.WriteLine("|====================--====================|");
            
            switch (iResult)
            {
                case (int) REPAIRS_MENU.Full_Kits:
                    return REPAIRS_MENU.Full_Kits;
                case (int) REPAIRS_MENU.Repair_Kits:
                    return REPAIRS_MENU.Repair_Kits;
                case (int) REPAIRS_MENU.Light_Armor:
                    return REPAIRS_MENU.Light_Armor;
                case (int) REPAIRS_MENU.Heavy_Armor:
                    return REPAIRS_MENU.Heavy_Armor;
                case (int) REPAIRS_MENU.Back:
                    return REPAIRS_MENU.Back;
                default:
                    return REPAIRS_MENU.Error;
            }
        }

        public static FUEL_MENU FuelMenu(IPILOT pPilot, int res = -1)
        {
            int iResult;
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|                Fuel  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            List<ICONSUMABLE> vFuelsReserve = pPilot.GetFuelsReserve();
            ICONSUMABLE iWood = vFuelsReserve[0];
            Console.Write("|     " + (int)FUEL_MENU.Wood + "-Wood: x" + iWood);
            if (iWood.GetValue() < 10)
            {
                Console.Write(" ");
            }
            ICONSUMABLE iCharcoal = vFuelsReserve[1];
            Console.Write("    ||   " + (int)FUEL_MENU.Charcoal + "-Charcoal: x" + iCharcoal);
            if (iCharcoal.GetValue() < 10)
            {
                Console.Write(" ");
            }
            Console.WriteLine("  |");
            Console.WriteLine("|     Energy: " + ENERGY.ENERGY_WOOD + "     ||     Energy: " + ENERGY.ENERGY_CHARCOAL + "     |");
            Console.WriteLine("|===================-<>-===================|");
            ICONSUMABLE iCoal = vFuelsReserve[2];
            Console.Write("|     " + (int)FUEL_MENU.Coal + "-Coal: x" + iCoal);
            if (iCoal.GetValue() < 10)
            {
                Console.Write(" ");
            }
            ICONSUMABLE iCompactCoal = vFuelsReserve[3];
            Console.Write("    || " + (int)FUEL_MENU.Compact_Coal + "-Compact Coal: x" + iCompactCoal);
            if (iCompactCoal.GetValue() < 10)
            {
                Console.Write(" ");
            }
            Console.WriteLine("|");
            Console.WriteLine("|     Energy: " + ENERGY.ENERGY_COAL + "     ||     Energy: " + ENERGY.ENERGY_COMPACT_COAL + "     |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|                    ||       " + (int)FUEL_MENU.Back + "-Back       |");
            Console.WriteLine("|===================-<>-===================|");
            Console.Write("| Select your fuel type : ");
            if (res == -1)
            {
                try
                {
                    iResult = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    return FUEL_MENU.Error;
                }
            }
            else
            {
                iResult = res;
            }
            Console.WriteLine("                |");
            Console.WriteLine("|====================--====================|");

            switch (iResult)
            {
                case (int)FUEL_MENU.Wood:
                    return FUEL_MENU.Wood;
                case (int)FUEL_MENU.Charcoal:
                    return FUEL_MENU.Charcoal;
                case (int)FUEL_MENU.Coal:
                    return FUEL_MENU.Coal;
                case (int)FUEL_MENU.Back:
                    return FUEL_MENU.Back;
                default:
                    return FUEL_MENU.Error;
            }
        }

        public static WEAPON_MENU WeaponMenu(IPILOT pPlayer, int res = -1)
        {
            int iResult;
            int iWeapon = 0;
            IROBOT playerRobot = pPlayer.GetRobot();
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|              Weapon  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            foreach(IWEAPON weapon in playerRobot.GetWeapons())
            {
                Console.Write("| Weapon n°" + (iWeapon+1) + " type: ");
                switch (weapon.TypeIs())
                {
                    case WEAPONS_TYPES.NORMAL:
                        {
                            Console.WriteLine("Normal               |");
                            break;
                        }
                    case WEAPONS_TYPES.MELEE:
                        {
                            Console.WriteLine("Melee                |");
                            break;
                        }
                    case WEAPONS_TYPES.PROJECTILE:
                        {
                            Console.WriteLine("Projectile           |");
                            int iAmmo = weapon.GetAmmo();
                            Console.Write("| Remaining ammo: x" + iAmmo);
                            if (iAmmo < 10)
                            {
                                Console.Write(" ");
                            }
                            Console.WriteLine("                      |");
                            break;
                        }
                    case WEAPONS_TYPES.THERMAL:
                        {
                            Console.WriteLine("Thermal              |");
                            int iFuel = weapon.GetHeatEffect();
                            Console.Write("| Burning fuels: x" + iFuel);
                            if (iFuel < 10)
                            {
                                Console.Write(" ");
                            }
                            Console.WriteLine("                     |");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Undefined            |");
                            break;
                        }
                }
                Console.WriteLine("|>- - - - - - - - - -<>- - - - - - - - - -<|");
                Console.WriteLine("| Damage: " + weapon.GetDamage() + "                                |");
                int iLeftAccuracy = playerRobot.GetWeaponHitChance(iWeapon);
                Console.Write("| Accuracy: " + iLeftAccuracy + "%");
                if (iLeftAccuracy < 100)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("                           |");
                Console.WriteLine("| Fuel Consumption: " + weapon.GetPowerConsumption() + "                     |");

                iWeapon++;
            }
            
            
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|                    ||       " + (int)WEAPON_MENU.Back + "-Back       |");
            Console.WriteLine("|===================-<>-===================|");
            Console.Write("| Select your weapon : ");
            if (res == -1)
            {
                try
                {
                    iResult = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    return WEAPON_MENU.Error;
                }
            }
            else
            {
                iResult = res;
            }
            Console.WriteLine("                   |");
            Console.WriteLine("|====================--====================|");
            
            switch(iResult)
            {
                case (int) WEAPON_MENU.Left_Weapon:
                    return WEAPON_MENU.Left_Weapon;
                case (int)WEAPON_MENU.Right_Weapon:
                    return WEAPON_MENU.Right_Weapon;
                case (int)WEAPON_MENU.Back:
                    return WEAPON_MENU.Back;
                default:
                    return WEAPON_MENU.Error;
            }
        }

        public static void RobotRestart()
        {
            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|      The robot need fuel to restart      |");
            Console.WriteLine("|--------------------==--------------------|");
        }

        public static void WeaponIsUnusable()
        {
            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|         This weapon  is unusable         |");
            Console.WriteLine("|--------------------==--------------------|");
        }

        public static void AlreadyDestroy()
        {
            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|       This part is already destroy       |");
            Console.WriteLine("|--------------------==--------------------|");
        }

        public static void MissedFire()
        {
            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|            It'  missed fire            |");
            Console.WriteLine("|--------------------==--------------------|");
        }

        public static void NoStockKit()
        {
            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|    No more kits of this type in stock    |");
            Console.WriteLine("|--------------------==--------------------|");
        }

        public static void PerfectlyFine()
        {
            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|              Perfectly Fine              |");
            Console.WriteLine("|--------------------==--------------------|");
        }

        public static void NoStockFuel()
        {
            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|    No more fuel of this type in stock    |");
            Console.WriteLine("|--------------------==--------------------|");
        }

        public static void WrongEntry()
        {
            Console.WriteLine("!!!-----------------!==!-----------------!!!");
            Console.WriteLine("|               Wrong  Entry               |");
            Console.WriteLine("!!!-----------------!==!-----------------!!!");
        }

        public static int TargetPartMenu()
        {
            throw new NotImplementedException();
        }

        public static void WeaponOutOfRange()
        {
            throw new NotImplementedException();
        }
    }
}