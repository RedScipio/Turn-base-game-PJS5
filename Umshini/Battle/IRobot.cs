using System.Collections.Generic;

namespace Battle
{
    public interface IROBOT
    {
        bool IsDestroy();
        bool NeedToRestart();
        int DealDamage(IROBOT pEnnemiRobot, int iWeaponChoice, TARGET_TYPE eTargetChoice);
        int TakeDamage(int iDamage, TARGET_TYPE eType);
        void RepairRobotLifePoint(int kitUsed, TARGET_TYPE eChoice);
        bool AttackTargetIsValid(TARGET_TYPE eTargetChoice);
        void WeaponFired(int iWeaponChoice);
        bool WeaponIsUsable(int iWeaponChoice);
        IROBOT Clone();
        void Refuel(int iFuel);
        bool RepairLifeTargetIsValid(TARGET_TYPE eTargetChoice);
        void RepairRobotArmor(int iRepairPoints, TARGET_TYPE eTargetChoice);
        bool RepairArmorTargetIsValid(TARGET_TYPE eTargetChoice);
        void RemoveFuel(int iFuel);
        List<IWEAPON> GetWeapons();
        int GetFurnaceLife();
        int GetFuel();
        int GetMaxFuel();
        int GetWeaponDamage(int iWeapon);
        int GetWeaponHitChance(int iWeapon);
        bool IsFurnaceBroken();
        bool IsLegsBroken();
        bool IsWeaponBroken(int iWeapon);
        int GetFurnaceArmor();
        int GetFurnaceMaxArmor();
        int GetFurnaceMaxLife();
        int GetFurnaceRestartLimit();
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


public enum TARGET_TYPE
{
    LEG = 0,
    FURNACE = 1,
    LEFT_WEAPON = 2,
    RIGHT_WEAPON = 3,
}