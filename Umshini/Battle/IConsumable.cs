
namespace Battle
{
    public interface ICONSUMABLE
    {

        public const int ENERGY_WOOD = 15;
        public const int ENERGY_CHARCOAL = 20;
        public const int ENERGY_COAL = 25;
        public const int ENERGY_COMPACT_COAL = 35;

        int GetNumberItems();
        int GetValue();
        void RemoveOneItem();
        //void Stacking(ICONSUMABLE consumable);
    }

    public enum ENERGY
    {
        ENERGY_WOOD = 15,
        ENERGY_CHARCOAL = 20,
        ENERGY_COAL = 25,
        ENERGY_COMPACT_COAL = 35,
    }
}
