using SnakeGame.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SnakeGame.GameObjects;
using System.Collections.Generic;
using SnakeGame;
using SnakeGame.Helpers;

namespace SnakeGameJMTestProject
{
    [TestClass]
    public class MovingFoodTests
    {
        [TestMethod]
        public void MovingFoodTest_MoveUp()
        {
            int x = 20;
            int y = 30;
            Position pos = new Position(x, y);
            int size = 5;
            int speed = 10;
            MovingFood movingFood = new MovingFood(pos, size);
            movingFood.Direction = MoveDirections.Up;
            movingFood.Speed = speed;
            int expectedX = 20;
            int expectedY = 20;
            movingFood.Move();
            Assert.AreEqual(expectedX, movingFood.Position.X);
            Assert.AreEqual(expectedY, movingFood.Position.Y);
        }

        [TestMethod]
        public void MovingFoodTest_MoveRight()
        {
            int x = 20;
            int y = 30;
            Position pos = new Position(x, y);
            int size = 5;
            int speed = 10;
            MovingFood movingFood = new MovingFood(pos, size);
            movingFood.Direction = MoveDirections.Right;
            movingFood.Speed = speed;
            int expectedX = 30;
            int expectedY = 30;
            movingFood.Move();
            Assert.AreEqual(expectedX, movingFood.Position.X);
            Assert.AreEqual(expectedY, movingFood.Position.Y);
        }

        [TestMethod]
        public void MovingFoodTest_MoveDown()
        {
            int x = 20;
            int y = 30;
            Position pos = new Position(x, y);
            int size = 5;
            int speed = 10;
            MovingFood movingFood = new MovingFood(pos, size);
            movingFood.Direction = MoveDirections.Down;
            movingFood.Speed = speed;
            int expectedX = 20;
            int expectedY = 40;
            movingFood.Move();
            Assert.AreEqual(expectedX, movingFood.Position.X);
            Assert.AreEqual(expectedY, movingFood.Position.Y);
        }

        [TestMethod]
        public void MovingFoodTest_MoveLeft()
        {
            int x = 20;
            int y = 30;
            Position pos = new Position(x, y);
            int size = 5;
            int speed = 10;
            MovingFood movingFood = new MovingFood(pos, size);
            movingFood.Direction = MoveDirections.Left;
            movingFood.Speed = speed;
            int expectedX = 10;
            int expectedY = 30;
            movingFood.Move();
            Assert.AreEqual(expectedX, movingFood.Position.X);
            Assert.AreEqual(expectedY, movingFood.Position.Y);
        }

        [TestMethod]
        public void ChangeDirectionTest_ToRight()
        {
            int size = 5;
            Position pos = new Position(20, 30);
            MovingFood movingFood = new MovingFood(pos, size);

            MoveDirections expectedDirection = MoveDirections.Right;
            movingFood.ChangeDirection(expectedDirection);
            MoveDirections actualDirection = movingFood.Direction;

            Assert.AreEqual(expectedDirection, actualDirection);
        }

        [TestMethod]
        public void ChangeDirectionTest_ToUp()
        {
            int size = 5;
            Position pos = new Position(20,30);
            MovingFood movingFood = new MovingFood(pos, size);
            
            MoveDirections expectedDirection = MoveDirections.Up;
            movingFood.ChangeDirection(expectedDirection);
            MoveDirections actualDirection = movingFood.Direction;

            Assert.AreEqual(expectedDirection, actualDirection);
        }

        [TestMethod]
        public void ChangeDirectionTest_ToLeft()
        {
            int size = 5;
            Position pos = new Position(20, 30);
            MovingFood movingFood = new MovingFood(pos, size);

            MoveDirections expectedDirection = MoveDirections.Left;
            movingFood.ChangeDirection(expectedDirection);
            MoveDirections actualDirection = movingFood.Direction;

            Assert.AreEqual(expectedDirection, actualDirection);
        }

        [TestMethod]
        public void ChangeDirectionTest_ToDown()
        {
            int size = 5;
            Position pos = new Position(20, 30);
            MovingFood movingFood = new MovingFood(pos, size);

            MoveDirections expectedDirection = MoveDirections.Down;
            movingFood.ChangeDirection(expectedDirection);
            MoveDirections actualDirection = movingFood.Direction;

            Assert.AreEqual(expectedDirection, actualDirection);
        }

        [TestMethod]
        public void MovingFoodTest_SpeedWith5()
        {
            int size = 5;
            Position pos = new Position(20, 30);
            int expectedSpeed = 7;
            MovingFood movingFood = new MovingFood(pos, size);
            movingFood.Speed = expectedSpeed;
            Assert.AreEqual(expectedSpeed, movingFood.Speed);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MovingFoodTest_SpeedWith0()
        {
            int size = 5;
            Position pos = new Position(20, 30);
            int expectedSpeed = 0;
            MovingFood movingFood = new MovingFood(pos, size);
            movingFood.Speed = expectedSpeed;
        }
    }
}
