#pragma once
#include "..\IPilot.h"

namespace PILOT
{
	class BOT_PILOT : public IPILOT
	{
	public:
		BOT_PILOT(ROBOT::ROBOT* pRobot, std::vector<int> vFuelsReserve = { 0, 0, 0, 0 }, std::vector<int> vRepairKitsReserve = { 0, 0, 0, 0 });
		~BOT_PILOT();

		void PlayTurn(ROBOT::ROBOT* ennemiRobot) override {};
	};
}
