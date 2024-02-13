
using Robot;

namespace Weapon
{
    /// <summary>
    /// Author : Beowulf-0 (Mehdi)
    /// Version : 0.1
    /// Date : 13/02/2024
    /// </summary>
    public class THERMAL_WEAPON : AWEAPON
    {
        private readonly int _iFuelBurn = -1;

        /// <summary>
        /// Represents a weapon that could burn down fuel of an enemy robot 
        /// </summary>
        /// <param name="iId"></param>
        /// <param name="sName"></param>
        /// <param name="iArmor"></param>
        /// <param name="iLifePoint"></param>
        /// <param name="iDamage"></param>
        /// <param name="iPowerConsumption"></param>
        /// <param name="iAccuracy"></param>
        /// <param name="iMinAccuracy"></param>
        /// <param name="iFuelBurn"></param>
        public THERMAL_WEAPON(int iId, string sName, int iArmor, int iLifePoint, int iDamage, int iPowerConsumption, int iAccuracy, int iMinAccuracy, int iFuelBurn) : base(iId, sName, iArmor, iLifePoint, iDamage, iPowerConsumption, iAccuracy, iMinAccuracy, WEAPONS_TYPES.THERMAL)
        {
            _iFuelBurn = iFuelBurn;
        }

        public override int GetAmmo()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// represents the amount of fuel burned
        /// </summary>
        /// <returns></returns>
        public override int GetHeatEffect()
        {
            return _iFuelBurn;
        }

        public override bool RemoveAmmo()
        {
            throw new System.NotImplementedException();
        }
    }
}
