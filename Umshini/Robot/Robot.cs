using Battle;
using System.Collections.Generic;

namespace Robot
{
    public class ROBOT : IROBOT
    {
        private const int MAX_FUEL = 100;

        private readonly IFURNACE _pFurnace;
        private readonly ILEG _pLeg;

        private readonly List<IWEAPON> _lWeapon;

        private bool _bNeedRestart = false;
        private int _iFuel;

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
            _lWeapon = new List<IWEAPON> { leftWeapon, rightWeapon };
            _iFuel = this.GetMaxFuel();
        }

        public IROBOT Clone()
        {
            return new ROBOT((IFURNACE) _pFurnace.Clone(), (ILEG) _pLeg.Clone(), (IWEAPON) _lWeapon[0].Clone(), (IWEAPON) _lWeapon[1].Clone());
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
        /// Check if the selected weapon is usable.
        /// Return false if it is broken or if the robot 
        /// lack fuel (or gets legs broken (Melee) 
        /// or lack ammo (Projectile)), else true.
        /// </summary>
        /// <developer>MBI</developer>
        /// <param name="iWeaponChoice"></param>
        /// <returns> bool </returns>
        public bool WeaponIsUsable(int iWeaponChoice)
        {
            if (iWeaponChoice < 0) return false;

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
        public int TakeDamage(int iDamage, TARGET_TYPE eType)
        {
            switch (eType)
            {
                case TARGET_TYPE.FURNACE:
                    return _pFurnace.TakeDamage(iDamage);
                case TARGET_TYPE.LEG:
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
        /// <param name="iFuel"> the amount of fuel
        /// removed </param>
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
        public int DealDamage(IROBOT pEnnemiRobot, int iWeaponChoice, TARGET_TYPE eTargetChoice)
        {
            IWEAPON pWeapon = _lWeapon[iWeaponChoice];
            this.RemoveFuel(pWeapon.GetPowerConsumption());

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

            if (pWeapon.TypeIs() == WEAPONS_TYPES.PROJECTILE)
            {
                pWeapon.RemoveAmmo();
            }

            RemoveFuel(pWeapon.GetPowerConsumption());
        }

        /// <summary>
        /// Refuel Robot furnace
        /// </summary>
        /// <developer>MBI</developer>
        /// <param name="iFuel"> amount of fuel refueled </param>
        public void Refuel(int iFuel)
        {
            _iFuel += iFuel;

            if (_iFuel > MAX_FUEL)
            {
                _iFuel = MAX_FUEL;
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
        public void RepairRobotArmor(int iRepairPoints, TARGET_TYPE eTargetChoice)
        {
            switch (eTargetChoice)
            {
                case TARGET_TYPE.FURNACE:
                    _pFurnace.RepairArmor(iRepairPoints);
                    return;
                case TARGET_TYPE.LEG:
                    _pLeg.RepairArmor(iRepairPoints);
                    return;
                default:
                    int iWeapon = (int) eTargetChoice - (int)TARGET_TYPE.LEFT_WEAPON;
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
        public void RepairRobotLifePoint(int iRepairPoints, TARGET_TYPE eTargetChoice)
        {
            switch (eTargetChoice)
            {
                case TARGET_TYPE.FURNACE:
                    _pFurnace.RepairLife(iRepairPoints);
                    return;
                case TARGET_TYPE.LEG:
                    _pLeg.RepairLife(iRepairPoints);
                    return;
                default:
                    _lWeapon[(int)eTargetChoice - (int)TARGET_TYPE.LEFT_WEAPON].RepairLife(iRepairPoints);
                    return;
            }
        }

        /// <summary>
        /// Check if the robot can attack the chosen part.
        /// Return true if the life points of the part are
        /// above 0, else false.
        /// </summary>
        /// <developer>MBI</developer>
        /// <param name="eChoice"></param>
        /// <returns></returns>
        public bool AttackTargetIsValid(TARGET_TYPE eChoice)
        {
            switch (eChoice)
            {
                case TARGET_TYPE.FURNACE:
                    if (_pFurnace.GetLife() > 0)
                    {
                        return true;
                    }
                    return false;
                case TARGET_TYPE.LEG:
                    if (_pLeg.GetLife() > 0)
                    {
                        return true;
                    }
                    return false;
                default:
                    int iWeapon = (int)eChoice - (int)TARGET_TYPE.LEFT_WEAPON;
                    if (_lWeapon[iWeapon].GetLife() > 0)
                    {
                        return true;
                    }
                    return false;
            }
        }

        /// <summary>
        /// Check if it's possible to repair the life 
        /// chosen part of the robot. Return true if part's
        /// life point are below max life points value,
        /// else false.
        /// </summary>
        /// <developer>MBI</developer>
        /// <param name="eChoice"></param>
        /// <returns></returns>
        public bool RepairLifeTargetIsValid(TARGET_TYPE eTargetChoice)
        {
            switch (eTargetChoice)
            {
                case TARGET_TYPE.FURNACE:
                    if (_pFurnace.GetLife() < _pFurnace.GetMaxLife())
                    {
                        return true;
                    }
                    return false;
                case TARGET_TYPE.LEG:
                    if (_pLeg.GetLife() < _pLeg.GetMaxLife())
                    {
                        return true;
                    }
                    return false;
                default:
                    int iWeapon = (int)eTargetChoice - (int)TARGET_TYPE.LEFT_WEAPON;
                    if (_lWeapon[iWeapon].GetLife() < _lWeapon[iWeapon].GetMaxLife())
                    {
                        return true;
                    }
                    return false;
            }
        }

        /// <summary>
        /// Check if it's possible to repair the armor
        /// from the chosen part of the robot. 
        /// Return true if the current armor value is strictly 
        /// below the max armor value, else false.
        /// </summary>
        /// <developer>MBI</developer>
        /// <param name="eChoice"></param>
        /// <returns></returns>
        public bool RepairArmorTargetIsValid(TARGET_TYPE eTargetChoice)
        {
            switch (eTargetChoice)
            {
                case TARGET_TYPE.FURNACE:
                    {
                        if (_pFurnace.GetArmor() < _pFurnace.GetMaxArmor())
                        {
                            return true;
                        }

                        return false;
                    }
                case TARGET_TYPE.LEG:
                    {
                        if (_pLeg.GetArmor() < _pLeg.GetMaxArmor())
                        {
                            return true;
                        }

                        return false;
                    }
                default:
                    {
                        int iWeapon = (int)eTargetChoice - (int)TARGET_TYPE.LEFT_WEAPON;

                        if (_lWeapon[iWeapon].GetMaxArmor() < _lWeapon[iWeapon].GetMaxArmor())
                        {
                            return true;
                        }

                        return false;
                    }
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

        /// <summary>
        /// Getter for the selected weapon damage
        /// </summary>
        /// <param name="iWeapon"> the selected weapon </param>
        /// <returns></returns>
        public int GetWeaponDamage(int iWeapon)
        {
            return this._lWeapon[iWeapon].GetDamage();
        }

        public int GetWeaponHitChance(int iWeapon)
        {

            return this._lWeapon[iWeapon].GetMinAccuracy() + (_lWeapon[iWeapon].GetAccuracy() - _lWeapon[iWeapon].GetMinAccuracy()) / _pLeg.GetMaxLife() * _pLeg.GetLife();
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

        public IWEAPON GetWeapon(int iWeapon)
        {
            return _lWeapon[iWeapon];
        }

        /// <summary>
        /// Return a copy of _lWeapon list to be use by the GUI
        /// We don't want to be able to modify the list or weapons
        /// </summary>
        /// <returns></returns>
        public List<IWEAPON> GetWeapons()
        {
            return new List<IWEAPON>(_lWeapon);
        }

        public int GetFurnaceArmor()
        {
            return _pFurnace.GetArmor();
        }

        public int GetFurnaceMaxArmor()
        {
            return _pFurnace.GetMaxArmor();
        }

        public int GetFurnaceMaxLife()
        {
            return _pFurnace.GetMaxLife();
        }

        public int GetFurnaceRestartLimit()
        {
           return _pFurnace.GetRestartLimit();
        }

        public int GetLegsArmor()
        {
            return _pLeg.GetArmor();
        }

        public int GetLegsMaxArmor()
        {
            return _pLeg.GetMaxArmor();
        }

        public int GetLegsLife()
        {
            return _pLeg.GetLife();
        }

        public int GetLegsMaxLife()
        {
            return _pLeg.GetMaxLife();
        }

        public int GetLeftWeaponArmor()
        {
            return _lWeapon[0].GetArmor();
        }

        public int GetLeftWeaponMaxArmor()
        {
            return _lWeapon[0].GetMaxArmor();
        }

        public int GetLeftWeaponLife()
        {
            return _lWeapon[0].GetLife();
        }

        public int GetLeftWeaponMaxLife()
        {
            return _lWeapon[0].GetMaxLife();
        }

        public int GetRightWeaponArmor()
        {
            return _lWeapon[1].GetArmor();
        }

        public int GetRightWeaponMaxArmor()
        {
            return _lWeapon[1].GetMaxArmor();
        }

        public int GetRightWeaponLife()
        {
            return _lWeapon[1].GetLife();
        }

        public int GetRightWeaponMaxLife()
        {
            return _lWeapon[1].GetMaxLife();
        }

        public int GetMaxFuel()
        {
            return ROBOT.MAX_FUEL;
        }
    }
}
