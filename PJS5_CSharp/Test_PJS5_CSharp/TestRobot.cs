using FluentAssertions;
using PJS5_CSharp.Sources.Pilot.Bot;
using PJS5_CSharp.Sources.Pilot.Player;
using PJS5_CSharp.Sources.Robot;
using PJS5_CSharp.Sources.Weapon.MeleeWeapon;
using PJS5_CSharp.Sources.Weapon.ProjectileWeapon;
using PJS5_CSharp.Sources.Weapon.ThermalWeapon;
using System.Diagnostics;
using WEAPON;

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

        List<int> playerFuelsReserve = new List<int> { 10, 10, 10, 10 };
        List<int> playerRepairKits = new List<int> { 10, 10, 10, 10 };

        List<int> botFuelsReserve = new List<int> { 10, 10, 10, 10 };
        List<int> botRepairKits = new List<int> { 10, 10, 10, 10 };

        public TestRobot()
        {
            furnPlayer = new FURNACE(1, "Normal Furnace", 1, 1, 50);
            furnBot = new FURNACE(1, "Normal Furnace", 1, 1, 50);
            legsPlayer = new LEGS(1, "Basic Legs", 2, 2);
            legsBot = new LEGS(1, "Basic Legs", 3, 2);

            leftBotWeap = new MELEE_WEAPON(1, "Melee Weapon", 3, 1, 3, 15, 100, 0);
            rightBotWeap = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 1, 1, 15, 80, 40);
            leftPlayerWeap = new MELEE_WEAPON(1, "Melee Weapon", 3, 1, 2, 15, 100, 0);
            rightPlayerWeap = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 1, 1, 15, 80, 40);

            robotPlayer = new Robot(furnPlayer, legsPlayer, leftPlayerWeap, rightPlayerWeap);
            robotBot = new Robot(furnBot, legsBot, leftBotWeap, rightBotWeap);

            pPlayerPilot = new PLAYER_PILOT(robotPlayer, playerFuelsReserve, playerRepairKits);
            pBotPilot = FactoryBot.Build(robotBot, botFuelsReserve, botRepairKits, FactoryBot.TypeBot.Dumb);
        }
        
        [Fact] 
        public void TestDealingDamageWithDifferentWeapons()
        {
            int iEnemyActualLegsArmorValue = robotPlayer.DealDamage(robotBot, WEAPON_SIDE.LEFT_WEAPON, PARTS_TYPE.LEGS);

            iEnemyActualLegsArmorValue.Should().Be(robotBot.GetLegsMaxArmor() - 2);
            Assert.Equal(robotBot.GetLegsArmor(), iEnemyActualLegsArmorValue);

            //Inflicting damage on a non-existent robot part
            //int iNonExistantPart = robotPlayer.DealDamage(robotBot, WEAPON_SIDE.RIGHT_WEAPON, 5);
            //iNonExistantPart.Should().Be(0);

            //Inflicting damage on a robot with a thermal weapon and checking if fuel has been removed from the enemy
            robotPlayer.SetWeapon(WEAPON_SIDE.RIGHT_WEAPON, new THERMAL_WEAPON(1, "Basic Thermal Weapon", 3, 1, 1, 25, 60, 40, 25));
            robotPlayer.GetRightWeaponType().Should().Be(4);
            robotPlayer.GetRightWeaponSpecificity().Should().Be(25);
            pPlayerPilot.PlayTurn(robotBot, 1, 2, 1, 1);
            robotBot.GetFuel().Should().Be(75);

            //Dealing damage to a robot with a projectile weapon and checking if ammo has been removed from it.
            robotPlayer.SetWeapon(WEAPON_SIDE.RIGHT_WEAPON, new PROJECTILE_WEAPON(1, "Basic Projectile Weapon", 3, 1, 4, 25, 60, 40, 5));
            robotPlayer.GetRightWeaponType().Should().Be(3);
            robotPlayer.GetRightWeaponSpecificity().Should().Be(5);   
            pPlayerPilot.PlayTurn(robotBot, 1, 2, 1, 50);
            robotPlayer.GetRightWeaponSpecificity().Should().Be(4);
        }

        [Fact]
        public void TestDifferentsWeaponIsUsable()
        {
            IWeapon pProjectileWeapon = new PROJECTILE_WEAPON(1, "Basic Projectile Weapon", 3, 1, 1, 25, 60, 50, 1);
            IWeapon pMeleeWeapon = new MELEE_WEAPON(1, "Basic Melee Weapon", 3, 1, 1, 25, 100, 0);
            IWeapon pNormalWeapon = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 1, 1, 100, 80, 40);

            //Projectile weapon testing
            robotPlayer.SetWeapon(WEAPON_SIDE.LEFT_WEAPON, pProjectileWeapon);
            robotPlayer.WeaponIsUsable(WEAPON_SIDE.LEFT_WEAPON).Should().BeTrue();
            //Checking if an empty weapon isn't usable.
            pPlayerPilot.PlayTurn(robotBot, 1, 1, 1, 1);
            robotPlayer.WeaponIsUsable(WEAPON_SIDE.LEFT_WEAPON).Should().BeFalse();

            //Melee weapon testing
            robotPlayer.SetWeapon(WEAPON_SIDE.LEFT_WEAPON, pMeleeWeapon);
            for (int i = 0; i <= 1; i++) robotBot.DealDamage(robotPlayer, WEAPON_SIDE.LEFT_WEAPON, PARTS_TYPE.LEGS);
            robotPlayer.WeaponIsUsable(WEAPON_SIDE.LEFT_WEAPON).Should().BeFalse();

            //Normal weapon testing
            robotPlayer.SetWeapon(WEAPON_SIDE.LEFT_WEAPON, pNormalWeapon);
            pPlayerPilot.PlayTurn(robotBot, 1, 1, 1);
            robotPlayer.WeaponIsUsable(WEAPON_SIDE.LEFT_WEAPON).Should().BeFalse();
        }

        [Fact]
        public void TestWeaponHitChance()
        {
            //Checking the calculation of the hit chance
        }
    }
}

