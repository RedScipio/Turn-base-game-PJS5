#pragma once
#include "..\Robot\Robot.h"
#include <vector>

namespace PILOT
{
	class IPILOT
	{
	public:
		IPILOT(ROBOT::ROBOT* pRobot, std::vector<int> vFuelsReserve = { 0, 0, 0, 0 }, std::vector<int> vRepairKitsReserve = { 0, 0, 0, 0 });
		~IPILOT() {  };

		virtual void PlayTurn(ROBOT::ROBOT* ennemiRobot) = 0;

		bool RobotIsDestroy() { return _pRobot->IsDestroy(); }
		ROBOT::ROBOT* GetRobot() { return _pRobot ; }

		std::vector<int> GetFuelsReserve() { return _vFuelsReserve; }
		std::vector<int> GetRepairKitsReserve() { return _vRepairKitsReserve; }

	protected:
		std::vector<int> _vFuelsReserve;
		std::vector<int> _vRepairKitsReserve;

		ROBOT::ROBOT* _pRobot = nullptr;
	};
}