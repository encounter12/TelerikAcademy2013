using System;

class IsPointOutsideRectangle
{
    static void Main()
    {
        Console.WriteLine("THIS PROGRAM CHECKS IF A POINT IS WITHIN RECTANGLE:");
        //R(top = 1, left = -1, width = 6, height = 2)

        float topY = 1f;
        float leftX = -1f;
        float width = 6f;
        float height = 2f;
        float rightX = leftX + width;
        float bottomY = topY - height;

        Console.WriteLine("Please write the point X coordinate:");
        float pointX = Single.Parse(Console.ReadLine());
        Console.WriteLine("Please write the point Y coordinate:");
        float pointY = Single.Parse(Console.ReadLine());
      
        if ((pointX < leftX) || (pointX > rightX) || (pointY < bottomY) || (pointY > topY))
        {
            Console.WriteLine("The point is OUTSIDE the rectangle");
        }
        else
        {
            Console.WriteLine("The point is WITHIN the rectangle");
        }

    }
}
