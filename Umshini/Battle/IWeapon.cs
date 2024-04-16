
namespace Battle
{
    public interface IWEAPON : IPART
    {
        WEAPONS_TYPES TypeIs();

        int GetPowerConsumption();
        int GetDamage();
        int GetAmmo();
        bool RemoveAmmo();
        int GetMinAccuracy();
        int GetAccuracy();
        int GetHeatEffect();
    }

    public enum WEAPONS_TYPES
    {
        NORMAL,
        MELEE,
        PROJECTILE,
        THERMAL
    }
}
