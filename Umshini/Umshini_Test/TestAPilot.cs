using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umshini_Test
{
    /// <summary>
    /// TestAPilot test the three main methods : Attack, Repair, Refuel
    /// </summary>
    /// <developer>Wahada</developer>
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

            _vPlayerRepairKitsReserve.Add(new RepairKit(1, REPAIR.LIGHT_ARMOR));
            _vPlayerRepairKitsReserve.Add(new RepairKit(1, REPAIR.HEAVY_ARMOR));
            _vPlayerRepairKitsReserve.Add(new RepairKit(0, REPAIR.LIGHT_KIT));
            _vPlayerRepairKitsReserve.Add(new RepairKit(1, REPAIR.FULL_KIT));

            _vPlayerFuelsReserve.Add(new RefuelKit(0, ENERGY.ENERGY_WOOD));
            _vPlayerFuelsReserve.Add(new RefuelKit(1, ENERGY.ENERGY_CHARCOAL));
            _vPlayerFuelsReserve.Add(new RefuelKit(0, ENERGY.ENERGY_COAL));
            _vPlayerFuelsReserve.Add(new RefuelKit(0, ENERGY.ENERGY_COMPACT_COAL));

            playerFurn = new FURNACE("1", "Normal Furnace", 3, 3, 50);
            botFurn = new FURNACE("1", "Normal Furnace", 1, 1, 50);
            playerLegs = new Part.LEG("1", "Basic Legs", 2, 2);
            botLegs = new Part.LEG("1", "Basic Legs", 3, 2);

            botLeftWeap = new MELEE_WEAPON("1", "Melee Weapon", 3, 1, 3, 15, 100, 0);
            botRightWeap = new NORMAL_WEAPON("1", "Basic Normal Weapon", 3, 1, 1, 15, 80, 40);
            playerLeftWeap = new MELEE_WEAPON("1", "Melee Weapon", 3, 1, 3, 15, 100, 0);
            playerRightWeap = new NORMAL_WEAPON("1", "Basic Normal Weapon", 3, 1, 1, 15, 80, 40);

            playerRobot = new ROBOT(playerFurn, playerLegs, playerLeftWeap, playerRightWeap);
            botRobot = new ROBOT(botFurn, botLegs, botLeftWeap, botRightWeap);


            pPlayerPilot = new PLAYER_PILOT(playerRobot, _vPlayerFuelsReserve, _vPlayerRepairKitsReserve);
            pBotPilot = new DumbBotPilot(botRobot, _vBotFuelsReserve, _vBotRepairKitsReserve);
        }

        [Fact]
        public void TestAttackAction()
        {
            ///Testing if the player can attack his enemy when his weapons is not broken
            bool attackHasHit = pPlayerPilot.Attack((int)WEAPON_MENU.Left_Weapon, botRobot, TARGET_TYPE.FURNACE, new List<int>());
            attackHasHit.Should().BeTrue();

            ///Breaking the left weapon, so it couldn't attack
            playerRobot.GetWeapon(0).TakeDamage(5);
            //Normally, it returns false because the left weapon is unusable
            attackHasHit = pPlayerPilot.Attack((int)WEAPON_MENU.Left_Weapon, botRobot, TARGET_TYPE.FURNACE, new List<int>());
            attackHasHit.Should().BeFalse();
        }

        [Fact]
        public void TestRepairAction() 
        {
            for(int i = 0; i < 4; i++) pPlayerPilot.GetRobot().DealDamage(playerRobot, 0, TARGET_TYPE.FURNACE);
            
            pPlayerPilot.GetRobot().GetFurnaceLife().Should().Be(1);
            

            ///The player has selected an empty repair kits
            bool repairDone = pPlayerPilot.Repair(REPAIRS_TYPE.Repair_Kits, TARGET_TYPE.FURNACE, new List<int>());
            repairDone.Should().BeFalse();

            //The player has selected a non empty life point repair kit and the furnace is damaged.
            repairDone = pPlayerPilot.Repair(REPAIRS_TYPE.Full_Kits, TARGET_TYPE.FURNACE, new List<int>());
            repairDone.Should().BeTrue();

            //The furnace's HP are full now
            pPlayerPilot.GetRobot().GetFurnaceLife().Should().Be(3);
            pPlayerPilot.GetRobot().GetFurnaceArmor().Should().Be(3);

            for (int i = 0; i < 5; i++) pPlayerPilot.GetRobot().DealDamage(playerRobot, 0, TARGET_TYPE.FURNACE);
            

            pPlayerPilot.GetRobot().GetFurnaceLife().Should().Be(1);
            pPlayerPilot.GetRobot().GetFurnaceArmor().Should().Be(0);

            ///repairing the furnace's armor (again) --> true
            repairDone = pPlayerPilot.Repair(REPAIRS_TYPE.Light_Armor, TARGET_TYPE.FURNACE, new List<int>());
            repairDone.Should().BeTrue();
            pPlayerPilot.GetRobot().GetFurnaceArmor().Should().Be(1);

            ///repairing the furnace's armor (again) --> true
            repairDone = pPlayerPilot.Repair(REPAIRS_TYPE.Heavy_Armor, TARGET_TYPE.FURNACE, new List<int>());
            repairDone.Should().BeTrue();
            pPlayerPilot.GetRobot().GetFurnaceArmor().Should().Be(3);

            //Refilling the player's repair kits 
            pPlayerPilot.GetRepairKitsReserve()[0].IncrNumberItems();
            pPlayerPilot.GetRepairKitsReserve()[1].IncrNumberItems();
            pPlayerPilot.GetRepairKitsReserve()[2].IncrNumberItems();
            pPlayerPilot.GetRepairKitsReserve()[3].IncrNumberItems();

           
            repairDone = pPlayerPilot.Repair(REPAIRS_TYPE.Repair_Kits, TARGET_TYPE.FURNACE, new List<int>());
            repairDone.Should().BeTrue();
            pPlayerPilot.GetRobot().GetFurnaceLife().Should().Be(3);

            ///The robot is fully repaired and we check
            ///if the kit isn't used in the process --> false
            repairDone = pPlayerPilot.Repair(REPAIRS_TYPE.Heavy_Armor, TARGET_TYPE.FURNACE, new List<int>());
            repairDone.Should().BeFalse();
            pPlayerPilot.GetRobot().GetFurnaceArmor().Should().Be(3);
        }

        [Fact]
        public void TestRefuelAction()
        {
            playerRobot.RemoveFuel(20);

            ///Refueling with an empty refuel kit --> false
            bool refuelDone = pPlayerPilot.Refuel(FUEL_TYPE.Wood, new List<int>());
            refuelDone.Should().BeFalse();

            ///Refueling with an refuel kit withou --> True
            refuelDone = pPlayerPilot.Refuel(FUEL_TYPE.Charcoal, new List<int>());
            refuelDone.Should().BeTrue();

            //Checking the robot get normally filled
            playerRobot.GetFuel().Should().Be(100);

            ///Try refueling while all kits are empty --> True
            refuelDone = pPlayerPilot.Refuel(FUEL_TYPE.Charcoal, new List<int>());
            refuelDone.Should().BeTrue();

            pPlayerPilot.GetFuelsReserve()[0].IncrNumberItems();

            //Refueling but we already have max fuel --> False
            refuelDone = pPlayerPilot.Refuel(FUEL_TYPE.Wood, new List<int>());
            refuelDone.Should().BeFalse();
        }
    }
}
