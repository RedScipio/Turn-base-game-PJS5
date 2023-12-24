using PILOT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PJS5_CSharp.Sources.Robot;
using System.Text.Json.Serialization;

namespace PJS5_CSharp.Sources.Pilot.Player
{
    public class PLAYER_PILOT : IPILOT
    {
        private Robot.Robot _pRobot;
        private List<int> _vFuelsReserve;
        private List<int> _vRepairKitsReserve;
        private List<int> _vActionResults;

        public PLAYER_PILOT(Robot.Robot pRobot, List<int> vFuelsReserve, List<int> vRepairKitsReserve) : base(pRobot, vFuelsReserve, vRepairKitsReserve)
        {
            _pRobot = pRobot;
            _vFuelsReserve = vFuelsReserve ?? new List<int> { 0, 0, 0, 0 };
            _vRepairKitsReserve = vRepairKitsReserve ?? new List<int> { 0, 0, 0, 0 };
            _vActionResults = new List<int> { };
        }

        override public void PlayTurn(Robot.Robot pEnnemiRobot, int iActionChoice = -1, int iUsed = -1, int iTargetPart = -1, int iHitChance = -1)
        {
            MainMenu(pEnnemiRobot, iActionChoice, iUsed, iTargetPart);
        }

        private void MainMenu(Robot.Robot pEnnemiRobot, int iActionChoice = -1, int iUsed = -1, int iTargetPart = -1, int iHitChance = -1)
        {
            if (iActionChoice == -1)
            {
                iActionChoice = GUI.Gui.MainMenu();
            }
            switch (iActionChoice)
            {
                case 1:
                    {
                        this.GetActionResults().Add(iActionChoice);
                        AttackMenu(pEnnemiRobot, iUsed, iTargetPart, iHitChance);
                        return;
                    }
                case 2:
                    {
                        this.GetActionResults().Add(iActionChoice);
                        RepairsMenu(pEnnemiRobot, iUsed, iTargetPart);
                        return;
                    }
                case 3:
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

        private void AttackMenu(Robot.Robot pEnnemiRobot, int iUsed = -1, int iTargetPart = -1, int iHitChance = -1)
        {
            if (iUsed == -1)
            {
                iUsed = GUI.Gui.WeaponMenu(this.GetRobot());
            }
            if (_pRobot.NeedToRestart())
            {
                GUI.Gui.RobotRestart();
                MainMenu(pEnnemiRobot);
                return;
            }
            switch (iUsed)
            {
                case 0:
                    {
                        MainMenu(pEnnemiRobot);
                        return;
                    }
                case 1:
                    {
                        this.GetActionResults().Add(iUsed);
                        if (_pRobot.WeaponIsUsable(iUsed))
                        {
                            int iTargetChoice = GUI.Gui.TargetMenu(iTargetPart);
                            this.GetActionResults().Add(iTargetChoice);
                            if (pEnnemiRobot.AttackTargetIsValid(iTargetChoice))
                            {
                                int iRandomizer;
                                if(iHitChance <= -1) iRandomizer = new Random().Next(1, 101);
                                else iRandomizer = iHitChance;

                                this.GetActionResults().Add(iRandomizer);
                                _pRobot.WeaponFired(iUsed);
                                if (_pRobot.GetLeftWeaponHitChance() < iRandomizer)
                                {
                                    GUI.Gui.MissedFire();
                                    return;
                                }
                                else
                                {
                                    int damage = _pRobot.DealDamage(pEnnemiRobot, iUsed, iTargetChoice);
                                    this.GetActionResults().Add(damage);
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
                        this.GetActionResults().Add(iUsed);
                        if (_pRobot.WeaponIsUsable(iUsed))
                        {
                            int iTargetChoice = GUI.Gui.TargetMenu(iTargetPart);
                            this.GetActionResults().Add(iTargetChoice);
                            if (pEnnemiRobot.AttackTargetIsValid(iTargetChoice))
                            {
                                int iRandomizer;
                                if (iHitChance <= -1) iRandomizer = new Random().Next(1, 101);
                                else iRandomizer = iHitChance;

                                this.GetActionResults().Add(iRandomizer);
                                _pRobot.WeaponFired(iUsed);
                                if (_pRobot.GetRightWeaponHitChance() < iRandomizer)
                                {
                                    GUI.Gui.MissedFire();
                                    return;
                                }
                                else
                                {
                                    int damage = _pRobot.DealDamage(pEnnemiRobot, iUsed, iTargetChoice);
                                    this.GetActionResults().Add(damage);
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

        private void RepairsMenu(Robot.Robot pEnnemiRobot, int iActionChoice = -1, int iUsed = -1)
        {
            if (iActionChoice == -1)
            {
                iActionChoice = GUI.Gui.RepairMenu(this, iUsed);
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
                        if (_vRepairKitsReserve[iActionChoice - 1] > 0)
                        {
                            int iTargetChoice = GUI.Gui.TargetMenu(iUsed);
                            this.GetActionResults().Add(iTargetChoice);
                            if (_pRobot.RepairArmorTargetIsValid(iTargetChoice))
                            {
                                _pRobot.RepairRobotArmor(1, iTargetChoice);
                                return;
                            }
                            else
                            {
                                GUI.Gui.PerfectlyFine();
                                RepairsMenu(pEnnemiRobot, iActionChoice, iUsed);
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
                        if (_vRepairKitsReserve[iActionChoice - 1] > 0)
                        {
                            int iTargetChoice = GUI.Gui.TargetMenu(iUsed);
                            this.GetActionResults().Add(iTargetChoice);
                            if (_pRobot.RepairArmorTargetIsValid(iTargetChoice))
                            {
                                _pRobot.RepairRobotArmor(3, iTargetChoice);
                                return;
                            }
                            else
                            {
                                GUI.Gui.PerfectlyFine();
                                RepairsMenu(pEnnemiRobot, iActionChoice, iUsed);
                                return;
                            }
                        }
                        else
                        {
                            GUI.Gui.NoStockKit();
                            RepairsMenu(pEnnemiRobot, iActionChoice, iUsed);
                            return;
                        }
                    }
                case 3:
                    {
                        if (_vRepairKitsReserve[iActionChoice - 1] > 0)
                        {
                            int iTargetChoice = GUI.Gui.TargetMenu(iUsed);
                            this.GetActionResults().Add(iTargetChoice);
                            if (_pRobot.RepairLifeTargetIsValid(iTargetChoice))
                            {
                                _pRobot.RepairRobotLifePoint(1, iTargetChoice);
                                return;
                            }
                            else
                            {
                                GUI.Gui.PerfectlyFine();
                                RepairsMenu(pEnnemiRobot, iActionChoice, iUsed);
                                return;
                            }
                        }
                        else
                        {
                            GUI.Gui.NoStockKit();
                            RepairsMenu(pEnnemiRobot, iActionChoice, iUsed);
                            return;
                        }
                    }
                case 4:
                    {
                        if (_vRepairKitsReserve[iActionChoice - 1] > 0)
                        {
                            int iTargetChoice = GUI.Gui.TargetMenu(iUsed);
                            this.GetActionResults().Add(iTargetChoice);
                            if (_pRobot.RepairLifeTargetIsValid(iTargetChoice))
                            {
                                _pRobot.RepairRobotLifePoint(3, iTargetChoice);
                                return;
                            }
                            else
                            {
                                GUI.Gui.PerfectlyFine();
                                RepairsMenu(pEnnemiRobot, iActionChoice, iUsed);
                                return;
                            }
                        }
                        else
                        {
                            GUI.Gui.NoStockKit();
                            RepairsMenu(pEnnemiRobot, iActionChoice, iUsed);
                            return;
                        }
                    }
                default:
                    {
                        GUI.Gui.WrongEntry();
                        RepairsMenu(pEnnemiRobot, iActionChoice, iUsed);
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

        public List<int> GetActionResults()
        {
            return _vActionResults;
        }
    }
}
