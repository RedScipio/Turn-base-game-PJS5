using Battle;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Pilot
{
    public abstract class APILOT : IPILOT
    {
        private protected IROBOT _pRobot;

        private protected List<ICONSUMABLES> _vFuelsReserve;

        private protected List<ICONSUMABLES> _vRepairKitsReserve;

        private protected List<int> _vResultsInputs;

        private protected const int MAX_FUEL = 100;

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

        /// <summary>
        /// False if the selected weapons is not 
        /// usable or if all kits (refuel or repair) 
        /// are empty, else true
        /// </summary>
        /// <param name="iChoice"> The choice in the main menu </param>
        /// <returns> bool </returns>
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
        /// Check if every kit in the list is empty.
        /// Return true if every element 
        /// in the list has 0 items
        /// </summary>
        /// <param name="listKits"> the list of kits selected </param>
        /// <returns> bool </returns>
        public bool IsAllKitsEmpty(List<ICONSUMABLES> listKits)
        {
            if(listKits.All(kits => kits.GetNumberItems() < 1))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Return true 
        /// </summary>
        /// <param name="iChoice"></param>
        /// <returns>bool </returns>
        public bool Refuel(int iChoice, List<int> lInputActions)
        {
            if (this._vFuelsReserve[iChoice].GetNumberItems() < 1)
            {
                if (IsAllKitsEmpty(_vFuelsReserve))
                {
                    return true;
                }
                return false;
            }

            if (this._pRobot.GetFuel() < APILOT.MAX_FUEL)
            {
                _pRobot.Refuel(_vFuelsReserve[iChoice].GetValue());
                lInputActions.Add(_vFuelsReserve[iChoice].GetValue());
                _vFuelsReserve[iChoice].decrNumberItems();
                return true;
            }

            if(iChoice <= 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eChoice"></param>
        /// <returns> bool </returns>
        public bool Repair(REPAIRS_MENU eChoice, TARGET_TYPE eChoicePart, List<int> lInputActions)
        {
            if (eChoice == REPAIRS_MENU.Error) return false;

            if (_vRepairKitsReserve[(int)eChoice].GetNumberItems() < 1)
            {
                return false;
            }

            if(eChoice == REPAIRS_MENU.Light_Armor || eChoice == REPAIRS_MENU.Heavy_Armor)
            {
                if (this._pRobot.RepairArmorTargetIsValid(eChoicePart))
                {
                    this._pRobot.RepairRobotArmor(_vRepairKitsReserve[(int)eChoice].GetValue(), eChoicePart);
                    lInputActions.Add(_vRepairKitsReserve[(int)eChoice].GetValue());
                    this._vRepairKitsReserve[(int)eChoice].decrNumberItems();
                    return true;
                }
                
            }
            
            if(eChoice == REPAIRS_MENU.Repair_Kits || eChoice == REPAIRS_MENU.Full_Kits)
            {
                if (this._pRobot.RepairLifeTargetIsValid(eChoicePart))
                {
                    this._pRobot.RepairRobotLifePoint(_vRepairKitsReserve[(int)eChoice].GetValue(), eChoicePart);
                    lInputActions.Add(_vRepairKitsReserve[(int)eChoice].GetValue());
                    this._vRepairKitsReserve[(int)eChoice].decrNumberItems();
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="iChoiceWeapon"> the weapon we choose to attack</param>
        /// <param name="ennemy"> the enemy pilot</param>
        /// <param name="target"> the part we selected to attack </param>
        /// <returns></returns>
        public bool Attack(int iChoiceWeapon, IROBOT ennemy, TARGET_TYPE target, List<int> lInputActions = null)

        {
            if (this.GetRobot().WeaponIsUsable(iChoiceWeapon))
            {
                lInputActions.Add(this.GetRobot().DealDamage(ennemy, iChoiceWeapon, target));
                return true;
            }

            return false;
        }

        public bool TargetPart(int iChoice)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Verify the weapon choosed is usable.
        /// </summary>
        /// <param name="iChoice"></param>
        /// <returns></returns>
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
