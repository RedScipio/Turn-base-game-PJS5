using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEAPON;

namespace PJS5_CSharp.Sources.Weapon.ThermalWeapon
{
    public class THERMAL_WEAPON : IWeapon
    {
        private int _iFuelBurn = -1;

        public THERMAL_WEAPON(int iId, string sName, int iArmor, int iLifePoint, int iDamage, int iPowerConsumption, int iAccuracy, int iMinAccuracy, int iFuelBurn)
            : base(iId, sName, iArmor, iLifePoint, iDamage, iPowerConsumption, iAccuracy, iMinAccuracy, WEAPON_TYPE.THERMAL_WEAPON)
        {
            _iFuelBurn = iFuelBurn;
        }

        public override int GetSpecificity()
        {
            return _iFuelBurn;
        }
    }
}
