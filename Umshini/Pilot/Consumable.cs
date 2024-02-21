using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilot
{
    internal class Consumable : ICONSUMABLE
    {
        private readonly int _iValue;
        private int _iNumberItems;


        public Consumable(int value, int numberItems)
        {
            this._iValue = value;
            this._iNumberItems = numberItems;
        }

        public int GetNumberItems()
        {
            return this._iNumberItems;
        }

        public int GetValue()
        {
            return this._iValue;
        }

        public void RemoveOneItem()
        {
            if (this._iNumberItems > 0)
            {
                this._iNumberItems -= 1;
            }
            else
            {
                throw new Exception("No more items to remove");
            }
        }

        public void Stacking(ICONSUMABLE consumable)
        {
            if (this.GetValue() == consumable.GetValue())
            {
                this._iNumberItems += consumable.GetNumberItems();
            }
        }
    }
}
