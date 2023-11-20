using PJS5_CSharp.Sources.Battle;
using PJS5_CSharp.Sources.Pilot.Bot;
using PJS5_CSharp.Sources.Pilot.Player;
using PJS5_CSharp.Sources.Robot;
using PJS5_CSharp.Sources.Weapon.MeleeWeapon;
using PJS5_CSharp.Sources.Weapon.NormalWeapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJS5_CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FURNACE basicFurnace = new FURNACE(1, "Basic Furnace", 3, 1, 80);
            LEGS basicLegs = new LEGS(1, "Basic Legs", 3, 2);
            NORMAL_WEAPON basicNormalWeapon = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 1, 1, 15, 80, 40);
            MELEE_WEAPON basicMeleeWeapon = new MELEE_WEAPON(1, "Basic Melee Weapon", 3, 1, 2, 10, 100, 0);
            Robot pPlayer = new Robot(basicFurnace, basicLegs, basicNormalWeapon, basicMeleeWeapon);
            Robot pBot = new Robot(basicFurnace, basicLegs, basicNormalWeapon, basicMeleeWeapon);
            PILOT.IPILOT pPlayerPilot = new PLAYER_PILOT(pPlayer, new List<int> { 10, 5, 2, 1 }, new List<int> { 3, 2, 3, 1 });
            PILOT.IPILOT pBotPilot = new BOT_PILOT(pBot, new List<int> { 10, 5, 2, 1 }, new List<int> { 3, 2, 3, 1 });
            Battle pBattle = new Battle(pPlayerPilot, pBotPilot);
            pBattle.BattleWithConsoleGui();
        }
    }
}
