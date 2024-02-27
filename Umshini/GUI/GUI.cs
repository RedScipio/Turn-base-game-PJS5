
using System.Collections.Generic;
using System;
using Battle;

namespace GUI
{
    public enum MAIN_MENU
    {
        Attack = 1,
        Repairs = 2,
        Furnace = 3,
    }

    public enum TARGET_MENU
    {
        Back = 0,
        Left_Weapon = 1,
        Right_Weapon = 2,
        Legs = 3,
        Furnace = 4,
    }

    public enum REPAIRS_MENU
    {
        Back = 0,
        Light_Armor = 1,
        Heavy_Armor = 2,
        Repair_Kits = 3,
        Full_Kits = 4,
    }

    public enum WEAPON_MENU
    {
        Back = 0,
        Left_Weapon = 1,
        Right_Weapon = 2,
    }

    public enum FUEL_MENU
    {
        Back = 0,
        Wood = 1,
        Charcoal = 2,
        Coal = 3,
        Compact_Coal = 4,
    }

    public static class GUI
    {
        public const int ENERGY_WOOD = 15;
        public const int ENERGY_CHARCOAL = 20;
        public const int ENERGY_COAL = 25;
        public const int ENERGY_COMPACT_COAL = 35;





        public static void ShowStatus(IROBOT pPlayer, IROBOT pBot)
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
        }

        public static int MainMenu(int res = -1)
        {
            int iResult = 0;
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|                Main  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|  " + (int)MAIN_MENU.Attack + "-Attack  ||  " + (int)MAIN_MENU.Repairs + "-Repairs  ||  " + (int)MAIN_MENU.Furnace + "-Furnace  |");
            Console.WriteLine("|===================-<>-===================|");
            Console.Write("| Tap the number of the desired action : ");
            if (res == -1)
            {
                iResult = Utils.GetInt();
            }
            Console.WriteLine(" |");
            Console.WriteLine("|====================--====================|");
            return iResult;
        }

        public static int TargetMenu(int res = -1)
        {
            int iResult = 0;
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
                iResult = Utils.GetInt();
            }
            else
            {
                iResult = res;
            }
            Console.WriteLine("               |");
            Console.WriteLine("|====================--====================|");
            return iResult;
        }

        public static int RepairMenu(IPILOT pPilot, int res)
        {
            int iResult;
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|                Kits  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            List<int> vRepairKitsReserve = pPilot.GetRepairKitsReserve();
            int iLightArmor = vRepairKitsReserve[0];
            Console.Write("| " + (int)REPAIRS_MENU.Light_Armor + "-Light armor: x" + iLightArmor);
            if (iLightArmor < 10)
            {
                Console.Write(" ");
            }
            int iHeavyKits = vRepairKitsReserve[1];
            Console.Write(" || " + (int)REPAIRS_MENU.Heavy_Armor + "-Heavy armor: x" + iHeavyKits);
            if (iHeavyKits < 10)
            {
                Console.Write(" ");
            }
            Console.WriteLine(" |");
            Console.WriteLine("|      Armor: 1      ||      Armor: 3      |");
            Console.WriteLine("|===================-<>-===================|");
            int iRepairKits = vRepairKitsReserve[2];
            Console.Write("| " + (int)REPAIRS_MENU.Repair_Kits + "-Repair kits: x" + iRepairKits);
            if (iRepairKits < 10)
            {
                Console.Write(" ");
            }
            int iFullKits = vRepairKitsReserve[3];
            Console.Write(" ||  " + (int)REPAIRS_MENU.Full_Kits + "-Full kits: x" + iFullKits);
            if (iFullKits < 10)
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
                iResult = Utils.GetInt();
            }
            else
            {
                iResult = res;
            }
            Console.WriteLine("                 |");
            Console.WriteLine("|====================--====================|");
            return iResult;
        }

        public static int FuelMenu(IPILOT pPilot, int res = -1)
        {
            int iResult;
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|                Fuel  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            List<int> vFuelsReserve = pPilot.GetFuelsReserve();
            int iWood = vFuelsReserve[0];
            Console.Write("|     " + (int)FUEL_MENU.Wood + "-Wood: x" + iWood);
            if (iWood < 10)
            {
                Console.Write(" ");
            }
            int iCharcoal = vFuelsReserve[1];
            Console.Write("    ||   " + (int)FUEL_MENU.Charcoal + "-Charcoal: x" + iCharcoal);
            if (iCharcoal < 10)
            {
                Console.Write(" ");
            }
            Console.WriteLine("  |");
            Console.WriteLine("|     Energy: " + ENERGY_WOOD + "     ||     Energy: " + ENERGY_CHARCOAL + "     |");
            Console.WriteLine("|===================-<>-===================|");
            int iCoal = vFuelsReserve[2];
            Console.Write("|     " + (int)FUEL_MENU.Coal + "-Coal: x" + iCoal);
            if (iCoal < 10)
            {
                Console.Write(" ");
            }
            int iCompactCoal = vFuelsReserve[3];
            Console.Write("    || " + (int)FUEL_MENU.Compact_Coal + "-Compact Coal: x" + iCompactCoal);
            if (iCompactCoal < 10)
            {
                Console.Write(" ");
            }
            Console.WriteLine("|");
            Console.WriteLine("|     Energy: " + ENERGY_COAL + "     ||     Energy: " + ENERGY_COMPACT_COAL + "     |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|                    ||       " + (int)FUEL_MENU.Back + "-Back       |");
            Console.WriteLine("|===================-<>-===================|");
            Console.Write("| Select your fuel type : ");
            if (res == -1)
            {
                iResult = Utils.GetInt();
            }
            else
            {
                iResult = res;
            }
            Console.WriteLine("                |");
            Console.WriteLine("|====================--====================|");
            return iResult;
        }

        public static int WeaponMenu(IROBOT pPlayer, int res = -1)
        {
            int iResult;
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|              Weapon  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            Console.Write("| " + (int)WEAPON_MENU.Left_Weapon + "-Left Weapon type: ");
            switch (pPlayer.GetLeftWeaponType())
            {
                case 1:
                    {
                        Console.WriteLine("Normal               |");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Melee                |");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Projectile           |");
                        int iAmmo = pPlayer.GetLeftWeaponSpecificity();
                        Console.Write("| Remaining ammo: x" + iAmmo);
                        if (iAmmo < 10)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine("                      |");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Thermal              |");
                        int iFuel = pPlayer.GetLeftWeaponSpecificity();
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
            Console.WriteLine("| Damage: " + pPlayer.GetLeftWeaponDamage() + "                                |");
            int iLeftAccuracy = pPlayer.GetLeftWeaponHitChance();
            Console.Write("| Accuracy: " + iLeftAccuracy + "%");
            if (iLeftAccuracy < 100)
            {
                Console.Write(" ");
            }
            Console.WriteLine("                           |");
            Console.WriteLine("| Fuel Consumption: " + pPlayer.GetLeftWeaponPowerConsumption() + "                     |");
            Console.WriteLine("|===================-<>-===================|");
            Console.Write("| " + (int)WEAPON_MENU.Right_Weapon + "-Right Weapon type: ");
            switch (pPlayer.GetRightWeaponType())
            {
                case 1:
                    {
                        Console.WriteLine("Normal              |");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Melee               |");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Projectile          |");
                        int iAmmo = pPlayer.GetRightWeaponSpecificity();
                        Console.Write("| Remaining ammo: x" + iAmmo);
                        if (iAmmo < 10)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine("                      |");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Thermal             |");
                        int iFuel = pPlayer.GetRightWeaponSpecificity();
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
                        Console.WriteLine("Undefined           |");
                        break;
                    }
            }
            Console.WriteLine("|>- - - - - - - - - -<>- - - - - - - - - -<|");
            Console.WriteLine("| Damage: " + pPlayer.GetRightWeaponDamage() + "                                |");
            int iRightAccuracy = pPlayer.GetRightWeaponHitChance();
            Console.Write("| Accuracy: " + iRightAccuracy + "%");
            if (iRightAccuracy < 100)
            {
                Console.Write(" ");
            }
            Console.WriteLine("                           |");
            Console.WriteLine("| Fuel Consumption: " + pPlayer.GetRightWeaponPowerConsumption() + "                     |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|                    ||       " + (int)WEAPON_MENU.Back + "-Back       |");
            Console.WriteLine("|===================-<>-===================|");
            Console.Write("| Select your weapon : ");
            if (res == -1)
            {
                iResult = Utils.GetInt();
            }
            else
            {
                iResult = res;
            }
            Console.WriteLine("                   |");
            Console.WriteLine("|====================--====================|");
            return iResult;
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
    }
}