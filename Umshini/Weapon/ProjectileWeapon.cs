
namespace Weapon
{
    /// <summary>
    /// Author : Beowulf-0 (Mehdi)
    /// Version : 0.1
    /// Date : 13/02/2024
    /// </summary>
    public class PROJECTILE_WEAPON : AWEAPON
    {
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
        public PROJECTILE_WEAPON(int iId, string sName, int iArmor, int iLifePoint, int iDamage, int iPowerConsumption, int iAccuracy, int iMinAccuracy, int iAmmo) : base(iId, sName, iArmor, iLifePoint, iDamage, iPowerConsumption, iAccuracy, iMinAccuracy)
        {
            _iAmmo = iAmmo;
        }

        /// <summary>
        /// Remove one ammo after each attack with this weapon
        /// </summary>
        public void RemoveAmmo()
        {
            this._iAmmo--;
        }

        /// <summary>
        /// Represents the actual number of ammunition contained in the weapon.
        /// </summary>
        /// <returns></returns>
        public override int GetSpecificity()
        {
            return _iAmmo;
        }
    }
}
