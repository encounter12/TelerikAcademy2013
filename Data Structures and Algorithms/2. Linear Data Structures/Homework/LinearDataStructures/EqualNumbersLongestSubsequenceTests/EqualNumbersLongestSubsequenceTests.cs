namespace EqualNumbersLongestSubsequenceTests
{
    using System;
    using System.Collections.Generic;
    using EqualNumbersLongestSubsequence;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EqualNumbersLongestSubsequenceTests
    {
        [TestMethod]
        public void EqualNumbersLongestSubsequenceInTheBeginningShouldReturnTrue()
        {
            List<int> numbers = new List<int>() { 2, 2, 2, 3, 1, 7, 9 };
            List<int> expected = new List<int>() { 2, 2, 2 };
            List<int> actual = LongestSubsequence.GetEqualNumbersLongestSubsequence(numbers);           
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualNumbersLongestSubsequenceAtTheEndShouldReturnTrue()
        {
            List<int> numbers = new List<int>() { 3, 1, 7, 9, 4, 4, 4, 4 };
            List<int> expected = new List<int>() { 4, 4, 4, 4 };
            List<int> actual = LongestSubsequence.GetEqualNumbersLongestSubsequence(numbers);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualNumbersLongestSubsequenceInTheMiddleShouldReturnTrue()
        {
            List<int> numbers = new List<int>() { 2, 1, 8, 8, 8, 2, 6, 3 };
            List<int> expected = new List<int>() { 8, 8, 8 };
            List<int> actual = LongestSubsequence.GetEqualNumbersLongestSubsequence(numbers);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualNumbersLongestSubsequenceWhenAllSubsequencesConsistOfOneElementReturnsTheFirstElement()
        {
            List<int> numbers = new List<int>() { 2, 1, 4, 6, 7, 8, 7, 3 };
            List<int> expected = new List<int>() { 2 };
            List<int> actual = LongestSubsequence.GetEqualNumbersLongestSubsequence(numbers);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualNumbersLongestSubsequenceConsistOfNegativeIntegersShouldReturnTrue()
        {
            List<int> numbers = new List<int>() { 3, 1, 2, -4, -4, -4, -4, 12, 12, 5, 5, 7, 8 };
            List<int> expected = new List<int>() { -4, -4, -4, -4 };
            List<int> actual = LongestSubsequence.GetEqualNumbersLongestSubsequence(numbers);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
