using System.Collections.Generic;

namespace Umshini
{
    public interface IBATTLE
    {
        List<int> PlayRound();
        List<int> PlayTurn(int iPilot);
    }
}
