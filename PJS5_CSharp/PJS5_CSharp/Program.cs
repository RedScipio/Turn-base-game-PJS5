using PJS5_CSharp.Sources.Battle;
using PJS5_CSharp.Sources.Pilot.Bot;
using PJS5_CSharp.Sources.Pilot.Player;
using PJS5_CSharp.Sources.Robot;
using PJS5_CSharp.Sources.Weapon.MeleeWeapon;
using PJS5_CSharp.Sources.Weapon.NormalWeapon;
using System;
using System.Collections.Generic;

namespace PJS5_CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
    }
}
