
using Battle;
using Newtonsoft.Json;

namespace Weapon
{
    /// <summary>
    /// Author : Beowulf-0 (Mehdi)
    /// Version : 0.1
    /// Date : 13/02/2024
    /// </summary>
    public class NORMAL_WEAPON : AWEAPON
    {
        /// <summary>
        /// Represents a weapon with no specificity, having no strength but no weakness
        /// </summary>
        /// <param name="iId"></param>
        /// <param name="sName"></param>
        /// <param name="iArmor"></param>
        /// <param name="iLifePoint"></param>
        /// <param name="iDamage"></param>
        /// <param name="iPowerConsumption"></param>
        /// <param name="iAccuracy"></param>
        /// <param name="iMinAccuracy"></param>
        [JsonConstructor]
        public NORMAL_WEAPON(string iId, string sName, int iArmor, int iLifePoint, string sUrlImage, int iDamage, int iPowerConsumption, int iAccuracy, int iMinAccuracy) : base(iId, sName, iArmor, iLifePoint, sUrlImage, iDamage, iPowerConsumption, iAccuracy, iMinAccuracy, WEAPONS_TYPES.NORMAL)
        {
        }

        public NORMAL_WEAPON(NORMAL_WEAPON normalWeapon) : base(normalWeapon._iId, normalWeapon._sName, normalWeapon._iArmor, normalWeapon._iLifePoint, normalWeapon._sUrlImage, normalWeapon._iDamage, normalWeapon._iPowerConsumption, normalWeapon._iAccuracy, normalWeapon._iMinAccuracy, WEAPONS_TYPES.NORMAL)
        {
        }

        public override IPART Clone()
        {
            return new NORMAL_WEAPON(this);
        }

        public override int GetAmmo()
        {
            throw new System.NotImplementedException();
        }

        public override int GetHeatEffect()
        {
            throw new System.NotImplementedException();
        }

        public override bool RemoveAmmo()
        {
            throw new System.NotImplementedException();
        }
    }
}
