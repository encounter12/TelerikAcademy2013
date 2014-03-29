using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFiles
{
    class ConcatenateTwoTextFiles
    {
        static void Main(string[] args)
        {
            
            List<string> filePaths = new List<string>()
            {
                {@"..\..\Text File 01.txt"},
                {@"..\..\Text File 02.txt"}
            };

            string resultFileName = @"Text File Result.txt";
            string resultFilePath = @"..\..\" + resultFileName;
            StringBuilder sb = new StringBuilder();

            foreach (string path in filePaths)
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    sb.Append(reader.ReadToEnd());
                    //sb.AppendLine();
                }
                                                                           
            }

            using (StreamWriter outfile = new StreamWriter(resultFilePath) )
            {
                outfile.Write(sb.ToString());
            }          

        }
    }
}
