namespace EqualNumbersLongestSubsequenceTests
{
    using System;
    using System.Collections.Generic;
    using EqualNumbersLongestSubsequence;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetLongerSequenceTests
    {
        [TestMethod]
        public void FirstSequenceLongerThanSecondShouldReturnFirstSequence()
        {
            List<int> firstSequence = new List<int>() { 2, 2, 2, 2 };
            List<int> secondSequence = new List<int>() { 3, 3, 3 };
            List<int> actualLongerSequence = LongestSubsequence.GetLongerSequence(firstSequence, secondSequence);
            CollectionAssert.AreEqual(firstSequence, actualLongerSequence);
        }

        [TestMethod]
        public void SecondSequenceLongerThanFirstShouldReturnFirstSequence()
        {
            List<int> firstSequence = new List<int>() { 1, 1 };
            List<int> secondSequence = new List<int>() { 4, 4, 4, 4 };
            List<int> actualLongerSequence = LongestSubsequence.GetLongerSequence(firstSequence, secondSequence);
            CollectionAssert.AreEqual(secondSequence, actualLongerSequence);
        }

        [TestMethod]
        public void FirstSequenceWithNegativeIntegersLongerThanSecondWithPositiveIntegersShouldReturnFirstSequence()
        {
            List<int> firstSequence = new List<int>() { -4, -4, -4, -4 };
            List<int> secondSequence = new List<int>() { 3, 3, 3 };
            List<int> actualLongerSequence = LongestSubsequence.GetLongerSequence(firstSequence, secondSequence);
            CollectionAssert.AreEqual(firstSequence, actualLongerSequence);
        }

        [TestMethod]
        public void FirstSequenceWithPositiveIntegersLongerThanSecondWithNegativeIntegersShouldReturnFirstSequence()
        {
            List<int> firstSequence = new List<int>() { 12, 12, 12, 12 };
            List<int> secondSequence = new List<int>() { -5, -5, -5 };
            List<int> actualLongerSequence = LongestSubsequence.GetLongerSequence(firstSequence, secondSequence);
            CollectionAssert.AreEqual(firstSequence, actualLongerSequence);
        }

        [TestMethod]
        public void FirstAndSecondSequencesHaveEqualLengthShouldReturnFirstSequence()
        {
            List<int> firstSequence = new List<int>() { 8, 8, 8, 8 };
            List<int> secondSequence = new List<int>() { 5, 5, 5, 5 };
            List<int> actualLongerSequence = LongestSubsequence.GetLongerSequence(firstSequence, secondSequence);
            CollectionAssert.AreEqual(firstSequence, actualLongerSequence);
        }

        [TestMethod]
        public void FirstAndSecondSequencesHaveOnlyOneElementShouldReturnFirstSequence()
        {
            List<int> firstSequence = new List<int>() { 11 };
            List<int> secondSequence = new List<int>() { 72 };
            List<int> actualLongerSequence = LongestSubsequence.GetLongerSequence(firstSequence, secondSequence);
            CollectionAssert.AreEqual(firstSequence, actualLongerSequence);
        }
    }
}