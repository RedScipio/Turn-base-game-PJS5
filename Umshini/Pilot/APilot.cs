using Battle;
using System.Collections.Generic;

namespace Pilot
{
    public abstract class APILOT : IPILOT
    {
        private protected IROBOT _pRobot;

        private protected List<ICONSUMABLES> _vFuelsReserve;

        private protected List<ICONSUMABLES> _vRepairKitsReserve;

        private protected List<int> _vResultsInputs;

        public APILOT(IROBOT pRobot, List<ICONSUMABLES> vFuelsReserve, List<ICONSUMABLES> vRepairKitsReserve)
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

        public List<ICONSUMABLES> GetFuelsReserve()
        {
            return _vFuelsReserve;
        }

        public List<ICONSUMABLES> GetRepairKitsReserve()
        {
            return _vRepairKitsReserve;
        }

        public List<int> GetInputsResults()
        {
            return _vResultsInputs;
        }

        public abstract bool IsBotPilot();

        public List<int> PlayTurnAuto()
        {
            throw new System.NotImplementedException();
        }

        public bool FirstChoiceIsValid(int iChoice)
        {
            return false;
        }

        public bool Refuel(int iChoice)
        {
            if (this._vFuelsReserve[iChoice].GetNumberItems() < 1)
            {
                return false;
            }

            if (this._pRobot.GetFuel() < 100)
            {
                _vFuelsReserve[iChoice].decrNumberItems();
                return true;
            }

            if(iChoice <= 0)
            {
                return true;
            }

            return false;
        }

        public bool Repair(int iChoice)
        {
            if (this._pRobot.RepairLifeTargetIsValid((PARTS_TYPES)iChoice))
            {

            }

            return false;
        }

        public bool Attack(int iChoice, IPILOT e)
        {
            throw new System.NotImplementedException();
        }

        public bool TargetPart(int iChoice)
        {
            throw new System.NotImplementedException();
        }

        public bool IsWeaponUsable(int iChoice)
        {
            return _pRobot.WeaponIsUsable(iChoice);
        }

        /// <summary>
        /// return true if the leg is broken
        /// </summary>
        public bool IsLegsBroken()
        {
            return _pRobot.IsLegsBroken();
        }

        /// <summary>
        /// return true if the furnace is broken
        /// </summary>
        public bool IsFurnaceBroken()
        {
            return _pRobot.IsFurnaceBroken();
        }

        /// <summary>
        /// return true if the weapon is broken
        /// </summary>
        public bool IsWeaponBroken(int iChoice)
        {
            return _pRobot.IsWeaponBroken(iChoice);
        }

        public int GetLeftWeaponType()
        {
           return  _pRobot.GetWeaponDamage(0);
        }
    }
}
