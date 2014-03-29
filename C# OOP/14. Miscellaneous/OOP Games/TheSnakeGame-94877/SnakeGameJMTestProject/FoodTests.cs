using SnakeGame.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SnakeGame.GameObjects;
using System.Collections.Generic;
using SnakeGame;


namespace SnakeGameJMTestProject
{
    [TestClass]
    public class FoodTests
    {
        [TestMethod]
        public void FoodTest_Constructor()
        {
            int x = 10;
            int y = 20;
            int size = 5;
            Position pos = new Position(x, y);
            Food food = new Food(pos, size);
            Assert.AreEqual(food.Position, pos);
            Assert.AreEqual(food.Size, size);
        }

        [TestMethod]
        public void FoodTest_Destroy()
        {
            int x = 10;
            int y = 20;
            int size = 5;
            Position pos = new Position(x, y);
            Food food = new Food(pos, size);
            food.Destroy();
            Assert.IsTrue(food.IsDestroyed);
        }
        [TestMethod]
        public void FoodTest_IsDestroyFalse()
        {
            int x = 10;
            int y = 20;
            int size = 5;
            Position pos = new Position(x, y);
            Food food = new Food(pos, size);
            Assert.IsFalse(food.IsDestroyed);
        }
    }
}