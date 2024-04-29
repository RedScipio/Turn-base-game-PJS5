using System.Collections.Generic;

namespace Battle
{
    public interface IROBOT
    {
        bool IsDestroy();
        bool NeedToRestart();
        int DealDamage(IROBOT pEnnemiRobot, int iWeaponChoice, PARTS_TYPES eTargetChoice);
        int TakeDamage(int iDamage, PARTS_TYPES eType);
        void RepairRobotLifePoint(int kitUsed, PARTS_TYPES eChoice);
        bool AttackTargetIsValid(PARTS_TYPES eTargetChoice);
        void WeaponFired(int iWeaponChoice);
        bool WeaponIsUsable(int iWeaponChoice);
        void Refuel(int iFuel);
        bool RepairLifeTargetIsValid(PARTS_TYPES eTargetChoice);
        void RepairRobotArmor(int iRepairPoints, PARTS_TYPES eTargetChoice);
        bool RepairArmorTargetIsValid(PARTS_TYPES eTargetChoice);
        void RemoveFuel(int iFuel);
        List<IWEAPON> GetWeapons();
        int GetFurnaceLife();
        int GetFuel();
        int GetWeaponDamage(int iWeapon);
        int GetWeaponHitChance(int iWeapon);
        bool IsFurnaceBroken();
        bool IsLegsBroken();
        bool IsWeaponBroken(int iWeapon);
        int GetFurnaceArmor();
        int GetFurnaceMaxArmor();
        int GetFurnaceMaxLife();
        int GetLegsArmor();
        int GetLegsMaxArmor();
        int GetLegsLife();
        int GetLegsMaxLife();
        int GetLeftWeaponArmor();
        int GetLeftWeaponMaxArmor();
        int GetLeftWeaponLife();
        int GetLeftWeaponMaxLife();
        int GetRightWeaponArmor();
        int GetRightWeaponMaxArmor();
        int GetRightWeaponLife();
        int GetRightWeaponMaxLife();
    }
}
