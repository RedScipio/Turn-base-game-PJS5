
using Consumable;
using System.ComponentModel.Design;

namespace Umshini_Test
{
    public class TestPlayTurn
    {
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
        ABATTLE basicBattle = null;

        public TestPlayTurn() 
        {
            List<ICONSUMABLES> _vPlayerRepairKitsReserve = new List<ICONSUMABLES>();
            List<ICONSUMABLES> _vBotRepairKitsReserve = new List<ICONSUMABLES>(); 

            List<ICONSUMABLES> _vPlayerFuelsReserve = new List<ICONSUMABLES>(); 
            List<ICONSUMABLES> _vBotFuelsReserve = new List<ICONSUMABLES>();


            _vPlayerRepairKitsReserve.Add(new RepairKit(3, REPAIR.LIGHT_ARMOR));
            _vPlayerRepairKitsReserve.Add(new RepairKit(3, REPAIR.HEAVY_ARMOR));
            _vPlayerRepairKitsReserve.Add(new RepairKit(3, REPAIR.LIGHT_KIT));
            _vPlayerRepairKitsReserve.Add(new RepairKit(3, REPAIR.FULL_KIT));

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

            basicBattle = new BASIC_BATTLE(pPlayerPilot, pBotPilot);
        }

        [Fact]
        public void TestAttackMenuTurn()
        {
            ///Attacking the left weapon of the enemy robot 
            ///with our left weapon, breaking his armor 
            ///and not harming his weapon's life points
            List<int> lInputsResults = basicBattle.PlayTurn(0, MAIN_MENU.Attack, 0, 0);
            List<int> lOutputsResults = new List<int> { 0, 0, 2, 0 };
            lInputsResults.Should().BeEquivalentTo(lOutputsResults);

            botRobot.GetLeftWeaponArmor().Should().Be(0);

            ///Reattacking the left weapon to break it
            lInputsResults = basicBattle.PlayTurn(0, MAIN_MENU.Attack, 0, 0);
            lOutputsResults = new List<int> { 0, 0, 2, 3 };
            lInputsResults.Should().BeEquivalentTo(lOutputsResults);

            bool isRobotLeftWeapBroken = botRobot.GetWeapon(0).IsBroken();
            isRobotLeftWeapBroken.Should().BeTrue();

            ///Attacking the enemy robot's furnace 
            ///to destroy him
            lInputsResults = basicBattle.PlayTurn(0, MAIN_MENU.Attack, 0, 3);
            lOutputsResults = new List<int> { 0, 0, 1, 3 };
            lInputsResults.Should().BeEquivalentTo(lOutputsResults);

            botRobot.IsDestroy().Should().BeTrue();
        }


        [Fact]
        public void TestRepairMenuTurn() 
        {
            ///Changing the values of the parts to not
            ///destroy the player robot
            playerFurn = new FURNACE(1, "Normal Furnace", 3, 3, 50);
            playerLegs = new LEG(1, "Basic Legs", 3, 3);
            playerLeftWeap = new MELEE_WEAPON(1, "Melee Weapon", 3, 3, 3, 15, 100, 0);
            playerRightWeap = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 3, 1, 15, 80, 40);
            playerRobot = new ROBOT(playerFurn, playerLegs, playerLeftWeap, playerRightWeap);
            pPlayerPilot = new PLAYER_PILOT(playerRobot, pPlayerPilot.GetFuelsReserve(), pPlayerPilot.GetRepairKitsReserve());
            basicBattle = new BASIC_BATTLE(pPlayerPilot, pBotPilot);


            basicBattle.PlayTurn(1);
            playerRobot.GetFurnaceArmor().Should().Be(0);

            ///Repairing the armor fully with Heavy armor kit
            List<int> lInputRepair = basicBattle.PlayTurn(0, MAIN_MENU.Repairs, 1, 3);
            List<int> lOutputRepair = new List<int> { 1, 1, 1, 2};
            lInputRepair.Should().BeEquivalentTo(lOutputRepair);
            playerRobot.GetFurnaceArmor().Should().Be(2);

            basicBattle.PlayTurn(1);
            playerRobot.GetFurnaceArmor().Should().Be(3);
            playerRobot.GetFurnaceLife().Should().Be(2);

            ///Repairing furnace's life points with repair kits
            lInputRepair = basicBattle.PlayTurn(0, MAIN_MENU.Repairs, 2, 3);
            lOutputRepair = new List<int> { 1, 2, 1, 3 };
            lInputRepair.Should().BeEquivalentTo(lOutputRepair);
            playerRobot.GetFurnaceLife().Should().Be(3);

            basicBattle.PlayTurn(1);
            playerRobot.GetFurnaceArmor().Should().Be(0);

            ///Repairing furnace's armor with light armor kits
            lInputRepair = basicBattle.PlayTurn(0, MAIN_MENU.Repairs, 0, 3);
            lOutputRepair = new List<int> { 1, 0, 1, 1 };
            lInputRepair.Should().BeEquivalentTo(lOutputRepair);
            playerRobot.GetFurnaceArmor().Should().Be(1);

            ///Damaging the robot's player furnace to see if
            ///he gets fully healed
            for(int i = 0; i < 3; i++) basicBattle.PlayTurn(1);
            playerRobot.GetFurnaceLife().Should().Be(1);
            playerRobot.GetFurnaceArmor().Should().Be(3);

            ///Repairing furnace's life points with 
            ///full charged repair kits
            lInputRepair = basicBattle.PlayTurn(0, MAIN_MENU.Repairs, 3, 3);
            lOutputRepair = new List<int> { 1, 3, 1, 4 };
            lInputRepair.Should().BeEquivalentTo(lOutputRepair);
            playerRobot.GetFurnaceLife().Should().Be(3);
        }

        [Fact]
        public void TestRefuelMenuTurn() {
            playerRobot.RemoveFuel(100);
            playerRobot.NeedToRestart().Should().BeTrue();

            ///Removing all fuel of the player's robot to check 
            ///if he is unusable, then refill it 
            ///to see the good fuel refill values
            List<int> lInputs = basicBattle.PlayTurn(0, MAIN_MENU.Furnace, 0);
            List<int> lOutputs = new List<int> { 2, 0, 15 };
            lInputs.Should().BeEquivalentTo(lOutputs);
            playerRobot.GetFuel().Should().Be(15);

            lInputs = basicBattle.PlayTurn(0, MAIN_MENU.Furnace, 1);
            lOutputs = new List<int> { 2, 1, 20 };
            lInputs.Should().BeEquivalentTo(lOutputs);
            playerRobot.GetFuel().Should().Be(15 + 20);

            lInputs = basicBattle.PlayTurn(0, MAIN_MENU.Furnace, 2);
            lOutputs = new List<int> { 2, 2, 25 };
            lInputs.Should().BeEquivalentTo(lOutputs);
            playerRobot.GetFuel().Should().Be(15 + 20 + 25);

            playerRobot.NeedToRestart().Should().BeFalse();

            lInputs = basicBattle.PlayTurn(0, MAIN_MENU.Furnace, 3);
            lOutputs = new List<int> { 2, 3, 35 };
            lInputs.Should().BeEquivalentTo(lOutputs);
            playerRobot.GetFuel().Should().Be(15 + 20 + 25 + 35);
            


        }

    }
}
