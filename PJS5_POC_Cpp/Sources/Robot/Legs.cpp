#include "Legs.h"

namespace ROBOT
{
	LEGS::LEGS(const int iId, const std::string& sName, const int iArmor, const int iLifePoint, const int iLegs)
		: IPARTS(iId, sName, iArmor, iLifePoint),
		_iLegs(iLegs)
	{
	}

	LEGS::~LEGS()
	{

	}
}