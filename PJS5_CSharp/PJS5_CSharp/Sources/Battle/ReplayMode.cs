using PILOT;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PJS5_CSharp.Sources.Battle
{
    public class ReplayMode
    {
        [JsonInclude]
        private IPILOT[] tPilot;
        public ReplayMode(IPILOT pPlayer, IPILOT pBot)
        {
            tPilot = new IPILOT[] { pPlayer, pBot };
        }

        public void Replay(JsonDocument json)
        {
            
        }

        
    }
}
