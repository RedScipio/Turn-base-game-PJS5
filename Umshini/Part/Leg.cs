

using Battle;

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
        public LEG(string iId, string sName, int iArmor, int iLegsNumber, string sUrlImage) : base(iId, sName, iArmor, iLegsNumber, sUrlImage)
        {
            
        }
    }
}
