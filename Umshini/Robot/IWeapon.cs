
namespace Robot
{
    public interface IWEAPON : IPART
    {
        WEAPONS_TYPES TypeIs();

        int GetPowerConsumption();
        int GetDamage();
        int GetAmmo();
        bool RemoveAmmo();
        int GetHeatEffect();
    }
}
