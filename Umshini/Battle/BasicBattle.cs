using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Battle
{
    public class BASIC_BATTLE : ABATTLE
    {
        private BasikBattle _basikBattle;

        public BASIC_BATTLE(BasikBattle basikBattle, IPILOT pilot1, IPILOT pilot2) : base(pilot1, pilot2)
        {
            _basikBattle = basikBattle;
        }

        public void PlayBattle()
        {
            _basikBattle.PlayBattle();
        }

        public override List<int> PlayRound()
        {
            return _basikBattle.PlayRound();
        }

        public override List<int> PlayTurn(int iPilot, MAIN_MENU eChoiceMenu = MAIN_MENU.Error, int iRes = -1, int iTargetPart = -1)
        {
            return _basikBattle.PlayTurn(iPilot, eChoiceMenu, iRes, iTargetPart);
        }
    }
}
