
using PJS5_CSharp.Sources.Robot;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PILOT
{

    [System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Property, AllowMultiple = false)]
    public abstract class IPILOT : System.Attribute
    {
        [JsonIgnore]
        protected Robot _pRobot;
        [JsonIgnore]
        protected List<int> _vFuelsReserve;
        [JsonIgnore]
        protected List<int> _vRepairKitsReserve;
        [JsonInclude]
        protected List<int> _vResultsInputs;

        public IPILOT(Robot pRobot, List<int> vFuelsReserve, List<int> vRepairKitsReserve)
        {
            _pRobot = pRobot;
            _vFuelsReserve = vFuelsReserve;
            _vRepairKitsReserve = vRepairKitsReserve;
        }

        public abstract void PlayTurn(Robot ennemiRobot, int iChoice = -1, int iRes = -1, int iChoiceTarget = -1, int iHitRate = -1);

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

        public List<int> GetInputsResults()
        {
            return _vResultsInputs;
        }
    }
}


