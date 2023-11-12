#pragma once

namespace PILOT
{
	class IPILOT;
}

namespace ROBOT
{
	class ROBOT;
}

namespace GUI
{
	void ShowStatus(ROBOT::ROBOT* pPlayer, ROBOT::ROBOT* pBot);

	int MainMenu();
	int WeaponMenu(ROBOT::ROBOT* pPlayer);
	int RepairMenu(PILOT::IPILOT* pPilot);
	int FuelMenu(PILOT::IPILOT* pPilot);
	int TargetMenu();

	void RobotRestart();
	void WeaponIsUnusable();
	void AlreadyDestroy();
	void MissedFire();
	void NoStockKit();
	void PerfectlyFine();
	void NoStockFuel();
	void WrongEntry();
}