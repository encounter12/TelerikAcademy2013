namespace AcademyTasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AcademyTasks
    {
        static List<int> tasks = new List<int>();
        static int variety;
        static int maxIndex;

        static void Main()
        {
            // This recursive solution is not optimal in general cases eventhough it gets 100 points in BGCoder. 
            // For best solution use dynamic programming.
    
            string tasksAsStringLine = Console.ReadLine();
            var tasksAsString = tasksAsStringLine.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var taskAsString in tasksAsString)
            {
                tasks.Add(int.Parse(taskAsString));
            }
            variety = int.Parse(Console.ReadLine());

            bestSolution = tasks.Count;

            int currentMin = tasks[0];
            int currentMax = tasks[0];

            maxIndex = -1;

            for (int i = 0; i < tasks.Count; i++)
            {
                currentMin = Math.Min(currentMin, tasks[i]);
                currentMax = Math.Max(currentMax, tasks[i]);
                if (currentMax - currentMin >= variety)
                {
                    maxIndex = i;
                    break;
                }
            }

            if (maxIndex == -1)
            {
                Console.WriteLine(tasks.Count);
                return;
            }

            Solve(0, 1, tasks[0], tasks[0]);
            Console.WriteLine(bestSolution);
        }

        static int bestSolution = int.MaxValue;
        static void Solve(int currentIndex, int taskSolved, int currentMin, int currentMax)
        {
            if (currentMax - currentMin >= variety)
            {
                bestSolution = Math.Min(bestSolution, taskSolved);
                return;
            }
            if (currentIndex >= maxIndex)
            {
                return;
            }

            for (int i = 2; i >= 1; i--)
            {
                if (currentIndex + i < tasks.Count)
                {
                    Solve(currentIndex + i, taskSolved + 1,
                        Math.Min(currentMin, tasks[currentIndex + i]),
                        Math.Max(currentMax, tasks[currentIndex + i]));
                    if (bestSolution != tasks.Count)
                    {
                        return;
                    }
                }
            }
        }
    }
}