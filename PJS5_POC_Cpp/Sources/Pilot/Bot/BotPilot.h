#pragma once
#include "..\IPilot.h"

namespace PILOT
{
	class BOT_PILOT : public IPILOT
	{
	public:
		BOT_PILOT(const ROBOT::ROBOT& robot);
		~BOT_PILOT();

		void PlayTurn(ROBOT::ROBOT* ennemiRobot) override {};
	};
}
