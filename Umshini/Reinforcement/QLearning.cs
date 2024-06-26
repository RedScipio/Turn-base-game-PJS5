using Battle;
using Part;
using Robot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weapon;

namespace Reinforcement
{
    public class QLearning : IQLearning
    {
        private protected IROBOT _IARobot;
        private protected IROBOT _robotToKill;

        private protected double[][] _qTable;

        private protected readonly Random _random = new Random();
        private protected double _gamma;

        private protected IState _typeState;

        public QLearning(IROBOT r1, IROBOT r2, IState state, double gamma)
        {
            this._qTable = GenerateQTable();

            this._IARobot = r1;
            this._robotToKill = r2;

            this._typeState = state;
            this._gamma = gamma;
        }

        /// <summary>
        /// Generates Q table
        /// </summary>
        /// <developer>CME</developer>
        /// <returns>Q table</returns>
        private double[][] GenerateQTable()
        {
            int nbActions = Enum.GetValues(typeof(Action)).Length;
            double[][] Qtable = new double[nbActions][];

            for (int i = 0; i < nbActions; i++)
            {
                this._qTable[i] = new double[nbActions];
                for (int j = 0; j < nbActions; j++)
                {
                    this._qTable[i][j] = 0;
                }
            }

            return Qtable;
        }


        public void Run()
        {
            throw new NotImplementedException();
        }

        private protected IROBOT GetClone(IROBOT robot)
        {
            IFURNACE cloneFurnace = new FURNACE("1", "Normal Furnace", robot.GetFurnaceMaxArmor(), robot.GetFurnaceMaxLife(), "", robot.GetFurnaceRestartLimit());
            ILEG cloneLegs = new LEG("1", "Basic Legs", robot.GetLegsMaxArmor(), robot.GetLegsMaxLife(), "");
            IWEAPON cloneLeftWeap = new MELEE_WEAPON("1", "Melee Weapon", 3, 3, "", 1, 15, 100, 15);
            IWEAPON cloneRightWeap = new NORMAL_WEAPON("1", "Basic Normal Weapon", 3, 1, "", 1, 15, 80, 40);

            return new ROBOT(cloneFurnace, cloneLegs, cloneLeftWeap, cloneRightWeap);
        }



        public void TrainingAgent(int nbTrains)
        {
            IROBOT[] robots = new IROBOT[] { this._IARobot, this._robotToKill };

            for (int i=0; i < nbTrains; i++)
            {
                double initialState = this._typeState.ConvertNumber(robots[0], robots[1]);
                double currentState = this._typeState.ConvertNumber(robots[0], robots[1]);

                while (!IsSimulationOver(robots[0], robots[1]))
                {

                    // List Actions
                    Action[] legalActions = GetLegalActions(robots[0], robots[1]);

                    Action action = legalActions[0];

                    currentState = NextState(robots[0], robots[1], action);
                }
            }
        }

        private int TakeAction(IROBOT agent, IROBOT opposent, double currentState)
        {
            Action[] validActions = this.GetLegalActions(agent, opposent);
            int randomIndexAction = _random.Next(0, validActions.Length);
            int action = (int) validActions[randomIndexAction];

            double saReward = this.GetReward(agent, opposent);
            double nsReward = _qTable[action].Max();
            double qCurrentState = saReward + (_gamma * nsReward);
            _qTable[(int) currentState][action] = qCurrentState;
            int newState = action;
            return newState;
        }

        /// <summary>
        /// Allows the agent to perform an action against the robot, and returns the new state of the game.
        /// </summary>
        /// <param name="agent">Agent Robot</param>
        /// <param name="opponent">Robot opponent</param>
        /// <param name="action">Type of action performed by the agent robot</param>
        /// <developer>CME</developer>
        /// <returns>State following agent robot action</returns>
        private protected double NextState(IROBOT agent, IROBOT opponent, Action action)
        {

            if (action == Action.LEFT_WEAPON_ATTACK_LEGS)
            {
                agent.DealDamage(opponent, 0, TARGET_TYPE.LEG);
            }

            else if (action == Action.LEFT_WEAPON_ATTACK_LEFT_WEAPON)
            {
                agent.DealDamage(opponent, 0, TARGET_TYPE.LEFT_WEAPON);
            }

            else if (action == Action.LEFT_WEAPON_ATTACK_RIGHT_WEAPON)
            {
                agent.DealDamage(opponent, 0, TARGET_TYPE.RIGHT_WEAPON);
            }

            else if (action == Action.LEFT_WEAPON_ATTACK_FURNACE)
            {
                agent.DealDamage(opponent, 0, TARGET_TYPE.FURNACE);
            }

            else if (action == Action.RIGHT_WEAPON_ATTACK_LEGS)
            {
                agent.DealDamage(opponent, 1, TARGET_TYPE.LEG);
            }

            else if (action == Action.RIGHT_WEAPON_ATTACK_LEFT_WEAPON)
            {
                agent.DealDamage(opponent, 1, TARGET_TYPE.LEFT_WEAPON);
            }

            else if (action == Action.RIGHT_WEAPON_ATTACK_RIGHT_WEAPON)
            {
                agent.DealDamage(opponent, 1, TARGET_TYPE.RIGHT_WEAPON);
            }

            else if (action == Action.RIGHT_WEAPON_ATTACK_FURNACE)
            {
                agent.DealDamage(opponent, 1, TARGET_TYPE.FURNACE);
            }

            return this._typeState.ConvertNumber(agent, opponent);
        }

        /// <summary>
        /// Indicates whether the simulation is complete
        /// </summary>
        /// <developer>CME</developer>
        /// <returns>True if the simulation is complete, false otherwise</returns>
        private protected bool IsSimulationOver(IROBOT agent, IROBOT opponent)
        {
            return agent.IsDestroy() || opponent.IsDestroy();
        }

        /// <summary>
        /// Checks whether the action given as a parameter is possible in the current state.
        /// </summary>
        /// <param name="agent">Agent Robot</param>
        /// <param name="opponent">Robot opponent</param>
        /// <param name="action">Type of action performed by the agent robot</param>
        /// <developer>CME</developer>
        /// <returns>True if the action is legal, false otherwise</returns>
        private protected bool IsLegalAction(IROBOT agent, IROBOT opponent, Action action)
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
        private protected Action[] GetLegalActions(IROBOT agent, IROBOT opponent)
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

        private protected double GetReward(IROBOT agent, IROBOT opponent)
        {
            if (agent.IsDestroy())
            {
                return (double) Rewards.LOSE;
            }

            if (opponent.IsDestroy())
            {
                return (double) Rewards.WIN;
            }

            return (double) Rewards.LEGAL;
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
