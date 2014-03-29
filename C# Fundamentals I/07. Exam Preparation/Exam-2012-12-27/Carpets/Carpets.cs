using System;

class Carpets
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string upperLeftString = "/";
        string upperRightString = @"\";
        string bottomLeftString = @"\";
        string bottomRightString = "/";


        for (int halfRows = 0; halfRows < n / 2; halfRows++)
        {
            for (int i = 0; i < (n - 2) / 2 - halfRows; i++)
            {
                Console.Write(".");
            }                           
            if (halfRows > 0 && halfRows % 2 != 0)
            {
                upperLeftString += " ";
                bottomLeftString += " ";
                upperRightString = upperRightString.Insert(0, " ");
                bottomRightString = bottomRightString.Insert(0, " ");
            }
            else if (halfRows > 0)
            {
                upperLeftString += "/";
                bottomLeftString += @"\";
                upperRightString = upperRightString.Insert(0, @"\");
                bottomRightString = bottomRightString.Insert(0, "/");
            } 
           
                                  
            Console.Write(upperLeftString);
            Console.Write(upperRightString);

            for (int i = 0; i < (n - 2) / 2 - halfRows; i++)
            {
                Console.Write(".");
            }     
            Console.WriteLine();
        }

        for (int halfRows = 0; halfRows < n / 2; halfRows++)
        {
            for (int i = 0; i < halfRows; i++)
            {
                Console.Write(".");
            }

            Console.Write(bottomLeftString);
            bottomLeftString = bottomLeftString.Remove(bottomLeftString.Length - 1);

            Console.Write(bottomRightString);
            bottomRightString = bottomRightString.Remove(0, 1);

            for (int i = 0; i < halfRows; i++)
            {
                Console.Write(".");

            }
            Console.WriteLine();
        }
    }  
}

