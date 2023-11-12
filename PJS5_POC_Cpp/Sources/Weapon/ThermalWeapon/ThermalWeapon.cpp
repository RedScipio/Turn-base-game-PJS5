#include "ThermalWeapon.h"

namespace WEAPON
{
	THERMAL_WEAPON::THERMAL_WEAPON(const int iId, const std::string& sName, const int iArmor, const int iLifePoint, const int iDamage, const int iPowerConsumption, const int iAccuracy, const int iMinAccuracy, const int iFuelBurn)
		: IWEAPON::IWEAPON(iId, sName, iArmor, iLifePoint, iDamage, iPowerConsumption, iAccuracy, iMinAccuracy, WEAPON_TYPE::THERMAL_WEAPON),
		_iFuelBurn(iFuelBurn)
	{
	}
}