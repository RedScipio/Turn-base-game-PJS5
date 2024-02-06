using PJS5_CSharp.Sources.Robot;
using System;
using System.Diagnostics;

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
        NORMAL_WEAPON,
        MELEE_WEAPON,
        PROJECTILE_WEAPON,
        THERMAL_WEAPON
    }

    public abstract class IWeapon : IPARTS, IWEAPON
    {
        private readonly int _iDamage = -1;
        private readonly int _iPowerConsumption = -1;
        private readonly int _iAccuracy = -1;
        private readonly int _iMinAccuracy = -1;
        private readonly WEAPON_TYPE _eWeaponType;

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

        public new int GetType()
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

        public virtual int GetSpecificity()
        {
            return -1;
        }
    }
}


