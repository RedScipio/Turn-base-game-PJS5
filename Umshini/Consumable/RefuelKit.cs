using Battle;
using System;

namespace Consumable
{
    public class RefuelKit : ACONSUMABLE
    {
        public RefuelKit(int iNumberItems, ENERGY? eRefuel = null) : base(iNumberItems, null, eRefuel) { }

        public RefuelKit(RefuelKit refuelKit) : base(refuelKit) { }

        public override ICONSUMABLES Clone()
        {
            return new RefuelKit(this);
        }
    }
}
