using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reinforcement
{
    internal class FactoryState
    {
        public enum Type_State
        {
            State2,
            State3,
            State_Death_Bot,
        }

        public static IState GetState(Type_State type)
        {
            switch (type)
            {
                case Type_State.State2:
                    return new State2();
                case Type_State.State3:
                    return new State3();
                case Type_State.State_Death_Bot:
                    return new State_Death_Bot();
                default:
                    throw new Exception("State not found");
            }
        }
    }
}
