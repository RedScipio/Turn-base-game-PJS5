
namespace Pilot
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
        int GetFurnaceLife();
        int GetWeaponDamage(int iWeapon);
        int GetWeaponHitChance(int iWeapon);
    }
}
