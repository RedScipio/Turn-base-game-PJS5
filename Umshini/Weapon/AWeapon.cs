using Part;
using Robot;

namespace Weapon
{
    /// <summary>
    /// Author : Beowulf-0
    /// Version : 0.1
    /// Date : 13/02/2024
    /// </summary>
    public abstract class AWEAPON : APART, IWEAPON
    {
        private readonly int _iDamage = -1;
        private readonly int _iPowerConsumption = -1;
        private readonly int _iAccuracy = -1;
        private readonly int _iMinAccuracy = -1;
        private WEAPONS_TYPES _eWeaponType;

        /// <summary>
        /// represents a weapon equipable by the robot
        /// </summary>
        /// <param name="iId"></param>
        /// <param name="sName"></param>
        /// <param name="iArmor"></param>
        /// <param name="iLifePoint"></param>
        /// <param name="iMaxArmor"></param>
        /// <param name="iMaxLifePoint"></param>
        protected AWEAPON(int iId, string sName, int iArmor, int iLifePoint, int iDamage, int iPowerConsumption, int iAccuracy, int iMinAccuracy, WEAPONS_TYPES eWeaponType) : base(iId, sName, iArmor, iLifePoint)
        {
            _iDamage = iDamage;
            _iPowerConsumption = iPowerConsumption;
            _iAccuracy = iAccuracy;
            _iMinAccuracy = iMinAccuracy;
            _eWeaponType = eWeaponType;
        }

        public int GetAccuracy()
        {
            return _iAccuracy;
        }

        public abstract int GetAmmo();
        public int GetDamage()
        {
            return _iDamage;
        }
        public abstract int GetHeatEffect();

        public int GetMinAccuracy()
        {
            return _iMinAccuracy;
        }

        public int GetPowerConsumption()
        {
            return _iPowerConsumption;
        }
        public abstract bool RemoveAmmo();
        public WEAPONS_TYPES TypeIs()
        {
            return _eWeaponType;
        }
    }
}
