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

        public abstract void PlayTurn(IROBOT ennemiRobot, int iChoice = -1, int iRes = -1, int iChoiceTarget = -1, int iHitRate = -1);

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

        /*public bool TargetPart(int iChoice)
        {
            
        }*/

        public abstract bool IsBotPilot();

        List<int> IPILOT.PlayTurnAuto()
        {
            throw new System.NotImplementedException();
        }

        bool IPILOT.FirstChoice(int iChoice)
        {
            throw new System.NotImplementedException();
        }

        bool IPILOT.Refuel(int iChoice)
        {
            throw new System.NotImplementedException();
        }

        bool IPILOT.Repair(int iChoice)
        {
            throw new System.NotImplementedException();
        }

        bool IPILOT.Attack(int iChoice)
        {
            throw new System.NotImplementedException();
        }

        bool IPILOT.TargetPart(int iChoice)
        {
            throw new System.NotImplementedException();
        }

        List<ICONSUMABLE> IPILOT.GetFuelsReserve()
        {
            return _vFuelsReserve;
        }

        List<ICONSUMABLE> IPILOT.GetRepairKitsReserve()
        {
            return _vRepairKitsReserve;
        }

        public bool IsWeaponUsable(int iChoice)
        {
            throw new System.NotImplementedException();
        }
    }
}
