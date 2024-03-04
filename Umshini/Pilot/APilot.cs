using Battle;
using System.Collections.Generic;

namespace Pilot
{
    public abstract class APILOT : IPILOT
    {
        private protected IROBOT _pRobot;

        private protected List<ICONSUMABLE> _vFuelsReserve;

        private protected List<ICONSUMABLE> _vRepairKitsReserve;

        private protected List<int> _vResultsInputs;

        public APILOT(IROBOT pRobot, List<ICONSUMABLE> vFuelsReserve, List<ICONSUMABLE> vRepairKitsReserve)
        {
            _pRobot = pRobot;
            _vFuelsReserve = vFuelsReserve;
            _vRepairKitsReserve = vRepairKitsReserve;
        }

        public abstract void PlayTurn(IROBOT ennemiRobot, IGUI gui, int iChoice = -1, int iRes = -1, int iChoiceTarget = -1, int iHitRate = -1);

        public bool RobotIsDestroy()
        {
            return _pRobot.IsDestroy();
        }

        public IROBOT GetRobot()
        {
            return _pRobot;
        }

        public List<ICONSUMABLE> GetFuelsReserve()
        {
            return _vFuelsReserve;
        }

        public List<ICONSUMABLE> GetRepairKitsReserve()
        {
            return _vRepairKitsReserve;
        }

        public List<int> GetInputsResults()
        {
            return _vResultsInputs;
        }
    }
}
