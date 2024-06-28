using Battle;

namespace Reinforcement
{
    public class QLearning : IQLearning
    {
        private readonly IROBOT _IARobot;
        private readonly IPILOT _robotToKill;

        private double[][] _qTable;

        private readonly Random _random;
        private readonly double _gamma;

        private readonly IState _typeState;

        private int _nbVictories;
        private int _nbDefeats;

        public int NbVictories { get => _nbVictories; }
        public int NbDefeats { get => _nbDefeats; }

        public QLearning(IROBOT r1, IPILOT r2, IState state, double gamma)
        {
            this._IARobot = r1;
            this._robotToKill = r2;

            this._typeState = state;
            this._random = new Random();
            this._gamma = gamma;

            this._nbVictories = 0;
            this._nbDefeats = 0;

            GenerateQTable();
        }

        /// <summary>
        /// Generates Q table
        /// </summary>
        /// <developer>CME</developer>
        private void GenerateQTable()
        {
            int nbActions = Enum.GetValues(typeof(Action)).Length;
            int nbStates = ((int)this._typeState.GetMaxValue()) + 1;
            this._qTable = new double[nbStates][];

            for (int i = 0; i < this._typeState.GetMaxValue() + 1; i++)
            {
                this._qTable[i] = new double[nbActions];
                for (int j = 0; j < nbActions; j++)
                {
                    this._qTable[i][j] = 0;
                }
            }
        }

        public void Run(int nbBattles)
        {
            this.TrainingAgent(nbBattles, 0, 0, 0);
        }

        public void TrainingAgent(int nbTrains, float exploration, float decrementationExploration, float minExploration)
        {
            this._nbVictories = 0;
            this._nbDefeats = 0;

            for (int i = 0; i < nbTrains; i++)
            {
                IROBOT agent = this._IARobot.Clone();
                IPILOT opponent = this._robotToKill.Clone();

                double currentState = this._typeState.ConvertNumber(agent, opponent.GetRobot());

                while (!IsSimulationOver(agent, opponent.GetRobot()))
                {
                    this.TakeAction(agent, opponent, currentState, exploration);
                }

                if (agent.IsDestroy())
                {
                    this._nbDefeats++;
                }
                else
                {
                    this._nbVictories++;
                }

                exploration = Math.Max(exploration - decrementationExploration, minExploration);
            }
        }

        private void TakeAction(IROBOT agent, IPILOT opposent, double currentState, float exploration)
        {
            Action[] validActions = QLearning.GetLegalActions(agent, opposent.GetRobot());
            int indexAction;
            if (_random.Next(0, 100)/100 <= exploration)
                indexAction = _random.Next(0, validActions.Length);
            else
                indexAction = _qTable[(int)currentState].ToList().IndexOf(_qTable[(int)currentState].Max());

            int action = (int)validActions[indexAction];
            NextState(agent, opposent, (Action)action);

            double saReward = QLearning.GetReward(agent, opposent.GetRobot());
            double nsReward = _qTable[action].Max();
            double qCurrentState = saReward + (_gamma * nsReward);
            _qTable[(int)currentState][action] = qCurrentState;
        }

        /// <summary>
        /// Allows the agent to perform an action against the robot, and returns the new state of the game.
        /// </summary>
        /// <param name="agent">Agent Robot</param>
        /// <param name="opponent">Robot opponent</param>
        /// <param name="action">Type of action performed by the agent robot</param>
        /// <developer>CME</developer>
        /// <returns>State following agent robot action</returns>
        private double NextState(IROBOT agent, IPILOT opponent, Action action)
        {

            if (action == Action.LEFT_WEAPON_ATTACK_LEGS)
            {
                agent.DealDamage(opponent.GetRobot(), 0, TARGET_TYPE.LEG);
            }

            else if (action == Action.LEFT_WEAPON_ATTACK_LEFT_WEAPON)
            {
                agent.DealDamage(opponent.GetRobot(), 0, TARGET_TYPE.LEFT_WEAPON);
            }

            else if (action == Action.LEFT_WEAPON_ATTACK_RIGHT_WEAPON)
            {
                agent.DealDamage(opponent.GetRobot(), 0, TARGET_TYPE.RIGHT_WEAPON);
            }

            else if (action == Action.LEFT_WEAPON_ATTACK_FURNACE)
            {
                agent.DealDamage(opponent.GetRobot(), 0, TARGET_TYPE.FURNACE);
            }

            else if (action == Action.RIGHT_WEAPON_ATTACK_LEGS)
            {
                agent.DealDamage(opponent.GetRobot(), 1, TARGET_TYPE.LEG);
            }

            else if (action == Action.RIGHT_WEAPON_ATTACK_LEFT_WEAPON)
            {
                agent.DealDamage(opponent.GetRobot(), 1, TARGET_TYPE.LEFT_WEAPON);
            }

            else if (action == Action.RIGHT_WEAPON_ATTACK_RIGHT_WEAPON)
            {
                agent.DealDamage(opponent.GetRobot(), 1, TARGET_TYPE.RIGHT_WEAPON);
            }

            else if (action == Action.RIGHT_WEAPON_ATTACK_FURNACE)
            {
                agent.DealDamage(opponent.GetRobot(), 1, TARGET_TYPE.FURNACE);
            }

            if (!opponent.GetRobot().IsDestroy())
                opponent.PlayTurnAuto(agent, false);

            return this._typeState.ConvertNumber(agent, opponent.GetRobot());
        }

        /// <summary>
        /// Indicates whether the simulation is complete
        /// </summary>
        /// <developer>CME</developer>
        /// <returns>True if the simulation is complete, false otherwise</returns>
        private static bool IsSimulationOver(IROBOT agent, IROBOT opponent)
        {
            return agent.IsDestroy() || opponent.IsDestroy() || agent.GetFuel() == 0;
        }

        /// <summary>
        /// Checks whether the action given as a parameter is possible in the current state.
        /// </summary>
        /// <param name="agent">Agent Robot</param>
        /// <param name="opponent">Robot opponent</param>
        /// <param name="action">Type of action performed by the agent robot</param>
        /// <developer>CME</developer>
        /// <returns>True if the action is legal, false otherwise</returns>
        private static bool IsLegalAction(IROBOT agent, IROBOT opponent, Action action)
        {
            if (action == Action.LEFT_WEAPON_ATTACK_LEGS)
            {
                return agent.WeaponIsUsable(0) && opponent.GetLegsLife() > 0;
            }

            else if (action == Action.LEFT_WEAPON_ATTACK_LEFT_WEAPON)
            {
                return agent.WeaponIsUsable(0) && opponent.GetLeftWeaponLife() > 0;
            }

            else if (action == Action.LEFT_WEAPON_ATTACK_RIGHT_WEAPON)
            {
                return agent.WeaponIsUsable(0) && opponent.GetRightWeaponLife() > 0;
            }

            else if (action == Action.LEFT_WEAPON_ATTACK_FURNACE)
            {
                return agent.WeaponIsUsable(0) && opponent.GetFurnaceLife() > 0;
            }

            else if (action == Action.RIGHT_WEAPON_ATTACK_LEGS)
            {
                return agent.WeaponIsUsable(1) && opponent.GetLegsLife() > 0;
            }

            else if (action == Action.RIGHT_WEAPON_ATTACK_LEFT_WEAPON)
            {
                return agent.WeaponIsUsable(1) && opponent.GetLeftWeaponLife() > 0;
            }

            else if (action == Action.RIGHT_WEAPON_ATTACK_RIGHT_WEAPON)
            {
                return agent.WeaponIsUsable(1) && opponent.GetRightWeaponLife() > 0;
            }

            else if (action == Action.RIGHT_WEAPON_ATTACK_FURNACE)
            {
                return agent.WeaponIsUsable(1) && opponent.GetFurnaceLife() > 0;
            }

            return true;
        }

        /// <summary>
        /// Lists possible actions in the current state of the simulation
        /// </summary>
        /// <param name="agent">Agent Robot</param>
        /// <param name="opponent">Robot opponent</param>
        /// <developer>CME</developer>
        /// <returns>Possible actions in the current state of the simulation</returns>
        private static Action[] GetLegalActions(IROBOT agent, IROBOT opponent)
        {
            List<Action> legalActions = new List<Action>();

            foreach (Action action in Enum.GetValues(typeof(Action)))
            {
                if (IsLegalAction(agent, opponent, action))
                {
                    legalActions.Add(action);
                }
            }

            return legalActions.ToArray();
        }

        private static double GetReward(IROBOT agent, IROBOT opponent)
        {
            if (agent.IsDestroy() || agent.GetFuel() == 0)
            {
                return (double)Rewards.LOSE;
            }

            if (opponent.IsDestroy())
            {
                return (double)Rewards.WIN;
            }

            return (double)Rewards.LEGAL;
        }


        private enum Rewards
        {
            WIN = 1,
            LEGAL = 0,
            LOSE = -1,
            //ILLEGAL = -100,
        }
    }
}
