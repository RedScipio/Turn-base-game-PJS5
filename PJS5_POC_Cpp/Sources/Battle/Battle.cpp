#include "Battle.h"
#include "../Gui/Gui.h"

BATTLE::BATTLE(PILOT::IPILOT* pPlayer, PILOT::IPILOT* pBot)
	: _tPilot{ pPlayer, pBot }
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
		for (int iPilot = 0; iPilot < 2; iPilot++)
		{
			GUI::ShowStatus(_tPilot[0]->GetRobot(), _tPilot[1]->GetRobot());
			_tPilot[iPilot]->PlayTurn(_tPilot[1 - iPilot]->GetRobot());

			if (_tPilot[1 - iPilot]->RobotIsDestroy())
			{
				// _tPilot[iPilot] Win
			}
		}
	}
}