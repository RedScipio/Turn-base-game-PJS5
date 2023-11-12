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
		IWEAPON(const int iId, const std::string& sName, const int iArmor, const int iLifePoint, const int iDamage, const int iPowerConsumption, const int iAccuracy, const int iMinAccuracy, const WEAPON_TYPE eWeaponType);

		WEAPON_TYPE TypeIs() { return _eWeaponType; }

		int GetType() { return static_cast<int>(_eWeaponType); }
		int GetDamage() { return _iDamage; }
		int GetPowerConsumption() { return _iPowerConsumption; }
		int GetAccuracy() { return _iAccuracy; }
		int GetMinAccuracy() { return _iMinAccuracy; }
		int GetSpecificity() { return -1; }

	private:
		int _iDamage = -1;
		int _iPowerConsumption = -1;
		int _iAccuracy = -1;
		int _iMinAccuracy = -1;

		WEAPON_TYPE _eWeaponType = WEAPON_TYPE::ABSTRACT_WEAPON;
	};
}