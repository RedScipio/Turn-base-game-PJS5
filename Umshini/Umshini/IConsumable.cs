
namespace Umshini
{
    public interface ICONSUMABLE
    {

        int GetNumberItems();
        int GetValue();
        string GetName();
    }

    public enum ENERGY
    {
        UNDEFINED = -1,
        ENERGY_WOOD = 15,
        ENERGY_CHARCOAL = 20,
        ENERGY_COAL = 25,
        ENERGY_COMPACT_COAL = 35,
    }

    public enum REPAIR
    {
        UNDEFINED = -1,
        LIGHT_ARMOR = 1,
        HEAVY_ARMOR = 3,
        LIGHT_KIT = 2,
        FULL_KIT = 4
    }
}
