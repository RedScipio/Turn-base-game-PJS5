#include "IWeapon.h"

namespace WEAPON
{
	IWEAPON::IWEAPON(const int iId, const std::string& sName, const int iArmor, const int iLifePoint, const int iDamage, const int iPowerConsumption, const int iAccuracy, const int iMaxInaccuracy, const WEAPON_TYPE eWeaponType)
		: IPARTS(iId, sName, iArmor, iLifePoint),
		_iDamage(iDamage),
		_iPowerConsumption(iPowerConsumption),
		_iAccuracy(iAccuracy),
		_iMaxInaccuracy(iMaxInaccuracy),
		_eWeaponType(eWeaponType)
	{
	}
}