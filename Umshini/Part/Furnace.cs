﻿using Battle;
using Newtonsoft.Json;

namespace Part
{
    /// <summary>
    /// Author : Beowulf-0 (Mehdi)
    /// Version : 0.1
    /// Date : 13/02/2024
    /// </summary>
    public class FURNACE : APART, IFURNACE
    {
        
        private int _iRestartLimit = -1;

        public FURNACE(FURNACE furnace) : base(furnace._iId, furnace._sName, furnace._iArmor, furnace._iLifePoint, furnace._sUrlImage)
        {
            _iRestartLimit = furnace._iRestartLimit;
        }

        [JsonConstructor]
        public FURNACE(string iId, string sName, int iArmor, int iLifePoint, string sUrlImage, int iRestartLimit = -1) : base(iId, sName, iArmor, iLifePoint, sUrlImage)
        {
            _iRestartLimit = iRestartLimit;
        }

        /// <summary>
        /// Represents the limit above which the robot must be refueled to use his weapons 
        /// </summary>
        /// <returns>int</returns>
        public int GetRestartLimit()
        {
            return _iRestartLimit;
        }

        public override IPART Clone()
        {
            return new FURNACE(this);
        }
    }
}
