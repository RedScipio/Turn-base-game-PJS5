using PJS5_CSharp.Sources;
using PJS5_CSharp.Sources.Pilot;
using PJS5_CSharp.Sources.Robot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public static class Gui
    {


 

        public static int MainMenu()
        {
            int iResult;
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|                Main  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|  1-Attack  ||  2-Repairs  ||  3-Furnace  |");
            Console.WriteLine("|===================-<>-===================|");
            Console.Write("| Tap the number of the desired action : ");
            iResult = Utils.GetInt();
            Console.WriteLine(" |");
            Console.WriteLine("|====================--====================|");
            return iResult;
        }

        public static int TargetMenu()
        {
            int iResult;
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|              Target  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|    1-Left Weapon   ||   2-Right Weapon   |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|       3-Legs       ||     4-Furnace      |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|                    ||       0-Back       |");
            Console.WriteLine("|===================-<>-===================|");
            Console.Write("| Select the target part : ");
            iResult = Utils.GetInt();
            Console.WriteLine("               |");
            Console.WriteLine("|====================--====================|");
            return iResult;
        }

        public static int RepairMenu(PILOT.IPILOT pPilot)
        {
            int iResult;
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|                Kits  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            List<int> vRepairKitsReserve = pPilot.GetRepairKitsReserve();
            int iLightArmor = vRepairKitsReserve[0];
            Console.Write("| 1-Light armor: x" + iLightArmor);
            if (iLightArmor < 10)
            {
                Console.Write(" ");
            }
            int iHeavyKits = vRepairKitsReserve[1];
            Console.Write(" || 2-Heavy armor: x" + iHeavyKits);
            if (iHeavyKits < 10)
            {
                Console.Write(" ");
            }
            Console.WriteLine(" |");
            Console.WriteLine("|      Armor: 1      ||      Armor: 3      |");
            Console.WriteLine("|===================-<>-===================|");
            int iRepairKits = vRepairKitsReserve[2];
            Console.Write("| 3-Repair kits: x" + iRepairKits);
            if (iRepairKits < 10)
            {
                Console.Write(" ");
            }
            int iFullKits = vRepairKitsReserve[3];
            Console.Write(" ||  4-Full kits: x" + iFullKits);
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
            iResult = Utils.GetInt();
            Console.WriteLine("                 |");
            Console.WriteLine("|====================--====================|");
            return iResult;
        }

        public static int FuelMenu(PILOT.IPILOT pPilot)
        {
            int iResult;
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|                Fuel  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            List<int> vFuelsReserve = pPilot.GetFuelsReserve();
            int iWood = vFuelsReserve[0];
            Console.Write("|     1-Wood: x" + iWood);
            if (iWood < 10)
            {
                Console.Write(" ");
            }
            int iCharcoal = vFuelsReserve[1];
            Console.Write("    ||   2-Charcoal: x" + iCharcoal);
            if (iCharcoal < 10)
            {
                Console.Write(" ");
            }
            Console.WriteLine("  |");
            Console.WriteLine("|     Energy: 15     ||     Energy: 20     |");
            Console.WriteLine("|===================-<>-===================|");
            int iCoal = vFuelsReserve[2];
            Console.Write("|     3-Coal: x" + iCoal);
            if (iCoal < 10)
            {
                Console.Write(" ");
            }
            int iCompactCoal = vFuelsReserve[3];
            Console.Write("    || 4-Compact Coal: x" + iCompactCoal);
            if (iCompactCoal < 10)
            {
                Console.Write(" ");
            }
            Console.WriteLine("|");
            Console.WriteLine("|     Energy: 25     ||     Energy: 35     |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|                    ||       0-Back       |");
            Console.WriteLine("|===================-<>-===================|");
            Console.Write("| Select your fuel type : ");
            iResult = Utils.GetInt();
            Console.WriteLine("                |");
            Console.WriteLine("|====================--====================|");
            return iResult;
        }

        public static int WeaponMenu(Robot pPlayer)
        {
            int iResult;
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|              Weapon  Menu                |");
            Console.WriteLine("|===================-<>-===================|");
            Console.Write("| 1-Left Weapon type: ");
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
            Console.Write("| 2-Right Weapon type: ");
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
            Console.WriteLine("|                    ||       0-Back       |");
            Console.WriteLine("|===================-<>-===================|");
            Console.Write("| Select your weapon : ");
            iResult = Utils.GetInt();
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
            Console.WriteLine("|            It's a missed fire            |");
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
