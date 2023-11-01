#pragma once
#include "..\IWeapon.h"

namespace WEAPON
{
	class IWEAPON;

	class PROJECTILE_WEAPON : public IWEAPON
	{
	public:
		PROJECTILE_WEAPON(const int iId, const std::string& sName, const int iArmor, const int iLifePoint, const int iDamage, const int iPowerConsumption, const int iAccuracy, const int iMaxInaccuracy, const int iAmmo);
	
	private:
		int _iAmmo = -1;
	};
}