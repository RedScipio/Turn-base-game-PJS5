
namespace Battle
{
    public interface ICONSUMABLE
    {
        int GetNumberItems();
        int GetValue();
        void RemoveOneItem();
        void Stacking(ICONSUMABLE consumable);
    }
}
