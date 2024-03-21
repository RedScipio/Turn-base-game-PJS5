

using Umshini;

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
            List<ICONSUMABLE> _vPlayerRepairKitsReserve = new List<ICONSUMABLE>();
            List<ICONSUMABLE> _vBotRepairKitsReserve = new List<ICONSUMABLE>(); 

            List<ICONSUMABLE> _vPlayerFuelsReserve = new List<ICONSUMABLE>(); 
            List<ICONSUMABLE> _vBotFuelsReserve = new List<ICONSUMABLE>(); 

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
            pPlayerPilot.PlayTurn(botRobot, 1, 2, (int)PARTS_TYPES.WEAPON, 40);
            botRobot.GetWeapon(0).GetArmor().Should().Be(2);

            pBotPilot.PlayTurn(playerRobot);
            //Supposed to return 1
            playerRobot.GetFurnaceLife().Should().Be(playerFurn.GetMaxLife() - 1);
            playerFurn.GetArmor().Should().Be(1);

            pPlayerPilot.PlayTurn(botRobot, 1, 1, (int)PARTS_TYPES.WEAPON, 40);
            botRobot.GetWeapon(0).IsBroken().Should().BeTrue();

            //The player has destroyed the robot
            pPlayerPilot.PlayTurn(botRobot, 1, 1, (int)PARTS_TYPES.FURNACE, 40);
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

            pBotPilot.PlayTurn(playerRobot);
            playerFurn.GetArmor().Should().Be(0);

            //The player, whose furnace's damaged, will repair it.
            pPlayerPilot.PlayTurn(playerRobot, 2, 1, (int)PARTS_TYPES.FURNACE);
            playerFurn.GetArmor().Should().Be(1);
        }
    }
}
