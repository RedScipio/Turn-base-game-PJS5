
using System.Collections.Generic;
using System;

namespace Pilot
{
    public class PLAYER_PILOT : APILOT
    {
        private List<int> _vActionResults;

        public PLAYER_PILOT(IROBOT pRobot, List<ICONSUMABLE> vFuelsReserve, List<ICONSUMABLE> vRepairKitsReserve) : base(pRobot, vFuelsReserve, vRepairKitsReserve)
        {
            _vActionResults = new List<int> { };
        }

        override public void PlayTurn(IROBOT pEnnemiRobot, int iActionChoice = -1, int iUsed = -1, int iTargetPart = -1, int iHitChance = -1)
        {
            MainMenu(pEnnemiRobot, iActionChoice, iUsed, iTargetPart, iHitChance);
        }

        private void MainMenu(IROBOT pEnnemiRobot, int iActionChoice = -1, int iUsed = -1, int iTargetPart = -1, int iHitChance = -1)
        {
            if (iActionChoice == -1)
            {
                iActionChoice = GUI.MainMenu();
            }
            switch ((MAIN_MENU)iActionChoice)
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
        private void AttackMenu(IROBOT pEnemyRobot, int iUsed = -1, int iTargetPart = -1, int iHitChance = -1)
        {
            if (iUsed == -1)
            {
                iUsed = GUI.WeaponMenu(this.GetRobot());
            }
            if (_pRobot.NeedToRestart())
            {
                GUI.RobotRestart();
                MainMenu(pEnemyRobot);
                return;
            }
            WEAPON_SIDE eUsed = (WEAPON_SIDE)(iUsed - 1);
            switch ((WEAPON_MENU)iUsed)
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
                            int iTargetChoice = GUI.TargetMenu(iTargetPart);
                            PARTS_TYPE eTargetChoice = (PARTS_TYPE)(iTargetChoice);
                            this.GetActionResults().Add(iTargetChoice);
                            if (pEnemyRobot.AttackTargetIsValid(eTargetChoice))
                            {
                                int iRandomizer;
                                if (iHitChance <= -1) iRandomizer = new Random().Next(1, 101);
                                else iRandomizer = iHitChance;

                                this.GetActionResults().Add(iRandomizer);
                                _pRobot.WeaponFired(eUsed);
                                if (_pRobot.GetLeftWeaponHitChance() < iRandomizer)
                                {
                                    GUI.MissedFire();
                                    return;
                                }
                                else
                                {
                                    int damage = _pRobot.DealDamage(pEnemyRobot, (WEAPON_SIDE)iUsed, (PARTS_TYPE)iTargetChoice);
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
                case WEAPON_MENU.Right_Weapon:
                    {
                        this.GetActionResults().Add(iUsed);
                        if (_pRobot.WeaponIsUsable(eUsed))
                        {
                            int iTargetChoice = GUI.TargetMenu(iTargetPart);
                            PARTS_TYPE eTargetChoice = (PARTS_TYPE)iTargetChoice;
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
                                    GUI.MissedFire();
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
        private void RepairsMenu(IROBOT pEnemyRobot, int iActionChoice = -1, int iUsed = -1)
        {
            if (iActionChoice == -1)
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
                        if (_vRepairKitsReserve[iActionChoice - 1].GetNumberItems() > 0)
                        {
                            int iTargetChoice = GUI.TargetMenu(iUsed);
                            PARTS_TYPE eTargetChoice = (PARTS_TYPE)iTargetChoice;
                            this.GetActionResults().Add(iTargetChoice);
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
                        if (_vRepairKitsReserve[iActionChoice - 1].GetNumberItems() > 0)
                        {
                            int iTargetChoice = GUI.TargetMenu(iUsed);
                            PARTS_TYPE eTargetChoice = (PARTS_TYPE)iTargetChoice;
                            this.GetActionResults().Add(iTargetChoice);
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
                        if (_vRepairKitsReserve[iActionChoice - 1].GetNumberItems() > 0)
                        {
                            PARTS_TYPE eTargetChoice = (PARTS_TYPE)GUI.TargetMenu(iUsed);

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
                        if (_vRepairKitsReserve[iActionChoice - 1].GetNumberItems() > 0)
                        {
                            int iTargetChoice = GUI.TargetMenu(iUsed);
                            PARTS_TYPE eTargetChoice = (PARTS_TYPE)iTargetChoice;

                            this.GetActionResults().Add(iTargetChoice);
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

        private void FurnaceMenu(IROBOT pEnnemiRobot, int iActionChoice = -1, int iUsed = -1)
        {
            if (iActionChoice == -1)
            {
                iActionChoice = GUI.FuelMenu(this, iUsed);
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
                        ICONSUMABLE iStock = _vFuelsReserve[iActionChoice - 1];
                        if (iStock.GetNumberItems() > 0)
                        {
                            _pRobot.Refuel(15);
                            _vFuelsReserve[iActionChoice - 1].RemoveOneItem();
                            return;
                        }
                        else
                        {
                            GUI.NoStockFuel();
                            FurnaceMenu(pEnnemiRobot, iUsed);
                            return;
                        }
                    }
                case 2:
                    {
                        ICONSUMABLE iStock = _vFuelsReserve[iActionChoice - 1];
                        if (_vFuelsReserve[iActionChoice - 1].GetValue() > 0)
                        {
                            _pRobot.Refuel(20);
                            _vFuelsReserve[iActionChoice - 1].RemoveOneItem();
                            return;
                        }
                        else
                        {
                            GUI.NoStockFuel();
                            FurnaceMenu(pEnnemiRobot, iActionChoice, iUsed);
                            return;
                        }
                    }
                case 3:
                    {
                        ICONSUMABLE iStock = _vFuelsReserve[iActionChoice - 1];
                        if (_vFuelsReserve[iActionChoice - 1].GetValue() > 0)
                        {
                            _pRobot.Refuel(25);
                            _vFuelsReserve[iActionChoice - 1].RemoveOneItem();
                            return;
                        }
                        else
                        {
                            GUI.NoStockFuel();
                            FurnaceMenu(pEnnemiRobot, iActionChoice, iUsed);
                            return;
                        }
                    }
                case 4:
                    {
                        ICONSUMABLE iStock = _vFuelsReserve[iActionChoice - 1];
                        if (_vFuelsReserve[iActionChoice - 1].GetValue() > 0)
                        {
                            _pRobot.Refuel(35);
                            _vFuelsReserve[iActionChoice - 1].RemoveOneItem();
                            return;
                        }
                        else
                        {
                            GUI.NoStockFuel();
                            FurnaceMenu(pEnnemiRobot, iActionChoice, iUsed);
                            return;
                        }
                    }
                default:
                    {
                        GUI.WrongEntry();
                        FurnaceMenu(pEnnemiRobot);
                        return;
                    }
            }
        }

        public List<int> GetActionResults()
        {
            return _vActionResults;
        }

        private class GUI
        {
            internal static void AlreadyDestroy()
            {
                throw new NotImplementedException();
            }

            internal static int FuelMenu(PLAYER_PILOT pLAYER_PILOT, int iUsed)
            {
                throw new NotImplementedException();
            }

            internal static int MainMenu()
            {
                throw new NotImplementedException();
            }

            internal static void MissedFire()
            {
                throw new NotImplementedException();
            }

            internal static void NoStockFuel()
            {
                throw new NotImplementedException();
            }

            internal static void NoStockKit()
            {
                throw new NotImplementedException();
            }

            internal static void PerfectlyFine()
            {
                throw new NotImplementedException();
            }

            internal static int RepairMenu(PLAYER_PILOT pLAYER_PILOT, int iUsed)
            {
                throw new NotImplementedException();
            }

            internal static void RobotRestart()
            {
                throw new NotImplementedException();
            }

            internal static int TargetMenu(int iUsed)
            {
                throw new NotImplementedException();
            }

            internal static void WeaponIsUnusable()
            {
                throw new NotImplementedException();
            }

            internal static int WeaponMenu(IROBOT iROBOT)
            {
                throw new NotImplementedException();
            }

            internal static void WrongEntry()
            {
                throw new NotImplementedException();
            }
        }
    }

    public enum MAIN_MENU
    {
        Attack = 1,
        Repairs = 2,
        Furnace = 3,
    }

    public enum TARGET_MENU
    {
        Back = 0,
        Left_Weapon = 1,
        Right_Weapon = 2,
        Legs = 3,
        Furnace = 4,
    }

    public enum REPAIRS_MENU
    {
        Back = 0,
        Light_Armor = 1,
        Heavy_Armor = 2,
        Repair_Kits = 3,
        Full_Kits = 4,
    }

    public enum WEAPON_MENU
    {
        Back = 0,
        Left_Weapon = 1,
        Right_Weapon = 2,
    }

    public enum FUEL_MENU
    {
        Back = 0,
        Wood = 1,
        Charcoal = 2,
        Coal = 3,
        Compact_Coal = 4,
    }
}
