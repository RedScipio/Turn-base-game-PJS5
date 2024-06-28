using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reinforcement
{
    internal interface IQLearning
    {
        /// <summary>
        /// Used to train the agent against the opposing robot
        /// </summary>
        /// <param name="nbTrains">Number of training sessions</param>
        /// <param name="explorationPourcentage">Chance to explore with each action</param>
        /// <param name="decrementationExploration">Decrease exploration percentage for each action</param>
        /// <param name="minExploration">Minimum exploration for each action</param>
        void TrainingAgent(int nbTrains, float explorationPourcentage, float decrementationExploration, float minExploration);

        /// <summary>
        /// Runs the game as in training, but with 0% exploration change
        /// </summary>
        /// <param name="nbBattles">Number of battles to play</param>
        void Run(int nbBattles);

        /// <summary>
        /// Number of agent wins after the last Run()
        /// </summary>
        int NbVictories { get; }

        /// <summary>
        /// Number of agent defeats after the last Run()
        /// </summary>
        int NbDefeats { get; }
    }
}
