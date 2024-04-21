﻿
using System;
//using Umshini;
using System.Collections.Generic;

namespace Battle
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
                iResult = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine(" |");
            Console.WriteLine("|====================--====================|");
            return iResult;
        }

        public static int TargetMenu(int res = -1)
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
                iResult = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                iResult = res;
            }
            Console.WriteLine("               |");
            Console.WriteLine("|====================--====================|");
            return iResult;
        }

        public static int RepairMenu(IPILOT pPilot, int res = -1)
        {
            int iResult;
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|                Kits  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            List<ICONSUMABLE> vRepairKitsReserve = pPilot.GetRepairKitsReserve();
            ICONSUMABLE iLightArmor = vRepairKitsReserve[0];
            Console.Write("| " + (int)REPAIRS_MENU.Light_Armor + "-Light armor: x" + iLightArmor);
            if (iLightArmor.GetValue() < 10)
            {
                Console.Write(" ");
            }
            ICONSUMABLE iHeavyKits = vRepairKitsReserve[1];
            Console.Write(" || " + (int)REPAIRS_MENU.Heavy_Armor + "-Heavy armor: x" + iHeavyKits);
            if (iHeavyKits.GetValue() < 10)
            {
                Console.Write(" ");
            }
            Console.WriteLine(" |");
            Console.WriteLine("|      Armor: 1      ||      Armor: 3      |");
            Console.WriteLine("|===================-<>-===================|");
            ICONSUMABLE iRepairKits = vRepairKitsReserve[2];
            Console.Write("| " + (int)REPAIRS_MENU.Repair_Kits + "-Repair kits: x" + iRepairKits);
            if (iRepairKits.GetValue() < 10)
            {
                Console.Write(" ");
            }
            ICONSUMABLE iFullKits = vRepairKitsReserve[3];
            Console.Write(" ||  " + (int)REPAIRS_MENU.Full_Kits + "-Full kits: x" + iFullKits);
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
                iResult = Convert.ToInt32(Console.ReadLine());
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
            List<ICONSUMABLE> vFuelsReserve = pPilot.GetFuelsReserve();
            ICONSUMABLE Wood = vFuelsReserve[0];
            Console.Write("|     " + (int)FUEL_MENU.Wood + "-"+ Wood.GetName() + ": x" + Wood.GetValue());
            if (Wood.GetValue() < 10)
            {
                Console.Write(" ");
            }
            ICONSUMABLE Charcoal = vFuelsReserve[1];
            Console.Write("    ||  " + (int)FUEL_MENU.Charcoal +  " -"+ Charcoal.GetName() + ": x" + Charcoal.GetValue());
            if (Charcoal.GetValue() < 10) // adapt to two digits
            {
                Console.Write(" ");
            }
            Console.WriteLine("  |");
            Console.WriteLine("|     Energy: " + (int)ENERGY.ENERGY_WOOD + "     ||     Energy: " + (int)ENERGY.ENERGY_CHARCOAL + "     |");
            Console.WriteLine("|===================-<>-===================|");
            ICONSUMABLE Coal = vFuelsReserve[2];
            Console.Write("|     " + (int)FUEL_MENU.Coal + "-"+ Coal.GetName() + ": x" + Coal.GetValue());
            if (Coal.GetValue() < 10)
            {
                Console.Write(" ");
            }
            ICONSUMABLE CompactCoal = vFuelsReserve[3];
            Console.Write("    || " + (int)FUEL_MENU.Compact_Coal + "-"+ CompactCoal.GetName() + ": x" + CompactCoal.GetValue());
            if (CompactCoal.GetValue() < 10)
            {
                Console.Write(" ");
            }
            Console.WriteLine("|");
            Console.WriteLine("|     Energy: " + (int)ENERGY.ENERGY_COAL + "     ||     Energy: " + (int)ENERGY.ENERGY_COMPACT_COAL + "     |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|                    ||       " + (int)FUEL_MENU.Back + "-Back       |");
            Console.WriteLine("|===================-<>-===================|");
            Console.Write("| Select your fuel type : ");
            if (res == -1)
            {
                iResult = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                iResult = res;
            }
            Console.WriteLine("                |");
            Console.WriteLine("|====================--====================|");
            return iResult;
        }

        public static int WeaponMenu(IPILOT pPlayer, int res = -1)
        {
            int iResult;
            int iWeapon = 0;
            IROBOT playerRobot = pPlayer.GetRobot();
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|              Weapon  Menu                |");
            Console.WriteLine("|===================-<>-===================|");

            foreach(IWEAPON weapon in playerRobot.GetWeapons())
            {
                Console.Write("| " + (int)WEAPON_MENU.Left_Weapon + "-Left Weapon type: ");
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
                iResult = Convert.ToInt32(Console.ReadLine());
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