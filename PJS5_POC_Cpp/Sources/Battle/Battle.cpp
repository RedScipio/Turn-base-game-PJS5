#include "Battle.h"

BATTLE::BATTLE(const PILOT::PLAYER_PILOT& player, const PILOT::BOT_PILOT& bot)
	: _tPilot{ new PILOT::PLAYER_PILOT(player), new PILOT::BOT_PILOT(bot) }
{
}

BATTLE::~BATTLE()
{
	for (auto pPilot : _tPilot)
	{
		delete pPilot;
	}
}

void BATTLE::BattleWithConsoleGui()
{
	while (!BattleIsOver())
	{
		for (int iPilot = 0; iPilot < sizeof(_tPilot); iPilot++)
		{
			_tPilot[iPilot]->PlayTurn(_tPilot[1 - iPilot]->GetRobot());

			if (_tPilot[1 - iPilot]->RobotIsDestroy())
			{
				// _tPilot[iPilot] Win
			}
		}
	}
}