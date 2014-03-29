using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using SnakeGame.GameObjects;
using SnakeGame.Helpers;

namespace SnakeGameJMTestProject.GameObjectsTests
{
    [TestClass]
    public class PositionTests
    {
        [TestMethod]
        public void CreatePosition_WhenXandYAreValid_ShouldUpdateXandY()
        {
            int x = 6;
            int y = 5;
            Position pos = new Position(x, y);
            Assert.AreEqual(x, pos.X);
            Assert.AreEqual(y, pos.Y);
        }

        [TestMethod]
        public void CreatePosition_WhenXisNegative_ShouldUpdateXToMaxX()
        {
            int x = -6;
            int y = 5;
            Position pos = new Position(x, y);
            var expected = x + Constants.MaxX;
            var actual = pos.X;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreatePosition_WhenYisNegative_ShouldUpdateYToMaxY()
        {
            int x = 6;
            int y = -5;
            Position pos = new Position(x, y);
            var expected = y + Constants.MaxY;
            var actual = pos.Y;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreatePosition_WhenXIsLargerThanMaxX_ShouldUpdateXToZero()
        {
            int x = Constants.MaxX + 1;
            int y = 5;
            Position pos = new Position(x, y);
            var expected = x % Constants.MaxX;
            var actual = pos.X;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreatePosition_WhenYIsLargerThanMaxY_ShouldUpdateYToZero()
        {
            int x = 5;
            int y = Constants.MaxY + 1;

            Position pos = new Position(x, y);
            var expected = y % Constants.MaxY;
            var actual = pos.Y;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_WhenTwoPositionAreWIthEqualXAndY_ShouldReturnTrue()
        {
            int x = 5;
            int y = 6;

            Position firstPos = new Position(x, y);
            Position secondPos = new Position(x, y);
            var result = firstPos.Equals(secondPos);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_WhenTwoPositionsAreWithEqualXAndDiffentY_ShouldReturnFalse()
        {
            int x = 5;
            int y1 = 6;
            int y2 = 7;

            Position firstPos = new Position(x, y1);
            Position secondPos = new Position(x, y2);
            var result = firstPos.Equals(secondPos);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_WhenTwoPositionsAreWithEqualYAndDiffentX_ShouldReturnFalse()
        {
            int x1 = 5;
            int x2 = 6;
            int y = 7;

            Position firstPos = new Position(x1, y);
            Position secondPos = new Position(x2, y);
            var result = firstPos.Equals(secondPos);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_WhenSecondComponentIsNotPosition_ShouldReturnFalse()
        {
            int x = 5;
            int y = 6;
            Position pos = new Position(x, y);
            string other = "Test Object";
            Assert.AreNotEqual(pos, other);
        }
    }
}