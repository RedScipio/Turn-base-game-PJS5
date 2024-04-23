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

        public abstract void PlayTurn(IROBOT ennemiRobot, MAIN_MENU iChoice = MAIN_MENU.Error, int iRes = -1, int iChoiceTarget = -1, int iHitRate = -1);

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

        public abstract bool IsBotPilot();

        public List<int> PlayTurnAuto()
        {
            throw new System.NotImplementedException();
        }

        public bool FirstChoiceIsValid(MAIN_MENU iChoice)
        {
            return true;        }

        public bool Refuel(FUEL_MENU iChoice)
        {
            throw new System.NotImplementedException();
        }

        public bool Repair(REPAIRS_MENU iChoice)
        {
            if (this._pRobot.RepairLifeTargetIsValid((PARTS_TYPES)iChoice))
            {

            }

            return false;
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
