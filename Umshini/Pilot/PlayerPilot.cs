
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
                iUsed = GUI.WeaponMenu();
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
                case 0:
                    {
                        MainMenu(pEnemyRobot);
                        return;
                    }
                case 1:
                case 2:
                    {
                        int iWeapon = iUsed - 1;

                        this.GetActionResults().Add(iUsed);

                        if (_pRobot.WeaponIsUsable(iWeapon))
                        {
                            int iTargetChoice = GUI.TargetMenu(iTargetPart);
                            PARTS_TYPES eTargetChoice = (PARTS_TYPES)(iTargetChoice);
                            
                            this.GetActionResults().Add(iTargetChoice);

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
                        if (_vRepairKitsReserve.Count() > 0)
                        {
                            int iTargetChoice = GUI.TargetMenu(iUsed);
                            PARTS_TYPES eTargetChoice = (PARTS_TYPES)iTargetChoice;
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
                        if (_vRepairKitsReserve.Count() > 0)
                        {
                            int iTargetChoice = GUI.TargetMenu(iUsed);
                            PARTS_TYPES eTargetChoice = (PARTS_TYPES)iTargetChoice;
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
                            int iTargetChoice = GUI.TargetMenu(iUsed);
                            PARTS_TYPES eTargetChoice = (PARTS_TYPES)iTargetChoice;

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
            //not finished again
            if (iActionChoice == -1)
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

    public enum FUEL_MENU
    {
        Back = 0,
        Wood = 1,
        Charcoal = 2,
        Coal = 3,
        Compact_Coal = 4,
    }
}
