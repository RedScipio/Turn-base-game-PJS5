using PJS5_CSharp.Sources.Pilot.Bot;
using PJS5_CSharp.Sources.Pilot.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using WEAPON;

namespace Test_PJS5_CSharp
{
    public class TestPlayTurn
    {
        
        private static readonly FURNACE furnPlayer = new FURNACE(1, "Normal Furnace", 2, 4, 50);
        private static readonly FURNACE furnBot = new FURNACE(1, "Normal Furnace", 2, 1, 50);
        private static readonly LEGS legsPlayer = new LEGS(1, "Basic Legs", 3, 2);
        private static readonly LEGS legsBot = new LEGS(1, "Basic Legs", 3, 2);

        private static readonly WEAPON.IWeapon leftBotWeap = new MELEE_WEAPON(1, "Melee Weapon", 3, 1, 4, 15, 100, 0);
        private static readonly WEAPON.IWeapon rightBotWeap = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 1, 3, 0, 60, 30);
        private static readonly WEAPON.IWeapon leftPlayerWeap = new MELEE_WEAPON(1, "Melee Weapon", 3, 1, 2, 15, 100, 0);
        private static readonly WEAPON.IWeapon rightPlayerWeap = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 1, 1, 25, 80, 40);

        private static readonly List<int> playerFuelsReserve = new List<int> { 10, 10, 10, 10 };
        private static readonly List<int> playerRepairKits = new List<int> { 10, 10, 10, 10 };

        private static readonly List<int> botFuelsReserve = new List<int> { 10, 10, 10, 10 };
        private static readonly List<int> botRepairKits = new List<int> { 10, 10, 10, 10 };

        private static Robot playerRobot = null;
        private static Robot botRobot = null;

        private static PILOT.IPILOT pPlayerPilot = null;
        private static PILOT.IPILOT pBotPilot = null;


        public TestPlayTurn()
        {
            playerRobot = new Robot(furnPlayer, legsPlayer, leftPlayerWeap, rightPlayerWeap);
            botRobot = new Robot(furnBot, legsBot, leftBotWeap, rightBotWeap);

            pPlayerPilot = new PLAYER_PILOT(playerRobot, playerFuelsReserve, playerRepairKits);
            pBotPilot = new PLAYER_PILOT(botRobot, botFuelsReserve, botRepairKits);
        }

        [Fact]
        public void TestPlayTurn_attack()
        {
            Assert.NotNull(playerRobot);
            Assert.NotNull(botRobot);
            
            pPlayerPilot.PlayTurn(botRobot, 1, 1, 1, 47);
            Assert.Equal(1, botRobot.GetLeftWeaponArmor());
            Assert.Equal(85, playerRobot.GetFuel());

            pBotPilot.PlayTurn(playerRobot, 1, 2, 4, 90);
            Assert.Equal(2, playerRobot.GetFurnaceArmor());

            pPlayerPilot.PlayTurn(botRobot, 1, 2, 4, 20);
            Assert.Equal(1, botRobot.GetFurnaceArmor());

            pPlayerPilot.PlayTurn(botRobot, 1, 1, 4, 30);
            Assert.True(botRobot.IsDestroy());
        }

        [Fact]
        public void TestPlayTurn_repair()
        {
            pBotPilot.PlayTurn(playerRobot, 1, 1, 1, 50);
            leftPlayerWeap.IsBroken().Should().BeTrue();
            leftPlayerWeap.GetArmor().Should().Be(0);

            pPlayerPilot.PlayTurn(playerRobot, 2, 3, 1);
            leftPlayerWeap.IsBroken().Should().BeFalse();
            pPlayerPilot.PlayTurn(playerRobot, 2, 2, 1);    
            playerRobot.GetLeftWeaponArmor().Should().Be(3);
            playerRobot.GetLeftWeaponLife().Should().Be(1);

            for (int i = 0; i <= 2; i++)
            {
                pBotPilot.PlayTurn(playerRobot, 1, 2, 4, 45);
            }
            playerRobot.GetFurnaceLife().Should().Be(1);
            pPlayerPilot.PlayTurn(playerRobot, 2, 4, 4);
            pPlayerPilot.GetRobot().GetFurnaceLife().Should().Be(4);
        }

        
        [Fact]
        public void TestPlayTurn_refuel()
        {
            pPlayerPilot.PlayTurn(botRobot, 1, 2, 1, 47);
            playerRobot.GetFuel().Should().Be(75);
            playerRobot.NeedToRestart().Should().BeFalse();
            pPlayerPilot.PlayTurn(botRobot, 1, 2, 3, 70);
            pPlayerPilot.PlayTurn(botRobot, 1, 2, 2, 70);
            pPlayerPilot.PlayTurn(botRobot, 1, 2, 2, 70);
            playerRobot.NeedToRestart().Should().BeTrue();

            //rechargement en fuel du robot
            pPlayerPilot.PlayTurn(botRobot, 3, 1);
            playerRobot.GetFuel().Should().Be(15);
            pPlayerPilot.PlayTurn(botRobot, 3, 2);
            playerRobot.GetFuel().Should().Be(35);
            pPlayerPilot.PlayTurn(botRobot, 3, 3);
            playerRobot.GetFuel().Should().Be(60);
            playerRobot.NeedToRestart().Should().BeFalse();
            pPlayerPilot.PlayTurn(botRobot, 3, 4);
            playerRobot.GetFuel().Should().Be(95);
        }
    }
}
