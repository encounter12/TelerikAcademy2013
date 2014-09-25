namespace MessagesInABottleV2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Solution using Stack in Solve function.
    /// </summary>
    class MessagesInABottleV2
    {
        static List<KeyValuePair<char, string>> ciphers = new List<KeyValuePair<char, string>>();
        static string message;

        static void Main()
        {
            message = Console.ReadLine();
            string cipher = Console.ReadLine();

            char key = char.MinValue;

            StringBuilder value = new StringBuilder();

            for (int i = 0; i < cipher.Length; i++)
            {
                if (cipher[i] >= 'A' && cipher[i] <= 'Z')
                {
                    if (key != char.MinValue)
                    {
                        ciphers.Add(new KeyValuePair<char, string>(key, value.ToString()));
                        value.Clear();
                    }
                    key = cipher[i];
                }
                else
                {
                    value.Append(cipher[i]);
                }
            }

            if (key != char.MinValue)
            {
                ciphers.Add(new KeyValuePair<char, string>(key, value.ToString()));
                value.Clear();
            }

            stack = new Stack<char>();
            Solve(0);

            Console.WriteLine(solutions.Count);
            solutions.Sort();
            foreach (var solution in solutions)
            {
                Console.WriteLine(solution);
            }
        }

        static List<string> solutions = new List<string>();
        static Stack<char> stack;

        static void Solve(int secretMessageIndex)
        {
            if (secretMessageIndex == message.Length)
            {
                var stackAsArray = stack.ToArray();
                stackAsArray = stackAsArray.Reverse().ToArray();
                solutions.Add(new string(stackAsArray));
                return;
            }
            foreach (var cipher in ciphers)
            {
                if (message.Substring(secretMessageIndex).StartsWith(cipher.Value))
                {
                    stack.Push(cipher.Key);
                    Solve(secretMessageIndex + cipher.Value.Length);
                    stack.Pop();
                }
            }
        }
    }
}