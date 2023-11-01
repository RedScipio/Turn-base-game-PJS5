#pragma once
#include "IParts.h"
#include <string>

namespace ROBOT
{
	class FURNACE : public IPARTS
	{
	public:
		FURNACE(const int iId, const std::string& sName, const int iArmor, const int iLifePoint, const int iRestartLimit);
		~FURNACE();

		bool IsBroken() { return _iLifePoint < 1; }

	private:
		int _iRestartLimit = -1;
	};
}