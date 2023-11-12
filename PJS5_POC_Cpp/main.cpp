#include <iostream>
#include "Sources/Gui/Gui.h"
#include "Sources/Battle/Battle.h"
#include "Sources/Pilot/IPilot.h"
#include "Sources/Pilot/Player/PlayerPilot.h"
#include "Sources/Pilot/Bot/BotPilot.h"
#include "Sources/Robot/Robot.h"
#include "Sources/Weapon/NormalWeapon/NormalWeapon.h"
#include "Sources/Weapon/MeleeWeapon/MeleeWeapon.h"

int main()
{
    ROBOT::FURNACE basicFurnace(1, "Basic Furnace", 3, 1, 80);
    ROBOT::LEGS basicLegs(1, "Basic Legs", 3, 2);
    WEAPON::NORMAL_WEAPON basicNormalWeapon(1, "Basic Normal Weapon", 3, 1, 1, 15, 80, 40);
    WEAPON::MELEE_WEAPON basicMeleeWeapon(1, "Basic Melee Weapon", 3, 1, 2, 10, 100, 0);

    ROBOT::ROBOT* pPlayer = new ROBOT::ROBOT(basicFurnace, basicLegs, basicNormalWeapon, basicMeleeWeapon);
    ROBOT::ROBOT* pBot = new ROBOT::ROBOT(basicFurnace, basicLegs, basicNormalWeapon, basicMeleeWeapon);

    PILOT::IPILOT* pPlayerPilot = new PILOT::PLAYER_PILOT(pPlayer, { 10, 5, 2, 1 }, { 3, 2, 3, 1 });
    PILOT::IPILOT* pBotPilot = new PILOT::BOT_PILOT(pBot, { 10, 5, 2, 1 }, { 3, 2, 3, 1 });

    BATTLE* pBattle = new BATTLE(pPlayerPilot, pBotPilot);

    pBattle->BattleWithConsoleGui();

    delete pPlayerPilot;
    delete pBotPilot;
    delete pPlayer;
    delete pBot;
}