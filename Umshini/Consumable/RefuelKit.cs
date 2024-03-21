using System;
using Umshini;

namespace Consumable
{
    public class RefuelKit : ACONSUMABLE
    {
        public RefuelKit(ENERGY? eRefuel = null) : base(null, eRefuel) { }

        public override int GetNumberItems()
        {
            throw new NotImplementedException();
        }
    }
}
