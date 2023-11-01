#pragma once
#include "Furnace.h"

namespace WEAPON
{
	class IWEAPON;
}

namespace ROBOT
{
	class FURNACE;
	class LEGS;

	class ROBOT
	{
	public:
		ROBOT(const FURNACE& furnace, const LEGS& legs, const WEAPON::IWEAPON& leftWeapon, const WEAPON::IWEAPON& rightWeapon);
		~ROBOT();

		bool IsDestroy() { return _pFurnace->IsBroken(); }
	private:
		FURNACE* _pFurnace = nullptr;
		LEGS* _pLegs = nullptr;
		WEAPON::IWEAPON* _pLeftWeapon = nullptr;
		WEAPON::IWEAPON* _pRightWeapon = nullptr;

		int _iFuel = 100;
	};
}