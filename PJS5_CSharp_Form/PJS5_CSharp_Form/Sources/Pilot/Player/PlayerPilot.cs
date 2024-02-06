using PILOT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PJS5_CSharp.Sources.Robot;
using PJS5_CSharp_Form;
using System.CodeDom;

namespace PJS5_CSharp.Sources.Pilot.Player
{
    public class PLAYER_PILOT : IPILOT
    {
        private const int WAIT_CODE = 133;
        private Robot.Robot _pRobot;
        private List<int> _vFuelsReserve;
        private List<int> _vRepairKitsReserve;

        public PLAYER_PILOT(Robot.Robot pRobot, List<int> vFuelsReserve, List<int> vRepairKitsReserve) : base(pRobot, vFuelsReserve, vRepairKitsReserve)
        {
            _pRobot = pRobot;
            _vFuelsReserve = vFuelsReserve ?? new List<int> { 0, 0, 0, 0 };
            _vRepairKitsReserve = vRepairKitsReserve ?? new List<int> { 0, 0, 0, 0 };
        }

        override
        public void PlayTurn(Robot.Robot pEnnemiRobot)
        {
            MainMenu(pEnnemiRobot);
        }

        private void MainMenu(Robot.Robot pEnnemiRobot, int iChoice = -1)
        {
            if (iChoice == -1)
            {
                iChoice = CombatForm.MainMenu();
            }
            switch (iChoice)
            {
                case 1:
                    {
                        AttackMenu(pEnnemiRobot);
                        return;
                    }
                case 2:
                    {
                        RepairsMenu(pEnnemiRobot);
                        return;
                    }
                case 3:
                    {
                        FurnaceMenu(pEnnemiRobot);
                        return;
                    }
                case WAIT_CODE:
                    return;
                default:
                    {
                        MainMenu(pEnnemiRobot);
                        return;
                    }
            }
        }


        private async void AttackMenu(Robot.Robot pEnnemiRobot, int iChoice = -1)
        {
            if (iChoice == -1)
            {
                iChoice = CombatForm.WeaponMenu(this.GetRobot());
            }
            if (_pRobot.NeedToRestart())
            {
                CombatForm.RobotRestart();
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
                            int iTargetChoice = CombatForm.TargetMenu();
                            if (pEnnemiRobot.AttackTargetIsValid(iTargetChoice))
                            {
                                int iRandomizer = new Random().Next(1, 101);
                                _pRobot.WeaponFired(iChoice);
                                if (_pRobot.GetLeftWeaponHitChance() < iRandomizer)
                                {
                                    CombatForm.MissedFire();
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
                                CombatForm.AlreadyDestroy();
                                AttackMenu(pEnnemiRobot);
                                return;
                            }
                        }
                        else
                        {
                            CombatForm.WeaponIsUnusable();
                            AttackMenu(pEnnemiRobot);
                            return;
                        }
                    }
                case 2:
                    {
                        if (_pRobot.WeaponIsUsable(iChoice))
                        {
                            int iTargetChoice = CombatForm.TargetMenu();
                            if (pEnnemiRobot.AttackTargetIsValid(iTargetChoice))
                            {
                                int iRandomizer = new Random().Next(1, 101);
                                _pRobot.WeaponFired(iChoice);
                                if (_pRobot.GetRightWeaponHitChance() < iRandomizer)
                                {
                                    CombatForm.MissedFire();
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
                                CombatForm.AlreadyDestroy();
                                AttackMenu(pEnnemiRobot);
                                return;
                            }
                        }
                        else
                        {
                            CombatForm.WeaponIsUnusable();
                            AttackMenu(pEnnemiRobot);
                            return;
                        }
                    }
                case WAIT_CODE:
                    await Task.Delay(1);
                    int iC = CombatForm.GetiResultValue();
                    AttackMenu(pEnnemiRobot, iC);
                    return;
                default:
                    {
                        CombatForm.WrongEntry();
                        AttackMenu(pEnnemiRobot);
                        return;
                    }
            }
        }

        private async void RepairsMenu(Robot.Robot pEnnemiRobot, int iChoice = -1)
        {
            if (iChoice == -1)
            {
                iChoice = CombatForm.RepairMenu(this);
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
                            int iTargetChoice = CombatForm.TargetMenu();
                            if (_pRobot.RepairArmorTargetIsValid(iTargetChoice))
                            {
                                _pRobot.RepairRobotArmor(1, iTargetChoice);
                                return;
                            }
                            else
                            {
                                CombatForm.PerfectlyFine();
                                RepairsMenu(pEnnemiRobot);
                                return;
                            }
                        }
                        else
                        {
                            CombatForm.NoStockKit();
                            RepairsMenu(pEnnemiRobot);
                            return;
                        }
                    }
                case 2:
                    {
                        if (_vRepairKitsReserve[iChoice - 1] > 0)
                        {
                            int iTargetChoice = CombatForm.TargetMenu();
                            if (_pRobot.RepairArmorTargetIsValid(iTargetChoice))
                            {
                                _pRobot.RepairRobotArmor(3, iTargetChoice);
                                return;
                            }
                            else
                            {
                                CombatForm.PerfectlyFine();
                                RepairsMenu(pEnnemiRobot);
                                return;
                            }
                        }
                        else
                        {
                            CombatForm.NoStockKit();
                            RepairsMenu(pEnnemiRobot);
                            return;
                        }
                    }
                case 3:
                    {
                        if (_vRepairKitsReserve[iChoice - 1] > 0)
                        {
                            int iTargetChoice = CombatForm.TargetMenu();
                            if (_pRobot.RepairLifeTargetIsValid(iTargetChoice))
                            {
                                _pRobot.RepairRobotLifePoint(1, iTargetChoice);
                                return;
                            }
                            else
                            {
                                CombatForm.PerfectlyFine();
                                RepairsMenu(pEnnemiRobot);
                                return;
                            }
                        }
                        else
                        {
                            CombatForm.NoStockKit();
                            RepairsMenu(pEnnemiRobot);
                            return;
                        }
                    }
                case 4:
                    {
                        if (_vRepairKitsReserve[iChoice - 1] > 0)
                        {
                            int iTargetChoice = CombatForm.TargetMenu();
                            if (_pRobot.RepairLifeTargetIsValid(iTargetChoice))
                            {
                                _pRobot.RepairRobotLifePoint(3, iTargetChoice);
                                return;
                            }
                            else
                            {
                                CombatForm.PerfectlyFine();
                                RepairsMenu(pEnnemiRobot);
                                return;
                            }
                        }
                        else
                        {
                            CombatForm.NoStockKit();
                            RepairsMenu(pEnnemiRobot);
                            return;
                        }
                    }
                case WAIT_CODE:
                    await Task.Delay(1);
                    int iC = CombatForm.GetiResultValue();
                    RepairsMenu(pEnnemiRobot, iC);
                    return;
                default:
                    {
                        CombatForm.WrongEntry();
                        RepairsMenu(pEnnemiRobot);
                        return;
                    }
            }
        }

        private async void FurnaceMenu(Robot.Robot pEnnemiRobot, int iChoice = -1)
        {
            if (iChoice == -1)
            {
                iChoice = CombatForm.FuelMenu(this);
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
                            CombatForm.NoStockFuel();
                            FurnaceMenu(pEnnemiRobot);
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
                            CombatForm.NoStockFuel();
                            FurnaceMenu(pEnnemiRobot);
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
                            CombatForm.NoStockFuel();
                            FurnaceMenu(pEnnemiRobot);
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
                            CombatForm.NoStockFuel();
                            FurnaceMenu(pEnnemiRobot);
                            return;
                        }
                    }
                case WAIT_CODE:
                    await Task.Delay(1);
                    int iC = CombatForm.GetiResultValue();
                    FurnaceMenu(pEnnemiRobot, iC);
                    return;
                default:
                    {
                        CombatForm.WrongEntry();
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
