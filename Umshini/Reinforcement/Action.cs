using Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reinforcement
{

    internal enum Action
    {
        LEFT_WEAPON_ATTACK_LEFT_WEAPON = 0,
        LEFT_WEAPON_ATTACK_RIGHT_WEAPON = 1,
        LEFT_WEAPON_ATTACK_FURNACE = 2,
        LEFT_WEAPON_ATTACK_LEGS = 3,

        RIGHT_WEAPON_ATTACK_LEFT_WEAPON = 4,
        RIGHT_WEAPON_ATTACK_RIGHT_WEAPON = 5,
        RIGHT_WEAPON_ATTACK_FURNACE = 6,
        RIGHT_WEAPON_ATTACK_LEGS = 7,
    }
}
