using System;

class SpecialValue
{

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[][] jagged = new int[n][];

        string[] stringSeparator = new string[] {", "};  

        for (int i = 0; i < n; i++)
        {
            string[] rowString = Console.ReadLine().Split(stringSeparator, StringSplitOptions.None);
            
            jagged[i] = new int[rowString.Length];

            for (int j = 0; j < rowString.Length; j++)
            {
                jagged[i][j] = int.Parse(rowString[j]);
            }
        }

        int specialValue = 0;
        int currentSpecialValue = 0;
        int currentPath = 0;        
        bool currentPathExists = true;
        bool[][] cellVisited = new bool[jagged.Length][];

        for (int i = 0; i < jagged[0].Length; i++)
        {
            for (int j = 0; j < jagged.Length; j++)
            {
                cellVisited[j] = new bool[jagged[j].Length];
            }
            
            int currentRow = 0;
            int currentColumn = i;
            currentPath = 0;
            int cellValue = jagged[currentRow][currentColumn];

            while (true)
            {                
                currentPath++;
                cellValue = jagged[currentRow][currentColumn];

                if (cellValue < 0)
                {
                    currentPathExists = true;
                    break;
                }

                if (cellVisited[currentRow][currentColumn] == true)
                {
                    currentPathExists = false;
                    break;
                }

                cellVisited[currentRow][currentColumn] = true;
                                
                currentColumn = cellValue;
                                
                currentRow++;

                if (currentRow == jagged.Length)
                {
                    currentRow = 0;
                }

                
            }

            if (currentPathExists == true)
            {
                currentSpecialValue = currentPath + Math.Abs(cellValue);
                if (currentSpecialValue > specialValue)
                {
                    specialValue = currentSpecialValue;
                }  
            }                     
           
        }

        Console.WriteLine(specialValue);
    }
}

