using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reinforcement
{
    internal enum Action
    {
        LEFT_WEAPON_ATTACK_LEFT_WEAPON,
        LEFT_WEAPON_ATTACK_RIGHT_WEAPON,
        LEFT_WEAPON_ATTACK_FURNACE,
        LEFT_WEAPON_ATTACK_LEGS,

        RIGHT_WEAPON_ATTACK_LEFT_WEAPON,
        RIGHT_WEAPON_ATTACK_RIGHT_WEAPON,
        RIGHT_WEAPON_ATTACK_FURNACE,
        RIGHT_WEAPON_ATTACK_LEGS,
        
        NOTHING,
    }
}
