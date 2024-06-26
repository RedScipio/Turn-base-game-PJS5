﻿

using Battle;
using Newtonsoft.Json;

namespace Part
{
    /// <summary>
    /// Author : Beowulf-0 (Mehdi)
    /// Version : 0.1
    /// Date : 13/02/2024
    /// </summary>
    public class LEG : APART, ILEG
    {
        /// <summary>
        /// Represents the legs of the robot, which influences his accuracy
        /// </summary>
        /// <param name="iId"></param>
        /// <param name="sName"></param>
        /// <param name="iArmor"></param>
        /// <param name="iLegsNumber"></param>
        [JsonConstructor]
        public LEG(string iId, string sName, int iArmor, int iLegsNumber, string sUrlImage) : base(iId, sName, iArmor, iLegsNumber, sUrlImage)
        {
            
        }

        public LEG(LEG legs) : base(legs._iId, legs._sName, legs._iArmor, legs._iLifePoint, legs._sUrlImage)
        {
            
        }

        public override IPART Clone()
        {
            return new LEG(this);
        }
    }
}
