
using System.Collections.Generic;

namespace Battle
{
    public interface IPILOT
    {
        List<ICONSUMABLE> GetFuelsReserve();
        List<ICONSUMABLE> GetRepairKitsReserve();
    }
}
