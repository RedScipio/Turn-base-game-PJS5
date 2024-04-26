using Battle;
using System.Collections.Generic;
using System.Linq;

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

        public abstract void PlayTurn(IROBOT ennemyRobot, MAIN_MENU iChoice = MAIN_MENU.Error, int iRes = -1, int iChoiceTarget = -1, int iHitRate = -1);

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

        public abstract List<int> PlayTurnAuto(IROBOT ennemyRobot);

        public bool FirstChoiceIsValid(MAIN_MENU iChoice)
        {
            if(iChoice == MAIN_MENU.Attack)
            {
                if (!this.IsWeaponUsable((int)iChoice))
                {
                    return false;
                }
            }
            else if(iChoice == MAIN_MENU.Repairs)
            {
                if (IsAllKitsEmpty(_vRepairKitsReserve))
                {
                    return false;
                }
            }
            else if(iChoice == MAIN_MENU.Furnace)
            {
                if (IsAllKitsEmpty(_vFuelsReserve))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Check if every kit in the list is empty
        /// </summary>
        /// <param name="listKits"> the list of kits selected </param>
        /// <returns>true if every element in the list has 0 items</returns>
        public bool IsAllKitsEmpty(List<ICONSUMABLES> listKits)
        {
            if(listKits.All(rf => rf.GetNumberItems() < 1))
            {
                return true;
            }
            return false;
        }

        public bool Refuel(int iChoice)
        {
            if (this._vFuelsReserve[iChoice].GetNumberItems() < 1)
            {
                if (IsAllKitsEmpty(_vFuelsReserve))
                {
                    return true;
                }
                return false;
            }

            if (this._pRobot.GetFuel() < 100)
            {
                _pRobot.Refuel(_vFuelsReserve[iChoice].GetValue());
                _vFuelsReserve[iChoice].decrNumberItems();
                return true;
            }

            if(iChoice <= 0)
            {
                return true;
            }

            return false;
        }

        public bool Repair(REPAIRS_MENU iChoice)
        {
            if (iChoice == REPAIRS_MENU.Error) return false;

            if (this._pRobot.RepairLifeTargetIsValid((PARTS_TYPES)iChoice))
            {

            }

            return true;
        }

        public bool Attack(int iChoiceWeapon, IPILOT ennemy, PARTS_TYPES target)
        {
            if (this.GetRobot().WeaponIsUsable(iChoiceWeapon))
            {
                ennemy.GetRobot().DealDamage(ennemy.GetRobot(), iChoiceWeapon, target);
                return true;
            }

            return false;
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
