#include "IPilot.h"

namespace PILOT
{
	IPILOT::IPILOT(const ROBOT::ROBOT& robot)
		: _pRobot(new ROBOT::ROBOT(robot))
	{
	}
}