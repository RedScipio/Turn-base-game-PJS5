
using static System.Net.Mime.MediaTypeNames;

namespace Battle
{
    public interface IPART
    {
        bool IsBroken();
        int GetLife();
        int GetMaxLife();
        int GetArmor();
        int GetMaxArmor();
        int TakeDamage(int iDamage);
        void RepairArmor(int iRepairPoints);
        void RepairLife(int iRepairPoints);
    }

    public enum PARTS_TYPES
    {
        FURNACE,
        LEG,
        WEAPON,
    }
}
