using PJS5_CSharp.Sources.Robot;
using System;

namespace WEAPON
{
    public interface IWEAPON
    {
        int GetDamage();
        int GetPowerConsumption();
        int GetAccuracy();
        int GetMinAccuracy();
        int GetSpecificity();
    }

    public enum WEAPON_TYPE
    {
        ABSTRACT_WEAPON,
        NORMAL_WEAPON,
        MELEE_WEAPON,
        PROJECTILE_WEAPON,
        THERMAL_WEAPON
    }

    public class IWeapon : IPARTS, IWEAPON
    {
        private int _iDamage = -1;
        private int _iPowerConsumption = -1;
        private int _iAccuracy = -1;
        private int _iMinAccuracy = -1;
        private WEAPON_TYPE _eWeaponType = WEAPON_TYPE.ABSTRACT_WEAPON;

        public IWeapon(int iId, string sName, int iArmor, int iLifePoint, int iDamage, int iPowerConsumption, int iAccuracy, int iMinAccuracy, WEAPON_TYPE eWeaponType)
            : base(iId, sName, iArmor, iLifePoint)
        {
            _iDamage = iDamage;
            _iPowerConsumption = iPowerConsumption;
            _iAccuracy = iAccuracy;
            _iMinAccuracy = iMinAccuracy;
            _eWeaponType = eWeaponType;
        }

        public WEAPON_TYPE TypeIs()
        {
            return _eWeaponType;
        }

        public int GetType()
        {
            return (int)_eWeaponType;
        }

        public int GetDamage()
        {
            return _iDamage;
        }

        public int GetPowerConsumption()
        {
            return _iPowerConsumption;
        }

        public int GetAccuracy()
        {
            return _iAccuracy;
        }

        public int GetMinAccuracy()
        {
            return _iMinAccuracy;
        }

        public int GetSpecificity()
        {
            return -1;
        }
    }
}


