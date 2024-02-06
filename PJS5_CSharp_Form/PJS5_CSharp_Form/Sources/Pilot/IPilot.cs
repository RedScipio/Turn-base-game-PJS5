
using PJS5_CSharp.Sources.Robot;
using System.Collections.Generic;

namespace PILOT
{


    public abstract class IPILOT
    {
        protected Robot _pRobot;
        protected List<int> _vFuelsReserve;
        protected List<int> _vRepairKitsReserve;

        public IPILOT(Robot pRobot, List<int> vFuelsReserve, List<int> vRepairKitsReserve)
        {
            _pRobot = pRobot;
            _vFuelsReserve = vFuelsReserve;
            _vRepairKitsReserve = vRepairKitsReserve;
        }

        public abstract void PlayTurn(Robot ennemiRobot);
        

        public bool RobotIsDestroy()
        {
            return _pRobot.IsDestroy();
        }

        public Robot GetRobot()
        {
            return _pRobot;
        }

        public List<int> GetFuelsReserve()
        {
            return _vFuelsReserve;
        }

        public List<int> GetRepairKitsReserve()
        {
            return _vRepairKitsReserve;
        }
    }
}


