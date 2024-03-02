
namespace Pilot
{
    public interface IROBOT
    {
        int GetFurnaceLife();
        int GetLeftWeaponDamage();
        int GetLeftWeaponHitChance();
        sbyte GetRightWeaponDamage();
        sbyte GetRightWeaponHitChance();
        bool IsDestroy();
        bool NeedToRestart();
        int DealDamage(IROBOT pEnnemiRobot, int iWeaponChoice, PARTS_TYPE eTargetChoice);
        int TakeDamage(int iDamage, PARTS_TYPE eType);
        void RepairRobotLifePoint(int kitUsed, PARTS_TYPE eChoice);
        bool AttackTargetIsValid(PARTS_TYPE eTargetChoice);
        void WeaponFired(WEAPON_SIDE eUsed);
        bool WeaponIsUsable(int iWeaponChoice);
        void Refuel(int v);
        bool RepairLifeTargetIsValid(PARTS_TYPE eTargetChoice);
        void RepairRobotArmor(int v, PARTS_TYPE eTargetChoice);
        bool RepairArmorTargetIsValid(PARTS_TYPE eTargetChoice);
        void RemoveFuel(int iFuel);
    }
}
