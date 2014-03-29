using System;

class IsPointWithinACircle
{
    static void Main()
    {
        Console.WindowWidth = 105;
        /*Circle K (A,r) has center coordinates A(x0 = 0, y0 = 0) and radius r = 5 which are hardcoded below. 
        The same variables could be assigned different values either by user input or by another system. */

        double x0 = 0;
        double y0 = 0;
        double r = 5;
        Console.WriteLine("This program checks if a given point C(x, y) is within a circle K with center: A({0},{1}) and radius r= {2}"
            ,x0, y0, r);

        Console.WriteLine("Please enter the point coordinate x:");
        double x = Double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the point coordinate y:");
        double y = Double.Parse(Console.ReadLine());

        /*In order to solve this task we compare the hypothenuse AC of the right triangle ABC with the circle radius r
         A(x0,y0) - circle center;
         B(x,y0);
         C(x,y)
         
         AB = x - x0;
         BC = y - y0;
         AC = sqrt[(x - x0)^2 + (y - y0)^2]
         If AC <= r then the point C(x,y) is within the circle K
        
         */

        double hypothenuseAC = Math.Sqrt(Math.Pow(x-x0, 2) + Math.Pow(y-y0, 2));

        if (hypothenuseAC <= r)
        {
            Console.WriteLine("The point C({0},{1}) is WITHIN the circle K(A({2},{3}), r (={4}))", x, y, x0, y0, r);            
        }
        else
	    {
            Console.WriteLine("The point C({0},{1}) is OUTSIDE the circle K(A({2},{3}), r (={4}))", x, y, x0, y0, r);                
	    }
       
    }
}

