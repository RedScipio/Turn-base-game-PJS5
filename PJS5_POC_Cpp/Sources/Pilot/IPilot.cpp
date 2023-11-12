#include "IPilot.h"

namespace PILOT
{
	IPILOT::IPILOT(ROBOT::ROBOT* pRobot, std::vector<int> vFuelsReserve, std::vector<int> vRepairKitsReserve)
		: _pRobot(pRobot),
		_vFuelsReserve(vFuelsReserve),
		_vRepairKitsReserve(vRepairKitsReserve)
	{
	}
}