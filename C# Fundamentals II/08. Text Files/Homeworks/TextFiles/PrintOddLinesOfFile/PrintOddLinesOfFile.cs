using System;
using System.IO;

namespace PrintOddLinesOfFile
{
    class PrintOddLinesOfFile
    {
        /**
         * Write a program that reads a text file and prints on the console its odd lines.
         */
        static void Main()
        {
            string fileName = "../../file.txt";

            try
            {
                StreamReader streamReader = new StreamReader(fileName);
                using (streamReader)
                {
                    int lineNumber = 1;
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        if (lineNumber % 2 != 0)
                        {
                            Console.WriteLine("Line {0}: {1}", lineNumber, line);
                        }
                        lineNumber++;
                        line = streamReader.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("Can not find file {0}.", fileName);
            }
            catch (DirectoryNotFoundException)
            {
                Console.Error.WriteLine("Invalid directory in the file path.");
            }
            catch (IOException)
            {
                Console.Error.WriteLine("Can not open the file {0} due to I/O error.", fileName);
            }
        }
    }
}
