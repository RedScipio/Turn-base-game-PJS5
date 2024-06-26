using Battle;
using Reinforcement;
using Robot;

/*IFURNACE furnace1 = new FURNACE();


IROBOT r1 = new ROBOT();
IROBOT r2 = new ROBOT();*/

double[][] x = new double[20_000][];
for (int i = 0; i < 20_000; i++)
{
    x[i] = new double[20];
    for (int j = 0; j < 20; j++)
    {
        x[i][j] = 0;
    }
}

//QLearning qLearning = new QLearning(r1, r2, 0.8);
Console.WriteLine("Training Agent...");
//qLearning.TrainingAgent(2000);

Console.WriteLine("Training is Done!");
Console.WriteLine("Press any key to continue...");
Console.ReadLine();
