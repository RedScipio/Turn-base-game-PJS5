using Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reinforcement
{
    internal class State3 : IState
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


        private const int COEFF_LEGS_AGENT = 1;

        private const int COEFF_WEAPON_LEFT_AGENT = 3;

        private const int COEFF_WEAPON_RIGHT_AGENT = 9;

        private const int COEFF_FURNACE_AGENT = 27;

        private const int COEFF_FUEL_AGENT = 81;


        private const int COEFF_LEGS_OPPONENT = 243;

        private const int COEFF_WEAPON_LEFT_OPPONENT = 729;

        private const int COEFF_WEAPON_RIGHT_OPPONENT = 2_187;

        private const int COEFF_FURNACE_OPPONENT = 6_561;

        private const int COEFF_FUEL_OPPONENT = 19_683;


        public double ConvertNumber(IROBOT agent, IROBOT opponent)
        {
            double n = 0;

            n += agent.GetLegsArmor() > 0 ? (double) StateOfEquipement.Armor_Undestroyed * State3.COEFF_LEGS_AGENT : 
                (agent.GetLegsLife() > 0 ? (double) StateOfEquipement.Armor_Destroyed * State3.COEFF_LEGS_AGENT : (double) StateOfEquipement.Equipement_Destroyed * State3.COEFF_LEGS_AGENT);

            n += agent.GetLeftWeaponArmor() > 0 ? (double)StateOfEquipement.Armor_Undestroyed * State3.COEFF_WEAPON_LEFT_AGENT:
                (agent.GetLeftWeaponLife() > 0 ? (double)StateOfEquipement.Armor_Destroyed * State3.COEFF_WEAPON_LEFT_AGENT : (double)StateOfEquipement.Equipement_Destroyed * State3.COEFF_WEAPON_LEFT_AGENT);


            n += agent.GetRightWeaponArmor() > 0 ? (double)StateOfEquipement.Armor_Undestroyed * State3.COEFF_WEAPON_RIGHT_AGENT :
                (agent.GetRightWeaponLife() > 0 ? (double)StateOfEquipement.Armor_Destroyed * State3.COEFF_WEAPON_RIGHT_AGENT : (double)StateOfEquipement.Equipement_Destroyed * State3.COEFF_WEAPON_RIGHT_AGENT);

            n += agent.GetFurnaceArmor() > 0 ? (double)StateOfEquipement.Armor_Undestroyed * State3.COEFF_FURNACE_AGENT :
                (agent.GetFurnaceLife() > 0 ? (double)StateOfEquipement.Armor_Destroyed * State3.COEFF_FURNACE_AGENT : (double)StateOfEquipement.Equipement_Destroyed * State3.COEFF_FURNACE_AGENT);

            n += agent.GetFuel() > 50 ? (double)StateOfFuel.Fuel_Above_50_Pourcent * State3.COEFF_FUEL_AGENT :
                (agent.GetFuel() > 25 ? (double)StateOfFuel.Fuel_Under_50_Pourcent * State3.COEFF_FUEL_AGENT : (double)StateOfFuel.Fuel_Under_25_Pourcent * State3.COEFF_FUEL_AGENT);


            n += opponent.GetLegsArmor() > 0 ? (double)StateOfEquipement.Armor_Undestroyed * State3.COEFF_LEGS_OPPONENT :
                (opponent.GetLegsLife() > 0 ? (double)StateOfEquipement.Armor_Destroyed * State3.COEFF_LEGS_OPPONENT : (double)StateOfEquipement.Equipement_Destroyed * State3.COEFF_LEGS_OPPONENT);

            n += opponent.GetLeftWeaponArmor() > 0 ? (double)StateOfEquipement.Armor_Undestroyed * State3.COEFF_WEAPON_LEFT_OPPONENT :
                (opponent.GetLeftWeaponLife() > 0 ? (double)StateOfEquipement.Armor_Destroyed * State3.COEFF_WEAPON_LEFT_OPPONENT : (double)StateOfEquipement.Equipement_Destroyed * State3.COEFF_WEAPON_LEFT_OPPONENT);

            n += opponent.GetRightWeaponArmor() > 0 ? (double)StateOfEquipement.Armor_Undestroyed * State3.COEFF_WEAPON_RIGHT_OPPONENT :
                (opponent.GetRightWeaponLife() > 0 ? (double)StateOfEquipement.Armor_Destroyed * State3.COEFF_WEAPON_RIGHT_OPPONENT : (double)StateOfEquipement.Equipement_Destroyed * State3.COEFF_WEAPON_RIGHT_OPPONENT);

            n += opponent.GetFurnaceArmor() > 0 ? (double)StateOfEquipement.Armor_Undestroyed * State3.COEFF_FURNACE_OPPONENT :
                (opponent.GetFurnaceLife() > 0 ? (double)StateOfEquipement.Armor_Destroyed * State3.COEFF_FURNACE_OPPONENT : (double)StateOfEquipement.Equipement_Destroyed * State3.COEFF_FURNACE_OPPONENT);

            n += opponent.GetFuel() > 50 ? (double)StateOfFuel.Fuel_Above_50_Pourcent * State3.COEFF_FUEL_OPPONENT :
                (opponent.GetFuel() > 25 ? (double)StateOfFuel.Fuel_Under_50_Pourcent * State3.COEFF_FUEL_OPPONENT : (double)StateOfFuel.Fuel_Under_25_Pourcent * State3.COEFF_FUEL_OPPONENT);


            return n;
        }

        public double GetMaxValue()
        {
            return State3.COEFF_FUEL_OPPONENT * 3 - 1;
        }
    }
}
