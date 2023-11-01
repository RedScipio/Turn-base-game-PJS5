#pragma once
#include "..\Robot\IParts.h"
#include <string>

namespace WEAPON
{
	enum class WEAPON_TYPE {
		ABSTRACT_WEAPON,
		NORMAL_WEAPON,
		MELEE_WEAPON,
		PROJECTILE_WEAPON,
		THERMAL_WEAPON,
	};

	class IWEAPON : public ROBOT::IPARTS
	{
	public:
		IWEAPON(const int iId, const std::string& sName, const int iArmor, const int iLifePoint, const int iDamage, const int iPowerConsumption, const int iAccuracy, const int iMaxInaccuracy, const WEAPON_TYPE eWeaponType);

		bool IsBroken() { return _iLifePoint < 1; }
		WEAPON_TYPE TypeIs() { return _eWeaponType; }

	private:
		int _iDamage = -1;
		int _iPowerConsumption = -1;
		int _iAccuracy = -1;
		int _iMaxInaccuracy = -1;

		WEAPON_TYPE _eWeaponType = WEAPON_TYPE::ABSTRACT_WEAPON;
	};
}