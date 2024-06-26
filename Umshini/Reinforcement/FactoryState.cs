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
            State3
        }

        public static IState GetState(Type_State type)
        {
            switch (type)
            {
                case Type_State.State2:
                    return new State2();
                case Type_State.State3:
                    return new State3();
                default:
                    throw new Exception("State not found");
            }
        }
    }
}
