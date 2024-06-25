using Battle;
using Reinforcement;
using Robot;

IFURNACE furnace1 = new FURNACE();


IROBOT r1 = new ROBOT();
IROBOT r2 = new ROBOT();

QLearning qLearning = new QLearning(r1, r2, 0.8);
Console.WriteLine("Training Agent...");
qLearning.TrainingAgent(2000);

Console.WriteLine("Training is Done!");
Console.WriteLine("Press any key to continue...");
Console.ReadLine();
