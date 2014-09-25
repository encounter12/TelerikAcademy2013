namespace EqualNumbersLongestSubsequenceTests
{
    using System;
    using EqualNumbersLongestSubsequence;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConvertInputToListTests
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InputStartingWithInvalidElementShouldThrowFormatException()
        {
            string input = "Microsoft 1 3 7";
            LongestSubsequence.ConvertInputToList(input);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InputEndingWithInvalidElementShouldThrowFormatException()
        {
            string input = "1 3 7 Google";
            LongestSubsequence.ConvertInputToList(input);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InputWithInvalidElementInTheMiddleShouldThrowFormatException()
        {
            string input = "1 3 Oracle 4 7";
            LongestSubsequence.ConvertInputToList(input);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InputWithInvalidSeparatorInTheBeginningShouldThrowFormatException()
        {
            string input = ";1, 3, 4, 7, 5";
            LongestSubsequence.ConvertInputToList(input);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InputWithInvalidSeparatorInTheEndShouldThrowFormatException()
        {
            string input = "1, 3, 4, 7, 5;";
            LongestSubsequence.ConvertInputToList(input);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InputWithInvalidSeparatorInTheMiddleShouldThrowFormatException()
        {
            string input = "1, 3, 4; 7, 5";
            LongestSubsequence.ConvertInputToList(input);
        }
    }
}
