using Pilot;
using System.Collections.Generic;

namespace Robot
{
    public class ROBOT : IROBOT
    {
        private readonly IFURNACE _pFurnace;
        private readonly ILEG _pLeg;

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
        public int TakeDamage(int iDamage, PARTS_TYPES eType)
        {
            switch (eType)
            {
                case PARTS_TYPES.FURNACE:
                    return _pFurnace.TakeDamage(iDamage);
                case PARTS_TYPES.LEG:
                    return _pLeg.TakeDamage(iDamage);
                default:
                    int iWeapon = (int)eType - (int)PARTS_TYPES.WEAPON;
                    return _lWeapon[iWeapon].TakeDamage(iDamage);
            }
        }

        /// <summary>
        /// Remove fuel when needed
        /// </summary>
        /// <developer>MBI</developer>
        /// <param name="iFuel"></param>
        public void RemoveFuel(int iFuel)
        {
            if (_iFuel < 1 && iFuel < 1)
            {
                return;
            }

            _iFuel -= iFuel;
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
        public int DealDamage(IROBOT pEnnemiRobot, int iWeaponChoice, PARTS_TYPES eTargetChoice)
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

        /// <summary>
        /// Repair the armor of one part of the robot
        /// </summary>
        /// <developer>MBI</developer>
        /// <param name="iRepairPoints"></param>
        /// <param name="iTargetChoice"></param>
        public void RepairRobotArmor(int iRepairPoints, PARTS_TYPES eTargetChoice)
        {
            switch (eTargetChoice)
            {
                case PARTS_TYPES.FURNACE:
                    _pFurnace.RepairArmor(iRepairPoints);
                    return;
                case PARTS_TYPES.LEG:
                    _pLeg.RepairArmor(iRepairPoints);
                    return;
                default:
                    int iWeapon = (int)eTargetChoice - (int)PARTS_TYPES.WEAPON;
                    _lWeapon[iWeapon].RepairArmor(iRepairPoints);
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
                case PARTS_TYPES.FURNACE:
                    _pFurnace.RepairLife(iRepairPoints);
                    return;
                case PARTS_TYPES.LEG:
                    _pLeg.RepairLife(iRepairPoints);
                    return;
                default:
                    _lWeapon[(int)eTargetChoice - (int)PARTS_TYPES.WEAPON].RepairLife(iRepairPoints);
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
                    int iWeapon = (int)eChoice - (int)PARTS_TYPES.WEAPON;
                    if (_lWeapon[iWeapon].GetLife() > 0)
                    {
                        return true;
                    }
                    return false;
            }
        }

        /// <summary>
        /// Check if it's possible to repair the life chosen part of the robot
        /// </summary>
        /// <developer>MBI</developer>
        /// <param name="eChoice"></param>
        /// <returns></returns>
        public bool RepairLifeTargetIsValid(PARTS_TYPES eTargetChoice)
        {
            switch (eTargetChoice)
            {
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
                    int iWeapon = (int)eTargetChoice - (int)PARTS_TYPES.WEAPON;
                    if (_lWeapon[iWeapon].GetLife() < _lWeapon[iWeapon].GetMaxLife())
                    {
                        return true;
                    }
                    return false;
            }
        }

        /// <summary>
        /// Check if it's possible to repair the armor chosen part of the robot
        /// </summary>
        /// <developer>MBI</developer>
        /// <param name="eChoice"></param>
        /// <returns></returns>
        public bool RepairArmorTargetIsValid(PARTS_TYPES eTargetChoice)
        {
            switch (eTargetChoice)
            {
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
                    int iWeapon = (int)eTargetChoice - (int)PARTS_TYPES.WEAPON;
                    if (_lWeapon[iWeapon].GetMaxArmor() < _lWeapon[iWeapon].GetMaxArmor())
                    {
                        return true;
                    }
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
        /// Return true if the robot need to restart
        /// </summary>
        /// <developer>CME</developer>
        /// <returns> bool </returns>
        public bool NeedToRestart()
        {
            return _bNeedRestart;
        }

        public int GetFurnaceLife()
        {
            return this._pFurnace.GetLife();
        }

        public int GetWeaponDamage(int iWeapon)
        {
            return this._lWeapon[iWeapon].GetDamage();
        }

        public int GetWeaponHitChance(int iWeapon)
        {
            return 100;
        }

        public bool IsFurnaceBroken()
        {
            return this._pFurnace.IsBroken();
        }

        public bool IsLegsBroken()
        {
            return this._pLeg.IsBroken();
        }

        public bool IsWeaponBroken(int iWeapon)
        {
            return _lWeapon[iWeapon].IsBroken();
        }
    }
}
