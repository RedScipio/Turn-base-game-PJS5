#include "MeleeWeapon.h"

namespace WEAPON
{
	MELEE_WEAPON::MELEE_WEAPON(const int iId, const std::string& sName, const int iArmor, const int iLifePoint, const int iDamage, const int iPowerConsumption, const int iAccuracy, const int iMaxInaccuracy)
		: IWEAPON::IWEAPON(iId, sName, iArmor, iLifePoint, iDamage, iPowerConsumption, iAccuracy, iMaxInaccuracy, WEAPON_TYPE::MELEE_WEAPON)
	{
	}
}