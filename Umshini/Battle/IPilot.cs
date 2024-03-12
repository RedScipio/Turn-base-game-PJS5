
using System.Collections.Generic;
using Umshini;

namespace Battle
{
    public interface IPILOT
    {
        List<ICONSUMABLE> GetFuelsReserve();
        List<ICONSUMABLE> GetRepairKitsReserve();

        bool IsBotPilot();
        List<int> PlayTurnAuto();
        bool FirstChoice(int iChoice);
        bool Refuel(int iChoice);
        bool Repair(int iChoice);
        bool Attack(int iChoice);
        bool TargetPart(int iChoice);
        bool IsWeaponUsable(int iChoice);
        bool UseWeapon(int iChoice);
        bool IsFurnaceBroken();
        bool IsLegsBroken();
        bool IsWeaponBroken(int iWeapon);
    }
}