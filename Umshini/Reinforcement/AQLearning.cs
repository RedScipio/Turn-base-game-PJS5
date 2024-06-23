using Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reinforcement
{
    internal abstract class AQLearning : IQLearning
    {
        private protected IROBOT IARobot;
        private protected IROBOT RobotToKill;

        private protected double[][] Qtable;

        internal AQLearning(IROBOT r1, IROBOT r2)
        {
            this.Qtable = GenerateQTable();

            this.IARobot = r1;
            this.RobotToKill = r2;
        }
        
        private double[][] GenerateQTable()
        {
            int nbActions = Enum.GetValues(typeof(Action)).Length;
            double[][] Qtable = new double[nbActions][];

            for (int i = 0; i < nbActions; i++)
            {
                this.Qtable[i] = new double[nbActions];
                for (int j = 0; j < nbActions; j++)
                {
                    this.Qtable[i][j] = 0;
                }
            }

            return Qtable;
        }

        public void TrainingAgent(int nbTrains)
        {
            IROBOT[] robots = new IROBOT[] { this.IARobot, this.RobotToKill };

            for (int i = 0; i < nbTrains; i++)
            {
                if (IsLegalAction(robots[0], robots[1]))
                {
                    // Update Qtable
                }
            }
        }

        public abstract void Run();

        // Permet de lister les actions légales
        private protected abstract Action[] GetLegalActions(IROBOT agent, IROBOT opponent);

        // Permet de savoir si l'action est légale
        private protected abstract bool IsLegalAction(IROBOT agent, IROBOT opponent);

        // Permet d'avoir la liste des actions valides
        private protected abstract Action[] GetValidActions(IROBOT agent, IROBOT opposent);

        // Pemret de savoir si la partie est terminée
        private protected abstract bool IsGameOver(IROBOT r1, IROBOT r2);

        // Permet de porter un coup
        private protected abstract State NextState(IROBOT agent, IROBOT opponent, Action action);
    }
}
