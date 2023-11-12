#include "Robot.h"
#include "../Weapon/ProjectileWeapon/ProjectileWeapon.h"

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

	int ROBOT::DealDamage(ROBOT* pEnnemiRobot, const int iChoiceWeapon, const int iTargetChoice)
	{
		WEAPON::IWEAPON* pWeapon = _pLeftWeapon;
		if (iChoiceWeapon == 2)
		{
			pWeapon = _pRightWeapon;
		}
		
		if (pWeapon->TypeIs() == WEAPON::WEAPON_TYPE::THERMAL_WEAPON)
		{
			pEnnemiRobot->RemoveFuel(pWeapon->GetSpecificity());
		}

		switch (iTargetChoice)
			{
			case 1:
			{
				return pEnnemiRobot->_pLeftWeapon->TakeDamage(pWeapon->GetDamage());
			}
			case 2:
			{
				return pEnnemiRobot->_pRightWeapon->TakeDamage(pWeapon->GetDamage());
			}
			case 3:
			{
				return pEnnemiRobot->_pLegs->TakeDamage(pWeapon->GetDamage());
			}
			case 4:
			{
				return pEnnemiRobot->_pFurnace->TakeDamage(pWeapon->GetDamage());
			}
			default:
			{
				return 0;
			}
			}

		return 0;
	}

	bool ROBOT::WeaponIsUsable(const int iChoice)
	{
		WEAPON::IWEAPON* pWeapon = _pLeftWeapon;
		if (iChoice == 2)
		{
			pWeapon = _pRightWeapon;
		}

		switch (pWeapon->TypeIs())
		{
		case WEAPON::WEAPON_TYPE::ABSTRACT_WEAPON:
		{
			return false;
		}
		case WEAPON::WEAPON_TYPE::MELEE_WEAPON:
		{
			if (_pLegs->GetLife() > 0 && pWeapon->GetLife() > 0 && pWeapon->GetPowerConsumption() <= _iFuel)
			{
				return true;
			}
			return false;
		}
		case WEAPON::WEAPON_TYPE::PROJECTILE_WEAPON:
		{
			if (pWeapon->GetSpecificity() > 0 && pWeapon->GetLife() > 0 && pWeapon->GetPowerConsumption() <= _iFuel)
			{
				return true;
			}
			return false;
		}
		default:
		{
			if (pWeapon->GetLife() > 0 && pWeapon->GetPowerConsumption() <= _iFuel)
			{
				return true;
			}
			return false;
		}
		}

		return false;
	}

	void ROBOT::WeaponFired(const int iWeapon)
	{
		WEAPON::IWEAPON* pWeapon = _pLeftWeapon;
		if (iWeapon == 2)
		{
			pWeapon = _pRightWeapon;
		}

		switch (pWeapon->TypeIs())
		{
		case WEAPON::WEAPON_TYPE::ABSTRACT_WEAPON:
		{
			return;
		}
		case WEAPON::WEAPON_TYPE::PROJECTILE_WEAPON:
		{
			static_cast<WEAPON::PROJECTILE_WEAPON*>(pWeapon)->RemoveAmmo();
		}
		default:
		{
			RemoveFuel(pWeapon->GetPowerConsumption());

			return;
		}
		}

	}

	bool ROBOT::AttackTargetIsValid(const int iChoice)
	{
		switch (iChoice)
		{
		case 1:
		{
			if(_pLeftWeapon->GetLife() > 0)
			{
				return true;
			}
			return false;
		}
		case 2:
		{
			if (_pRightWeapon->GetLife() > 0)
			{
				return true;
			}
			return false;
		}
		case 3:
		{
			if (_pLegs->GetLife() > 0)
			{
				return true;
			}
			return false;
		}
		case 4:
		{
			if (_pFurnace->GetLife() > 0)
			{
				return true;
			}
			return false;
		}
		default:
		{
			return false;
		}
		}
	}

	void ROBOT::RepairRobotArmor( int iRepairPoints, const int iTargetChoice)
	{
		switch (iTargetChoice)
		{
		case 1:
		{
			_pLeftWeapon->RepairArmor(iRepairPoints);
			return;
		}
		case 2:
		{
			_pRightWeapon->RepairArmor(iRepairPoints);
			return;
		}
		case 3:
		{
			_pLegs->RepairArmor(iRepairPoints);
			return;
		}
		case 4:
		{
			_pFurnace->RepairArmor(iRepairPoints);
			return;
		}
		default:
		{
			return;
		}
		}

		return;
	}

	void ROBOT::RepairRobotLifePoint(int iRepairPoints, const int iTargetChoice)
	{
		switch (iTargetChoice)
		{
		case 1:
		{
			_pLeftWeapon->RepairLife(iRepairPoints);
			return;
		}
		case 2:
		{
			_pRightWeapon->RepairLife(iRepairPoints);
			return;
		}
		case 3:
		{
			_pLegs->RepairLife(iRepairPoints);
			return;
		}
		case 4:
		{
			_pFurnace->RepairLife(iRepairPoints);
			return;
		}
		default:
		{
			return;
		}
		}

		return;
	}

	bool ROBOT::RepairLifeTargetIsValid(const int iChoice)
	{
		switch (iChoice)
		{
		case 1:
		{
			if (_pLeftWeapon->GetLife() < _pLeftWeapon->GetMaxLife())
			{
				return true;
			}
			return false;
		}
		case 2:
		{
			if (_pRightWeapon->GetLife() < _pRightWeapon->GetMaxLife())
			{
				return true;
			}
			return false;
		}
		case 3:
		{
			if (_pLegs->GetLife() < _pLegs->GetMaxLife())
			{
				return true;
			}
			return false;
		}
		case 4:
		{
			if (_pFurnace->GetLife() < _pLegs->GetMaxLife())
			{
				return true;
			}
			return false;
		}
		default:
		{
			return false;
		}
		}
	}

	bool ROBOT::RepairArmorTargetIsValid(const int iChoice)
	{
		switch (iChoice)
		{
		case 1:
		{
			if (_pLeftWeapon->GetArmor() < _pLeftWeapon->GetMaxArmor())
			{
				return true;
			}
			return false;
		}
		case 2:
		{
			if (_pRightWeapon->GetArmor() < _pRightWeapon->GetMaxArmor())
			{
				return true;
			}
			return false;
		}
		case 3:
		{
			if (_pLegs->GetArmor() < _pLegs->GetMaxArmor())
			{
				return true;
			}
			return false;
		}
		case 4:
		{
			if (_pFurnace->GetArmor() < _pLegs->GetMaxArmor())
			{
				return true;
			}
			return false;
		}
		default:
		{
			return false;
		}
		}
	}

	void ROBOT::RemoveFuel(const int iFuel)
	{
		_iFuel = _iFuel - iFuel;
		if (_iFuel <= 0)
		{
			_iFuel = 0;
			_bNeedRestart = true;
		}
	}

	void ROBOT::Refuel(const int iFuel)
	{
		_iFuel = _iFuel + iFuel;
		if (_iFuel > 100)
		{
			_iFuel = 100;
		}

		if (_iFuel >= _pFurnace->GetRestartLimit())
		{
			_bNeedRestart = false;
		}
	}
}