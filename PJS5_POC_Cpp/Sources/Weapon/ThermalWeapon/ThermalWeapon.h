#pragma once
#include "..\IWeapon.h"

namespace WEAPON
{
	class IWEAPON;

	class THERMAL_WEAPON : public IWEAPON
	{
	public:
		THERMAL_WEAPON(const int iId, const std::string& sName, const int iArmor, const int iLifePoint, const int iDamage, const int iPowerConsumption, const int iAccuracy, const int iMinAccuracy, const int iFuelBurn);

		int GetSpecificity() { return _iFuelBurn; }

	private:
		int _iFuelBurn = -1;
	};
}