using System.Collections.Generic;

namespace Battle
{
    public interface IPILOT
    {
        List<ICONSUMABLES> GetFuelsReserve();
        List<ICONSUMABLES> GetRepairKitsReserve();
        bool IsBotPilot();
        List<int> PlayTurnAuto(IROBOT enemyRobot, bool showIndications = true);
        void PlayTurn(IROBOT enemyRobot, MAIN_MENU iChoice = MAIN_MENU.Error, int iRes = -1, int iChoiceTarget = -1, int iHitRate = -1);
        bool FirstChoiceIsValid(MAIN_MENU iChoice); // specify if the current choice in the main menu is possible (broken weapon, etc)
        bool Refuel(FUEL_TYPE eChoice, List<int> lInputActions = null);
        bool Repair(REPAIRS_TYPE eChoice, TARGET_TYPE eChoicePart, List<int> lInputActions = null);
        bool Attack(int iChoice, IROBOT enemy, TARGET_TYPE eTarget, List<int> lInputActions = null);
        bool IsWeaponUsable(int iChoice);
        bool IsLegsBroken();
        bool IsFurnaceBroken();
        bool IsWeaponBroken(int iChoice);
        bool IsAllKitsEmpty(List<ICONSUMABLES> list);
        IROBOT GetRobot();
    }
}