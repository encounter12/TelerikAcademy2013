namespace Frames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Frames
    {
        static SortedSet<string> permutations = new SortedSet<string>();

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Frame[] frames = new Frame[n];
            

            for (int i = 0; i < n; i++)
            {
                int[] sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                frames[i] = new Frame(sizes[0], sizes[1]);
            }

            GeneratePermutations(frames, 0);
            Console.WriteLine(permutations.Count);
            Print(permutations);
        }

        struct Frame
        {
            public Frame(int width, int height) : this()
            {
                this.Width = width;
                this.Height = height;
            }
            public int Width { get; set; }
            public int Height { get; set; }

            public override string ToString()
            {
                return string.Format("({0}, {1})", this.Width, this.Height);
            }
        }

        static void GeneratePermutations(Frame[] arr, int k)
        {
            if (k >= arr.Length)
            {
                permutations.Add(string.Join(" | ", arr));
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                FlipFrame(ref arr[k]);
                GeneratePermutations(arr, k + 1);

                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, k + 1);

                    FlipFrame(ref arr[k]);
                    GeneratePermutations(arr, k + 1);

                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        static void Print(SortedSet<string> permutations)
        {
            StringBuilder output = new StringBuilder();
            foreach (var permutation in permutations)
            {
                output.AppendLine(permutation);
            }
            Console.WriteLine(output.ToString().Trim());
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }

        static void FlipFrame(ref Frame frame)
        {
            int oldWidth = frame.Width;
            frame.Width = frame.Height;
            frame.Height = oldWidth;
        }
    }
}