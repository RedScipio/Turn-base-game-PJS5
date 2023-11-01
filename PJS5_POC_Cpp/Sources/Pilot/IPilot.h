#pragma once
#include "..\Robot\Robot.h"

namespace PILOT
{
	class IPILOT
	{
	public:
		IPILOT(const ROBOT::ROBOT& robot);
		~IPILOT() {  };

		virtual void PlayTurn(ROBOT::ROBOT* ennemiRobot) = 0;

		bool RobotIsDestroy() { return _pRobot->IsDestroy(); }
		ROBOT::ROBOT* GetRobot() { return _pRobot ; }

	protected:
		ROBOT::ROBOT* _pRobot = nullptr;
	};
}