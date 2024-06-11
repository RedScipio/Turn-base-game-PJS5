using System.Collections.Generic;

namespace Battle
{
    public abstract class ABATTLE 
    {
        protected List<IPILOT> _lPilots;

        public ABATTLE(IPILOT pilot1, IPILOT pilot2)
        {
            _lPilots = new List<IPILOT> { pilot1, pilot2 };
        }

        // Property to access _lPilots
        public List<IPILOT> Pilots => _lPilots;

        public abstract List<int> PlayRound();
        public abstract List<int> PlayTurn(int iPilot, MAIN_MENU eChoiceMenu = MAIN_MENU.Error, int iRes = -1, int iTargetPart = -1);
    }
}
