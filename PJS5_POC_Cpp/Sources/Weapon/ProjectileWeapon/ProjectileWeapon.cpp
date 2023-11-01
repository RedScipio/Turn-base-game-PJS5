#include "ProjectileWeapon.h"

namespace WEAPON
{
	PROJECTILE_WEAPON::PROJECTILE_WEAPON(const int iId, const std::string& sName, const int iArmor, const int iLifePoint, const int iDamage, const int iPowerConsumption, const int iAccuracy, const int iMaxInaccuracy, const int iAmmo)
		: IWEAPON::IWEAPON(iId, sName, iArmor, iLifePoint, iDamage, iPowerConsumption, iAccuracy, iMaxInaccuracy, WEAPON_TYPE::PROJECTILE_WEAPON),
		_iAmmo(iAmmo)
	{
	}
}