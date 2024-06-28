using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battle;

namespace Reinforcement
{
    internal class State_Death_Bot : IState
    {
        private enum StateOfEquipement
        {
            Equipement_Destroyed = 0,
            Armor_Destroyed = 1,
            Armor_Undestroyed = 2
        }

        private enum StateOfFuel
        {
            Fuel_Under_25_Pourcent = 0,
            Fuel_Under_50_Pourcent = 1,
            Fuel_Above_50_Pourcent = 2
        }

        private enum StateOfLife
        {
            Agent_Destroy = 0,
            Opponent_Destroy = 1,
            Both_Alive = 2
        }

        private enum StateOfFurnaceArmor
        {
            Furnace_Armor_Destroyed = 0,
            Furnace_Armor_Undestroyed = 1
        }

        private const int NB_ROBOTS = 2;


        private const int COEFF_LEGS_AGENT = 1;

        private const int COEFF_WEAPON_LEFT_AGENT = 3;

        private const int COEFF_WEAPON_RIGHT_AGENT = 9;

        private const int COEFF_FURNACE_AGENT = 27;

        private const int COEFF_FUEL_AGENT = 54;


        private const int COEFF_LEGS_OPPONENT = 162;

        private const int COEFF_WEAPON_LEFT_OPPONENT = 486;

        private const int COEFF_WEAPON_RIGHT_OPPONENT = 1_458;

        private const int COEFF_FURNACE_OPPONENT = 4_374;

        private const int COEFF_FUEL_OPPONENT = 8_748;



        public int ConvertNumber(IROBOT agent, IROBOT opponent)
        {
            if (agent.IsDestroy() || agent.GetFuel() == 0) return (int)StateOfLife.Agent_Destroy;

            if (opponent.IsDestroy()) return (int)StateOfLife.Opponent_Destroy;


            int n = (int)StateOfLife.Both_Alive;

            n += agent.GetLegsArmor() > 0 ? (int)StateOfEquipement.Armor_Undestroyed * State_Death_Bot.COEFF_LEGS_AGENT :
                            (agent.GetLegsLife() > 0 ? (int)StateOfEquipement.Armor_Destroyed * State_Death_Bot.COEFF_LEGS_AGENT : (int)StateOfEquipement.Equipement_Destroyed * State_Death_Bot.COEFF_LEGS_AGENT);

            n += agent.GetLeftWeaponArmor() > 0 ? (int)StateOfEquipement.Armor_Undestroyed * State_Death_Bot.COEFF_WEAPON_LEFT_AGENT :
                (agent.GetLeftWeaponLife() > 0 ? (int)StateOfEquipement.Armor_Destroyed * State_Death_Bot.COEFF_WEAPON_LEFT_AGENT : (int)StateOfEquipement.Equipement_Destroyed * State_Death_Bot.COEFF_WEAPON_LEFT_AGENT);


            n += agent.GetRightWeaponArmor() > 0 ? (int)StateOfEquipement.Armor_Undestroyed * State_Death_Bot.COEFF_WEAPON_RIGHT_AGENT :
                (agent.GetRightWeaponLife() > 0 ? (int)StateOfEquipement.Armor_Destroyed * State_Death_Bot.COEFF_WEAPON_RIGHT_AGENT : (int)StateOfEquipement.Equipement_Destroyed * State_Death_Bot.COEFF_WEAPON_RIGHT_AGENT);

            n += agent.GetFurnaceArmor() > 0 ? (int)StateOfFurnaceArmor.Furnace_Armor_Undestroyed * State_Death_Bot.COEFF_FURNACE_AGENT :
                (int)StateOfFurnaceArmor.Furnace_Armor_Destroyed * State_Death_Bot.COEFF_FURNACE_AGENT;

            n += agent.GetFuel() > 50 ? (int)StateOfFuel.Fuel_Above_50_Pourcent * State_Death_Bot.COEFF_FUEL_AGENT :
                (agent.GetFuel() > 25 ? (int)StateOfFuel.Fuel_Under_50_Pourcent * State_Death_Bot.COEFF_FUEL_AGENT : (int)StateOfFuel.Fuel_Under_25_Pourcent * State_Death_Bot.COEFF_FUEL_AGENT);


            n += opponent.GetLegsArmor() > 0 ? (int)StateOfEquipement.Armor_Undestroyed * State_Death_Bot.COEFF_LEGS_OPPONENT :
                (opponent.GetLegsLife() > 0 ? (int)StateOfEquipement.Armor_Destroyed * State_Death_Bot.COEFF_LEGS_OPPONENT : (int)StateOfEquipement.Equipement_Destroyed * State_Death_Bot.COEFF_LEGS_OPPONENT);

            n += opponent.GetLeftWeaponArmor() > 0 ? (int)StateOfEquipement.Armor_Undestroyed * State_Death_Bot.COEFF_WEAPON_LEFT_OPPONENT :
                (opponent.GetLeftWeaponLife() > 0 ? (int)StateOfEquipement.Armor_Destroyed * State_Death_Bot.COEFF_WEAPON_LEFT_OPPONENT : (int)StateOfEquipement.Equipement_Destroyed * State_Death_Bot.COEFF_WEAPON_LEFT_OPPONENT);

            n += opponent.GetRightWeaponArmor() > 0 ? (int)StateOfEquipement.Armor_Undestroyed * State_Death_Bot.COEFF_WEAPON_RIGHT_OPPONENT :
                (opponent.GetRightWeaponLife() > 0 ? (int)StateOfEquipement.Armor_Destroyed * State_Death_Bot.COEFF_WEAPON_RIGHT_OPPONENT : (int)StateOfEquipement.Equipement_Destroyed * State_Death_Bot.COEFF_WEAPON_RIGHT_OPPONENT);

            n += opponent.GetFurnaceArmor() > 0 ? (int)StateOfFurnaceArmor.Furnace_Armor_Undestroyed * State_Death_Bot.COEFF_FURNACE_OPPONENT :
                (int)StateOfFurnaceArmor.Furnace_Armor_Destroyed * State_Death_Bot.COEFF_FURNACE_OPPONENT;

            n += opponent.GetFuel() > 50 ? (int)StateOfFuel.Fuel_Above_50_Pourcent * State_Death_Bot.COEFF_FUEL_OPPONENT :
                (opponent.GetFuel() > 25 ? (int)StateOfFuel.Fuel_Under_50_Pourcent * State_Death_Bot.COEFF_FUEL_OPPONENT : (int)StateOfFuel.Fuel_Under_25_Pourcent * State_Death_Bot.COEFF_FUEL_OPPONENT);


            return n;
        }

        public int GetMaxValue()
        {
            return State_Death_Bot.COEFF_FUEL_OPPONENT * 3 + State_Death_Bot.NB_ROBOTS - 1;
        }

    }
}
