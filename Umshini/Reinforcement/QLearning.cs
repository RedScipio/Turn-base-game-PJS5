﻿using Battle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reinforcement
{
    enum Rewards
    {
        WIN = 100,
        LEGAL = 0,
        LOSE = -1,
        ILLEGAL = -100,
    }


    internal class QLearning : IQLearning
    {
        private protected IROBOT IARobot;
        private protected IROBOT RobotToKill;

        private protected double[][] Qtable;

        internal QLearning(IROBOT r1, IROBOT r2)
        {
            this.Qtable = GenerateQTable();

            this.IARobot = r1;
            this.RobotToKill = r2;
        }

        /// <summary>
        /// Generates Q table
        /// </summary>
        /// <returns>Q table</returns>
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


        public void Run()
        {
            throw new NotImplementedException();
        }

        public void TrainingAgent(int nbTrains)
        {
            IROBOT[] robots = new IROBOT[] { this.IARobot, this.RobotToKill };

            for (int i=0; i < nbTrains; i++)
            {
                // List Actions
                Action[] legalActions = GetLegalActions(robots[0], robots[1]);
                
            }
        }

        /// <summary>
        /// Allows the agent to perform an action against the robot, and returns the new state of the game.
        /// </summary>
        /// <param name="agent">Agent Robot</param>
        /// <param name="opponent">Robot opponent</param>
        /// <param name="action">Type of action performed by the agent robot</param>
        /// <returns>State following agent robot action</returns>
        private protected State NextState(IROBOT agent, IROBOT opponent, Action action)
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


            return new State(agent, opponent);
        }

        /// <summary>
        /// Indicates whether the simulation is complete
        /// </summary>
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

    }
}
