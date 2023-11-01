#include "Robot.h"
#include "Legs.h"
#include "..\Weapon\IWeapon.h"

namespace ROBOT
{
	ROBOT::ROBOT(const FURNACE& furnace, const LEGS& legs, const WEAPON::IWEAPON& leftWeapon, const WEAPON::IWEAPON& rightWeapon)
		: _pFurnace(new FURNACE(furnace)),
		_pLegs(new LEGS(legs)),
		_pLeftWeapon(new WEAPON::IWEAPON(leftWeapon)),
		_pRightWeapon(new WEAPON::IWEAPON(rightWeapon))
	{
	}

	ROBOT::~ROBOT()
	{
		delete _pFurnace;
		delete _pLegs;
		delete _pLeftWeapon;
		delete _pRightWeapon;
	}
}