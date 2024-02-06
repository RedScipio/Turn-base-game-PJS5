using PILOT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PJS5_CSharp.Sources.Robot;
using GUI;

namespace PJS5_CSharp.Sources.Pilot.Player
{
    public class PLAYER_PILOT : IPILOT
    {
        private List<int> _vActionResults;

        public PLAYER_PILOT(Robot.Robot pRobot, List<int> vFuelsReserve, List<int> vRepairKitsReserve) : base(pRobot, vFuelsReserve, vRepairKitsReserve)
        {
            _vActionResults = new List<int> { };
        }

        override public void PlayTurn(Robot.Robot pEnnemiRobot, int iActionChoice = -1, int iUsed = -1, int iTargetPart = -1, int iHitChance = -1)
        {
            MainMenu(pEnnemiRobot, iActionChoice, iUsed, iTargetPart, iHitChance);
        }

        private void MainMenu(Robot.Robot pEnnemiRobot, int iActionChoice = -1, int iUsed = -1, int iTargetPart = -1, int iHitChance = -1)
        {
            if (iActionChoice == -1)
            {
                iActionChoice = GUI.Gui.MainMenu();
            }
            switch ((MAIN_MENU) iActionChoice)
            {
                case MAIN_MENU.Attack:
                    {
                        this.GetActionResults().Add(iActionChoice);
                        AttackMenu(pEnnemiRobot, iUsed, iTargetPart, iHitChance);
                        return;
                    }
                case MAIN_MENU.Repairs:
                    {
                        this.GetActionResults().Add(iActionChoice);
                        RepairsMenu(pEnnemiRobot, iUsed, iTargetPart);
                        return;
                    }
                case MAIN_MENU.Furnace:
                    {
                        this.GetActionResults().Add(iActionChoice);
                        FurnaceMenu(pEnnemiRobot, iUsed, iTargetPart);
                        return;
                    }
                default:
                    {
                        MainMenu(pEnnemiRobot, iUsed, iTargetPart);
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
        private void AttackMenu(Robot.Robot pEnemyRobot, int iUsed = -1, int iTargetPart = -1, int iHitChance = -1)
        {
            if (iUsed == -1)
            {
                iUsed = GUI.Gui.WeaponMenu(this.GetRobot());
            }
            if (_pRobot.NeedToRestart())
            {
                GUI.Gui.RobotRestart();
                MainMenu(pEnemyRobot);
                return;
            }
            WEAPON_SIDE eUsed = (WEAPON_SIDE) (iUsed - 1);
            switch ((WEAPON_MENU) iUsed)
            {
                case WEAPON_MENU.Back:
                    {
                        MainMenu(pEnemyRobot);
                        return;
                    }
                case WEAPON_MENU.Left_Weapon:
                    {
                        this.GetActionResults().Add(iUsed);
                        if (_pRobot.WeaponIsUsable(eUsed))
                        {
                            int iTargetChoice = GUI.Gui.TargetMenu(iTargetPart);
                            PARTS_TYPE eTargetChoice = (PARTS_TYPE) (iTargetChoice);
                            this.GetActionResults().Add(iTargetChoice);
                            if (pEnemyRobot.AttackTargetIsValid(eTargetChoice))
                            {
                                int iRandomizer;
                                if(iHitChance <= -1) iRandomizer = new Random().Next(1, 101);
                                else iRandomizer = iHitChance;

                                this.GetActionResults().Add(iRandomizer);
                                _pRobot.WeaponFired(eUsed);
                                if (_pRobot.GetLeftWeaponHitChance() < iRandomizer)
                                {
                                    GUI.Gui.MissedFire();
                                    return;
                                }
                                else
                                {
                                    int damage = _pRobot.DealDamage(pEnemyRobot, (WEAPON_SIDE) iUsed, (PARTS_TYPE) iTargetChoice);
                                    this.GetActionResults().Add(damage);
                                    return;
                                }
                            }
                            else
                            {
                                GUI.Gui.AlreadyDestroy();
                                AttackMenu(pEnemyRobot);
                                return;
                            }
                        }
                        else
                        {
                            GUI.Gui.WeaponIsUnusable();
                            AttackMenu(pEnemyRobot);
                            return;
                        }
                    }
                case WEAPON_MENU.Right_Weapon:
                    {
                        this.GetActionResults().Add(iUsed);
                        if (_pRobot.WeaponIsUsable(eUsed))
                        {
                            int iTargetChoice = GUI.Gui.TargetMenu(iTargetPart);
                            PARTS_TYPE eTargetChoice = (PARTS_TYPE) iTargetChoice;
                            this.GetActionResults().Add(iTargetChoice);
                            if (pEnemyRobot.AttackTargetIsValid(eTargetChoice))
                            {
                                int iRandomizer;
                                if (iHitChance <= -1) iRandomizer = new Random().Next(1, 101);
                                else iRandomizer = iHitChance;

                                this.GetActionResults().Add(iRandomizer);
                                _pRobot.WeaponFired(eUsed);
                                if (_pRobot.GetRightWeaponHitChance() < iRandomizer)
                                {
                                    GUI.Gui.MissedFire();
                                    return;
                                }
                                else
                                {
                                    int damage = _pRobot.DealDamage(pEnemyRobot, eUsed, eTargetChoice);
                                    this.GetActionResults().Add(damage);
                                    return;
                                }
                            }
                            else
                            {
                                GUI.Gui.AlreadyDestroy();
                                AttackMenu(pEnemyRobot);
                                return;
                            }
                        }
                        else
                        {
                            GUI.Gui.WeaponIsUnusable();
                            AttackMenu(pEnemyRobot);
                            return;
                        }
                    }
                default:
                    {
                        GUI.Gui.WrongEntry();
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
        private void RepairsMenu(Robot.Robot pEnemyRobot, int iActionChoice = -1, int iUsed = -1)
        {
            if (iActionChoice == -1)
            {
                iActionChoice = GUI.Gui.RepairMenu(this, iUsed);
            }
            switch ((REPAIRS_MENU) iActionChoice)
            {
                case REPAIRS_MENU.Back:
                    {
                        MainMenu(pEnemyRobot);
                        return;
                    }
                case REPAIRS_MENU.Light_Armor:
                    {
                        if (_vRepairKitsReserve[iActionChoice - 1] > 0)
                        {
                            int iTargetChoice = GUI.Gui.TargetMenu(iUsed);
                            PARTS_TYPE eTargetChoice = (PARTS_TYPE)iTargetChoice;
                            this.GetActionResults().Add(iTargetChoice);
                            if (_pRobot.RepairArmorTargetIsValid(eTargetChoice))
                            {
                                _pRobot.RepairRobotArmor(1, eTargetChoice);
                                return;
                            }
                            else
                            {
                                GUI.Gui.PerfectlyFine();
                                RepairsMenu(pEnemyRobot, iActionChoice, iUsed);
                                return;
                            }
                        }
                        else
                        {
                            GUI.Gui.NoStockKit();
                            RepairsMenu(pEnemyRobot);
                            return;
                        }
                    }
                case REPAIRS_MENU.Heavy_Armor:
                    {
                        if (_vRepairKitsReserve[iActionChoice - 1] > 0)
                        {
                            int iTargetChoice = GUI.Gui.TargetMenu(iUsed);
                            PARTS_TYPE eTargetChoice = (PARTS_TYPE)iTargetChoice;
                            this.GetActionResults().Add(iTargetChoice);
                            if (_pRobot.RepairArmorTargetIsValid(eTargetChoice))
                            {
                                _pRobot.RepairRobotArmor(3, eTargetChoice);
                                return;
                            }
                            else
                            {
                                GUI.Gui.PerfectlyFine();
                                RepairsMenu(pEnemyRobot, iActionChoice, iUsed);
                                return;
                            }
                        }
                        else
                        {
                            GUI.Gui.NoStockKit();
                            RepairsMenu(pEnemyRobot, iActionChoice, iUsed);
                            return;
                        }
                    }
                case REPAIRS_MENU.Repair_Kits:
                    {
                        if (_vRepairKitsReserve[iActionChoice - 1] > 0)
                        {
                            PARTS_TYPE eTargetChoice = (PARTS_TYPE) GUI.Gui.TargetMenu(iUsed);

                            if (_pRobot.RepairLifeTargetIsValid(eTargetChoice))
                            {
                                _pRobot.RepairRobotLifePoint(1, eTargetChoice);
                                return;
                            }
                            else
                            {
                                GUI.Gui.PerfectlyFine();
                                RepairsMenu(pEnemyRobot, iActionChoice, iUsed);
                                return;
                            }
                        }
                        else
                        {
                            GUI.Gui.NoStockKit();
                            RepairsMenu(pEnemyRobot, iActionChoice, iUsed);
                            return;
                        }
                    }
                case REPAIRS_MENU.Full_Kits:
                    {
                        if (_vRepairKitsReserve[iActionChoice - 1] > 0)
                        {
                            int iTargetChoice = GUI.Gui.TargetMenu(iUsed);
                            PARTS_TYPE eTargetChoice = (PARTS_TYPE) iTargetChoice;

                            this.GetActionResults().Add(iTargetChoice);
                            if (_pRobot.RepairLifeTargetIsValid(eTargetChoice))
                            {
                                _pRobot.RepairRobotLifePoint(3, eTargetChoice);
                                return;
                            }
                            else
                            {
                                GUI.Gui.PerfectlyFine();
                                RepairsMenu(pEnemyRobot, iActionChoice, iUsed);
                                return;
                            }
                        }
                        else
                        {
                            GUI.Gui.NoStockKit();
                            RepairsMenu(pEnemyRobot, iActionChoice, iUsed);
                            return;
                        }
                    }
                default:
                    {
                        GUI.Gui.WrongEntry();
                        RepairsMenu(pEnemyRobot, iActionChoice, iUsed);
                        return;
                    }
            }
        }

        private void FurnaceMenu(Robot.Robot pEnnemiRobot, int iActionChoice = -1, int iUsed = -1)
        {
            if (iActionChoice == -1)
            {
                iActionChoice = GUI.Gui.FuelMenu(this, iUsed);
            }
            switch (iActionChoice)
            {
                case 0:
                    {
                        MainMenu(pEnnemiRobot);
                        return;
                    }
                case 1:
                    {
                        int iStock = _vFuelsReserve[iActionChoice - 1];
                        if (iStock > 0)
                        {
                            _pRobot.Refuel(15);
                            _vFuelsReserve[iActionChoice - 1] = iStock - 1;
                            return;
                        }
                        else
                        {
                            GUI.Gui.NoStockFuel();
                            FurnaceMenu(pEnnemiRobot, iUsed);
                            return;
                        }
                    }
                case 2:
                    {
                        int iStock = _vFuelsReserve[iActionChoice - 1];
                        if (_vFuelsReserve[iActionChoice - 1] > 0)
                        {
                            _pRobot.Refuel(20);
                            _vFuelsReserve[iActionChoice - 1] = iStock - 1;
                            return;
                        }
                        else
                        {
                            GUI.Gui.NoStockFuel();
                            FurnaceMenu(pEnnemiRobot, iActionChoice, iUsed);
                            return;
                        }
                    }
                case 3:
                    {
                        int iStock = _vFuelsReserve[iActionChoice - 1];
                        if (_vFuelsReserve[iActionChoice - 1] > 0)
                        {
                            _pRobot.Refuel(25);
                            _vFuelsReserve[iActionChoice - 1] = iStock - 1;
                            return;
                        }
                        else
                        {
                            GUI.Gui.NoStockFuel();
                            FurnaceMenu(pEnnemiRobot, iActionChoice, iUsed);
                            return;
                        }
                    }
                case 4:
                    {
                        int iStock = _vFuelsReserve[iActionChoice - 1];
                        if (_vFuelsReserve[iActionChoice - 1] > 0)
                        {
                            _pRobot.Refuel(35);
                            _vFuelsReserve[iActionChoice - 1] = iStock - 1;
                            return;
                        }
                        else
                        {
                            GUI.Gui.NoStockFuel();
                            FurnaceMenu(pEnnemiRobot, iActionChoice, iUsed);
                            return;
                        }
                    }
                default:
                    {
                        GUI.Gui.WrongEntry();
                        FurnaceMenu(pEnnemiRobot);
                        return;
                    }
            }
        }

        public List<int> GetActionResults()
        {
            return _vActionResults;
        }
    }
}
