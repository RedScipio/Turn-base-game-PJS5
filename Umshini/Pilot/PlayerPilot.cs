
using System.Collections.Generic;
using System;
using System.Linq;
using Battle;

namespace Pilot
{
    public class PLAYER_PILOT : APILOT
    {

        private readonly List<int> _vActionResults;

        public PLAYER_PILOT(IROBOT pRobot, List<ICONSUMABLE> vFuelsReserve, List<ICONSUMABLE> vRepairKitsReserve) : base(pRobot, vFuelsReserve, vRepairKitsReserve)
        {
            _vActionResults = new List<int> { };
        }

        override public void PlayTurn(IROBOT pEnnemiRobot, MAIN_MENU iActionChoice = MAIN_MENU.Error, int iUsed = -1, int iTargetPart = -1, int iHitChance = -1)
        {
            MainMenu(pEnnemiRobot, iActionChoice, iUsed, iTargetPart, iHitChance);
        }

        private void MainMenu(IROBOT pEnnemiRobot, MAIN_MENU iActionChoice = MAIN_MENU.Error, int iUsed = -1, int iTargetPart = -1, int iHitChance = -1)
        {
            if (iActionChoice == MAIN_MENU.Error)
            {
                iActionChoice = GUI.MainMenu();
            }
            switch (iActionChoice)
            {
                case MAIN_MENU.Attack:
                    {
                        this.GetActionResults().Add((int)iActionChoice);
                        AttackMenu(pEnnemiRobot, (WEAPON_MENU) iUsed, iTargetPart, iHitChance);
                        return;
                    }
                case MAIN_MENU.Repairs:
                    {
                        this.GetActionResults().Add((int)iActionChoice);
                        RepairsMenu(pEnnemiRobot, (REPAIRS_MENU) iUsed, iTargetPart);
                        return;
                    }
                case MAIN_MENU.Furnace:
                    {
                        this.GetActionResults().Add((int)iActionChoice);
                        FurnaceMenu(pEnnemiRobot, (FUEL_MENU) iUsed, iTargetPart);
                        return;
                    }
                default:
                    {
                        MainMenu(pEnnemiRobot, (MAIN_MENU) iUsed, iTargetPart);
                        return;
                    }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEnemyRobot"></param>
        /// <param name="iUsed"></param>
        /// <param name="iTargetPart"></param>
        /// <param name="iHitChance"></param>
        private void AttackMenu(IROBOT pEnemyRobot, WEAPON_MENU iUsed = WEAPON_MENU.Error, int iTargetPart = -1, int iHitChance = -1)
        {
            if (iUsed == WEAPON_MENU.Error)
            {
                iUsed = GUI.WeaponMenu(this);
            }
            if (_pRobot.NeedToRestart())
            {
                GUI.RobotRestart();
                MainMenu(pEnemyRobot);
                return;
            }

            //--iUsed; // Converti la valeur 1 en 0, etc

            switch (iUsed)
            {
                case WEAPON_MENU.Back:
                    {
                        MainMenu(pEnemyRobot);
                        return;
                    }
                case WEAPON_MENU.Left_Weapon:
                case WEAPON_MENU.Right_Weapon:
                    {
                        int iWeapon = ((int) iUsed) - 1;

                        this.GetActionResults().Add(((int)iUsed));

                        if (_pRobot.WeaponIsUsable(iWeapon))
                        {
                            TARGET_MENU iTargetChoice = GUI.TargetMenu(iTargetPart);
                            PARTS_TYPES eTargetChoice = (PARTS_TYPES)(iTargetChoice);
                            
                            this.GetActionResults().Add((int) iTargetChoice);

                            if (pEnemyRobot.AttackTargetIsValid(eTargetChoice))
                            {
                                int iRandomizer;

                                if (iHitChance <= -1)
                                {
                                    iRandomizer = new Random().Next(1, 101);
                                }
                                else
                                {
                                    iRandomizer = iHitChance;
                                }

                                this.GetActionResults().Add(iRandomizer);
                                _pRobot.WeaponFired(iWeapon);

                                if (_pRobot.GetWeaponHitChance(iWeapon) < iRandomizer)
                                {
                                    GUI.MissedFire();
                                    return;
                                }
                                else
                                {
                                    int damage = _pRobot.DealDamage(pEnemyRobot, iWeapon, (PARTS_TYPES)iTargetChoice);
                                    this.GetActionResults().Add(damage);
                                    return;
                                }
                            }
                            else
                            {
                                GUI.AlreadyDestroy();
                                AttackMenu(pEnemyRobot);
                                return;
                            }
                        }
                        else
                        {
                            GUI.WeaponIsUnusable();
                            AttackMenu(pEnemyRobot);
                            return;
                        }
                    }
                default:
                    {
                        GUI.WrongEntry();
                        AttackMenu(pEnemyRobot);
                        return;
                    }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEnemyRobot">Enemy Robot</param>
        /// <param name="iActionChoice">Choice of Repair's Menu</param>
        /// <param name="iUsed"></param>
        private void RepairsMenu(IROBOT pEnemyRobot, REPAIRS_MENU iActionChoice = REPAIRS_MENU.Error, int iUsed = -1)
        {
            if (iActionChoice == REPAIRS_MENU.Error)
            {
                iActionChoice = GUI.RepairMenu(this, iUsed);
            }
            switch ((REPAIRS_MENU)iActionChoice)
            {
                case REPAIRS_MENU.Back:
                    {
                        MainMenu(pEnemyRobot);
                        return;
                    }
                case REPAIRS_MENU.Light_Armor:
                    {
                        if (_vRepairKitsReserve.Count() > 0)
                        {
                            TARGET_MENU iTargetChoice = GUI.TargetMenu(iUsed);
                            PARTS_TYPES eTargetChoice = (PARTS_TYPES)iTargetChoice;
                            this.GetActionResults().Add((int)iTargetChoice);
                            if (_pRobot.RepairArmorTargetIsValid(eTargetChoice))
                            {
                                _pRobot.RepairRobotArmor(1, eTargetChoice);
                                return;
                            }
                            else
                            {
                                GUI.PerfectlyFine();
                                RepairsMenu(pEnemyRobot, iActionChoice, iUsed);
                                return;
                            }
                        }
                        else
                        {
                            GUI.NoStockKit();
                            RepairsMenu(pEnemyRobot);
                            return;
                        }
                    }
                case REPAIRS_MENU.Heavy_Armor:
                    {
                        if (_vRepairKitsReserve.Count() > 0)
                        {
                            TARGET_MENU iTargetChoice = GUI.TargetMenu(iUsed);
                            PARTS_TYPES eTargetChoice = (PARTS_TYPES)iTargetChoice;
                            this.GetActionResults().Add((int) iTargetChoice);
                            if (_pRobot.RepairArmorTargetIsValid(eTargetChoice))
                            {
                                _pRobot.RepairRobotArmor(3, eTargetChoice);
                                return;
                            }
                            else
                            {
                                GUI.PerfectlyFine();
                                RepairsMenu(pEnemyRobot, iActionChoice, iUsed);
                                return;
                            }
                        }
                        else
                        {
                            GUI.NoStockKit();
                            RepairsMenu(pEnemyRobot, iActionChoice, iUsed);
                            return;
                        }
                    }
                case REPAIRS_MENU.Repair_Kits:
                    {
                        if (_vRepairKitsReserve.Count() > 0)
                        {
                            PARTS_TYPES eTargetChoice = (PARTS_TYPES)GUI.TargetMenu(iUsed);

                            if (_pRobot.RepairLifeTargetIsValid(eTargetChoice))
                            {
                                _pRobot.RepairRobotLifePoint(1, eTargetChoice);
                                return;
                            }
                            else
                            {
                                GUI.PerfectlyFine();
                                RepairsMenu(pEnemyRobot, iActionChoice, iUsed);
                                return;
                            }
                        }
                        else
                        {
                            GUI.NoStockKit();
                            RepairsMenu(pEnemyRobot, iActionChoice, iUsed);
                            return;
                        }
                    }
                case REPAIRS_MENU.Full_Kits:
                    {
                        if (_vRepairKitsReserve.Count() > 0)
                        {
                            TARGET_MENU iTargetChoice = GUI.TargetMenu(iUsed);
                            PARTS_TYPES eTargetChoice = (PARTS_TYPES)iTargetChoice;

                            this.GetActionResults().Add((int)iTargetChoice);
                            if (_pRobot.RepairLifeTargetIsValid(eTargetChoice))
                            {
                                _pRobot.RepairRobotLifePoint(3, eTargetChoice);
                                return;
                            }
                            else
                            {
                                GUI.PerfectlyFine();
                                RepairsMenu(pEnemyRobot, iActionChoice, iUsed);
                                return;
                            }
                        }
                        else
                        {
                            GUI.NoStockKit();
                            RepairsMenu(pEnemyRobot, iActionChoice, iUsed);
                            return;
                        }
                    }
                default:
                    {
                        GUI.WrongEntry();
                        RepairsMenu(pEnemyRobot, iActionChoice, iUsed);
                        return;
                    }
            }
        }

        private void FurnaceMenu(IROBOT pEnnemiRobot, FUEL_MENU iActionChoice = FUEL_MENU.Error, int iUsed = -1)
        {
            //not finished again
            if (iActionChoice == FUEL_MENU.Error)
            {
                iActionChoice = GUI.FuelMenu(this, iUsed);
            }
            switch((FUEL_MENU)iActionChoice) {
                case FUEL_MENU.Wood:
                    {
                        if (_vFuelsReserve.Count() > 0)
                        {
                            pEnnemiRobot.Refuel(15);
                            return;
                        }
                        else
                        {
                            GUI.NoStockFuel();
                            return;
                        }
                    }
                case FUEL_MENU.Charcoal:
                    {
                        if (_vFuelsReserve.Count() > 0)
                        {
                            pEnnemiRobot.Refuel(20);
                            return;
                        }
                        else
                        {
                            GUI.NoStockFuel();
                            return;
                        }
                    }
                case FUEL_MENU.Coal:
                    {
                        if (_vFuelsReserve.Count() > 0)
                        {
                            pEnnemiRobot.Refuel(25);
                            return;
                        }
                        else
                        {
                            GUI.NoStockFuel();
                            return;
                        }
                    }
                case FUEL_MENU.Compact_Coal:
                    {
                        if (_vFuelsReserve.Count() > 0)
                        {
                            this._pRobot.Refuel(35);
                            return;
                        }
                        else
                        {
                            GUI.NoStockFuel();
                            return;
                        }
                    }
                default:
                    return;
            }

        }

        public List<int> GetActionResults()
        {
            return _vActionResults;
        }

        public override bool IsBotPilot()
        {
            return false;
        }
    }
}
