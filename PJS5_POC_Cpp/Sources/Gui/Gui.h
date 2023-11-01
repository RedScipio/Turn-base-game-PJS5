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
	void WeaponMenu();
	void RepairMenu();
	void FuelMenu();
	void TargetMenu();

	void ResultAction();
}