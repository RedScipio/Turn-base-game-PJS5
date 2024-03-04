using Battle;

namespace Pilot
{
    public interface IGUI
    {
        void AlreadyDestroy();
        int FuelMenu(IPILOT pLAYER_PILOT, int iUsed);
        int MainMenu();
        void MissedFire();
        void NoStockFuel();
        void NoStockKit();
        void PerfectlyFine();
        int RepairMenu(IPILOT pLAYER_PILOT, int iUsed);
        void RobotRestart();
        int TargetMenu(int iUsed);
        void WeaponIsUnusable();
        int WeaponMenu(IROBOT iROBOT);
        void WrongEntry();
    }
}