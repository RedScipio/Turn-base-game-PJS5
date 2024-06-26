using Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reinforcement
{
    // obsolete class
    internal class State
    {
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


        internal State(IROBOT agent, IROBOT opponent)
        {
            this.pvLegsAgent = agent.GetLegsLife();
            this.pvArmorLegsAgent = agent.GetLegsArmor();

            this.pvFurnaceAgent = agent.GetFurnaceLife();
            this.pvArmorFurnacetAgent = agent.GetFurnaceArmor();

            this.pvWeaponLeftAgent = agent.GetLeftWeaponLife();
            this.pvArmorWeaponLeftAgent = agent.GetLeftWeaponArmor();

            this.pvWeaponRightAgent = agent.GetRightWeaponLife();
            this.pvArmorWeaponRightAgent = agent.GetRightWeaponArmor();

            this.fuelAgent = agent.GetFuel();



            this.pvLegsOpponent = opponent.GetLegsLife();
            this.ArmorLegsOpponent = opponent.GetLegsArmor();

            this.pvPurnaceOpponent = opponent.GetFurnaceLife();
            this.pvArmorFurnacetOpponent = opponent.GetFurnaceArmor();

            this.pvWeaponLeftOpponent = opponent.GetLeftWeaponLife();
            this.pvArmorWeaponLeftOpponent = opponent.GetLeftWeaponArmor();

            this.pvWeaponRightOpponent = opponent.GetRightWeaponLife();
            this.pvArmorWeaponRightOpponent = opponent.GetRightWeaponArmor();

            this.fuelOpponent = opponent.GetFuel();
        }
    }
}
