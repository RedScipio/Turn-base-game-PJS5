#pragma once
#include "Furnace.h"
#include "Legs.h"
#include "../Weapon/IWeapon.h"

namespace ROBOT
{
	class ROBOT
	{
	public:
		ROBOT(const FURNACE& furnace, const LEGS& legs, const WEAPON::IWEAPON& leftWeapon, const WEAPON::IWEAPON& rightWeapon);
		~ROBOT();

		bool IsDestroy() { return _pFurnace->IsBroken(); }
		bool WeaponIsUsable(const int iChoice);
		
		int DealDamage(ROBOT* pEnnemiRobot, const int iChoiceWeapon, const int iTargetChoice);
		void RepairRobotArmor(const int iRepairPoints, const int iTargetChoice);
		void RepairRobotLifePoint(const int iRepairPoints, const int iTargetChoice);

		bool AttackTargetIsValid(const int iChoice);
		bool RepairLifeTargetIsValid(const int iChoice);
		bool RepairArmorTargetIsValid(const int iChoice);

		void WeaponFired(const int iWeapon);

		void Refuel(const int iFuel);
		int GetFuel() { return _iFuel; }

		bool NeedToRestart() { return _bNeedRestart; }

		int GetFurnaceLife() { return _pFurnace->GetLife(); }
		int GetFurnaceArmor() { return _pFurnace->GetArmor(); }
		int GetFurnaceMaxLife() { return _pFurnace->GetMaxLife(); }
		int GetFurnaceMaxArmor() { return _pFurnace->GetMaxArmor(); }

		int GetLegsLife() { return _pLegs->GetLife(); }
		int GetLegsArmor() { return _pLegs->GetArmor(); }
		int GetLegsMaxLife() { return _pLegs->GetMaxLife(); }
		int GetLegsMaxArmor() { return _pLegs->GetMaxArmor(); }

		int GetLeftWeaponLife() { return _pLeftWeapon->GetLife(); }
		int GetLeftWeaponArmor() { return _pLeftWeapon->GetArmor(); }
		int GetLeftWeaponMaxLife() { return _pLeftWeapon->GetMaxLife(); }
		int GetLeftWeaponMaxArmor() { return _pLeftWeapon->GetMaxArmor(); }

		int GetLeftWeaponType() { return _pLeftWeapon->GetType(); }
		int GetLeftWeaponDamage() { return _pLeftWeapon->GetDamage(); }
		int GetLeftWeaponPowerConsumption() { return _pLeftWeapon->GetPowerConsumption(); }
		int GetLeftWeaponAccuracy() { return _pLeftWeapon->GetAccuracy(); }
		int GetLeftWeaponMinAccuracy() { return _pLeftWeapon->GetMinAccuracy(); }
		int GetLeftWeaponSpecificity() { return _pLeftWeapon->GetSpecificity(); }
		int GetLeftWeaponHitChance() { return GetLeftWeaponMinAccuracy() + GetLeftWeaponAccuracy() - GetLeftWeaponMinAccuracy() / GetLegsMaxLife() * GetLegsLife(); }


		int GetRightWeaponLife() { return _pRightWeapon->GetLife(); }
		int GetRightWeaponArmor() { return _pRightWeapon->GetArmor(); }
		int GetRightWeaponMaxLife() { return _pRightWeapon->GetMaxLife(); }
		int GetRightWeaponMaxArmor() { return _pRightWeapon->GetMaxArmor(); }

		int GetRightWeaponType() { return _pRightWeapon->GetType(); }
		int GetRightWeaponDamage() { return _pRightWeapon->GetDamage(); }
		int GetRightWeaponPowerConsumption() { return _pRightWeapon->GetPowerConsumption(); }
		int GetRightWeaponAccuracy() { return _pRightWeapon->GetAccuracy(); }
		int GetRightWeaponMinAccuracy() { return _pRightWeapon->GetMinAccuracy(); }
		int GetRightWeaponSpecificity() { return _pRightWeapon->GetSpecificity(); }
		int GetRightWeaponHitChance() { return GetRightWeaponMinAccuracy() + GetRightWeaponAccuracy() - GetRightWeaponMinAccuracy() / GetLegsMaxLife() * GetLegsLife();	}

	private:
		void RemoveFuel(const int iFuel);

		FURNACE* _pFurnace = nullptr;
		LEGS* _pLegs = nullptr;
		WEAPON::IWEAPON* _pLeftWeapon = nullptr;
		WEAPON::IWEAPON* _pRightWeapon = nullptr;

		bool _bNeedRestart = false;
		int _iFuel = 100;
	};
}