using System;

class Program
{
    static void Main()
    {
        int tomatoSeeds = int.Parse(Console.ReadLine());
        int tomatoArea = int.Parse(Console.ReadLine());
        
        int cucumberSeeds = int.Parse(Console.ReadLine());
        int cucumberArea = int.Parse(Console.ReadLine());
        
        int potatoSeeds = int.Parse(Console.ReadLine());
        int potatoArea = int.Parse(Console.ReadLine());
        
        int carrotSeeds = int.Parse(Console.ReadLine());
        int carrotArea = int.Parse(Console.ReadLine());
        
        int cabbageSeeds = int.Parse(Console.ReadLine());
        int cabbageArea = int.Parse(Console.ReadLine());
        
        int beansSeeds = int.Parse(Console.ReadLine());

        int totalArea = 250;
        int beansArea = 250 - (tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea);
        double totalCost = tomatoSeeds * 0.5d + cucumberSeeds * 0.4d + potatoSeeds * 0.25d + carrotSeeds * 0.6d + cabbageSeeds * 0.3d + beansSeeds * 0.4d;

        Console.WriteLine("Total costs:{0: 0.00}", totalCost);

        if (beansArea > 0)
        {
            Console.WriteLine("Beans area: {0}", beansArea);
        }
        else if (beansArea == 0)
        {
            Console.WriteLine("No area for beans");
        }
        else
        {
            Console.WriteLine("Insufficient area");
        }             
    }
}