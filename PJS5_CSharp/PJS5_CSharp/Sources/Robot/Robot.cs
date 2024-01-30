using PJS5_CSharp.Sources.Robot;
using PJS5_CSharp.Sources.Weapon.ProjectileWeapon;
using WEAPON;

namespace PJS5_CSharp.Sources.Robot
{
    public enum PARTS_TYPE
    {
        LEFT_WEAPON,
        RIGHT_WEAPON,
        FURNACE,
        LEGS
    }

    public class Robot
    {
        private FURNACE _pFurnace;
        private LEGS _pLegs;
        private IWeapon _pLeftWeapon;
        private IWeapon _pRightWeapon;
        private bool _bNeedRestart = false;
        private int _iFuel = 100;

        public Robot(FURNACE furnace, LEGS legs, IWeapon leftWeapon, IWeapon rightWeapon)
        {
            _pFurnace = furnace;
            _pLegs = legs;
            _pLeftWeapon = leftWeapon;
            _pRightWeapon = rightWeapon;
        }

        ~Robot()
        {
            _pFurnace = null;
            _pLegs = null;
            _pLeftWeapon = null;
            _pRightWeapon = null;
        }

        public bool IsDestroy()
        {
            return _pFurnace.IsBroken();
        }

        public bool WeaponIsUsable(int iChoice)
        {
            IWeapon pWeapon = _pLeftWeapon;
            if (iChoice == 2)
            {
                pWeapon = _pRightWeapon;
            }
            switch (pWeapon.TypeIs())
            {
                case WEAPON_TYPE.ABSTRACT_WEAPON:
                    return false;
                case WEAPON_TYPE.MELEE_WEAPON:
                    if (_pLegs.GetLife() > 0 && pWeapon.GetLife() > 0 && pWeapon.GetPowerConsumption() <= _iFuel)
                    {
                        return true;
                    }
                    return false;
                case WEAPON_TYPE.PROJECTILE_WEAPON:
                    if (pWeapon.GetSpecificity() > 0 && pWeapon.GetLife() > 0 && pWeapon.GetPowerConsumption() <= _iFuel)
                    {
                        return true;
                    }
                    return false;
                default:
                    if (pWeapon.GetLife() > 0 && pWeapon.GetPowerConsumption() <= _iFuel)
                    {
                        return true;
                    }
                    return false;
            }
        }

        public int DealDamage(Robot pEnnemiRobot, int iChoiceWeapon, int iTargetChoice)
        {
            IWeapon pWeapon = _pLeftWeapon;
            if (iChoiceWeapon == 2)
            {
                pWeapon = _pRightWeapon;
            }
            if (pWeapon.TypeIs() == WEAPON_TYPE.THERMAL_WEAPON)
            {
                pEnnemiRobot.RemoveFuel(pWeapon.GetSpecificity());
            }
            switch (iTargetChoice)
            {
                case 1:
                    return pEnnemiRobot.TakeDamage(pWeapon.GetDamage(), PARTS_TYPE.LEFT_WEAPON);
                case 2:
                    return pEnnemiRobot.TakeDamage(pWeapon.GetDamage(), PARTS_TYPE.RIGHT_WEAPON);
                case 3:
                    return pEnnemiRobot.TakeDamage(pWeapon.GetDamage(), PARTS_TYPE.LEGS);
                case 4:
                    return pEnnemiRobot.TakeDamage(pWeapon.GetDamage()  , PARTS_TYPE.FURNACE);
                default:
                    return 0;
            }
        }


        private int TakeDamage(int iDamage, PARTS_TYPE eType)
        {
            switch (eType)
            {
                case PARTS_TYPE.LEFT_WEAPON:
                    return _pLeftWeapon.TakeDamage(iDamage);
                case PARTS_TYPE.RIGHT_WEAPON:
                    return _pRightWeapon.TakeDamage(iDamage);
                case PARTS_TYPE.LEGS:
                    return _pLegs.TakeDamage(iDamage);
                case PARTS_TYPE.FURNACE:
                    return _pFurnace.TakeDamage(iDamage);
                default:
                    return 0;
            }
        }

        public void RepairRobotArmor(int iRepairPoints, int iTargetChoice)
        {
            switch (iTargetChoice)
            {
                case 1:
                    _pLeftWeapon.RepairArmor(iRepairPoints);
                    return;
                case 2:
                    _pRightWeapon.RepairArmor(iRepairPoints);
                    return;
                case 3:
                    _pLegs.RepairArmor(iRepairPoints);
                    return;
                case 4:
                    _pFurnace.RepairArmor(iRepairPoints);
                    return;
                default:
                    return;
            }
        }

        public void RepairRobotLifePoint(int iRepairPoints, int iTargetChoice)
        {
            switch (iTargetChoice)
            {
                case 1:
                    _pLeftWeapon.RepairLife(iRepairPoints);
                    return;
                case 2:
                    _pRightWeapon.RepairLife(iRepairPoints);
                    return;
                case 3:
                    _pLegs.RepairLife(iRepairPoints);
                    return;
                case 4:
                    _pFurnace.RepairLife(iRepairPoints);
                    return;
                default:
                    return;
            }
        }

        public bool AttackTargetIsValid(int iChoice)
        {
            switch (iChoice)
            {
                case 1:
                    if (_pLeftWeapon.GetLife() > 0)
                    {
                        return true;
                    }
                    return false;
                case 2:
                    if (_pRightWeapon.GetLife() > 0)
                    {
                        return true;
                    }
                    return false;
                case 3:
                    if (_pLegs.GetLife() > 0)
                    {
                        return true;
                    }
                    return false;
                case 4:
                    if (_pFurnace.GetLife() > 0)
                    {
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }

        public bool RepairLifeTargetIsValid(int iChoice)
        {
            switch (iChoice)
            {
                case 1:
                    if (_pLeftWeapon.GetLife() < _pLeftWeapon.GetMaxLife())
                    {
                        return true;
                    }
                    return false;
                case 2:
                    if (_pRightWeapon.GetLife() < _pRightWeapon.GetMaxLife())
                    {
                        return true;
                    }
                    return false;
                case 3:
                    if (_pLegs.GetLife() < _pLegs.GetMaxLife())
                    {
                        return true;
                    }
                    return false;
                case 4:
                    if (_pFurnace.GetLife() < _pLegs.GetMaxLife())
                    {
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }

        public bool RepairArmorTargetIsValid(int iChoice)
        {
            switch (iChoice)
            {
                case 1:
                    if (_pLeftWeapon.GetArmor() < _pLeftWeapon.GetMaxArmor())
                    {
                        return true;
                    }
                    return false;
                case 2:
                    if (_pRightWeapon.GetArmor() < _pRightWeapon.GetMaxArmor())
                    {
                        return true;
                    }
                    return false;
                case 3:
                    if (_pLegs.GetArmor() < _pLegs.GetMaxArmor())
                    {
                        return true;
                    }
                    return false;
                case 4:
                    if (_pFurnace.GetArmor() < _pLegs.GetMaxArmor())
                    {
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }

        public void WeaponFired(int iWeapon)
        {
            IWeapon pWeapon = _pLeftWeapon;
            if (iWeapon == 2)
            {
                pWeapon = _pRightWeapon;
            }
            switch (pWeapon.TypeIs())
            {
                case WEAPON_TYPE.ABSTRACT_WEAPON:
                    return;
                case WEAPON_TYPE.PROJECTILE_WEAPON:
                    ((PROJECTILE_WEAPON)pWeapon).RemoveAmmo();
                    return;
                default:
                    RemoveFuel(pWeapon.GetPowerConsumption());
                    return;
            }
        }

        public void RemoveFuel(int iFuel)
        {
            if (iFuel < 0)
                return;

            _iFuel = _iFuel - iFuel;
            if (_iFuel <= 0)
            {
                _iFuel = 0;
                _bNeedRestart = true;
            }
        }

        public void Refuel(int iFuel)
        {
            _iFuel = _iFuel + iFuel;
            if (_iFuel > 100)
            {
                _iFuel = 100;
            }
            if (_iFuel >= _pFurnace.GetRestartLimit())
            {
                _bNeedRestart = false;
            }
        }

        public int GetFuel()
        {
            return _iFuel;
        }

        public bool NeedToRestart()
        {
            return _bNeedRestart;
        }

        public int GetFurnaceLife()
        {
            return _pFurnace.GetLife();
        }

        public int GetFurnaceArmor()
        {
            return _pFurnace.GetArmor();
        }

        public int GetFurnaceMaxLife()
        {
            return _pFurnace.GetMaxLife();
        }

        public int GetFurnaceMaxArmor()
        {
            return _pFurnace.GetMaxArmor();
        }

        public int GetLegsLife()
        {
            return _pLegs.GetLife();
        }

        public int GetLegsArmor()
        {
            return _pLegs.GetArmor();
        }

        public int GetLegsMaxLife()
        {
            return _pLegs.GetMaxLife();
        }

        public int GetLegsMaxArmor()
        {
            return _pLegs.GetMaxArmor();
        }

        public int GetLeftWeaponLife()
        {
            return _pLeftWeapon.GetLife();
        }

        public int GetLeftWeaponArmor()
        {
            return _pLeftWeapon.GetArmor();
        }

        public int GetLeftWeaponMaxLife()
        {
            return _pLeftWeapon.GetMaxLife();
        }

        public int GetLeftWeaponMaxArmor()
        {
            return _pLeftWeapon.GetMaxArmor();
        }

        public int GetLeftWeaponType()
        {
            return _pLeftWeapon.GetType();
        }

        public int GetLeftWeaponDamage()
        {
            return _pLeftWeapon.GetDamage();
        }

        public int GetLeftWeaponPowerConsumption()
        {
            return _pLeftWeapon.GetPowerConsumption();
        }

        public int GetLeftWeaponAccuracy()
        {
            return _pLeftWeapon.GetAccuracy();
        }

        public int GetLeftWeaponMinAccuracy()
        {
            return _pLeftWeapon.GetMinAccuracy();
        }

        public int GetLeftWeaponSpecificity()
        {
            return _pLeftWeapon.GetSpecificity();
        }

        public int GetLeftWeaponHitChance()
        {
            return GetLeftWeaponMinAccuracy() + GetLeftWeaponAccuracy() - GetLeftWeaponMinAccuracy() / GetLegsMaxLife() * GetLegsLife();
        }

        public int GetRightWeaponLife()
        {
            return _pRightWeapon.GetLife();
        }

        public int GetRightWeaponArmor()
        {
            return _pRightWeapon.GetArmor();
        }

        public int GetRightWeaponMaxLife()
        {
            return _pRightWeapon.GetMaxLife();
        }

        public int GetRightWeaponMaxArmor()
        {
            return _pRightWeapon.GetMaxArmor();
        }

        public int GetRightWeaponType()
        {
            return _pRightWeapon.GetType();
        }

        public int GetRightWeaponDamage()
        {
            return _pRightWeapon.GetDamage();
        }

        public int GetRightWeaponPowerConsumption()
        {
            return _pRightWeapon.GetPowerConsumption();
        }

        public int GetRightWeaponAccuracy()
        {
            return _pRightWeapon.GetAccuracy();
        }

        public int GetRightWeaponMinAccuracy()
        {
            return _pRightWeapon.GetMinAccuracy();
        }

        public int GetRightWeaponSpecificity()
        {
            return _pRightWeapon.GetSpecificity();
        }

        public int GetRightWeaponHitChance()
        {
            return GetRightWeaponMinAccuracy() + GetRightWeaponAccuracy() - GetRightWeaponMinAccuracy() / GetLegsMaxLife() * GetLegsLife();
        }

        public void SetWeapon(int iWeaponPart, IWeapon pWeapon)
        {
            if(iWeaponPart == 1)
            {
                _pLeftWeapon = pWeapon;
            }
            else
            {
                _pRightWeapon = pWeapon;
            }
        }
    }
}