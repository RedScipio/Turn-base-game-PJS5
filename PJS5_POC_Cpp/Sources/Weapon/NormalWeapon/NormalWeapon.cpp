#include "NormalWeapon.h"

namespace WEAPON
{
	NORMAL_WEAPON::NORMAL_WEAPON(const int iId, const std::string& sName, const int iArmor, const int iLifePoint, const int iDamage, const int iPowerConsumption, const int iAccuracy, const int iMinAccuracy)
		: IWEAPON::IWEAPON(iId, sName, iArmor, iLifePoint, iDamage, iPowerConsumption, iAccuracy, iMinAccuracy, WEAPON_TYPE::NORMAL_WEAPON)
	{
	}
}