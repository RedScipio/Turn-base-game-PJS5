#include "BotPilot.h"

namespace PILOT
{
	BOT_PILOT::BOT_PILOT(ROBOT::ROBOT* pRobot, std::vector<int> vFuelsReserve, std::vector<int> vRepairKitsReserve)
		: IPILOT(pRobot, vFuelsReserve, vRepairKitsReserve)
	{
	}

	BOT_PILOT::~BOT_PILOT()
	{
	}
}