#include "Furnace.h"

namespace ROBOT
{
	FURNACE::FURNACE(const int iId, const std::string& sName, const int iArmor, const int iLifePoint, const int iRestartLimit)
		: IPARTS(iId, sName, iArmor, iLifePoint),
		_iRestartLimit(iRestartLimit)
	{
	}

	FURNACE::~FURNACE()
	{
	}
}