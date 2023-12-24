using PJS5_CSharp.Sources.Pilot.Bot;
using PJS5_CSharp.Sources.Pilot.Player;
using PJS5_CSharp.Sources.Robot;
using PJS5_CSharp.Sources.Weapon.MeleeWeapon;

namespace Test_PJS5_CSharp
{
    public class TestRobot
    {
        Robot playerRobot = null; 
        Robot botRobot = null;
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
        
        
        [Fact] //Déroulement d'un tour entier
        public void TestBattle()
        {
            //On vérifie que les objets soient vides.
            Assert.Null(playerRobot); 
            Assert.Null(botRobot);
            Assert.Null(furnPlayer); Assert.Null(furnBot);
            Assert.Null(legsPlayer); Assert.Null(legsBot);
            Assert.Null(leftPlayerWeap); Assert.Null(rightPlayerWeap);
            Assert.Null(pPlayerPilot); Assert.Null(pBotPilot);

            //Initialisation des variables
            legsPlayer = new LEGS(1, "Basic Legs", 3, 2);
            furnPlayer = new FURNACE(1, "Normal Furnace", 1, 1, 50);
            leftPlayerWeap = new MELEE_WEAPON(1, "Melee Weapon", 3, 1, 2, 15, 100, 0);
            rightPlayerWeap = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 1, 1, 15, 80, 40);

            legsBot = new LEGS(1, "Basic Legs", 3, 2);
            furnBot = new FURNACE(1, "Normal Furnace", 1, 1, 50);
            leftBotWeap = new MELEE_WEAPON(1, "Melee Weapon", 3, 1, 2, 15, 100, 0);
            rightBotWeap = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 1, 1, 15, 80, 40);

            List<int> playerFuelsReserve = new List<int> { 10, 10, 10, 10 };
            List<int> playerRepairKits = new List<int> { 10, 10, 10, 10 };

            List<int> botFuelsReserve = new List<int> { 10, 10, 10, 10 };
            List<int> botRepairKits = new List<int> { 10, 10, 10, 10 };

            Robot robotPlayer = new Robot(furnPlayer, legsPlayer, leftPlayerWeap, rightPlayerWeap);
            Robot robotBot = new Robot(furnBot, legsBot, leftBotWeap, rightBotWeap);
            
            pPlayerPilot = new PLAYER_PILOT(robotPlayer, playerFuelsReserve, playerRepairKits);
            pBotPilot = new BOT_PILOT(robotBot, botFuelsReserve, botRepairKits);
            
            //Le robot joueur attaque
            int actualBotRightWeapArmor = robotPlayer.DealDamage(robotBot, 2, 2);
            Assert.Equal(actualBotRightWeapArmor, robotBot.GetRightWeaponArmor());

            //Le robot ennemi contre attaque
            int actualPlayerArmor = robotBot.DealDamage(robotPlayer, 1, 4);
            Assert.Equal(99, actualPlayerArmor);

            //Le robot joueur est détruit
            Assert.True(robotPlayer.IsDestroy());

        }
    }
}

