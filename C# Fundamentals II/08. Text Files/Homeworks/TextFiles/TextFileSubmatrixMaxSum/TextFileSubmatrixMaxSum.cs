using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileSubmatrixMaxSum
{
    class TextFileSubmatrixMaxSum
    {
        public static int SubMatrixElementsMaxSum(int[,] matrix, int subMatrixRows, int subMatrixCols)
        {
            int maxSum = int.MinValue;
            int currentSum = 0;
            for (int i = 0; i <= matrix.GetLength(0) - subMatrixRows; i++)
            {
                for (int j = 0; j <= matrix.GetLength(1) - subMatrixCols; j++)
                {
                    currentSum = SubMatrixSum(matrix, i, j, subMatrixRows, subMatrixCols);
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
                
            }
            return maxSum;
        }
        public static int SubMatrixSum(int[,] matrix, int firstElementRow, int firstElementCol, int subMatrixRows, int subMatrixCols)
        {
            int subMatrixSum = 0;
            for (int i = firstElementRow; i < firstElementRow + subMatrixRows; i++)
            {                
                for (int j = firstElementCol; j < firstElementCol + subMatrixCols; j++)
                {
                    subMatrixSum += matrix[i, j];
                }
                
            }
            return subMatrixSum;
        }
        static void Main(string[] args)
        {
            string matrixFilePath = @"..\..\InputOutput\Input.txt";
            List<string[]> stringLines = new List<string[]>();

            using (StreamReader reader = new StreamReader(matrixFilePath))
            {
                string lineString = "";
                while (reader.Peek() >= 0)
                {
                    lineString = reader.ReadLine().ToString();
                    string[] lineStringArray = lineString.Split(' ');
                    stringLines.Add(lineStringArray);
                }                
            }

            int matrixLength = stringLines.Count - 1;
            int[,] matrix = new int[matrixLength, matrixLength];

            for (int i = 1; i < stringLines.Count; i++)
            {
                int j = 0;
                foreach (string line in stringLines[i])
                {
                    matrix[i - 1, j] = int.Parse(line);
                    j++;
                }
            }
            int subMatrixMaxSum = SubMatrixElementsMaxSum(matrix, 2, 2);

            string resultFileName = @"Output.txt";
            string resultFilePath = @"..\..\InputOutput\" + resultFileName;

            using (StreamWriter outfile = new StreamWriter(resultFilePath))
            {
                outfile.Write(subMatrixMaxSum);
            }

            //The Input and Output text files are located in: 08.TextFiles\TextFileSubmatrixMaxSum\InputOutput
        }
    }
}
