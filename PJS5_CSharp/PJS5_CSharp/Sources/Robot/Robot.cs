using PJS5_CSharp.Sources.Weapon.ProjectileWeapon;
using WEAPON;
using System;
using static PJS5_CSharp.Sources.Robot.IPARTS;

namespace PJS5_CSharp.Sources.Robot
{
    public enum PARTS_TYPE
    {
        LEFT_WEAPON = WEAPON_SIDE.LEFT_WEAPON,
        RIGHT_WEAPON = WEAPON_SIDE.RIGHT_WEAPON,
        LEGS = 2,
        FURNACE = 3,
    }

    public enum WEAPON_SIDE
    {
        LEFT_WEAPON,
        RIGHT_WEAPON
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

        public bool WeaponIsUsable(WEAPON_SIDE iChoice)
        {
            IWeapon pWeapon = _pLeftWeapon;
            if (iChoice == WEAPON_SIDE.RIGHT_WEAPON)
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

        public int DealDamage(Robot pEnnemiRobot, WEAPON_SIDE iChoiceWeapon, int iTargetChoice)
        {
            IWeapon pWeapon = _pLeftWeapon;
            if (iChoiceWeapon == WEAPON_SIDE.RIGHT_WEAPON)
            {
                pWeapon = _pRightWeapon;
            }
            if (pWeapon.TypeIs() == WEAPON_TYPE.THERMAL_WEAPON)
            {
                pEnnemiRobot.RemoveFuel(pWeapon.GetSpecificity());
            }

            PARTS_TYPE eTargetChoice = (PARTS_TYPE) iTargetChoice;

            switch (eTargetChoice)
            {
                case PARTS_TYPE.LEFT_WEAPON:
                    return pEnnemiRobot.TakeDamage(pWeapon.GetDamage(), PARTS_TYPE.LEFT_WEAPON);
                case PARTS_TYPE.RIGHT_WEAPON:
                    return pEnnemiRobot.TakeDamage(pWeapon.GetDamage(), PARTS_TYPE.RIGHT_WEAPON);
                case PARTS_TYPE.LEGS:
                    return pEnnemiRobot.TakeDamage(pWeapon.GetDamage(), PARTS_TYPE.LEGS);
                case PARTS_TYPE.FURNACE:
                    return pEnnemiRobot.TakeDamage(pWeapon.GetDamage(), PARTS_TYPE.FURNACE);
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



        public delegate void RepairRobotDelegate(int iRepair);

        private void RepairRobot(PARTS_TYPE eChoice, int repairPoint, RepairRobotDelegate R)
        {
            switch (eChoice)
            {
                case PARTS_TYPE.LEFT_WEAPON:
                    R.Invoke(repairPoint);
                    return;

                case PARTS_TYPE.RIGHT_WEAPON:
                    R.Invoke(repairPoint);
                    return;

                case PARTS_TYPE.LEGS:
                    R.Invoke(repairPoint);
                    return;

                case PARTS_TYPE.FURNACE:
                    R.Invoke(repairPoint);
                    return;

                default:
                    return;
            }
        }

        /*
         * Comprendre les délégués avant tirage
        public void NewRepairRobotLifePoint(PARTS_TYPE iTargetChoice, int damage)
        {
            RepairRobot(iTargetChoice, damage, IPARTS.RepairLife);
        }

        public void NewRepairRobotArmor(PARTS_TYPE iTargetChoice, int damage)
        {
            RepairRobot(iTargetChoice, damage, IPARTS.RepairArmor);
        }
        */

        public void RepairRobotArmor(int iRepairPoints, PARTS_TYPE iTargetChoice)
        {
            switch (iTargetChoice)
            {
                case PARTS_TYPE.LEFT_WEAPON:
                    _pLeftWeapon.RepairArmor(iRepairPoints);
                    return;
                case PARTS_TYPE.RIGHT_WEAPON:
                    _pRightWeapon.RepairArmor(iRepairPoints);
                    return;
                case PARTS_TYPE.LEGS:
                    _pLegs.RepairArmor(iRepairPoints);
                    return;
                case PARTS_TYPE.FURNACE:
                    _pFurnace.RepairArmor(iRepairPoints);
                    return;
                default:
                    return;
            }
        }


        public void RepairRobotLifePoint(int iRepairPoints, PARTS_TYPE iTargetChoice)
        {
            switch (iTargetChoice)
            {
                case PARTS_TYPE.LEFT_WEAPON:
                    _pLeftWeapon.RepairLife(iRepairPoints);
                    return;
                case PARTS_TYPE.RIGHT_WEAPON:
                    _pRightWeapon.RepairLife(iRepairPoints);
                    return;
                case PARTS_TYPE.LEGS:
                    _pLegs.RepairLife(iRepairPoints);
                    return;
                case PARTS_TYPE.FURNACE:
                    _pFurnace.RepairLife(iRepairPoints);
                    return;
                default:
                    return;
            }
        }

        public bool AttackTargetIsValid(int iChoice)
        {
            PARTS_TYPE eChoice = (PARTS_TYPE) iChoice;
            Console.WriteLine(eChoice);
            switch (eChoice)
            {
                case PARTS_TYPE.LEFT_WEAPON:
                    return _pLeftWeapon.GetLife() > 0;

                case PARTS_TYPE.RIGHT_WEAPON:
                    return _pRightWeapon.GetLife() > 0;

                case PARTS_TYPE.LEGS:
                    return _pLegs.GetLife() > 0;

                case PARTS_TYPE.FURNACE:
                    return _pFurnace.GetLife() > 0;

                default:
                    return false;
            }
        }

        private bool RepairTargetIsValid(int iChoice, Func<IPARTS, int> getValue, Func<IPARTS, int> getMaxValue)
        {
            PARTS_TYPE eChoice = (PARTS_TYPE)iChoice;

            switch (eChoice)
            {
                case PARTS_TYPE.LEFT_WEAPON:
                    return getValue(_pLeftWeapon) < getMaxValue(_pLeftWeapon);

                case PARTS_TYPE.RIGHT_WEAPON:
                    return getValue(_pRightWeapon) < getMaxValue(_pRightWeapon);

                case PARTS_TYPE.LEGS:
                    return getValue(_pLegs) < getMaxValue(_pLegs);

                case PARTS_TYPE.FURNACE:
                    return getValue(_pFurnace) < getMaxValue(_pFurnace);

                default:
                    return false;
            }
        }

        public bool RepairLifeTargetIsValid(int iChoice)
        {
            return RepairTargetIsValid(iChoice, part => part.GetLife(), part => part.GetMaxLife());
        }

        public bool RepairArmorTargetIsValid(int iChoice)
        {
            return RepairTargetIsValid(iChoice, part => part.GetArmor(), part => part.GetMaxArmor());
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
            _iFuel -= iFuel;
            if (_iFuel <= 0)
            {
                _iFuel = 0;
                _bNeedRestart = true;
            }
        }

        public void Refuel(int iFuel)
        {
            _iFuel += iFuel;
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
            return _pLeftWeapon.GetWeaponType();
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
            return CalculateWeaponHitChance(GetLeftWeaponMinAccuracy(), GetLeftWeaponAccuracy(), GetLegsMaxLife(), GetLegsLife());
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
            return _pRightWeapon.GetWeaponType();
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
            return CalculateWeaponHitChance(GetRightWeaponMinAccuracy(), GetRightWeaponAccuracy(), GetLegsMaxLife(), GetLegsLife());
        }

        private int CalculateWeaponHitChance(int minAccuracy, int accuracy, int maxLife, int life)
        {
            return minAccuracy + accuracy - minAccuracy / maxLife * life;
        }
    }
}