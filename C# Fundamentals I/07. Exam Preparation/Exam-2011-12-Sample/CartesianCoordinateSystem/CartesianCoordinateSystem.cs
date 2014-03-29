using System;

class CartesianCoordinateSystem
{
    static void Main()
    {
        float coordX = float.Parse(Console.ReadLine());
        float coordY = float.Parse(Console.ReadLine());

        if (coordX == 0 && coordY == 0)
        {
            Console.Write("0");
        }
        else if (coordX != 0 && coordY == 0)
        {
            Console.Write("6");
        }
        else if (coordX == 0 && coordY != 0)
        {
            Console.Write("5");
        }
        else if (coordX > 0 && coordY > 0)
        {

            Console.Write("1");
        }
        else if (coordX < 0 && coordY > 0)
        {
            Console.Write("2");
        }
        else if (coordX < 0 && coordY < 0)
        {
            Console.Write("3");
        }
        else if (coordX > 0 && coordY < 0)
        {
            Console.Write("4");
        }
    }
}

