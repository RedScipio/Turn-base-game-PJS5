using Umshini;

namespace Consumable
{
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
        public abstract int GetNumberItems();
        public int GetValue()
        {
            /*if (eRepair != REPAIR.UNDEFINED)
            {
                switch (eRepair)
                {
                    case REPAIR.LIGHT_ARMOR:
                        iValue = ((int)REPAIR.LIGHT_ARMOR);
                        break;
                    case REPAIR.HEAVY_ARMOR:
                        iValue = ((int)REPAIR.HEAVY_ARMOR);
                        break;
                    case REPAIR.LIGHT_KIT:
                        iValue = ((int)REPAIR.LIGHT_KIT);
                        break;
                    case REPAIR.FULL_KIT:
                        iValue = ((int)REPAIR.FULL_KIT);
                        break;
                    default: break;
                }
            }
            else
            {
                switch (eEnergy)
                {
                    case ENERGY.ENERGY_WOOD:
                        iValue = ((int)ENERGY.ENERGY_WOOD);
                        break;
                    case ENERGY.ENERGY_CHARCOAL:
                        iValue = ((int)ENERGY.ENERGY_CHARCOAL);
                        break;
                    case ENERGY.ENERGY_COAL:
                        iValue = ((int)ENERGY.ENERGY_COAL);
                        break;
                    case ENERGY.ENERGY_COMPACT_COAL:
                        iValue = ((int)ENERGY.ENERGY_COMPACT_COAL);
                        break;
                    default: break;
                }
            }*/
            return iValue;
        }
    }
}
