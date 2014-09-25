using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    class Program
    {
        static void Main()
        {
            DateTime start = DateTime.Now;
            var table = new HashDictionary<string, int>();
            //var dict = new Dictionary<string, int>();
            var count = 1000000;

            for (var i = 0; i < count; i++)
            {
                table.Add("test" + i, i);
                //dict.Add("test" + i, i);
            }

            Console.WriteLine(DateTime.Now - start);
        }
    }
}
