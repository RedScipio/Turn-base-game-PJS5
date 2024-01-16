using FluentAssertions;
using PJS5_CSharp.Sources.Pilot.Bot;
using PJS5_CSharp.Sources.Pilot.Player;
using PJS5_CSharp.Sources.Robot;
using PJS5_CSharp.Sources.Weapon.MeleeWeapon;
using PJS5_CSharp.Sources.Weapon.ProjectileWeapon;
using PJS5_CSharp.Sources.Weapon.ThermalWeapon;

namespace Test_PJS5_CSharp
{
    public class TestRobot
    {
        Robot robotPlayer = null; 
        Robot robotBot = null;
        FURNACE furnPlayer = null;
        FURNACE furnBot = null;
        LEGS legsPlayer = null;
        LEGS legsBot = null;

        WEAPON.IWeapon leftBotWeap = null;
        WEAPON.IWeapon rightBotWeap = null;
        WEAPON.IWeapon leftPlayerWeap = null;
        WEAPON.IWeapon rightPlayerWeap = null;

        PILOT.IPILOT pPlayerPilot = null;
        PILOT.IPILOT pBotPilot = null;
        
        public TestRobot()
        {
            furnPlayer = new FURNACE(1, "Normal Furnace", 1, 1, 50);
            furnBot = new FURNACE(1, "Normal Furnace", 1, 1, 50);
            legsPlayer = new LEGS(1, "Basic Legs", 3, 2);
            legsBot = new LEGS(1, "Basic Legs", 3, 2);

            leftBotWeap = new MELEE_WEAPON(1, "Melee Weapon", 3, 1, 2, 15, 100, 0);
            rightBotWeap = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 1, 1, 15, 80, 40);
            leftPlayerWeap = new MELEE_WEAPON(1, "Melee Weapon", 3, 1, 2, 15, 100, 0);
            rightPlayerWeap = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 1, 1, 15, 80, 40);

            List<int> playerFuelsReserve = new List<int> { 10, 10, 10, 10 };
            List<int> playerRepairKits = new List<int> { 10, 10, 10, 10 };

            List<int> botFuelsReserve = new List<int> { 10, 10, 10, 10 };
            List<int> botRepairKits = new List<int> { 10, 10, 10, 10 };

            robotPlayer = new Robot(furnPlayer, legsPlayer, leftPlayerWeap, rightPlayerWeap);
            robotBot = new Robot(furnBot, legsBot, leftBotWeap, rightBotWeap);

            pPlayerPilot = new PLAYER_PILOT(robotPlayer, playerFuelsReserve, playerRepairKits);
            pBotPilot = new BOT_PILOT(robotBot, botFuelsReserve, botFuelsReserve);
        }
        
        [Fact] 
        public void TestDealingDamage()
        {
            int iEnemyActualLegsArmorValue = robotPlayer.DealDamage(robotBot, 1, 3);
            iEnemyActualLegsArmorValue.Should().Be(1);
            Assert.Equal(robotBot.GetLegsArmor(), iEnemyActualLegsArmorValue);

            //Inflicting damage on a non-existent robot part
            int iNonExistantPart = robotPlayer.DealDamage(robotBot, 2, 5);
            iNonExistantPart.Should().Be(0);

            //Inflicting damage on a robot with a thermal weapon
            //rightPlayerWeap = new THERMAL_WEAPON(1, "Basic Thermal Weapon", 3, 1, 1, 25, 60, 40, 25);
            robotPlayer.SetWeapon(2, new THERMAL_WEAPON(1, "Basic Thermal Weapon", 3, 1, 1, 25, 60, 40, 25));
            robotPlayer.GetRightWeaponType().Should().Be(4);
            pPlayerPilot.PlayTurn(robotBot, 1, 2, 1, 50);
            robotBot.GetLeftWeaponArmor().Should().Be(2);
            //Failing test, as even if I have changed weapons for a thermal one (which has 25 of iFuelBurn), it takes the GetSpecificity of a normal weapon.
            robotBot.GetFuel().Should().Be(75);

            rightPlayerWeap = new PROJECTILE_WEAPON(1, "Basic Projectile Weapon", 3, 1, 1, 25, 60, 40, 5);
            //pPlayerPilot.PlayTurn(robotBot);
        }

        [Fact]
        public void Test()
        {

        }
    }
}

