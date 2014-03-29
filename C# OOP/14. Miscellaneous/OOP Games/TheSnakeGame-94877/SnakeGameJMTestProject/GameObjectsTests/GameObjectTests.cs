using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Telerik.JustMock;
using SnakeGame.GameObjects;
using SnakeGame.Helpers;
using SnakeGameJMTestProject.Objects;

namespace SnakeGameJMTestProject.GameObjectsTests
{
    [TestClass]
    public class GameObjectTests
    {
        [TestMethod]
        public void CreateGameObject_WhenXYandSizeAreValid_ShouldUpdatePositionAndSize()
        {
            int x = 5;
            int y = 6;
            int size = 10;
            var position = new Position(x, y);
            var go = new GameObjectInheritor(x,y,size);
            Assert.AreEqual(size, go.Size, "Size is not set");
            Assert.AreEqual(position, go.Position, "Position is unsuccessfull");
        }
         
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateGameObject_WhenSizeIsEqualTo0_ThrowArgumentException()
        {
            int x = 5;
            int y = 6;
            int size = 0;
            var go = new GameObjectInheritor(x, y, size);
        }
    }
}
