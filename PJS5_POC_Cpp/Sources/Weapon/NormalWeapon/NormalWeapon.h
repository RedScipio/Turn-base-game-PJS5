#pragma once
#include "..\IWeapon.h"

namespace WEAPON
{
	class IWEAPON;

	class NORMAL_WEAPON : public IWEAPON
	{
	public:
		NORMAL_WEAPON(const int iId, const std::string& sName, const int iArmor, const int iLifePoint, const int iDamage, const int iPowerConsumption, const int iAccuracy, const int iMinAccuracy);
	};
}