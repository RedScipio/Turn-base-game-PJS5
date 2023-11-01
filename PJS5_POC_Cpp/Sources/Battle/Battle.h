#pragma once
#include "..\Pilot\IPilot.h"
#include "..\Pilot\Player\PlayerPilot.h"
#include "..\Pilot\Bot\BotPilot.h"

class BATTLE
{
public:
	BATTLE(const PILOT::PLAYER_PILOT& player, const PILOT::BOT_PILOT& bot);
	~BATTLE();

	void BattleWithConsoleGui();

	bool BattleIsOver() { return  _tPilot[0]->RobotIsDestroy() || _tPilot[1]->RobotIsDestroy(); }

	PILOT::IPILOT* GetPlayerPilot() { return  _tPilot[0]; }
	PILOT::IPILOT* GetBotPilot() { return  _tPilot[1]; }

private:
	PILOT::IPILOT* _tPilot[2] ;

	int _iNumberOfTurns = 0;
};