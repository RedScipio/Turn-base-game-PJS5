#pragma once
#include "..\IWeapon.h"

namespace WEAPON
{
	class IWEAPON;

	class MELEE_WEAPON : public IWEAPON
	{
	public:
		MELEE_WEAPON(const int iId, const std::string& sName, const int iArmor, const int iLifePoint, const int iDamage, const int iPowerConsumption, const int iAccuracy, const int iMaxInaccuracy);
	};
}