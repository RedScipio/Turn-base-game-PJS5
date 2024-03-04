using System.Collections.Generic;
using Umshini;

namespace Battle
{
    public abstract class ABATTLE : IBATTLE
    {
        protected List<IPILOT> _lPilots;

        public ABATTLE(IPILOT pilot1, IPILOT pilot2)
        {
            this._lPilots = new List<IPILOT> { pilot1, pilot2 };
        }

        public abstract List<int> PlayRound();
        public abstract List<int> PlayTurn(int iPilot);
    }
}
