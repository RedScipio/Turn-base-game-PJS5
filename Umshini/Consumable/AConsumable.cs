using Battle;

namespace Consumable
{
    public abstract class ACONSUMABLE : ICONSUMABLE
    {
        public int GetNumberItems()
        {
            throw new System.NotImplementedException();
        }

        public int GetValue()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveOneItem()
        {
            throw new System.NotImplementedException();
        }

        public void Stacking(ICONSUMABLE consumable)
        {
            throw new System.NotImplementedException();
        }
    }
}
