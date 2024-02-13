
namespace Weapon
{
    public class MELEE_WEAPON : AWEAPON
    {
        public MELEE_WEAPON(int iId, string sName, int iArmor, int iLifePoint, int iDamage, int iPowerConsumption, int iAccuracy, int iMinAccuracy) : base(iId, sName, iArmor, iLifePoint, iDamage, iPowerConsumption, iAccuracy, iMinAccuracy)
        {
        }

        public override int GetSpecificity()
        {
            throw new System.NotImplementedException();
        }
    }
}
