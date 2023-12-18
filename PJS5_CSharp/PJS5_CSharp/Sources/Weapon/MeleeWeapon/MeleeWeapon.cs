using WEAPON;

namespace PJS5_CSharp.Sources.Weapon.MeleeWeapon
{
    public class MELEE_WEAPON : IWeapon
    {
        public MELEE_WEAPON(int iId, string sName, int iArmor, int iLifePoint, int iDamage, int iPowerConsumption, int iAccuracy, int iMinAccuracy)
            : base(iId, sName, iArmor, iLifePoint, iDamage, iPowerConsumption, iAccuracy, iMinAccuracy, WEAPON_TYPE.MELEE_WEAPON)
        {
        }
    }
}
