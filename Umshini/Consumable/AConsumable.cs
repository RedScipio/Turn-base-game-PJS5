using Battle;

namespace Consumable
{
    public abstract class ACONSUMABLE : ICONSUMABLES
    {
        private readonly REPAIR eRepair;
        private readonly ENERGY eEnergy;
        private string sName;
        private readonly int iValue;
        private int iNumberItems;

        public ACONSUMABLE(int iNumberItems, REPAIR? eRepair = null, ENERGY? eRefuel = null)
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
            this.iNumberItems = iNumberItems;
        }

        public ACONSUMABLE(ACONSUMABLE consumable)
        {
            eRepair = consumable.eRepair;
            eEnergy = consumable.eEnergy;
            sName = consumable.sName;
            iValue = consumable.iValue;
            iNumberItems = consumable.iNumberItems;
        }

        public abstract ICONSUMABLES Clone();

        /// <summary>
        /// Return the name of the consumable based on the type
        /// of consumable in the constructor
        /// </summary>
        /// <returns>String</returns>
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

        /// <summary>
        /// Return the number of items in a consumable
        /// </summary>
        /// <returns>int</returns>
        public int GetNumberItems()
        {
            return iNumberItems;
        }

        /// <summary>
        /// Reduce the number of items by 1
        /// </summary>
        public void DecrNumberItems()
        {
            iNumberItems--;
        }

        /// <summary>
        /// Raise the number of items  by 1
        /// Only used for testing purpose
        /// </summary>
        public void IncrNumberItems()
        {
            iNumberItems++;
        }

        public int GetValue()
        {
            return iValue;
        }
    }
}
