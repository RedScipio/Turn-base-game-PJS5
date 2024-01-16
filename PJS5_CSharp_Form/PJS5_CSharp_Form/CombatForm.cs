using PJS5_CSharp.Sources.Battle;
using PJS5_CSharp.Sources.Pilot.Bot;
using PJS5_CSharp.Sources.Pilot.Player;
using PJS5_CSharp.Sources.Robot;
using PJS5_CSharp.Sources.Weapon.MeleeWeapon;
using PJS5_CSharp.Sources.Weapon.NormalWeapon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PJS5_CSharp_Form
{
    public partial class CombatForm : Form
    {

        public CombatForm()
        {
            InitializeComponent();
            NORMAL_WEAPON pBasicNormalWeaponPlayer = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 1, 1, 15, 80, 40);
            MELEE_WEAPON pBasicMeleeWeaponPlayer = new MELEE_WEAPON(1, "Basic Melee Weapon", 3, 1, 2, 10, 100, 0);
            FURNACE pBasicFurnacePlayer = new FURNACE(1, "Basic Furnace", 3, 1, 80);
            LEGS pBasicLegsPlayer = new LEGS(1, "Basic Legs", 3, 2);

            NORMAL_WEAPON pBasicNormalWeaponBot = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 1, 1, 15, 80, 40);
            MELEE_WEAPON pBasicMeleeWeaponBot = new MELEE_WEAPON(1, "Basic Melee Weapon", 3, 1, 2, 10, 100, 0);
            FURNACE pBasicFurnaceBot = new FURNACE(1, "Basic Furnace", 3, 1, 80);
            LEGS pBasicLegsBot = new LEGS(1, "Basic Legs", 3, 2);

            Robot pPlayer = new Robot(pBasicFurnacePlayer, pBasicLegsPlayer, pBasicNormalWeaponPlayer, pBasicMeleeWeaponPlayer);
            Robot pBot = new Robot(pBasicFurnaceBot, pBasicLegsBot, pBasicNormalWeaponBot, pBasicMeleeWeaponBot);
            PILOT.IPILOT pPlayerPilot = new PLAYER_PILOT(pPlayer, new List<int> { 10, 5, 2, 1 }, new List<int> { 3, 2, 3, 1 });
            PILOT.IPILOT pBotPilot = new BOT_PILOT(pBot, new List<int> { 10, 5, 2, 1 }, new List<int> { 3, 2, 3, 1 });
            Battle pBattle = new Battle(pPlayerPilot, pBotPilot);
            pBattle.BattleWithConsoleGui();
        }

        public static void ShowStatus(Robot pPlayer, Robot pBot)
        {
            Console.WriteLine("|====================--====================|");
            Console.WriteLine("|                  Robots                  |");
            Console.WriteLine("|===================-<>-===================|");
            Console.WriteLine("|>-     Player     -<||>-     Ennemi     -<|");
            Console.WriteLine("|===================-<>-===================|");
            guiPlayerFurnaceArmor.Value = 100;
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
    }
}
