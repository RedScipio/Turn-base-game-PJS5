﻿using PILOT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PJS5_CSharp.Sources.Robot;

namespace PJS5_CSharp.Sources.Pilot.Player
{
    public class PLAYER_PILOT : IPILOT
    {
        private Robot.Robot _pRobot;
        private List<int> _vFuelsReserve;
        private List<int> _vRepairKitsReserve;
        private List<int> _ResultsInputs;

        public PLAYER_PILOT(Robot.Robot pRobot, List<int> vFuelsReserve, List<int> vRepairKitsReserve) : base(pRobot, vFuelsReserve, vRepairKitsReserve)
        {
            _pRobot = pRobot;
            _vFuelsReserve = vFuelsReserve ?? new List<int> { 0, 0, 0, 0 };
            _vRepairKitsReserve = vRepairKitsReserve ?? new List<int> { 0, 0, 0, 0 };
            //
            _ResultsInputs = new List<int> { };
        }

        override public void PlayTurn(Robot.Robot pEnnemiRobot, int iChoice = -1, int iRes = -1, int iParts = -1)
        {
            MainMenu(pEnnemiRobot, iChoice, iRes);
        }

        private void MainMenu(Robot.Robot pEnnemiRobot, int iChoice = -1, int iChoiceRes = -1)
        {
            if (iChoice == -1)
            {
                iChoice = GUI.Gui.MainMenu();
            }
            switch (iChoice)
            {
                case 1:
                    {
                        AttackMenu(pEnnemiRobot, iChoiceRes);
                        return;
                    }
                case 2:
                    {
                        RepairsMenu(pEnnemiRobot, iChoiceRes);
                        return;
                    }
                case 3:
                    {
                        FurnaceMenu(pEnnemiRobot, iChoiceRes);
                        return;
                    }
                default:
                    {
                        MainMenu(pEnnemiRobot, iChoiceRes);
                        return;
                    }
            }
        }

        private void AttackMenu(Robot.Robot pEnnemiRobot, int iChoice = -1, int iChoiceRes = -1)
        {
            if (iChoice == -1)
            {
                iChoice = GUI.Gui.WeaponMenu(this.GetRobot());
            }
            if (_pRobot.NeedToRestart())
            {
                GUI.Gui.RobotRestart();
                MainMenu(pEnnemiRobot);
                return;
            }
            switch (iChoice)
            {
                case 0:
                    {
                        MainMenu(pEnnemiRobot);
                        return;
                    }
                case 1:
                    {
                        if (_pRobot.WeaponIsUsable(iChoice))
                        {
                            int iTargetChoice = GUI.Gui.TargetMenu(iChoiceRes);
                            if (pEnnemiRobot.AttackTargetIsValid(iTargetChoice))
                            {
                                //get the value in a json file for example or a list (serialize)
                                int iRandomizer = new Random().Next(1, 101);
                                _pRobot.WeaponFired(iChoice);
                                if (_pRobot.GetLeftWeaponHitChance() < iRandomizer)
                                {
                                    GUI.Gui.MissedFire();
                                    return;
                                }
                                else
                                {
                                    _pRobot.DealDamage(pEnnemiRobot, iChoice, iTargetChoice);
                                    return;
                                }
                            }
                            else
                            {
                                GUI.Gui.AlreadyDestroy();
                                AttackMenu(pEnnemiRobot);
                                return;
                            }
                        }
                        else
                        {
                            GUI.Gui.WeaponIsUnusable();
                            AttackMenu(pEnnemiRobot);
                            return;
                        }
                    }
                case 2:
                    {
                        if (_pRobot.WeaponIsUsable(iChoice))
                        {
                            int iTargetChoice = GUI.Gui.TargetMenu(iChoiceRes);
                            if (pEnnemiRobot.AttackTargetIsValid(iTargetChoice))
                            {
                                int iRandomizer = new Random().Next(1, 101);
                                _pRobot.WeaponFired(iChoice);
                                if (_pRobot.GetRightWeaponHitChance() < iRandomizer)
                                {
                                    GUI.Gui.MissedFire();
                                    return;
                                }
                                else
                                {
                                    _pRobot.DealDamage(pEnnemiRobot, iChoice, iTargetChoice);
                                    return;
                                }
                            }
                            else
                            {
                                GUI.Gui.AlreadyDestroy();
                                AttackMenu(pEnnemiRobot);
                                return;
                            }
                        }
                        else
                        {
                            GUI.Gui.WeaponIsUnusable();
                            AttackMenu(pEnnemiRobot);
                            return;
                        }
                    }
                default:
                    {
                        GUI.Gui.WrongEntry();
                        AttackMenu(pEnnemiRobot);
                        return;
                    }
            }
        }

        private void RepairsMenu(Robot.Robot pEnnemiRobot, int iChoice = -1, int iChoiceRes = -1)
        {
            if (iChoice == -1)
            {
                iChoice = GUI.Gui.RepairMenu(this, iChoiceRes);
            }
            switch (iChoice)
            {
                case 0:
                    {
                        MainMenu(pEnnemiRobot);
                        return;
                    }
                case 1:
                    {
                        if (_vRepairKitsReserve[iChoice - 1] > 0)
                        {
                            int iTargetChoice = GUI.Gui.TargetMenu(iChoiceRes);
                            if (_pRobot.RepairArmorTargetIsValid(iTargetChoice))
                            {
                                _pRobot.RepairRobotArmor(1, iTargetChoice);
                                return;
                            }
                            else
                            {
                                GUI.Gui.PerfectlyFine();
                                RepairsMenu(pEnnemiRobot, iChoice, iChoiceRes);
                                return;
                            }
                        }
                        else
                        {
                            GUI.Gui.NoStockKit();
                            RepairsMenu(pEnnemiRobot);
                            return;
                        }
                    }
                case 2:
                    {
                        if (_vRepairKitsReserve[iChoice - 1] > 0)
                        {
                            int iTargetChoice = GUI.Gui.TargetMenu(iChoiceRes);
                            if (_pRobot.RepairArmorTargetIsValid(iTargetChoice))
                            {
                                _pRobot.RepairRobotArmor(3, iTargetChoice);
                                return;
                            }
                            else
                            {
                                GUI.Gui.PerfectlyFine();
                                RepairsMenu(pEnnemiRobot, iChoice, iChoiceRes);
                                return;
                            }
                        }
                        else
                        {
                            GUI.Gui.NoStockKit();
                            RepairsMenu(pEnnemiRobot, iChoice, iChoiceRes);
                            return;
                        }
                    }
                case 3:
                    {
                        if (_vRepairKitsReserve[iChoice - 1] > 0)
                        {
                            int iTargetChoice = GUI.Gui.TargetMenu(iChoiceRes);
                            if (_pRobot.RepairLifeTargetIsValid(iTargetChoice))
                            {
                                _pRobot.RepairRobotLifePoint(1, iTargetChoice);
                                return;
                            }
                            else
                            {
                                GUI.Gui.PerfectlyFine();
                                RepairsMenu(pEnnemiRobot, iChoice, iChoiceRes);
                                return;
                            }
                        }
                        else
                        {
                            GUI.Gui.NoStockKit();
                            RepairsMenu(pEnnemiRobot, iChoice, iChoiceRes);
                            return;
                        }
                    }
                case 4:
                    {
                        if (_vRepairKitsReserve[iChoice - 1] > 0)
                        {
                            int iTargetChoice = GUI.Gui.TargetMenu(iChoiceRes);
                            if (_pRobot.RepairLifeTargetIsValid(iTargetChoice))
                            {
                                _pRobot.RepairRobotLifePoint(3, iTargetChoice);
                                return;
                            }
                            else
                            {
                                GUI.Gui.PerfectlyFine();
                                RepairsMenu(pEnnemiRobot, iChoice, iChoiceRes);
                                return;
                            }
                        }
                        else
                        {
                            GUI.Gui.NoStockKit();
                            RepairsMenu(pEnnemiRobot, iChoice, iChoiceRes);
                            return;
                        }
                    }
                default:
                    {
                        GUI.Gui.WrongEntry();
                        RepairsMenu(pEnnemiRobot, iChoice, iChoiceRes);
                        return;
                    }
            }
        }

        private void FurnaceMenu(Robot.Robot pEnnemiRobot, int iChoice = -1, int iChoiceRes = -1)
        {
            if (iChoice == -1)
            {
                iChoice = GUI.Gui.FuelMenu(this, iChoiceRes);
            }
            switch (iChoice)
            {
                case 0:
                    {
                        MainMenu(pEnnemiRobot);
                        return;
                    }
                case 1:
                    {
                        int iStock = _vFuelsReserve[iChoice - 1];
                        if (iStock > 0)
                        {
                            _pRobot.Refuel(15);
                            _vFuelsReserve[iChoice - 1] = iStock - 1;
                            return;
                        }
                        else
                        {
                            GUI.Gui.NoStockFuel();
                            FurnaceMenu(pEnnemiRobot, iChoiceRes);
                            return;
                        }
                    }
                case 2:
                    {
                        int iStock = _vFuelsReserve[iChoice - 1];
                        if (_vFuelsReserve[iChoice - 1] > 0)
                        {
                            _pRobot.Refuel(20);
                            _vFuelsReserve[iChoice - 1] = iStock - 1;
                            return;
                        }
                        else
                        {
                            GUI.Gui.NoStockFuel();
                            FurnaceMenu(pEnnemiRobot, iChoice, iChoiceRes);
                            return;
                        }
                    }
                case 3:
                    {
                        int iStock = _vFuelsReserve[iChoice - 1];
                        if (_vFuelsReserve[iChoice - 1] > 0)
                        {
                            _pRobot.Refuel(25);
                            _vFuelsReserve[iChoice - 1] = iStock - 1;
                            return;
                        }
                        else
                        {
                            GUI.Gui.NoStockFuel();
                            FurnaceMenu(pEnnemiRobot, iChoice, iChoiceRes);
                            return;
                        }
                    }
                case 4:
                    {
                        int iStock = _vFuelsReserve[iChoice - 1];
                        if (_vFuelsReserve[iChoice - 1] > 0)
                        {
                            _pRobot.Refuel(35);
                            _vFuelsReserve[iChoice - 1] = iStock - 1;
                            return;
                        }
                        else
                        {
                            GUI.Gui.NoStockFuel();
                            FurnaceMenu(pEnnemiRobot, iChoice, iChoiceRes);
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


        public bool RobotIsDestroy()
        {
            return _pRobot.IsDestroy();
        }

        public Robot.Robot GetRobot()
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
