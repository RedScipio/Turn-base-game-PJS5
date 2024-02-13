
namespace Weapon
{
    public class THERMAL_WEAPON : AWEAPON
    {
        private readonly int _iFuelBurn = -1;

        public THERMAL_WEAPON(int iId, string sName, int iArmor, int iLifePoint, int iDamage, int iPowerConsumption, int iAccuracy, int iMinAccuracy, int iFuelBurn) : base(iId, sName, iArmor, iLifePoint, iDamage, iPowerConsumption, iAccuracy, iMinAccuracy)
        {
            _iFuelBurn = iFuelBurn;
        }

        public override int GetSpecificity()
        {
            return _iFuelBurn;
        }
    }
}
