
using Consumable;

namespace Umshini_Test
{
    public class TestPlayTurn
    {
        private static ROBOT playerRobot = null;
        private static ROBOT botRobot = null;
        private static IFURNACE playerFurn = null;
        private static IFURNACE botFurn = null;
        private static ILEG playerLegs = null;
        private static ILEG botLegs = null;

        private static IWEAPON botLeftWeap = null;
        private static IWEAPON botRightWeap = null;
        private static IWEAPON playerLeftWeap = null;
        private static IWEAPON playerRightWeap = null;

        private static APILOT pPlayerPilot = null;
        private static APILOT pBotPilot = null;


        public TestPlayTurn() 
        {
            List<ICONSUMABLES> _vPlayerRepairKitsReserve = new List<ICONSUMABLES>();
            List<ICONSUMABLES> _vBotRepairKitsReserve = new List<ICONSUMABLES>(); 

            List<ICONSUMABLES> _vPlayerFuelsReserve = new List<ICONSUMABLES>(); 
            List<ICONSUMABLES> _vBotFuelsReserve = new List<ICONSUMABLES>();

            _vPlayerRepairKitsReserve.Add(new RepairKit(3, REPAIR.LIGHT_KIT));
            _vPlayerRepairKitsReserve.Add(new RepairKit(3, REPAIR.FULL_KIT));
            _vPlayerRepairKitsReserve.Add(new RepairKit(3, REPAIR.LIGHT_ARMOR));
            _vPlayerRepairKitsReserve.Add(new RepairKit(3, REPAIR.HEAVY_ARMOR));

            _vPlayerFuelsReserve.Add(new RefuelKit(3, ENERGY.ENERGY_WOOD));
            _vPlayerFuelsReserve.Add(new RefuelKit(3, ENERGY.ENERGY_CHARCOAL));
            _vPlayerFuelsReserve.Add(new RefuelKit(3, ENERGY.ENERGY_COAL));
            _vPlayerFuelsReserve.Add(new RefuelKit(3, ENERGY.ENERGY_COMPACT_COAL));

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
        public void TestAttackMenuTurn()
        {
            //Verifying if the AttackMenu works
            pPlayerPilot.PlayTurn(botRobot, MAIN_MENU.Attack, 2, (int)PARTS_TYPES.WEAPON, 40);
            botRobot.GetWeapon(0).GetArmor().Should().Be(2);

            pBotPilot.PlayTurn(playerRobot);
            //Supposed to return 1
            playerRobot.GetFurnaceLife().Should().Be(playerFurn.GetMaxLife() - 1);
            playerFurn.GetArmor().Should().Be(1);

            pPlayerPilot.PlayTurn(botRobot, MAIN_MENU.Attack, 1, (int)PARTS_TYPES.WEAPON, 40);
            botRobot.GetWeapon(0).IsBroken().Should().BeTrue();

            //The player has destroyed the robot
            pPlayerPilot.PlayTurn(botRobot, MAIN_MENU.Attack, 1, (int)PARTS_TYPES.FURNACE, 40);
            botRobot.IsDestroy().Should().BeTrue();
        }


        [Fact]
        public void TestRepairMenuTurn() 
        {
            // modifying the life and armor points values to ensure repair kits are giving the good amounts 
            playerFurn = new FURNACE(1, "Normal Furnace", 3, 3, 50);
            botFurn = new FURNACE(1, "Normal Furnace", 3, 3, 50);
            playerLegs = new LEG(1, "Basic Legs", 3, 3);
            botLegs = new LEG(1, "Basic Legs", 3, 3);

            botLeftWeap = new MELEE_WEAPON(1, "Melee Weapon", 3, 3, 3, 15, 100, 0);
            botRightWeap = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 3, 1, 15, 80, 40);
            playerLeftWeap = new MELEE_WEAPON(1, "Melee Weapon", 3, 3, 3, 15, 100, 0);
            playerRightWeap = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 3, 1, 15, 80, 40);

            playerRobot = new ROBOT(playerFurn, playerLegs, playerLeftWeap, playerRightWeap);
            botRobot = new ROBOT(botFurn, botLegs, botLeftWeap, botRightWeap);

            pPlayerPilot = new PLAYER_PILOT(playerRobot, pPlayerPilot.GetRepairKitsReserve(), pPlayerPilot.GetFuelsReserve());
            pBotPilot = new DumbBotPilot(botRobot, pBotPilot.GetRepairKitsReserve(), pBotPilot.GetFuelsReserve());

            pBotPilot.PlayTurn(playerRobot);
            playerFurn.GetArmor().Should().Be(0);

            //The player, whose furnace's damaged, will repair it.
            pPlayerPilot.PlayTurn(playerRobot, MAIN_MENU.Repairs, 1, (int)PARTS_TYPES.FURNACE);
            playerFurn.GetArmor().Should().Be(1);

            for (int i = 0; i < 2; i++) { pBotPilot.PlayTurn(playerRobot); }
            playerFurn.GetLife().Should().Be(2);

            pPlayerPilot.PlayTurn(playerRobot, MAIN_MENU.Repairs, 3, (int)PARTS_TYPES.FURNACE);
            playerFurn.GetLife().Should().Be(3);

            //Checking that after repairing, the furnace life points are not superior to his maximum lifepoints (Being actually 3 life points max) when repaired
            for (int i = 0; i < 4; i++) { pBotPilot.PlayTurn(playerRobot); }

            playerFurn.GetLife().Should().Be(1);
            pPlayerPilot.PlayTurn(playerRobot, MAIN_MENU.Repairs, 4, (int)PARTS_TYPES.FURNACE);
            playerFurn.GetLife().Should().Be(3);
        }

        [Fact]
        public void TestRefuelMenuTurn() {
            //Removing all fuel of the player's robot to check if he is unusable, then refill it to see the good fuel refill values
            playerRobot.RemoveFuel(100);
            playerRobot.NeedToRestart().Should().BeTrue();

            //Checking after each refuel that the energies returning the good values
            pPlayerPilot.PlayTurn(playerRobot, MAIN_MENU.Furnace, 1);
            playerRobot.GetFuel().Should().Be(15); //Total : 15

            pPlayerPilot.PlayTurn(playerRobot, MAIN_MENU.Furnace, 2);
            playerRobot.GetFuel().Should().Be(15 + 20); //Total : 35

            pPlayerPilot.PlayTurn(playerRobot, MAIN_MENU.Furnace, 3);
            playerRobot.GetFuel().Should().Be(15 + 20 + 25); //Total : 60

            //Checking that the robot doesn't need to restart
            playerRobot.NeedToRestart().Should().BeFalse();

            pPlayerPilot.PlayTurn(playerRobot, MAIN_MENU.Furnace, 4);
            playerRobot.GetFuel().Should().Be(15 + 20 + 25 + 35); //Total : 95

            //Checking that when attacking, the robot weapons remove the good fuel values
            pPlayerPilot.PlayTurn(botRobot, MAIN_MENU.Attack, 1, (int)PARTS_TYPES.FURNACE, 40);
            playerRobot.GetFuel().Should().Be(20 + 25 + 35); //Total fuel : 80


        }

    }
}
