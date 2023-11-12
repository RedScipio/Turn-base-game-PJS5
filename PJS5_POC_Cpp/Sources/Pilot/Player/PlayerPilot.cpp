#include "PlayerPilot.h"
#include "..\..\Gui\Gui.h"
#include <stdlib.h>

namespace PILOT
{
	PLAYER_PILOT::PLAYER_PILOT(ROBOT::ROBOT* pRobot, std::vector<int> vFuelsReserve, std::vector<int> vRepairKitsReserve)
		: IPILOT(pRobot, vFuelsReserve, vRepairKitsReserve)
	{
	}

	PLAYER_PILOT::~PLAYER_PILOT()
	{
		delete _pRobot;
	}

	void PLAYER_PILOT::PlayTurn(ROBOT::ROBOT* pEnnemiRobot)
	{
		MainMenu(pEnnemiRobot);
	}

	void PLAYER_PILOT::MainMenu(ROBOT::ROBOT* pEnnemiRobot, int iChoice)
	{
		if (iChoice == -1)
		{
			iChoice = GUI::MainMenu();
		}

		switch (iChoice)
		{
		case 1:
		{
			AttackMenu(pEnnemiRobot);
			return;
		}
		case 2:
		{
			RepairsMenu(pEnnemiRobot);
			return;
		}
		case 3:
		{
			FurnaceMenu(pEnnemiRobot);
			return;
		}
		default:
		{
			MainMenu(pEnnemiRobot);
			return;
		}
		}

	}

	void PLAYER_PILOT::AttackMenu(ROBOT::ROBOT* pEnnemiRobot, int iChoice)
	{
		if (iChoice == -1)
		{
			iChoice = GUI::WeaponMenu(this->GetRobot());
		}

		if (_pRobot->NeedToRestart())
		{
			GUI::RobotRestart();
			MainMenu(pEnnemiRobot);
			return;
		}

		switch (iChoice)
		{
		case 0:
		{
			MainMenu(pEnnemiRobot);
			return;
		}
		case 1:
		{
			if (_pRobot->WeaponIsUsable(iChoice))
			{
				const int iTargetChoice = GUI::TargetMenu();

				if (pEnnemiRobot->AttackTargetIsValid(iTargetChoice))
				{
					int iRandomizer = std::rand() % 100 + 1;

					_pRobot->WeaponFired(iChoice);
					if (_pRobot->GetLeftWeaponHitChance() < iRandomizer)
					{
						GUI::MissedFire();
						return;
					}
					else
					{
						_pRobot->DealDamage(pEnnemiRobot, iChoice, iTargetChoice);
						return;
					}
				}
				else
				{
					GUI::AlreadyDestroy();
					AttackMenu(pEnnemiRobot);
					return;
				}
			}
			else
			{
				GUI::WeaponIsUnusable();
				AttackMenu(pEnnemiRobot);
				return;
			}
		}
		case 2:
		{
			if (_pRobot->WeaponIsUsable(iChoice))
			{
				const int iTargetChoice = GUI::TargetMenu();

				if (pEnnemiRobot->AttackTargetIsValid(iTargetChoice))
				{
					int iRandomizer = std::rand() % 100 + 1;

					_pRobot->WeaponFired(iChoice);
					if (_pRobot->GetRightWeaponHitChance() < iRandomizer)
					{
						GUI::MissedFire();
						return;
					}
					else
					{
						_pRobot->DealDamage(pEnnemiRobot, iChoice, iTargetChoice);
						return;
					}
				}
				else
				{
					GUI::AlreadyDestroy();
					AttackMenu(pEnnemiRobot);
					return;
				}
			}
			else
			{
				GUI::WeaponIsUnusable();
				AttackMenu(pEnnemiRobot);
				return;
			}
		}
		default:
		{
			GUI::WrongEntry();
			AttackMenu(pEnnemiRobot);
			return;
		}
		}
	}

	void PLAYER_PILOT::RepairsMenu(ROBOT::ROBOT* pEnnemiRobot, int iChoice)
	{
		if (iChoice == -1)
		{
			iChoice = GUI::RepairMenu(this);
		}

		switch (iChoice)
		{
		case 0:
		{
			MainMenu(pEnnemiRobot);
			return;
		}
		case 1:
		{
			if (_vRepairKitsReserve.at(iChoice - 1) > 0)
			{
				const int iTargetChoice = GUI::TargetMenu();

				if (_pRobot->RepairArmorTargetIsValid(iTargetChoice))
				{
					_pRobot->RepairRobotArmor(1, iTargetChoice);
					return;
				}
				else
				{
					GUI::PerfectlyFine();
					RepairsMenu(pEnnemiRobot);
					return;
				}
			}
			else
			{
				GUI::NoStockKit();
				RepairsMenu(pEnnemiRobot);
				return;
			}
		}
		case 2:
		{
			if (_vRepairKitsReserve.at(iChoice - 1) > 0)
			{
				const int iTargetChoice = GUI::TargetMenu();

				if (_pRobot->RepairArmorTargetIsValid(iTargetChoice))
				{
					_pRobot->RepairRobotArmor(3, iTargetChoice);
					return;
				}
				else
				{
					GUI::PerfectlyFine();
					RepairsMenu(pEnnemiRobot);
					return;
				}
			}
			else
			{
				GUI::NoStockKit();
				RepairsMenu(pEnnemiRobot);
				return;
			}
		}
		case 3:
		{
			if (_vRepairKitsReserve.at(iChoice - 1) > 0)
			{
				const int iTargetChoice = GUI::TargetMenu();

				if (_pRobot->RepairLifeTargetIsValid(iTargetChoice))
				{
					_pRobot->RepairRobotLifePoint(1, iTargetChoice);
					return;
				}
				else
				{
					GUI::PerfectlyFine();
					RepairsMenu(pEnnemiRobot);
					return;
				}
			}
			else
			{
				GUI::NoStockKit();
				RepairsMenu(pEnnemiRobot);
				return;
			}
		}
		case 4:
		{
			if (_vRepairKitsReserve.at(iChoice - 1) > 0)
			{
				const int iTargetChoice = GUI::TargetMenu();

				if (_pRobot->RepairLifeTargetIsValid(iTargetChoice))
				{
					_pRobot->RepairRobotLifePoint(3, iTargetChoice);
					return;
				}
				else
				{
					GUI::PerfectlyFine();
					RepairsMenu(pEnnemiRobot);
					return;
				}
			}
			else
			{
				GUI::NoStockKit();
				RepairsMenu(pEnnemiRobot);
				return;
			}
		}
		default:
		{
			GUI::WrongEntry();
			RepairsMenu(pEnnemiRobot);
			return;
		}
		}
	}

	void PLAYER_PILOT::FurnaceMenu(ROBOT::ROBOT* pEnnemiRobot, int iChoice)
	{
		if (iChoice == -1)
		{
			iChoice = GUI::FuelMenu(this);
		}

		switch (iChoice)
		{
		case 0:
		{
			MainMenu(pEnnemiRobot);
			return;
		}
		case 1:
		{
			const int iStock = _vFuelsReserve.at(iChoice - 1);

			if (iStock > 0)
			{
				_pRobot->Refuel(15);
				_vFuelsReserve.at(iChoice - 1) = iStock - 1;
				return;
			}
			else
			{
				GUI::NoStockFuel();
				FurnaceMenu(pEnnemiRobot);
				return;
			}
		}
		case 2:
		{
			const int iStock = _vFuelsReserve.at(iChoice - 1);

			if (_vFuelsReserve.at(iChoice - 1) > 0)
			{
				_pRobot->Refuel(20);
				_vFuelsReserve.at(iChoice - 1) = iStock - 1;
				return;
			}
			else
			{
				GUI::NoStockFuel();
				FurnaceMenu(pEnnemiRobot);
				return;
			}
		}
		case 3:
		{
			const int iStock = _vFuelsReserve.at(iChoice - 1);

			if (_vFuelsReserve.at(iChoice - 1) > 0)
			{
				_pRobot->Refuel(25);
				_vFuelsReserve.at(iChoice - 1) = iStock - 1;
				return;
			}
			else
			{
				GUI::NoStockFuel();
				FurnaceMenu(pEnnemiRobot);
				return;
			}
		}
		case 4:
		{
			const int iStock = _vFuelsReserve.at(iChoice - 1);

			if (_vFuelsReserve.at(iChoice - 1) > 0)
			{
				_pRobot->Refuel(35);
				_vFuelsReserve.at(iChoice - 1) = iStock - 1;
				return;
			}
			else
			{
				GUI::NoStockFuel();
				FurnaceMenu(pEnnemiRobot);
				return;
			}
		}
		default:
		{
			GUI::WrongEntry();
			FurnaceMenu(pEnnemiRobot);
			return;
		}
		}
	}
}