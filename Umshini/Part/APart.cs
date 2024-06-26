using Battle;
using Newtonsoft.Json;
using System;


namespace Part
{
    /// <summary>
    /// Author : Beowulf-0 (Mehdi)
    /// Version : 0.1
    /// Date : 13/02/2024
    /// </summary>
    public abstract class APART : IPART
    {
        [JsonProperty("id")]
        protected readonly string _iId;
        [JsonProperty("name")]
        protected readonly string _sName;
        [JsonProperty("armor")]
        protected int _iArmor;
        [JsonProperty("life_points")]
        protected int _iLifePoint;
        [JsonProperty("url_image")]
        protected string _sUrlImage;
        private protected readonly int _iMaxArmor;
        private protected readonly int _iMaxLifePoint;
        
        /// <summary>
        /// Represents an interchangeable part of a robot
        /// </summary>
        /// <param name="iId"></param>
        /// <param name="sName"></param>
        /// <param name="iArmor"></param>
        /// <param name="iLifePoint"></param>
        /// <param name="iMaxArmor"></param>
        /// <param name="iMaxLifePoint"></param>
        /// <param name="sUrlImage"></param>
        public APART(string iId, string sName, int iArmor, int iLifePoint, string sUrlImage)
        {
            _iId = iId;
            _sName = sName;
            _iArmor = iArmor;
            _iLifePoint = iLifePoint;
            _iMaxArmor = iArmor;
            _iMaxLifePoint = iLifePoint;
            _sUrlImage = sUrlImage;
        }

        public APART(APART apart)
        {
            _iId = apart._iId;
            _sName = apart._sName;
            _iArmor = apart._iArmor;
            _iLifePoint = apart._iLifePoint;
            _iMaxArmor = apart._iArmor;
            _iMaxLifePoint = apart._iLifePoint;
            _sUrlImage = apart._sUrlImage;
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
                _iArmor -= iDamage;
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

        /// <summary>
        /// The actual life points of a robot part
        /// </summary>
        /// <returns></returns>
        public int GetLife()
        {
            return _iLifePoint;
        }

        /// <summary>
        /// The maximum lifepoints of a robot part
        /// </summary>
        /// <returns></returns>
        public int GetMaxLife()
        {
            return _iMaxLifePoint;
        }

        /// <summary>
        /// The actual armor points of a robot part
        /// </summary>
        /// <returns></returns>
        public int GetArmor()
        {
            return _iArmor;
        }

        /// <summary>
        /// The maximum armor points of a robot part
        /// </summary>
        /// <returns></returns>
        public int GetMaxArmor()
        {
            return _iMaxArmor;
        }

        public override string ToString()
        {
            return "Id de l'arme : " + _iId + "\nNom de l'arme : " + _sName 
                + "\nPV : " + _iLifePoint + "\nArmure : " + _iArmor;
        }

        public abstract IPART Clone();
    }
}
