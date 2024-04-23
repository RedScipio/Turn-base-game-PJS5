using Battle;
using System;

namespace Consumable
{
    public class RefuelKit : ACONSUMABLE
    {
        public RefuelKit(int iNumberItems, ENERGY? eRefuel = null) : base(iNumberItems, null, eRefuel) { }

    }
}
