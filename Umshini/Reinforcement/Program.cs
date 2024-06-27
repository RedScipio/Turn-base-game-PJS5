using Battle;
using System.Collections.Generic;
using Part;
using Pilot;
using Robot;
using Weapon;

namespace Reinforcement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FactoryState.Type_State typeState = FactoryState.Type_State.State3;
            float gamma = 0.9f;

            int nbIterationTraining = 100_000;
            float explorationPourcentage = 0.95f;
            float decrementationExploration = 0.01f;
            float minExploration =  0.05f;



            IFURNACE agentFurnace = new FURNACE("1", "Normal Furnace", 3, 2, "", 50);
            IFURNACE opponentFurn = new FURNACE("1", "Normal Furnace", 3, 2, "", 50);

            ILEG agentLegs = new LEG("1", "Basic Legs", 2, 2, "");
            ILEG opponentLegs = new LEG("1", "Basic Legs", 3, 2, "");

            IWEAPON opponentLeftWeap = new MELEE_WEAPON("1", "Melee Weapon", 3, 3, "", 1, 1, 100, 15);
            IWEAPON opponentRightWeap = new NORMAL_WEAPON("1", "Basic Normal Weapon", 3, 1, "", 1, 1, 80, 40);

            IWEAPON agentLeftWeap = new MELEE_WEAPON("1", "Melee Weapon", 3, 3, "", 1, 1, 100, 15);
            IWEAPON agentRightWeap = new NORMAL_WEAPON("1", "Basic Normal Weapon", 3, 1, "", 1, 1, 80, 40);

            IROBOT agent = new ROBOT(agentFurnace, agentLegs, agentLeftWeap, agentRightWeap);
            IROBOT opponent = new ROBOT(opponentFurn, opponentLegs, opponentLeftWeap, opponentRightWeap);

            List<ICONSUMABLES> vFuelsReserve = new List<ICONSUMABLES>();
            List<ICONSUMABLES> vRepairKitsReserve = new List<ICONSUMABLES>();

            IPILOT opponentPilot = new SmartBotPilot(opponent, vFuelsReserve, vRepairKitsReserve);




            QLearning qLearning = new QLearning(agent, opponentPilot, FactoryState.GetState(typeState), gamma);

            Console.WriteLine("Training Agent...");
            qLearning.TrainingAgent(nbIterationTraining, explorationPourcentage, decrementationExploration, minExploration);

            Console.WriteLine("Training is Done!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}