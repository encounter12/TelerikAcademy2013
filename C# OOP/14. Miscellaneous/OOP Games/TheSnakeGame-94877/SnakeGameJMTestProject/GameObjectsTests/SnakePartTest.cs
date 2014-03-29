using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Telerik.JustMock;
using SnakeGame.GameObjects;
using SnakeGame.Helpers;

namespace SnakeGameJMTestProject.GameObjectsTests
{
    [TestClass]
    public class SnakePartTest
    {
        private static SnakePart GenerateSnakePart(int x, int y, int size, int speed)
        {
            var pos = new Position(x, y);
            var snakePart = new SnakePart(pos, size, speed);
            return snakePart;
        }
         
        [TestMethod]
        public void CreateSnakePart_WhenXYSizeAndSpeedAreValid_ShouldSetDirectionToRightAndUpdateSpeed()
        {
            int x = 5;
            int y = 6;
            int size = 10;
            int speed = 10;
            var snakePart = new SnakePart(new Position(x, y), size, speed);

            var expectedDirection = MoveDirections.Right;
            var actualDirection = snakePart.Direction;

            Assert.AreEqual(expectedDirection, actualDirection, "Directions are not equal");

            var expectedSpeed = speed;
            var actualSpeed = snakePart.Speed;

            Assert.AreEqual(expectedSpeed, actualSpeed, "Speed is not set");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateSnakePart_WhenSpeedIsLessOrEqualToZero_ShouldThrowArgumentException()
        {
            int x = 5;
            int y = 6;
            int size = 10;
            int speed = 0;
            var snakePart = new SnakePart(new Position(x, y), size, speed);
        }

        [TestMethod]
        public void ChangeDirectionToLeft_WhenDirectionIsRight_ShouldNotUpdateDirection()
        {
            var snakePart = GenerateSnakePart(5, 6, 10, 11);

            snakePart.ChangeDirection(MoveDirections.Left);
            var expected = MoveDirections.Right;
            var actual = snakePart.Direction;

            Assert.AreEqual(expected, actual);
        }
               
        [TestMethod]
        public void ChangeDirectionToUp_WhenDirectionIsRight_ShouldUpdateDirectionToUp()
        {
            var snakePart = GenerateSnakePart(5, 6, 10, 11);

            snakePart.ChangeDirection(MoveDirections.Up);
            var expected = MoveDirections.Up;
            var actual = snakePart.Direction;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ChangeDirectionToUp_WhenDirectionIsLeft_ShouldUpdateDirectionToUp()
        {
            var snakePart = GenerateSnakePart(5, 6, 10, 11);
            snakePart.ChangeDirection(MoveDirections.Up);
            snakePart.ChangeDirection(MoveDirections.Left);

            snakePart.ChangeDirection(MoveDirections.Up);

            Assert.AreEqual(MoveDirections.Up, snakePart.Direction);
        }

        [TestMethod]
        public void Move_WhenDirectionIsRight_ShouldIncreaseXWithSpeed()
        {
            int x = 10;
            int y = 6;
            int speed = 11;
            var snakePart = GenerateSnakePart(x, y, 10, speed);

            snakePart.Move();
            var expectedX = x + speed;
            var actualX = snakePart.Position.X;
            Assert.AreEqual(expectedX, actualX);

            var expectedY = y;
            var actualY = snakePart.Position.Y;
            Assert.AreEqual(expectedY, actualY);
        }

        [TestMethod]
        public void Move_WhenDirectionIsLeft_ShouldDecreaseXWithSpeed()
        {
            int x = 12;
            int y = 6;
            int speed = 11;
            var snakePart = GenerateSnakePart(x, y, 10, speed);

            snakePart.ChangeDirection(MoveDirections.Up);
            snakePart.ChangeDirection(MoveDirections.Left);

            snakePart.Move();
            var expectedX = x - speed;
            var actualX = snakePart.Position.X;
            Assert.AreEqual(expectedX, actualX);

            var expectedY = y;
            var actualY = snakePart.Position.Y;
            Assert.AreEqual(expectedY, actualY);
        }

        [TestMethod]
        public void Move_WhenDirectionIsDown_ShouldIncreaseYWithSpeed()
        {
            int y = 50;
            int speed = 11;
            var snakePart = GenerateSnakePart(10, y, 10, speed);
            snakePart.ChangeDirection(MoveDirections.Down);

            snakePart.Move();

            var expected = y + speed;
            var actual = snakePart.Position.Y;
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void FirePropertyChangedEvent_WhenMoveIsCalled_ShouldExecuteMethod()
        {
            int x = 10;
            int y = 10;
            SnakePart part = GenerateSnakePart(x,y, 10, 11);
            bool isXChanged = false;
            bool isYChanged = false;
            part.PropertyChanged += (snd, args) =>
            {
                if (args.PropertyName == "X")
                {
                    isXChanged = true;
                }
                else if (args.PropertyName == "Y")
                {
                    isYChanged = true;
                }
            };
            part.Move();

            Assert.IsTrue(isXChanged);
            Assert.IsTrue(isYChanged);
        }
    }
}
