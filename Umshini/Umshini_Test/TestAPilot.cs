using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umshini_Test
{
    public class TestAPilot
    {
        /// <summary>
        /// Tester les méthodes Attack, Repair et Refuel de la classe APilot
        /// </summary>
        /// 
        private ROBOT playerRobot = null;
        private ROBOT botRobot = null;
        private IFURNACE playerFurn = null;
        private IFURNACE botFurn = null;
        private ILEG playerLegs = null;
        private ILEG botLegs = null;

        private IWEAPON botLeftWeap = null;
        private IWEAPON botRightWeap = null;
        private IWEAPON playerLeftWeap = null;
        private IWEAPON playerRightWeap = null;

        private APILOT pPlayerPilot = null;
        private APILOT pBotPilot = null;

        public TestAPilot() 
        {
            List<ICONSUMABLES> _vPlayerRepairKitsReserve = new List<ICONSUMABLES>();
            List<ICONSUMABLES> _vBotRepairKitsReserve = new List<ICONSUMABLES>();

            List<ICONSUMABLES> _vPlayerFuelsReserve = new List<ICONSUMABLES>();
            List<ICONSUMABLES> _vBotFuelsReserve = new List<ICONSUMABLES>();

            _vPlayerRepairKitsReserve.Add(new RepairKit(1, REPAIR.LIGHT_KIT));
            _vPlayerRepairKitsReserve.Add(new RepairKit(1, REPAIR.FULL_KIT));
            _vPlayerRepairKitsReserve.Add(new RepairKit(1, REPAIR.LIGHT_ARMOR));
            _vPlayerRepairKitsReserve.Add(new RepairKit(1, REPAIR.HEAVY_ARMOR));

            _vPlayerFuelsReserve.Add(new RefuelKit(1, ENERGY.ENERGY_WOOD));
            _vPlayerFuelsReserve.Add(new RefuelKit(1, ENERGY.ENERGY_CHARCOAL));
            _vPlayerFuelsReserve.Add(new RefuelKit(1, ENERGY.ENERGY_COAL));
            _vPlayerFuelsReserve.Add(new RefuelKit(1, ENERGY.ENERGY_COMPACT_COAL));

            playerFurn = new FURNACE(1, "Normal Furnace", 1, 2, 50);
            botFurn = new FURNACE(1, "Normal Furnace", 1, 1, 50);
            playerLegs = new LEG(1, "Basic Legs", 2, 2);
            botLegs = new LEG(1, "Basic Legs", 3, 2);

            botLeftWeap = new MELEE_WEAPON(1, "Melee Weapon", 3, 1, 3, 15, 100, 0);
            botRightWeap = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 1, 1, 15, 80, 40);
            playerLeftWeap = new MELEE_WEAPON(1, "Melee Weapon", 3, 1, 3, 15, 100, 0);
            playerRightWeap = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 1, 1, 15, 80, 40);

            playerRobot = new ROBOT(playerFurn, playerLegs, playerLeftWeap, playerRightWeap);
            botRobot = new ROBOT(botFurn, botLegs, botLeftWeap, botRightWeap);


            pPlayerPilot = new PLAYER_PILOT(playerRobot, _vPlayerFuelsReserve, _vPlayerRepairKitsReserve);
            pBotPilot = new DumbBotPilot(botRobot, _vBotFuelsReserve, _vBotRepairKitsReserve);
        }

        [Fact]
        public void TestAttackAction()
        {
            //Checking
            bool attackHasHit = pPlayerPilot.Attack((int)WEAPON_MENU.Left_Weapon, botRobot, TARGET_TYPE.FURNACE);
            attackHasHit.Should().BeTrue();
        }
    }
}
