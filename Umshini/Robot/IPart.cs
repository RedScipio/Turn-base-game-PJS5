
using static System.Net.Mime.MediaTypeNames;

namespace Robot
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
}
