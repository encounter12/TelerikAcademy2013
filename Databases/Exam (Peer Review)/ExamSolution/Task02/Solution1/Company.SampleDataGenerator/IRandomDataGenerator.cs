using System;
using System.Linq;

namespace Company.SampleDataGenerator
{
    internal interface IRandomDataGenerator
    {
        int GetRandomNumber(int min, int max);

        string GetRandomString(int length);

        string GetRandomStringWithRandomLength(int min, int max);
    }
}
