using Umshini;

namespace Consumable
{
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

    public abstract class ACONSUMABLE : ICONSUMABLE
    {
        private readonly REPAIR eRepair;
        private readonly ENERGY eEnergy;
        private string sName;
        private int iValue;

        public ACONSUMABLE(REPAIR? eRepair = null, ENERGY? eRefuel = null)
        {
            if(eRepair == null && eRefuel == null)
            {
                throw new System.ArgumentNullException("A consumable is supposed to be a repair or a refuel kit");
            }
            else if(eRefuel != null)
            {
                eEnergy = (ENERGY)eRefuel;
                iValue = (int)eEnergy;
                this.eRepair = REPAIR.UNDEFINED;
            }
            else
            {
                this.eRepair = (REPAIR)eRepair;
                iValue = (int)eRepair;
                eEnergy = ENERGY.UNDEFINED;
            }
        }
        public string GetName()
        {
            
            if(eRepair != REPAIR.UNDEFINED)
            {
                switch(eRepair)
                {
                    case REPAIR.LIGHT_ARMOR:
                        sName = "Light armor kit";
                        break;
                    case REPAIR.HEAVY_ARMOR:
                        sName = "Heavy armor kit";
                        break;
                    case REPAIR.LIGHT_KIT:
                        sName = "Light repair kit";
                        break;
                    case REPAIR.FULL_KIT:
                        sName = "Full repair kit";
                        break;
                    default:
                        break;
                }
            }
            else if(eEnergy != ENERGY.UNDEFINED)
            {
                switch(eEnergy)
                {
                    case ENERGY.ENERGY_WOOD:
                        sName = "Wood";
                        break;
                    case ENERGY.ENERGY_CHARCOAL:
                        sName = "Charcoal";
                        break;
                    case ENERGY.ENERGY_COAL:
                        sName = "Coal";
                        break;
                    case ENERGY.ENERGY_COMPACT_COAL:
                        sName = "Compact coal";
                        break;
                    default : break;
                }
            }
            return sName;
        }
        public int GetValue()
        {
            return iValue;
        }
    }
}
