
using System;
//using Umshini;
using System.Collections.Generic;

namespace Battle
{    
    public enum MAIN_MENU
    {
        Error = -1,
        Attack,
        Repairs,
        Furnace,
    }

    public enum TARGET_MENU
    {
        Error = -1,
        Left_Weapon,
        Right_Weapon,
        Legs,
        Furnace,
        Back // Back is also used as count value
    }

    public enum REPAIRS_MENU
    {
        Error = -1,
        Light_Armor,
        Heavy_Armor,
        Repair_Kits,
        Full_Kits,
        Back // Back is also used as count value
    }

    public enum WEAPON_MENU
    {
        Error = -1,
        Left_Weapon,
        Right_Weapon,
        Back // Back is also used as count value
    }

    public enum FUEL_MENU
    {
        Error = -1,
        Wood,
        Charcoal,
        Coal,
        Compact_Coal,
        Back // Back is also used as count value
    }

    public enum FUEL_TYPE
    {
        Wood,
        Charcoal,
        Coal,
        Compact_Coal,
    }

    public enum REPAIRS_TYPE
    {
        Light_Armor,
        Heavy_Armor,
        Repair_Kits,
        Full_Kits,
    }

    public static class GUI
    {

        public static void ShowStatus(IPILOT pPlayer, IPILOT pBot)
        {
            //Console.Clear();
            IROBOT playerRobot = pPlayer.GetRobot();

            IROBOT botRobot = pBot.GetRobot();

            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|                  Robots                  |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|>-     Player     -<||>-      Enemy     -<|");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("| Furnace armor: " + playerRobot.GetFurnaceArmor() + "/" + playerRobot.GetFurnaceMaxArmor() + " || Furnace armor: " + botRobot.GetFurnaceArmor() + "/" + botRobot.GetFurnaceMaxArmor() + " |");
            Console.WriteLine("| Furnace life: " + playerRobot.GetFurnaceLife() + "/" + playerRobot.GetFurnaceMaxLife() + "  || Furnace life: " + botRobot.GetFurnaceLife() + "/" + botRobot.GetFurnaceMaxLife() + "  |");
            Console.WriteLine("|>- - - - - - - - - -<>- - - - - - - - - -<|");
            Console.WriteLine("| Legs armor: " + playerRobot.GetLegsArmor() + "/" + playerRobot.GetLegsMaxArmor() + "    || Legs armor: " + botRobot.GetLegsArmor() + "/" + botRobot.GetLegsMaxArmor() + "    |");
            Console.WriteLine("| Legs remains: " + playerRobot.GetLegsLife() + "/" + playerRobot.GetLegsMaxLife() + "  || Legs remains: " + botRobot.GetLegsLife() + "/" + botRobot.GetLegsMaxLife() + "  |");
            Console.WriteLine("|>- - - - - - - - - -<>- - - - - - - - - -<|");
            Console.WriteLine("| WeaponL armor: " + playerRobot.GetLeftWeaponArmor() + "/" + playerRobot.GetLeftWeaponMaxArmor() + " || WeaponL armor: " + botRobot.GetLeftWeaponArmor() + "/" + botRobot.GetLeftWeaponMaxArmor() + " |");
            Console.WriteLine("| WeaponL life: " + playerRobot.GetLeftWeaponLife() + "/" + playerRobot.GetLeftWeaponMaxLife() + "  || WeaponL life: " + botRobot.GetLeftWeaponLife() + "/" + botRobot.GetLeftWeaponMaxLife() + "  |");
            Console.WriteLine("|>- - - - - - - - - -<>- - - - - - - - - -<|");
            Console.WriteLine("| WeaponR armor: " + playerRobot.GetRightWeaponArmor() + "/" + playerRobot.GetRightWeaponMaxArmor() + " || WeaponR armor: " + botRobot.GetRightWeaponArmor() + "/" + botRobot.GetRightWeaponMaxArmor() + " |");
            Console.WriteLine("| WeaponR life: " + playerRobot.GetRightWeaponLife() + "/" + playerRobot.GetRightWeaponMaxLife() + "  || WeaponR life: " + botRobot.GetRightWeaponLife() + "/" + botRobot.GetRightWeaponMaxLife() + "  |");
            Console.WriteLine("|===================-<>-===================|");
            int iPlayerFuel = playerRobot.GetFuel();
            Console.Write("|    Fuel: " + iPlayerFuel + "/100");
            if (iPlayerFuel < 100)
            {
                Console.Write(" ");
            }
            int iBotFuel = botRobot.GetFuel();
            Console.Write("   ||    Fuel: " + iBotFuel + "/100");
            if (iBotFuel < 100)
            {
                Console.Write(" ");
            }
            Console.WriteLine("   |");
            Console.WriteLine("|====================--====================|");
        }

        public static MAIN_MENU MainMenu(int resultat = -1)
        {
            //Console.Clear();

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
            else
            {
                iResult = resultat;
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
            //Console.Clear();

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
            //Console.Clear();

            int iResult;
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|                Kits  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            List<ICONSUMABLES> vRepairKitsReserve = pPilot.GetRepairKitsReserve();
            ICONSUMABLES iLightArmor = vRepairKitsReserve[0];
            Console.Write("| " + (int)REPAIRS_MENU.Light_Armor + "-Light armor: x" + iLightArmor.GetNumberItems());
            if (iLightArmor.GetValue() < 10)
            {
                Console.Write(" ");
            }
            ICONSUMABLES iHeavyKits = vRepairKitsReserve[1];
            Console.Write(" || " + (int)REPAIRS_MENU.Heavy_Armor + "-Heavy armor: x" + iHeavyKits.GetNumberItems());
            if (iHeavyKits.GetValue() < 10)
            {
                Console.Write(" ");
            }
            Console.WriteLine(" |");
            Console.WriteLine("|      Armor: 1      ||      Armor: 3      |");
            Console.WriteLine("|===================-<>-===================|");
            ICONSUMABLES iRepairKits = vRepairKitsReserve[2];
            Console.Write("| " + (int)REPAIRS_MENU.Repair_Kits + "-Repair kits: x" + iRepairKits.GetNumberItems());
            if (iRepairKits.GetValue() < 10)
            {
                Console.Write(" ");
            }
            ICONSUMABLES iFullKits = vRepairKitsReserve[3];
            Console.Write(" ||  " + (int)REPAIRS_MENU.Full_Kits + "-Full kits: x" + iFullKits.GetNumberItems());
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
                case (int)REPAIRS_MENU.Light_Armor:
                    return REPAIRS_MENU.Light_Armor;
                case (int)REPAIRS_MENU.Heavy_Armor:
                    return REPAIRS_MENU.Heavy_Armor;
                case (int) REPAIRS_MENU.Full_Kits:
                    return REPAIRS_MENU.Full_Kits;
                case (int) REPAIRS_MENU.Repair_Kits:
                    return REPAIRS_MENU.Repair_Kits;
                case (int) REPAIRS_MENU.Back:
                    return REPAIRS_MENU.Back;
                default:
                    return REPAIRS_MENU.Error;
            }
        }

        public static FUEL_MENU FuelMenu(IPILOT pPilot, int res = -1)
        {
            //Console.Clear();

            int iResult;
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|                Fuel  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            List<ICONSUMABLES> vFuelsReserve = pPilot.GetFuelsReserve();
            ICONSUMABLES Wood = vFuelsReserve[0];
            Console.Write("|     " + (int)FUEL_MENU.Wood + "-"+ Wood.GetName() + ": x" + Wood.GetNumberItems());
            if (Wood.GetValue() < 10)
            {
                Console.Write(" ");
            }
            ICONSUMABLES Charcoal = vFuelsReserve[1];
            Console.Write("    ||  " + (int)FUEL_MENU.Charcoal +  " -"+ Charcoal.GetName() + ": x" + Charcoal.GetNumberItems());
            if (Charcoal.GetValue() < 10) // adapt to two digits
            {
                Console.Write(" ");
            }
            Console.WriteLine("  |");
            Console.WriteLine("|     Energy: " + (int)ENERGY.ENERGY_WOOD + "     ||     Energy: " + (int)ENERGY.ENERGY_CHARCOAL + "     |");
            Console.WriteLine("|===================-<>-===================|");
            ICONSUMABLES Coal = vFuelsReserve[2];
            Console.Write("|     " + (int)FUEL_MENU.Coal + "-"+ Coal.GetName() + ": x" + Coal.GetNumberItems());
            if (Coal.GetValue() < 10)
            {
                Console.Write(" ");
            }
            ICONSUMABLES CompactCoal = vFuelsReserve[3];
            Console.Write("    || " + (int)FUEL_MENU.Compact_Coal + "-"+ CompactCoal.GetName() + ": x" + CompactCoal.GetNumberItems());
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
                case (int)FUEL_MENU.Compact_Coal:
                    return FUEL_MENU.Compact_Coal;
                default:
                    return FUEL_MENU.Error;
            }
        }

        public static WEAPON_MENU WeaponMenu(IPILOT pPlayer, int res = -1)
        {
            //Console.Clear();

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
            //Console.Clear();

            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|      The robot need fuel to restart      |");
            Console.WriteLine("|--------------------==--------------------|");
        }

        public static void WeaponIsUnusable()
        {
            //Console.Clear();

            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|         This weapon  is unusable         |");
            Console.WriteLine("|--------------------==--------------------|");
        }

        public static void AlreadyDestroy()
        {
            //Console.Clear();

            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|       This part is already destroy       |");
            Console.WriteLine("|--------------------==--------------------|");
        }

        public static void MissedFire()
        {
            //Console.Clear();

            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|            It'  missed fire            |");
            Console.WriteLine("|--------------------==--------------------|");
        }

        public static void NoStockKit()
        {
            //Console.Clear();

            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|    No more kits of this type in stock    |");
            Console.WriteLine("|--------------------==--------------------|");
        }

        public static void PerfectlyFine()
        {
            //Console.Clear();

            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|              Perfectly Fine              |");
            Console.WriteLine("|--------------------==--------------------|");
        }

        public static void NoStockFuel()
        {
            //Console.Clear();

            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|    No more fuel of this type in stock    |");
            Console.WriteLine("|--------------------==--------------------|");
        }

        public static void WrongEntry()
        {
            //Console.Clear();

            Console.WriteLine("!!!-----------------!==!-----------------!!!");
            Console.WriteLine("|               Wrong  Entry               |");
            Console.WriteLine("!!!-----------------!==!-----------------!!!");
        }

        internal static void GameOver()
        {
            //Console.Clear();

            Console.WriteLine("|--------------------==--------------------|");
            Console.WriteLine("|                 Game Over                |");
            Console.WriteLine("|--------------------==--------------------|");
            
            Console.ReadLine();
        }

        public static TARGET_TYPE ConvertTargetType(TARGET_MENU eChoicePart)
        {
            switch (eChoicePart)
            {
                case TARGET_MENU.Legs:
                    return TARGET_TYPE.LEG;
                case TARGET_MENU.Furnace:
                    return TARGET_TYPE.FURNACE;
                case TARGET_MENU.Left_Weapon:
                    return TARGET_TYPE.LEFT_WEAPON;
                case TARGET_MENU.Right_Weapon:
                    return TARGET_TYPE.RIGHT_WEAPON;
                default:
                    throw new NotImplementedException();
            }
        }

        public static FUEL_TYPE ConvertFuelType(FUEL_MENU eChoicePart)
        {
            switch (eChoicePart)
            {
                case FUEL_MENU.Coal:
                    return FUEL_TYPE.Coal;
                case FUEL_MENU.Charcoal:
                    return FUEL_TYPE.Charcoal;
                case FUEL_MENU.Wood:
                    return FUEL_TYPE.Wood;
                case FUEL_MENU.Compact_Coal:
                    return FUEL_TYPE.Compact_Coal;
                default:
                    throw new NotImplementedException();
            }
        }

        public static REPAIRS_TYPE ConvertRepairType(REPAIRS_MENU eChoicePart)
        {
            switch (eChoicePart)
            {
                case REPAIRS_MENU.Full_Kits:
                    return REPAIRS_TYPE.Full_Kits;
                case REPAIRS_MENU.Light_Armor:
                    return REPAIRS_TYPE.Light_Armor;
                case REPAIRS_MENU.Heavy_Armor:
                    return REPAIRS_TYPE.Heavy_Armor;
                case REPAIRS_MENU.Repair_Kits:
                    return REPAIRS_TYPE.Repair_Kits;
                default:
                    throw new NotImplementedException();
            }
        }

        public static void RepairImpossible()
        {
            Console.WriteLine("|---------------------==--------------------|");
            Console.WriteLine("|             Repair impossible             |");
            Console.WriteLine("|---------------------==--------------------|");
        }

        internal static void AlreadyFullOfFuel()
        {
            Console.WriteLine("|---------------------==-------------------|");
            Console.WriteLine("|    The robot est already full of fuel    |");
            Console.WriteLine("|---------------------==-------------------|");
        }
    }
}