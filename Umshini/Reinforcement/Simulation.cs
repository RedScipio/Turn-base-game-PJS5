using Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reinforcement
{
    internal class Simulation : ISimulation
    {
        private protected IROBOT agent;
        private protected IROBOT opponent;

        public Simulation(IROBOT agent, IROBOT opponent) {
            this.agent = agent;
            this.opponent = opponent;
        }

        public void StartSimulation()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Allows the agent to perform an action against the robot, and returns the new state of the game.
        /// </summary>
        /// <param name="agent">Agent Robot</param>
        /// <param name="opponent">Robot opponent</param>
        /// <param name="action">Type of action performed by the agent robot</param>
        /// <returns>State following agent robot action</returns>
        public State NextState(IROBOT agent, IROBOT opponent, Action action)
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
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsOver()
        {
            return agent.IsDestroy() || opponent.IsDestroy();
        }

        public double[][] GetSimulationResults()
        {
            throw new NotImplementedException();
        }

        // Permet de savoir si l'action est légale
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

        // Permet de lister les actions légales
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

        public State P

    }
}
