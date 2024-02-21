
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
        int DealDamage(IROBOT robot, WEAPON_SIDE eWeaponChoice, PARTS_TYPE eChoice);
        void RepairRobotLifePoint(int kitUsed, PARTS_TYPE eChoice);
        bool AttackTargetIsValid(PARTS_TYPE eTargetChoice);
        void WeaponFired(WEAPON_SIDE eUsed);
        bool WeaponIsUsable(WEAPON_SIDE eWeaponChoice);
        void Refuel(int v);
        bool RepairLifeTargetIsValid(PARTS_TYPE eTargetChoice);
        void RepairRobotArmor(int v, PARTS_TYPE eTargetChoice);
        bool RepairArmorTargetIsValid(PARTS_TYPE eTargetChoice);
    }
}
