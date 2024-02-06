using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEAPON;

namespace PJS5_CSharp.Sources.Weapon.ProjectileWeapon
{
    public class PROJECTILE_WEAPON : IWeapon
    {
        private int _iAmmo = -1;

        public PROJECTILE_WEAPON(int iId, string sName, int iArmor, int iLifePoint, int iDamage, int iPowerConsumption, int iAccuracy, int iMinAccuracy, int iAmmo)
            : base(iId, sName, iArmor, iLifePoint, iDamage, iPowerConsumption, iAccuracy, iMinAccuracy, WEAPON_TYPE.PROJECTILE_WEAPON)
        {
            _iAmmo = iAmmo;
        }

        public override int GetSpecificity()
        {
            return _iAmmo;
        }

        public void RemoveAmmo()
        {
            _iAmmo--;
        }
    }
}
