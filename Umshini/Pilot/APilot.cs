﻿using Battle;
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

        public APILOT(APILOT pPilot)
        {
            _pRobot = pPilot.GetRobot();

            this._vFuelsReserve = new List<ICONSUMABLES>();

            foreach (ICONSUMABLES fuel in pPilot.GetFuelsReserve())
            {
                this._vFuelsReserve.Add(fuel.Clone());
            }

            this._vRepairKitsReserve = new List<ICONSUMABLES>();

            foreach (ICONSUMABLES kit in pPilot.GetRepairKitsReserve())
            {
                this._vRepairKitsReserve.Add(kit.Clone());
            }
        }

        public abstract IPILOT Clone();

        public abstract void PlayTurn(IROBOT enemyRobot, MAIN_MENU iChoice = MAIN_MENU.Error, int iRes = -1, int iChoiceTarget = -1, int iHitRate = -1);

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

        public abstract List<int> PlayTurnAuto(IROBOT enemyRobot, bool showIndications = true);

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
        /// Return true if every element in the list has 0 items
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
        /// Refill the robot in fuel with the selected
        /// refuel kit.
        /// Return false if no more kits or already at max fuel.
        /// Else return True.
        /// </summary>
        /// <param name="iChoice"></param>
        /// <returns>bool </returns>
        public bool Refuel(FUEL_TYPE iChoice, List<int> lInputActions)
        {
            if (this._vFuelsReserve[(int)iChoice].GetNumberItems() < 1)
            {
                if (IsAllKitsEmpty(_vFuelsReserve))
                {
                    return true;
                }
                return false;
            }

            if (this._pRobot.GetFuel() < APILOT.MAX_FUEL)
            {
                _pRobot.Refuel(_vFuelsReserve[(int)iChoice].GetValue());
                lInputActions.Add(_vFuelsReserve[(int)iChoice].GetValue());
                _vFuelsReserve[(int)iChoice].DecrNumberItems();
                return true;
            }

            

            return false;
        }

        /// <summary>
        /// Repairing the robot selected part with the selected kit.
        /// </summary>
        /// <param name="eChoice"></param>
        /// <returns> Return False if you are out of kits or if any 
        /// armor/life target are invalid, else return True. </returns>
        public bool Repair(REPAIRS_TYPE eChoice, TARGET_TYPE eChoicePart, List<int> lInputActions)
        {
            if (_vRepairKitsReserve[(int)eChoice].GetNumberItems() < 1)
            {
                return false;
            }

            if(eChoice == REPAIRS_TYPE.Light_Armor || eChoice == REPAIRS_TYPE.Heavy_Armor)
            {
                if (this._pRobot.RepairArmorTargetIsValid(eChoicePart))
                {
                    this._pRobot.RepairRobotArmor(_vRepairKitsReserve[(int)eChoice].GetValue(), eChoicePart);
                    lInputActions.Add(_vRepairKitsReserve[(int)eChoice].GetValue());
                    this._vRepairKitsReserve[(int)eChoice].DecrNumberItems();
                    return true;
                }
                
            }
            
            if(eChoice == REPAIRS_TYPE.Repair_Kits || eChoice == REPAIRS_TYPE.Full_Kits)
            {
                if (this._pRobot.RepairLifeTargetIsValid(eChoicePart))
                {
                    this._pRobot.RepairRobotLifePoint(_vRepairKitsReserve[(int)eChoice].GetValue(), eChoicePart);
                    lInputActions.Add(_vRepairKitsReserve[(int)eChoice].GetValue());
                    this._vRepairKitsReserve[(int)eChoice].DecrNumberItems();
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// Attack a part of the enemy and inflict damage
        /// Return False if the weapon is unusable,
        /// else return True
        /// </summary>
        /// <param name="iChoiceWeapon"> the weapon we choose to attack</param>
        /// <param name="enemy"> the enemy pilot</param>
        /// <param name="target"> the part we selected to attack </param>
        /// <returns>true if the robot attacked, false otherwise</returns>
        public bool Attack(int iChoiceWeapon, IROBOT enemy, TARGET_TYPE target, List<int> lInputActions)

        {
            if (this.GetRobot().WeaponIsUsable(iChoiceWeapon))
            {
                lInputActions.Add(this.GetRobot().DealDamage(enemy, iChoiceWeapon, target));
                return true;
            }

            return false;
        }

        /// <summary>
        /// Verify the weapon choosed is usable.
        /// </summary>
        /// <param name="iChoice"></param>
        /// <returns>bool</returns>
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
        /// return true if the leg is damage
        /// </summary>
        public bool IsLegsDamage()
        {
            return _pRobot.IsLegsDamage();
        }

        /// <summary>
        /// return true if the leg life is damage
        /// </summary>
        public bool IsLegsLifeDamage()
        {
            return _pRobot.IsLegsLifeDamage();
        }

        /// <summary>
        /// return true if the leg armmor is damage
        /// </summary>
        public bool IsLegsArmorDamage()
        {
            return _pRobot.IsLegsArmorDamage();
        }

        /// <summary>
        /// return true if the furnace is broken
        /// </summary>
        public bool IsFurnaceBroken()
        {
            return _pRobot.IsFurnaceBroken();
        }

        /// <summary>
        /// return true if the furnace is damage
        /// </summary>
        public bool IsFurnaceDamage()
        {
            return _pRobot.IsFurnaceDamage();
        }

        /// <summary>
        /// return true if the furnace life is damage
        /// </summary>
        public bool IsFurnaceLifeDamage()
        {
            return _pRobot.IsFurnaceLifeDamage();
        }

        /// <summary>
        /// return true if the furnace armmor is damage
        /// </summary>
        public bool IsFurnaceArmorDamage()
        {
            return _pRobot.IsFurnaceArmorDamage();
        }

        /// <summary>
        /// return true if the weapon is broken
        /// </summary>
        public bool IsWeaponBroken(int iChoice)
        {
            return _pRobot.IsWeaponBroken(iChoice);
        }

        /// <summary>
        /// return true if the weapon is damage
        /// </summary>
        public bool IsWeaponDamage(int iChoice)
        {
            return _pRobot.IsWeaponDamage(iChoice);
        }

        /// <summary>
        /// return true if the weapon life is damage
        /// </summary>
        public bool IsWeaponLifeDamage(int iChoice)
        {
            return _pRobot.IsWeaponLifeDamage(iChoice);
        }

        /// <summary>
        /// return true if the weapon armmor is damage
        /// </summary>
        public bool IsWeaponArmorDamage(int iChoice)
        {
            return _pRobot.IsWeaponArmorDamage(iChoice);
        }

        public int GetLeftWeaponType()
        {
           return  _pRobot.GetWeaponDamage(0);
        }
    }
}
