using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos
{
    class Program
    {
        static Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

        static void AddMark(string name, double mark)
        {
            if (!(students.ContainsKey(name)))
            {
                students[name] = new List<double>();
            }
            List<double> studentMarks = students[name];
            studentMarks.Add(mark);
        }

        static void CountAndPrintWords(IEnumerable<String> words,
                                       IDictionary<string, int> wordsCount)
        {
            foreach (var word in words)
            {
                if (!(wordsCount.ContainsKey(word)))
                {
                    wordsCount[word] = 0;
                }
                wordsCount[word]++;
            }

            foreach (var pair in wordsCount)
            {
                Console.WriteLine("{0} occurs {1} times", pair.Key, pair.Value);
            }
        }

        static void Main(string[] args)
        {

            ISet<string> names = new SortedSet<string>();

            names.Add("Peter");
            names.Add("Stamat");
            names.Add("Georgi");
            names.Add("Maria");
            names.Add("Asen");
            names.Add("Georgi");

            for (int i = 0; i < 10; i++)
            {
                names.Add("Peter" + i);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

        }
    }
}
