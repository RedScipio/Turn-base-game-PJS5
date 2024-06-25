using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reinforcement
{
    internal interface ISimulation
    {
        void StartSimulation();
        void NextState();
        bool IsOver();
        double[][] GetSimulationResults();
    }
}
