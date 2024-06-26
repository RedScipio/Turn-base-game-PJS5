using Battle;
using Newtonsoft.Json;

namespace Weapon
{
    /// <summary>
    /// Author : Beowulf-0 (Mehdi)
    /// Version : 0.1
    /// Date : 13/02/2024
    /// </summary>
    public class PROJECTILE_WEAPON : AWEAPON
    {
        [JsonProperty("ammo", Order = 2)]
        private int _iAmmo = -1;
        /// <summary>
        /// Represents an accurate weapon with limited ammunition
        /// </summary>
        /// <param name="iId"></param>
        /// <param name="sName"></param>
        /// <param name="iArmor"></param>
        /// <param name="iLifePoint"></param>
        /// <param name="iDamage"></param>
        /// <param name="iPowerConsumption"></param>
        /// <param name="iAccuracy"></param>
        /// <param name="iMinAccuracy"></param>
        /// <param name="eWeaponType"></param>
        [JsonConstructor]
        public PROJECTILE_WEAPON(string iId, string sName, int iArmor, int iLifePoint, string sUrlImage, int iDamage, int iPowerConsumption, int iAccuracy, int iMinAccuracy, int iAmmo) : base(iId, sName, iArmor, iLifePoint, sUrlImage, iDamage, iPowerConsumption, iAccuracy, iMinAccuracy, WEAPONS_TYPES.PROJECTILE)
        {
            _iAmmo = iAmmo;
        }

        public PROJECTILE_WEAPON(PROJECTILE_WEAPON projectileWeapon) : base(projectileWeapon._iId, projectileWeapon._sName, projectileWeapon._iArmor, projectileWeapon._iLifePoint, projectileWeapon._sUrlImage, projectileWeapon._iDamage, projectileWeapon._iPowerConsumption, projectileWeapon._iAccuracy, projectileWeapon._iMinAccuracy, WEAPONS_TYPES.PROJECTILE)
        {
            _iAmmo = projectileWeapon._iAmmo;
        }

        public override IPART Clone()
        {
            return new PROJECTILE_WEAPON(this);
        }

        /// <summary>
        /// Check the actual number of ammo 
        /// </summary>
        /// <returns>int</returns>
        public override int GetAmmo()
        {
            return _iAmmo;
        }

        public override int GetHeatEffect()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Checking if the weapon has any ammunition and remove 1 ammo per use if true.
        /// </summary>
        /// <returns>True if there's ammunition in the weapon, else false</returns>
        public override bool RemoveAmmo()
        {
            if(_iAmmo >= 1)
            {
                _iAmmo--;
                return true;
            }
            return false;
        }
    }
}
