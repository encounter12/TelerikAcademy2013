using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Math;

namespace MathUnitTests
{
    [TestClass]
    public class SummatorTests
    {
        [TestMethod]
        public bool IsPositiveIntegersSumCorrect()
        {
            int a = 5;
            int b = 15;
            var summator = new Summator(a, b);
            if (summator.Sum() == 20)
            {
                return true;
            }
            return false;
        }
    }
}
