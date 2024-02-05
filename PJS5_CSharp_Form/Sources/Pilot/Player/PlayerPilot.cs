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
        private const int CONTINUE_CODE = 134;
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

        private async void MainMenu(Robot.Robot pEnnemiRobot, int iChoice = -1)
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
                    await Task.Delay(100);
                    int iC = CombatForm.GetInt();
                    MainMenu(pEnnemiRobot, iC);
                    return;
                default:
                    {
                        //Console.WriteLine("ERROR");
                        return;
                    }
            }
        }


        private async void AttackMenu(Robot.Robot pEnnemiRobot, int iChoice = -1)
        {
            if (iChoice == -1)
            {
                CombatForm.WeaponMenu(this.GetRobot());
                while (CombatForm.GetiResultValue() == WAIT_CODE)
                {

                    await Task.Delay(100);
                    //Console.WriteLine("Waiting for Weapon");
                }
                iChoice = CombatForm.GetInt();
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
                            CombatForm.TargetMenu();
                            while (CombatForm.GetiResultValue() == WAIT_CODE)
                            {

                                await Task.Delay(100);
                                //Console.WriteLine("Waiting for Target");
                            }
                            int iTargetChoice = CombatForm.GetInt();
                            if (pEnnemiRobot.AttackTargetIsValid(iTargetChoice))
                            {
                                int iRandomizer = new Random().Next(1, 101);
                                _pRobot.WeaponFired(iChoice);
                                if (_pRobot.GetLeftWeaponHitChance() < iRandomizer)
                                {
                                    CombatForm.MissedFire();
                                    CombatForm.SetInt(CONTINUE_CODE);
                                    return;
                                }
                                else
                                {
                                    _pRobot.DealDamage(pEnnemiRobot, iChoice, iTargetChoice);
                                    CombatForm.SetInt(CONTINUE_CODE);
                                    return;
                                }
                            }
                            else
                            {
                                CombatForm.AlreadyDestroy();
                                AttackMenu(pEnnemiRobot);
                                CombatForm.SetInt(CONTINUE_CODE);
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
                            CombatForm.TargetMenu();
                            while (CombatForm.GetiResultValue() == WAIT_CODE)
                            {

                                await Task.Delay(100);
                                //Console.WriteLine("Waiting for Target");
                            }
                            int iTargetChoice = CombatForm.GetInt();
                            if (pEnnemiRobot.AttackTargetIsValid(iTargetChoice))
                            {
                                int iRandomizer = new Random().Next(1, 101);
                                _pRobot.WeaponFired(iChoice);
                                if (_pRobot.GetRightWeaponHitChance() < iRandomizer)
                                {
                                    CombatForm.MissedFire();
                                    CombatForm.SetInt(CONTINUE_CODE);
                                    return;
                                }
                                else
                                {
                                    _pRobot.DealDamage(pEnnemiRobot, iChoice, iTargetChoice);
                                    CombatForm.SetInt(CONTINUE_CODE);
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
                    await Task.Delay(100);
                    int iC = CombatForm.GetInt();
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
                CombatForm.RepairMenu(this);
                while (CombatForm.GetiResultValue() == WAIT_CODE)
                {

                    await Task.Delay(100);
                    //Console.WriteLine("Waiting for Kit Type");
                }
                iChoice = CombatForm.GetInt();
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
                            CombatForm.TargetMenu();
                            while (CombatForm.GetiResultValue() == WAIT_CODE)
                            {

                                await Task.Delay(100);
                                //Console.WriteLine("Waiting for Target");
                            }
                            int iTargetChoice = CombatForm.GetInt();
                            if (_pRobot.RepairArmorTargetIsValid(iTargetChoice))
                            {
                                _pRobot.RepairRobotArmor(1, iTargetChoice);
                                CombatForm.SetInt(CONTINUE_CODE);
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
                            CombatForm.TargetMenu();
                            while (CombatForm.GetiResultValue() == WAIT_CODE)
                            {

                                await Task.Delay(100);
                                //Console.WriteLine("Waiting for Target");
                            }
                            int iTargetChoice = CombatForm.GetInt();
                            if (_pRobot.RepairArmorTargetIsValid(iTargetChoice))
                            {
                                _pRobot.RepairRobotArmor(3, iTargetChoice);
                                CombatForm.SetInt(CONTINUE_CODE);
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
                            CombatForm.TargetMenu();
                            while (CombatForm.GetiResultValue() == WAIT_CODE)
                            {

                                await Task.Delay(100);
                                //Console.WriteLine("Waiting for Target");
                            }
                            int iTargetChoice = CombatForm.GetInt();
                            if (_pRobot.RepairLifeTargetIsValid(iTargetChoice))
                            {
                                _pRobot.RepairRobotLifePoint(1, iTargetChoice);
                                CombatForm.SetInt(CONTINUE_CODE);
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
                            CombatForm.TargetMenu();
                            while (CombatForm.GetiResultValue() == WAIT_CODE)
                            {

                                await Task.Delay(100);
                                //Console.WriteLine("Waiting for Target");
                            }
                            int iTargetChoice = CombatForm.GetInt();
                            if (_pRobot.RepairLifeTargetIsValid(iTargetChoice))
                            {
                                _pRobot.RepairRobotLifePoint(3, iTargetChoice);
                                CombatForm.SetInt(CONTINUE_CODE);
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
                    await Task.Delay(100);
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
                CombatForm.FuelMenu(this);
                while (CombatForm.GetiResultValue() == WAIT_CODE)
                {

                    await Task.Delay(100);
                    //Console.WriteLine("Waiting for Kit Type");
                }
                iChoice = CombatForm.GetInt();
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
                            CombatForm.SetInt(CONTINUE_CODE);
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
                            CombatForm.SetInt(CONTINUE_CODE);
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
                            CombatForm.SetInt(CONTINUE_CODE);
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
                            CombatForm.SetInt(CONTINUE_CODE);
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
                    await Task.Delay(100);
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
