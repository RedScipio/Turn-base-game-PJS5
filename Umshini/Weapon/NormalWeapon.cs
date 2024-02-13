
namespace Weapon
{
    public class NORMAL_WEAPON : AWEAPON
    {
        public NORMAL_WEAPON(int iId, string sName, int iArmor, int iLifePoint, int iDamage, int iPowerConsumption, int iAccuracy, int iMinAccuracy) : base(iId, sName, iArmor, iLifePoint, iDamage, iPowerConsumption, iAccuracy, iMinAccuracy, eWeaponType)
        {
        }

        public override int GetSpecificity()
        {
            throw new System.NotImplementedException();
        }
    }
}
