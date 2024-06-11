

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
            playerFurn = new FURNACE("1", "Normal Furnace", 1, 1, "", 50);
            botFurn = new FURNACE("1", "Normal Furnace", 1, 1, "", 50);
            playerLegs = new LEG("1", "Basic Legs", 2, 2, "");
            botLegs = new LEG("1", "Basic Legs", 3, 2, "");

            botLeftWeap = new MELEE_WEAPON("1", "Melee Weapon", 3, 1, "", 3, 15, 100, 0);
            botRightWeap = new NORMAL_WEAPON("1", "Basic Normal Weapon", 3, 1, "", 1, 15, 80, 40);
            playerLeftWeap = new MELEE_WEAPON("1", "Melee Weapon", 3, 1, "", 2, 15, 100, 0);
            playerRightWeap = new NORMAL_WEAPON("1", "Basic Normal Weapon", 3, 1, "", 1, 15, 80, 40);

            playerRobot = new ROBOT(playerFurn, playerLegs, playerLeftWeap, playerRightWeap);
            botRobot = new ROBOT(botFurn, botLegs, botLeftWeap, botRightWeap);

            //pPlayerPilot = new PLAYER_PILOT(playerRobot);
            //pBotPilot = new PLAYER_PILOT(botRobot);
        }

        [Fact]
        public void TestIsProjectileWeaponUsable() 
        {
            //Initializing test weapons
            IWEAPON projWeap = new PROJECTILE_WEAPON("1", "normal projectile weapon", 1, 1, "", 5, 0, 100, 95, 1);

            //Checking if projectile weapon can shoot, with and without ammo
            playerRobot = new ROBOT(playerFurn, playerLegs, playerLeftWeap, projWeap);
            playerRobot.WeaponIsUsable(1).Should().BeTrue();
            projWeap.GetAmmo().Should().Be(1);
            projWeap.RemoveAmmo().Should().BeTrue();

            playerRobot.WeaponIsUsable(1).Should().BeFalse();
        }

        [Fact]
        public void TestIsMeleeWeaponUsable()
        {
            IWEAPON melWeap = new MELEE_WEAPON("1", "normal melee weap", 1, 1, "", 5, 0, 100, 0);

            //Checking if melee weapon can attack, with and without legs
            playerRobot = new ROBOT(playerFurn, playerLegs, playerLeftWeap, melWeap);
            playerRobot.WeaponIsUsable((int)WEAPON_SIDE.RIGHT_WEAPON).Should().BeTrue();

            playerRobot.DealDamage(playerRobot, (int)WEAPON_SIDE.RIGHT_WEAPON, TARGET_TYPE.LEG);
            playerRobot.DealDamage(playerRobot, (int)WEAPON_SIDE.RIGHT_WEAPON, TARGET_TYPE.LEG);

            playerRobot.WeaponIsUsable((int)WEAPON_SIDE.RIGHT_WEAPON).Should().BeFalse();
        }

        [Fact]
        public void TestIsNormalWeaponUsable()
        {
            IWEAPON normWeap = new NORMAL_WEAPON("1", "normal melee weap", 1, 1, "", 5, 100, 60, 40);

            //Checking if normal weapon can attack
            playerRobot = new ROBOT(playerFurn, playerLegs, playerLeftWeap, normWeap);
            playerRobot.WeaponIsUsable((int)WEAPON_SIDE.RIGHT_WEAPON).Should().BeTrue();

            playerRobot.RemoveFuel(normWeap.GetPowerConsumption());

            playerRobot.WeaponIsUsable((int)WEAPON_SIDE.RIGHT_WEAPON).Should().BeFalse();

            playerRobot.Refuel(100);

            playerRobot.DealDamage(playerRobot, (int)WEAPON_SIDE.LEFT_WEAPON, TARGET_TYPE.RIGHT_WEAPON);

            playerRobot.WeaponIsUsable((int)WEAPON_SIDE.RIGHT_WEAPON).Should().BeFalse();
        }

        [Fact]
        public void TestDamageWithThermalWeapon()
        {
            IWEAPON thermWeap = new THERMAL_WEAPON("1", "normal melee weap", 1, 1, "", 3, 10, 20, 40, 40);

            //Checking if thermal weapons remove fuel correctly from the enemies
            playerRobot = new ROBOT(playerFurn, playerLegs, playerLeftWeap, thermWeap);
            playerRobot.WeaponIsUsable((int)WEAPON_SIDE.RIGHT_WEAPON).Should().BeTrue();
            

            //Removing fuel and checking if the enemy robot need to restart
            playerRobot.DealDamage(botRobot, (int)WEAPON_SIDE.RIGHT_WEAPON, TARGET_TYPE.LEG);
            botRobot.GetFuel().Should().Be(60);
            playerRobot.DealDamage(botRobot, (int)WEAPON_SIDE.RIGHT_WEAPON, TARGET_TYPE.LEG);
            botRobot.GetFuel().Should().Be(20);
            botRobot.NeedToRestart();
        }

        [Fact]
        public void TestHitChanceWithMeleeWeapons()
        {
            IWEAPON melWeap = new MELEE_WEAPON("1", "normal melee weap", 1, 1, "", 5, 0, 100, 0);

            //Checking if melee weapons lose 50% / 100% of hit chance with 1 / 2 legs lost
            playerRobot = new ROBOT(playerFurn, playerLegs, playerLeftWeap, melWeap);
            playerRobot.GetWeaponHitChance((int)WEAPON_SIDE.RIGHT_WEAPON).Should().Be(100);

            //With one leg broken
            playerRobot.DealDamage(playerRobot, (int)WEAPON_SIDE.RIGHT_WEAPON, TARGET_TYPE.LEG);
            playerRobot.GetWeaponHitChance((int)WEAPON_SIDE.RIGHT_WEAPON).Should().Be(50);

            //With two legs broken
            playerRobot.DealDamage(playerRobot, (int)WEAPON_SIDE.RIGHT_WEAPON, TARGET_TYPE.LEG);
            playerRobot.GetWeaponHitChance((int)WEAPON_SIDE.RIGHT_WEAPON).Should().Be(0);

            //After repairing one leg
            playerRobot.RepairRobotLifePoint(1, TARGET_TYPE.LEG);
            playerRobot.GetWeaponHitChance((int)WEAPON_SIDE.RIGHT_WEAPON).Should().Be(50);
        }

        [Fact]
        public void TestHitChanceWithProjectileWeapons()
        {
            IWEAPON projWeap = new PROJECTILE_WEAPON("1", "normal projectile weapon", 1, 1, "", 5, 0, 100, 80, 1);

            //Checking if projectile weapons loses less accuracy than every other weapons, as intended
            playerRobot = new ROBOT(playerFurn, playerLegs, playerLeftWeap, projWeap);
            playerRobot.GetWeaponHitChance((int)WEAPON_SIDE.RIGHT_WEAPON).Should().Be(100);

            //With one leg broken
            playerRobot.DealDamage(playerRobot, (int)WEAPON_SIDE.RIGHT_WEAPON, TARGET_TYPE.LEG);
            playerRobot.GetWeaponHitChance((int)WEAPON_SIDE.RIGHT_WEAPON).Should().Be(90);

            //With two legs broken
            playerRobot.DealDamage(playerRobot, (int)WEAPON_SIDE.RIGHT_WEAPON, TARGET_TYPE.LEG);
            playerRobot.GetWeaponHitChance((int)WEAPON_SIDE.RIGHT_WEAPON).Should().Be(80);
        }
    }
}