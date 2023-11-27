using PJS5_CSharp.Sources.Pilot.Bot;
using PJS5_CSharp.Sources.Pilot.Player;
using PJS5_CSharp.Sources.Weapon.MeleeWeapon;

namespace Test_PJS5_CSharp
{
    public class TestRobot
    {
        Robot robot = null;
        FURNACE furn = null;
        LEGS legs = null;
        WEAPON.IWeapon leftWeap = null;
        WEAPON.IWeapon rightWeap = null;
        PILOT.IPILOT pPlayerPilot = null;
        PILOT.IPILOT pBotPilot = null;
        
        
        [Fact] //Déroulement d'un tour entier
        public void TestBattle()
        {
            //On vérifie que les objets soient vides.
            Assert.Null(robot);
            Assert.Null(furn);
            Assert.Null(legs);
            Assert.Null(leftWeap); Assert.Null(rightWeap);
            Assert.Null(pPlayerPilot);
            Assert.Null(pBotPilot);

            //Initialisation des variables
            legs = new LEGS(1, "Basic Legs", 3, 2);
            furn = new FURNACE(1, "Normal Furnace", 1, 1, 50);
            leftWeap = new MELEE_WEAPON(1, "Melee Weapon", 3, 1, 2, 15, 100, 0);
            rightWeap = new NORMAL_WEAPON(1, "Basic Normal Weapon", 3, 1, 1, 15, 80, 40);

            List<int> fuelsReserve = new List<int> { 10, 10, 10, 10 };
            List<int> repairKits = new List<int> { 10,10,10,10 };

            Robot robotPlayer = new Robot(furn, legs, leftWeap, rightWeap);
            Robot robotBot = new Robot(furn, legs, leftWeap, rightWeap);
            
            pPlayerPilot = new PLAYER_PILOT(robotPlayer, fuelsReserve, repairKits);
            pBotPilot = new BOT_PILOT(robotBot, fuelsReserve, repairKits);
            
            //Le robot joueur attaque
            int actualBotRightWeapArmor = robotPlayer.DealDamage(robotBot, 2, 2);
            Assert.Equal(actualBotRightWeapArmor, robotBot.GetRightWeaponArmor());

            //Le robot ennemi contre attaque
            int actualPlayerArmor = robotBot.DealDamage(robotPlayer, 1, 4);
            Assert.Equal(99, actualPlayerArmor);

            //Le robot joueur est détruit
            Assert.True(robotPlayer.IsDestroy());

        }

        [Fact]
        public void TestWeapon()
        {
            
            //leftWeap = new MELEE_WEAPON(1, "Melee Weapon", 3, 1, 2, 15, 100, 0);
            //Assert.Equal(leftWeap.getType(), Weapon_Type.);   
            //rightWeap = new NormalWeapon(1, "Basic Normal Weapon", 3, 1, 1, 15, 80, 40);
            
        }
    }
}

