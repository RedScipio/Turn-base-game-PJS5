using Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reinforcement
{
    internal class State2 : IState
    {
        private const int COEFF_IS_LEGS_AGENT_DESTROY = 1;
        private const int COEFF_IS_ARMOR_LEGS_AGENT_DESTROY = 2;

        private const int COEFF_IS_WEAPON_LEFT_AGENT_DESTROY = 4;
        private const int COEFF_IS_ARMOR_WEAPON_LEFT_AGENT_DESTROY = 8;

        private const int COEFF_IS_WEAPON_RIGHT_AGENT_DESTROY = 16;
        private const int COEFF_IS_ARMOR_WEAPON_RIGHT_AGENT_DESTROY = 32;

        private const int COEFF_IS_FURNACE_AGENT_DESTROY = 64;
        private const int COEFF_IS_ARMOR_FURNACE_AGENT_DESTROY = 128;

        private const int COEFF_IS_FUEL_AGENT_UNDER_50_POURCENT = 256;
        private const int COEFF_IS_FUEL_AGENT_UNDER_25_POURCENT = 512;


        private const int COEFF_IS_LEGS_OPPONENT_DESTROY = 1_024;
        private const int COEFF_IS_ARMOR_LEGS_OPPONENT_DESTROY = 2_048;

        private const int COEFF_IS_WEAPON_LEFT_OPPONENT_DESTROY = 4_096;
        private const int COEFF_IS_ARMOR_WEAPON_LEFT_OPPONENT_DESTROY = 8_192;

        private const int COEFF_IS_WEAPON_RIGHT_OPPONENT_DESTROY = 16_384;
        private const int COEFF_IS_ARMOR_WEAPON_RIGHT_OPPONENT_DESTROY = 32_768;

        private const int COEFF_IS_FURNACE_OPPONENT_DESTROY = 65_536;
        private const int COEFF_IS_ARMOR_FURNACE_OPPONENT_DESTROY = 131_072;

        private const int COEFF_IS_FUEL_OPPONENT_UNDER_50_POURCENT = 262_144;
        private const int COEFF_IS_FUEL_OPPONENT_UNDER_25_POURCENT = 524_288;


        public int ConvertNumber(IROBOT agent, IROBOT opponent)
        {
            int n = 0;

            n += agent.GetLegsLife() > 0 ? 2 * State2.COEFF_IS_LEGS_AGENT_DESTROY : 0;
            n += agent.GetLegsArmor() > 0 ? 2 * State2.COEFF_IS_ARMOR_LEGS_AGENT_DESTROY : 0;

            n += agent.GetLeftWeaponLife() > 0 ? 2 * State2.COEFF_IS_ARMOR_WEAPON_LEFT_AGENT_DESTROY : 0;
            n += agent.GetLeftWeaponArmor() > 0 ? 2 * State2.COEFF_IS_WEAPON_LEFT_AGENT_DESTROY : 0;

            n += agent.GetRightWeaponLife() > 0 ? 2 * State2.COEFF_IS_ARMOR_WEAPON_RIGHT_AGENT_DESTROY : 0;
            n += agent.GetRightWeaponArmor() > 0 ? 2 * State2.COEFF_IS_WEAPON_RIGHT_AGENT_DESTROY : 0;

            n += agent.GetLeftWeaponLife() > 0 ? 2 * State2.COEFF_IS_ARMOR_WEAPON_LEFT_AGENT_DESTROY : 0;
            n += agent.GetLeftWeaponArmor() > 0 ? 2 * State2.COEFF_IS_WEAPON_LEFT_AGENT_DESTROY : 0;

            n += agent.GetLeftWeaponLife() > 0 ? 2 * State2.COEFF_IS_ARMOR_WEAPON_LEFT_AGENT_DESTROY : 0;
            n += agent.GetLeftWeaponArmor() > 0 ? 2 * State2.COEFF_IS_WEAPON_LEFT_AGENT_DESTROY : 0;

            n += agent.GetFurnaceLife() > 0 ? 2 * State2.COEFF_IS_FURNACE_AGENT_DESTROY : 0;
            n += agent.GetFurnaceArmor() > 0 ? 2 * State2.COEFF_IS_ARMOR_FURNACE_AGENT_DESTROY : 0;

            n += agent.GetFuel() < 50 ? 2 * State2.COEFF_IS_FUEL_AGENT_UNDER_50_POURCENT : 0;
            n += agent.GetFuel() < 25 ? 2 * State2.COEFF_IS_FUEL_AGENT_UNDER_25_POURCENT : 0;


            n += opponent.GetLegsLife() > 0 ? 2 * State2.COEFF_IS_LEGS_OPPONENT_DESTROY : 0;
            n += opponent.GetLegsArmor() > 0 ? 2 * State2.COEFF_IS_ARMOR_LEGS_OPPONENT_DESTROY : 0;

            n += opponent.GetLeftWeaponLife() > 0 ? 2 * State2.COEFF_IS_ARMOR_WEAPON_LEFT_OPPONENT_DESTROY : 0;
            n += opponent.GetLeftWeaponArmor() > 0 ? 2 * State2.COEFF_IS_WEAPON_LEFT_OPPONENT_DESTROY : 0;

            n += opponent.GetRightWeaponLife() > 0 ? 2 * State2.COEFF_IS_ARMOR_WEAPON_RIGHT_OPPONENT_DESTROY : 0;
            n += opponent.GetRightWeaponArmor() > 0 ? 2 * State2.COEFF_IS_WEAPON_RIGHT_OPPONENT_DESTROY : 0;

            n += opponent.GetLeftWeaponLife() > 0 ? 2 * State2.COEFF_IS_ARMOR_WEAPON_LEFT_OPPONENT_DESTROY : 0;
            n += opponent.GetLeftWeaponArmor() > 0 ? 2 * State2.COEFF_IS_WEAPON_LEFT_OPPONENT_DESTROY : 0;

            n += opponent.GetLeftWeaponLife() > 0 ? 2 * State2.COEFF_IS_ARMOR_WEAPON_LEFT_OPPONENT_DESTROY : 0;
            n += opponent.GetLeftWeaponArmor() > 0 ? 2 * State2.COEFF_IS_WEAPON_LEFT_OPPONENT_DESTROY : 0;

            n += opponent.GetFurnaceLife() > 0 ? 2 * State2.COEFF_IS_FURNACE_OPPONENT_DESTROY : 0;
            n += opponent.GetFurnaceArmor() > 0 ? 2 * State2.COEFF_IS_ARMOR_FURNACE_OPPONENT_DESTROY : 0;

            n += opponent.GetFuel() < 50 ? 2 * State2.COEFF_IS_FUEL_OPPONENT_UNDER_50_POURCENT : 0;
            n += opponent.GetFuel() < 25 ? 2 * State2.COEFF_IS_FUEL_OPPONENT_UNDER_25_POURCENT : 0;

            return n;
        }

        public int GetMaxValue()
        {
            return State2.COEFF_IS_FUEL_OPPONENT_UNDER_25_POURCENT * 2 - 1;
        }
    }
}
