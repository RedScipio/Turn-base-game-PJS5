

namespace Umshini_Test
{
    public class TestRobot
    {
        private static IROBOT playerRobot = null;
        private static IROBOT botRobot = null;
        private static IFURNACE playerFurn = null;
        private static IFURNACE botFurn = null;
        private static ILEG playerLegs = null;
        private static ILEG botLegs = null;

        private static IWEAPON botLeftWeap = null;
        private static IWEAPON botRightWeap = null;
        private static IWEAPON playerLeftWeap = null;
        private static IWEAPON playerRightWeap = null;

        private static IPILOT pPlayerPilot = null;
        private static IPILOT pBotPilot = null;
        public TestRobot()
        {
            playerFurn = new FURNACE(1, "Normal Furnace", 1, 1, 50);
            botFurn = new FURNACE(1, "Normal Furnace", 1, 1, 50);
            playerLegs = new LEG(1, "Basic Legs", 2, 2);
            botLegs = new LEG(1, "Basic Legs", 3, 2);

            botLeftWeap = new MELEE_WEAPON(1, "Melee Weapon", 3, 1, 3, 15, 100, 0);
            botRightWeap = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 1, 1, 15, 80, 40);
            playerLeftWeap = new MELEE_WEAPON(1, "Melee Weapon", 3, 1, 2, 15, 100, 0);
            playerRightWeap = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 1, 1, 15, 80, 40);

            playerRobot = new ROBOT(playerFurn, playerLegs, playerLeftWeap, playerRightWeap);
            botRobot = new ROBOT(botFurn, botLegs, botLeftWeap, botRightWeap);

            //pPlayerPilot = new PLAYER_PILOT(playerRobot);
            //pBotPilot = new PLAYER_PILOT(botRobot);
        }


        [Fact]
        public void TestIsWeaponUsable() 
        {
            //Initializing test weapons
            IWEAPON projWeap = new PROJECTILE_WEAPON(1, "normal projectile weapon", 1, 1, 5, 0, 100, 95, 1);
            IWEAPON melWeap = new MELEE_WEAPON(1, "normal melee weap", 1, 1, 5, 0, 100, 0);
            IWEAPON normWeap = new NORMAL_WEAPON(1, "normal melee weap", 1, 1, 5, 0, 100, 0);

            //Checking if projectile weapon can shoot, with and without ammo
            playerRobot = new ROBOT(playerFurn, playerLegs, playerLeftWeap, projWeap);
            playerRobot.WeaponIsUsable((int) PARTS_TYPES.RIGHT_WEAPON).Should().BeTrue();
            projWeap.GetAmmo().Should().Be(1);
            projWeap.RemoveAmmo().Should().BeTrue();

            playerRobot.WeaponIsUsable((int) PARTS_TYPES.RIGHT_WEAPON).Should().BeFalse();

        }
    }
}