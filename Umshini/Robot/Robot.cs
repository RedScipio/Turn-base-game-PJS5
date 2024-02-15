using Pilot;
using System.Collections.Generic;

namespace Robot
{
    public class ROBOT : IROBOT
    {
        private IFURNACE _pFurnace;
        private ILEG _pLeg;

        private readonly List<IWEAPON> _lWeapon;

        private bool _bNeedRestart = false;
        private int _iFuel = 100;

        /// <summary>
        /// ROBOT represent a robot used by a pilot during a Battle
        /// </summary>
        /// <developer>MBI</developer>
        /// <param name="furnace"></param>
        /// <param name="leg"></param>
        /// <param name="leftWeapon"></param>
        /// <param name="rightWeapon"></param>
        public ROBOT(IFURNACE furnace, ILEG leg, IWEAPON leftWeapon, IWEAPON rightWeapon)
        {
            _pFurnace = furnace;
            _pLeg = leg;
            _lWeapon = new List<IWEAPON> { leftWeapon , rightWeapon };
        }

        /// <summary>
        /// Check if the Furnace is destroyed
        /// </summary>
        /// <developer>MBI</developer>
        /// <returns> bool </returns>
        public bool IsDestroy()
        {
            return _pFurnace.IsBroken();
        }

        /// <summary>
        /// Check if the selected weapon is usable
        /// </summary>
        /// <developer>MBI</developer>
        /// <param name="iWeaponChoice"></param>
        /// <returns></returns>
        public bool WeaponIsUsable(int iWeaponChoice)
        {
            IWEAPON pWeapon = _lWeapon[iWeaponChoice];

            //Former line : if (pWeapon.IsBroken() || pWeapon.GetPowerConsumption() <= _iFuel)
            if (pWeapon.IsBroken() || pWeapon.GetPowerConsumption() > _iFuel)
            {
                return false;
            }

            switch (pWeapon.TypeIs())
            {
                case WEAPONS_TYPES.MELEE:
                    if (_pLeg.IsBroken())
                    {
                        return false;
                    }
                    return true;
                case WEAPONS_TYPES.PROJECTILE:
                    if (pWeapon.GetAmmo() < 1)
                    {
                        return false;
                    }
                    return true;
                default:
                    return true;
            }
        }

        /// <summary>
        /// Use to take damage from another robot
        /// </summary>
        /// <developer>MBI</developer>
        /// <param name="iDamage"></param>
        /// <param name="eType"></param>
        /// <returns></returns>
        private int TakeDamage(int iDamage, PARTS_TYPES eType)
        {
            switch (eType)
            {
                case PARTS_TYPES.LEFT_WEAPON:
                    return _lWeapon[0].TakeDamage(iDamage);
                case PARTS_TYPES.RIGHT_WEAPON:
                    return _lWeapon[1].TakeDamage(iDamage);
                case PARTS_TYPES.FURNACE:
                    return _pFurnace.TakeDamage(iDamage);
                case PARTS_TYPES.LEG:
                    return _pLeg.TakeDamage(iDamage);
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Remove fuel when needed
        /// </summary>
        /// <developer>MBI</developer>
        /// <param name="iFuel"></param>
        private void RemoveFuel(int iFuel)
        {
            if (_iFuel < 1 && iFuel < 1)
            {
                return;
            }

            _iFuel = _iFuel - iFuel;
            if (_iFuel < 1)
            {
                _iFuel = 0;
                _bNeedRestart = true;
            }
        }

        /// <summary>
        /// Deal damage to another robot
        /// </summary>
        /// <developer>MBI</developer>
        /// <param name="pEnnemiRobot"></param>
        /// <param name="iWeaponChoice"></param>
        /// <param name="eTargetChoice"></param>
        /// <returns> int </returns>
        public int DealDamage(ROBOT pEnnemiRobot, int iWeaponChoice, PARTS_TYPES eTargetChoice)
        {
            IWEAPON pWeapon = _lWeapon[iWeaponChoice];

            if (pWeapon.TypeIs() == WEAPONS_TYPES.THERMAL)
            {
                pEnnemiRobot.RemoveFuel(pWeapon.GetHeatEffect());
            }


            return pEnnemiRobot.TakeDamage(pWeapon.GetDamage(), eTargetChoice);
        }

        /// <summary>
        /// If the weapon has fired
        /// </summary>
        /// <developer>MBI</developer>
        /// <param name="iWeaponChoice"></param>
        public void WeaponFired(int iWeaponChoice)
        {
            IWEAPON pWeapon = _lWeapon[iWeaponChoice];

            if(pWeapon.TypeIs() == WEAPONS_TYPES.PROJECTILE)
            {
                pWeapon.RemoveAmmo();
            }

            RemoveFuel(pWeapon.GetPowerConsumption());
        }

        /// <summary>
        /// Refuel Robot furnace
        /// </summary>
        /// <developer>MBI</developer>
        /// <param name="iFuel"></param>
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

        /// <summary>
        /// Repair the armor of one part of the robot
        /// </summary>
        /// <developer>MBI</developer>
        /// <param name="iRepairPoints"></param>
        /// <param name="iTargetChoice"></param>
        public void RepairRobotArmor(int iRepairPoints, PARTS_TYPES iTargetChoice)
        {
            switch (iTargetChoice)
            {
                case PARTS_TYPES.LEFT_WEAPON:
                    _lWeapon[0].RepairArmor(iRepairPoints);
                    return;
                case PARTS_TYPES.RIGHT_WEAPON:
                    _lWeapon[1].RepairArmor(iRepairPoints);
                    return;
                case PARTS_TYPES.FURNACE:
                    _pFurnace.RepairArmor(iRepairPoints);
                    return;
                case PARTS_TYPES.LEG:
                    _pLeg.RepairArmor(iRepairPoints);
                    return;
                default:
                    // TO-DO: return custom error
                    return;
            }
        }

        /// <summary>
        /// Repair the life points of one part of the robot
        /// </summary>
        /// <developer>MBI</developer>
        /// <param name="iRepairPoints"></param>
        /// <param name="eTargetChoice"></param>
        public void RepairRobotLifePoint(int iRepairPoints, PARTS_TYPES eTargetChoice)
        {
            switch (eTargetChoice)
            {
                case PARTS_TYPES.LEFT_WEAPON:
                    _lWeapon[0].RepairLife(iRepairPoints);
                    return;
                case PARTS_TYPES.RIGHT_WEAPON:
                    _lWeapon[1].RepairLife(iRepairPoints);
                    return;
                case PARTS_TYPES.FURNACE:
                    _pFurnace.RepairLife(iRepairPoints);
                    return;
                case PARTS_TYPES.LEG:
                    _pLeg.RepairLife(iRepairPoints);
                    return;
                default:
                    return;
            }
        }

        /// <summary>
        /// Check if the robot can attack the chosen part
        /// </summary>
        /// <developer>MBI</developer>
        /// <param name="eChoice"></param>
        /// <returns></returns>
        public bool AttackTargetIsValid(PARTS_TYPES eChoice)
        {
            switch (eChoice)
            {
                case PARTS_TYPES.LEFT_WEAPON:
                    if (_lWeapon[0].GetLife() > 0)
                    {
                        return true;
                    }
                    return false;
                case PARTS_TYPES.RIGHT_WEAPON:
                    if (_lWeapon[1].GetLife() > 0)
                    {
                        return true;
                    }
                    return false;
                case PARTS_TYPES.FURNACE:
                    if (_pFurnace.GetLife() > 0)
                    {
                        return true;
                    }
                    return false;
                case PARTS_TYPES.LEG:
                    if (_pLeg.GetLife() > 0)
                    {
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Check if it's possible to repair the life chosen part of the robot
        /// </summary>
        /// <developer>MBI</developer>
        /// <param name="eChoice"></param>
        /// <returns></returns>
        public bool RepairLifeTargetIsValid(PARTS_TYPES eChoice)
        {
            switch (eChoice)
            {
                case PARTS_TYPES.LEFT_WEAPON:
                    if (_lWeapon[0].GetLife() < _lWeapon[0].GetMaxLife())
                    {
                        return true;
                    }
                    return false;
                case PARTS_TYPES.RIGHT_WEAPON:
                    if (_lWeapon[1].GetLife() < _lWeapon[1].GetMaxLife())
                    {
                        return true;
                    }
                    return false;
                case PARTS_TYPES.FURNACE:
                    if (_pFurnace.GetLife() < _pFurnace.GetMaxLife())
                    {
                        return true;
                    }
                    return false;
                case PARTS_TYPES.LEG:
                    if (_pLeg.GetLife() < _pLeg.GetMaxLife())
                    {
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Check if it's possible to repair the armor chosen part of the robot
        /// </summary>
        /// <developer>MBI</developer>
        /// <param name="eChoice"></param>
        /// <returns></returns>
        public bool RepairArmorTargetIsValid(PARTS_TYPES eChoice)
        {
            switch (eChoice)
            {
                case PARTS_TYPES.LEFT_WEAPON:
                    if (_lWeapon[0].GetArmor() < _lWeapon[0].GetMaxArmor())
                    {
                        return true;
                    }
                    return false;
                case PARTS_TYPES.RIGHT_WEAPON:
                    if (_lWeapon[1].GetArmor() < _lWeapon[1].GetMaxArmor())
                    {
                        return true;
                    }
                    return false;
                case PARTS_TYPES.FURNACE:
                    if (_pFurnace.GetArmor() < _pFurnace.GetMaxArmor())
                    {
                        return true;
                    }
                    return false;
                case PARTS_TYPES.LEG:
                    if (_pLeg.GetArmor() < _pLeg.GetMaxArmor())
                    {
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Getter for _iFuel
        /// </summary>
        /// <developer>MBI</developer>
        /// <returns> int </returns>
        public int GetFuel()
        {
            return _iFuel;
        }

        /// <summary>
        /// return true if the robot need to restart
        /// </summary>
        /// <returns> bool </returns>
        public bool NeedToRestart()
        {
            return _bNeedRestart;
        }
    }
}
