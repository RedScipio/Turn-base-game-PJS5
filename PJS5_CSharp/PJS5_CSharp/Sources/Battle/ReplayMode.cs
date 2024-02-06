using PILOT;


namespace PJS5_CSharp.Sources.Battle
{
    public class ReplayMode
    {
        
        private IPILOT[] tPilot;
        public ReplayMode(IPILOT pPlayer, IPILOT pBot)
        {
            tPilot = new IPILOT[] { pPlayer, pBot };
        }

        /*public void Replay(JsonDocument json)
        {
            
        }*/

        
    }
}
