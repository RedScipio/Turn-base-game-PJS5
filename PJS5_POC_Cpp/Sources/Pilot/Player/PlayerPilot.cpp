#include "PlayerPilot.h"
#include "..\..\Gui\Gui.h"

namespace PILOT
{
	PLAYER_PILOT::PLAYER_PILOT(const ROBOT::ROBOT& robot)
		: IPILOT(robot)
	{
	}

	PLAYER_PILOT::~PLAYER_PILOT()
	{
		delete _pRobot;
	}

	void PLAYER_PILOT::PlayTurn(ROBOT::ROBOT* ennemiRobot)
	{
	}

	void PLAYER_PILOT::MainMenu(int iChoice)
	{
		if (iChoice == -1)
		{
			iChoice = GUI::MainMenu();
		}
		
		switch (iChoice)
		{
			case 1:
			{
				AttackMenu();
				break;
			}
			case 2:
			{
				RepairsMenu();
				break;
			}
			case 3:
			{
				FurnaceMenu();
				break;
			}
			default:
			{
				MainMenu();
				break;
			}
		}

	}
}