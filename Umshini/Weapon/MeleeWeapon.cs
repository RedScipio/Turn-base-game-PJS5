
using Battle;
using Newtonsoft.Json;

namespace Weapon
{
    /// <summary>
    /// Author : Beowulf-0 (Mehdi)
    /// Version : 0.1
    /// Date : 13/02/2024
    /// </summary>
    public class MELEE_WEAPON : AWEAPON
    {
        /// <summary>
        /// Represents a powerful weapon that become much less accurate for each robot leg destroyed, and unusable if all of them
        /// </summary>
        /// <param name="iId"></param>
        /// <param name="sName"></param>
        /// <param name="iArmor"></param>
        /// <param name="iLifePoint"></param>
        /// <param name="iDamage"></param>
        /// <param name="iPowerConsumption"></param>
        /// <param name="iAccuracy"></param>
        /// <param name="iMinAccuracy"></param>*
        [JsonConstructor]
        public MELEE_WEAPON(string iId, string sName, int iArmor, int iLifePoint, string sUrlImage, int iDamage, int iPowerConsumption, int iAccuracy, int iMinAccuracy) : base(iId, sName, iArmor, iLifePoint, sUrlImage, iDamage, iPowerConsumption, iAccuracy, iMinAccuracy, WEAPONS_TYPES.MELEE)
        {
        }

        public MELEE_WEAPON(MELEE_WEAPON meleeWeapon) : base(meleeWeapon._iId, meleeWeapon._sName, meleeWeapon._iArmor, meleeWeapon._iLifePoint, meleeWeapon._sUrlImage, meleeWeapon._iDamage, meleeWeapon._iPowerConsumption, meleeWeapon._iAccuracy, meleeWeapon._iMinAccuracy, WEAPONS_TYPES.MELEE)
        {
        }

        public override IPART Clone()
        {
            return new MELEE_WEAPON(this);
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
