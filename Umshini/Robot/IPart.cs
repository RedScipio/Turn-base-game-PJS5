
namespace Robot
{
    public interface IPART
    {
        bool IsBroken();
        int TakeDamage(int iDamage);
        void RepairArmor(int iRepair);
        void RepairLife(int iRepair);
    }
}
