
namespace Battle
{
    public interface ICONSUMABLE
    {

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
