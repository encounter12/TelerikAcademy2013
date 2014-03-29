using System;

namespace Exception
{
    public class ExceptionTest<T> where T : IComparable
    {
        public static void IsValueWithinRange(T value, T startRange, T endRange)
        {
            if (value.CompareTo(startRange) < 0 || value.CompareTo(endRange) > 0)
            {
                throw new InvalidRangeException<T>(startRange, endRange, value);
            }
            else
            {
                Console.WriteLine("{0} is within the range [{1}, {2}]", value, startRange, endRange);
            }
        }
    }
}


