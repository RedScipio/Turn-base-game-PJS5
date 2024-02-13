﻿using Robot;
using System;


namespace Part
{
    /// <summary>
    /// Author : Beowulf-0 (Mehdi)
    /// 
    /// </summary>
    public abstract class APART : IPART
    {
        private readonly int _iId;
        private readonly string _sName;
        private int _iArmor;
        private int _iLifePoint;
        private readonly int _iMaxArmor;
        private readonly int _iMaxLifePoint;

        /// <summary>
        /// Represents an interchangeable part of a robot
        /// </summary>
        /// <param name="iId"></param>
        /// <param name="sName"></param>
        /// <param name="iArmor"></param>
        /// <param name="iLifePoint"></param>
        /// <param name="iMaxArmor"></param>
        /// <param name="iMaxLifePoint"></param>
        public APART(int iId, string sName, int iArmor, int iLifePoint)
        {
            _iId = iId;
            _sName = sName;
            _iArmor = iArmor;
            _iLifePoint = iLifePoint;
            _iMaxArmor = iArmor;
            _iMaxLifePoint = iLifePoint;
        }

        /// <summary>
        /// Checking if the part of a robot is broken
        /// </summary>
        /// <returns>True if the robot's is inferior to 1, else false</returns>
        public bool IsBroken()
        {
            return _iLifePoint < 1;
        }

        /// <summary>
        /// Inflict an amount of damage on the targeted robot part
        /// </summary>
        /// <param name="iDamage"></param>
        /// <returns>The damage taken</returns>
        public int TakeDamage(int iDamage)
        {
            int iResult = 0;
            int iRemainingDamage = iDamage;
            if (_iArmor > 0)
            {
                iRemainingDamage = iDamage - _iArmor;
                iResult = _iArmor - iDamage;
                _iArmor = _iArmor - iDamage;
            }
            if (_iLifePoint > 0 && iRemainingDamage > 0)
            {
                _iLifePoint--;
                iResult = iDamage;
                if (_iLifePoint > 0)
                {
                    _iArmor = _iMaxArmor;
                }
                else
                {
                    _iArmor = 0;
                }
            }
            Console.WriteLine("Dealt damage to " + _iId + ", " + _sName);
            return iResult;
        }

        /// <summary>
        /// Add an amount of armor point to repair the targeted part of the robot
        /// </summary>
        /// <param name="iRepair"></param>
        public void RepairArmor(int iRepair)
        {
            if (_iArmor < _iMaxArmor)
            {
                _iArmor = _iArmor + iRepair;
                if (_iArmor > _iMaxArmor)
                {
                    _iArmor = _iMaxArmor;
                }
            }
        }

        /// <summary>
        /// Repair an amount of life points
        /// </summary>
        /// <param name="iRepair"></param>
        public void RepairLife(int iRepair)
        {
            if (_iLifePoint < _iMaxLifePoint)
            {
                _iLifePoint = _iLifePoint + iRepair;
                if (_iLifePoint > _iMaxLifePoint)
                {
                    _iLifePoint = _iMaxLifePoint;
                }
            }
        }
    }
}