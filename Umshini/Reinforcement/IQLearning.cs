using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reinforcement
{
    internal interface IQLearning
    {
        void TrainingAgent(int nbTrains, float explorationPourcentage, float decrementationExploration, float minExploration);
        void Run();
    }
}
