#include "IParts.h"

namespace ROBOT
{
	IPARTS::IPARTS(const int iId, const std::string& sName, const int iArmor, const int iLifePoint) :
		_iId(iId),
		_sName(sName),
		_iArmor(iArmor),
		_iLifePoint(iLifePoint),
		_iMaxArmor(iArmor),
		_iMaxLifePoint(iLifePoint)
	{
	}
}