
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
        int DealDamage(IROBOT robot, WEAPON_SIDE x, PARTS_TYPE y);
        void RepairRobotLifePoint(int kitUtilise, PARTS_TYPE fURNACE);
        bool AttackTargetIsValid(PARTS_TYPE eTargetChoice);
        void WeaponFired(WEAPON_SIDE eUsed);
        bool WeaponIsUsable(WEAPON_SIDE lEFT_WEAPON);
        void Refuel(int v);
        bool RepairLifeTargetIsValid(PARTS_TYPE eTargetChoice);
        void RepairRobotArmor(int v, PARTS_TYPE eTargetChoice);
        bool RepairArmorTargetIsValid(PARTS_TYPE eTargetChoice);
    }
}
