
using Consumable;

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

            /* //Verifying if the AttackMenu works
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
             botRobot.IsDestroy().Should().BeTrue();*/
        }


        [Fact]
        public void TestRepairMenuTurn() 
        {
            initRepair();
            basicBattle.PlayTurn(1);
            
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

            lInputs = basicBattle.PlayTurn(0, MAIN_MENU.Furnace, 3);
            lOutputs = new List<int> { 2, 3, 35 };
            lInputs.Should().BeEquivalentTo(lOutputs);
            playerRobot.GetFuel().Should().Be(15 + 20 + 25 + 35);
            /*//Removing all fuel of the player's robot to check if he is unusable, then refill it to see the good fuel refill values
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
            playerRobot.GetFuel().Should().Be(20 + 25 + 35); //Total fuel : 80*/


        }

        public void initRepair()
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
        }

    }
}
