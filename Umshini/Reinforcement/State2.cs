using Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reinforcement
{
    internal class State2
    {
        /*
        public readonly int pvLegsAgent;
        public readonly int pvArmorLegsAgent;

        public readonly int pvWeaponLeftAgent;
        public readonly int pvArmorWeaponLeftAgent;

        public readonly int pvWeaponRightAgent;
        public readonly int pvArmorWeaponRightAgent;

        public readonly int pvFurnaceAgent;
        public readonly int pvArmorFurnacetAgent;

        public readonly int fuelAgent;


        public readonly int pvLegsOpponent;
        public readonly int ArmorLegsOpponent;

        public readonly int pvWeaponLeftOpponent;
        public readonly int pvArmorWeaponLeftOpponent;

        public readonly int pvWeaponRightOpponent;
        public readonly int pvArmorWeaponRightOpponent;

        public readonly int pvPurnaceOpponent;
        public readonly int pvArmorFurnacetOpponent;

        public readonly int fuelOpponent;
        */

        private const int COEFF_IS_LEGS_AGENT_DESTROY = 1;
        private const int COEFF_IS_ARMOR_LEGS_AGENT_DESTROY = 2;

        private const int COEFF_IS_WEAPON_LEFT_AGENT_DESTROY = 4;
        private const int COEFF_IS_ARMOR_WEAPON_LEFT_AGENT_DESTROY = 8;

        private const int COEFF_IS_WEAPON_RIGHT_AGENT_DESTROY = 16;
        private const int COEFF_IS_ARMOR_WEAPON_RIGHT_AGENT_DESTROY = 32;

        private const int COEFF_IS_FURNACE_AGENT_DESTROY = 64;
        private const int COEFF_IS_ARMOR_FURNACET_AGENT_DESTROY = 128;

        private const int COEFF_IS_FUEL_AGENT_UNDER_50_POURCENT = 256;
        private const int COEFF_IS_FUEL_AGENT_UNDER_25_POURCENT = 512;


        private const int COEFF_IS_LEGS_OPPONENT = 1_024;
        private const int COEFF_IS_ARMOR_LEGS_OPPONENT = 2_048;

        private const int COEFF_IS_WEAPON_LEFT_OPPONENT = 4_096;
        private const int COEFF_IS_ARMOR_WEAPON_LEFT_OPPONENT = 8_192;

        private const int COEFF_IS_WEAPON_RIGHT_OPPONENT = 16_384;
        private const int COEFF_IS_ARMOR_WEAPON_RIGHT_OPPONENT = 32_768;

        private const int COEFF_IS_PURNACE_OPPONENT = 65_536;
        private const int COEFF_IS_ARMOR_FURNACET_OPPONENT = 131_072;

        private const int COEFF_IS_FUEL_OPPONENT_UNDER_50_POURCENT = 262_144;
        private const int COEFF_IS_FUEL_AGENT_UNDER_25_POURCENT = 524_288;

        public const int MAX_STATE_VALUE = COEFF_IS_FUEL_AGENT_UNDER_25_POURCENT * 2 - 1;

        public double ConvertInt(IROBOT agent, IROBOT opponent)
        {
            bool IsLegsAgentDestroy;
            bool IsArmorLegsAgentDestroy;

            bool IsWeaponLeftAgentDestroy;
            bool IsArmorWeaponLeftAgentDestroy;

            bool IsWeaponRightAgentDestroy;
            bool IsArmorWeaponRightAgentDestroy;

            bool IsFurnaceAgentDestroy;
            bool IsArmorFurnacetAgentDestroy;

            bool IsFuelAgentUnder50Pourcent;


            bool IsLegsOpponentDestroy;
            bool IsArmorLegsOpponentDestroy;

            bool IsWeaponLeftOpponentDestroy;
            bool IsArmorWeaponLeftOpponentDestroy;

            bool IsWeaponRightOpponentDestroy;
            bool IsArmorWeaponRightOpponentDestroy;

            bool IsPurnaceOpponentDestroy;
            bool IsArmorFurnacetOpponentDestroy;

            bool IsFuelOpponentUnder50Pourcent;
            bool IsFuelOpponentUnder25Pourcent;
        }
    }
}
