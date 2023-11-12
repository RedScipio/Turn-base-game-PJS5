#pragma once
#include "..\IPilot.h"

namespace PILOT
{
	class PLAYER_PILOT :
		public IPILOT
	{
	public:

		PLAYER_PILOT(ROBOT::ROBOT* pRobot, std::vector<int> vFuelsReserve = { 0, 0, 0, 0 }, std::vector<int> vRepairKitsReserve = { 0, 0, 0, 0 });
		~PLAYER_PILOT();

		void PlayTurn(ROBOT::ROBOT* pEnnemiRobot) override;
	
	private:
		void MainMenu(ROBOT::ROBOT* pEnnemiRobot, int iChoice = -1);
		void AttackMenu(ROBOT::ROBOT* pEnnemiRobot, int iChoice = -1);
		void RepairsMenu(ROBOT::ROBOT* pEnnemiRobot, int iChoice = -1);
		void FurnaceMenu(ROBOT::ROBOT* pEnnemiRobot, int iChoice = -1);
	};
}
