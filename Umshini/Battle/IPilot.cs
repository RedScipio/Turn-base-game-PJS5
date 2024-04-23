using System.Collections.Generic;

namespace Battle
{
    public interface IPILOT
    {
        List<ICONSUMABLES> GetFuelsReserve();
        List<ICONSUMABLES> GetRepairKitsReserve();
        bool IsBotPilot();
        List<int> PlayTurnAuto();
        void PlayTurn(IROBOT ennemiRobot, MAIN_MENU iChoice = MAIN_MENU.Error, int iRes = -1, int iChoiceTarget = -1, int iHitRate = -1);
        bool FirstChoiceIsValid(MAIN_MENU iChoice); // specify if the current choice in the main menu is possible (broken weapon, etc)
        bool Refuel(FUEL_MENU iChoice);
        bool Repair(REPAIRS_MENU iChoice);
        bool Attack(int iChoice, IPILOT ennemy, PARTS_TYPES eTarget);
        bool TargetPart(int iChoice);
        bool IsWeaponUsable(int iChoice);
        bool IsLegsBroken();
        bool IsFurnaceBroken();
        bool IsWeaponBroken(int iChoice);
        IROBOT GetRobot();
    }
}