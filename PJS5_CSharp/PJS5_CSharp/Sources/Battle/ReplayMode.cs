using PILOT;
using PJS5_CSharp.Sources.Pilot.Player;
using PJS5_CSharp.Sources.Robot;
using PJS5_CSharp.Sources.Weapon.MeleeWeapon;
using PJS5_CSharp.Sources.Weapon.NormalWeapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
