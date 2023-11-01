#pragma once
#include "..\IPilot.h"

namespace PILOT
{
	class PLAYER_PILOT :
		public IPILOT
	{
	public:

		PLAYER_PILOT(const ROBOT::ROBOT& robot);
		~PLAYER_PILOT();

		void PlayTurn(ROBOT::ROBOT* ennemiRobot) override;
	
	private:
		void MainMenu(int iChoice = -1);
		void AttackMenu();
		void RepairsMenu();
		void FurnaceMenu();
	};
}
