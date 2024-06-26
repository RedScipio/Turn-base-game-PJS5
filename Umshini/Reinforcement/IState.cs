using Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reinforcement
{
    public interface IState
    {
        /// <summary>
        /// Converts the current state of the environment into an integer number
        /// </summary>
        /// <param name="agent"></param>
        /// <param name="opponent"></param>
        /// <returns>Integer representing the current state of the environment</returns>
        int ConvertNumber(IROBOT agent, IROBOT opponent);

        /// <summary>
        /// Gives the highest integer that can be obtained with this type of method
        /// </summary>
        /// <returns>Highest integer that can be obtained with this type of method</returns>
        int GetMaxValue();
    }
}
