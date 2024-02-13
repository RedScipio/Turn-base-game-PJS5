using System.Collections.Generic;
using Umshini;

namespace Battle
{
    public abstract class ABATTLE : IBATTLE
    {
        public abstract List<int> PlayTurn();
    }
}
