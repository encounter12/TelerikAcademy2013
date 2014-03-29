using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSymmetricNumeralMatrix
{
    class PrintSymmetricNumeralMatrix
    {
        static void Main()
        {
            byte n;
            do
            {
                Console.WriteLine("Enter positive integer n (n < 20):");
            } while (!byte.TryParse(Console.ReadLine(), out n) || n >= 20);

            byte[,] symmetricMatrix = new byte[n,n];

            for (byte i = 0; i < n; i++)
            {
                for (byte j = 0; j < n; j++)
                {
                    symmetricMatrix[i, j] = (byte)(j + i + 1);
                    Console.Write("{0, -2} ", symmetricMatrix[i,j]);
                }
                Console.WriteLine();
            }

        }
    }
}
