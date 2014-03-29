using SnakeGame.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SnakeGame.GameObjects;
using System.Collections.Generic;
using SnakeGame;

namespace SnakeGameJMTestProject
{
    [TestClass()]
    public class GameEngineTest
    {
        [TestMethod()]
        [DeploymentItem("SnakeGame.exe")]
        public void IsOver_WhenPositionsNotМatch_ShouldReturnFalse()
        {
            GameEngine_Accessor target = new GameEngine_Accessor();
            Position p1 = new Position(12, 13) ;
            int size1 = 1;
            Position p2 = new Position(13,14);
            int size2 = 2;
            bool actual = target.IsOver(p1, size1, p2, size2);
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        [DeploymentItem("SnakeGame.exe")]
        public void IsOver_WhenPositionsМatch_ShouldReturnTrue()
        {
            GameEngine_Accessor target = new GameEngine_Accessor();
            Position p1 = new Position(12, 13);
            int size1 = 2;
            Position p2 = new Position(13, 14);
            int size2 = 1;
            bool actual = target.IsOver(p1, size1, p2, size2);
            Assert.IsTrue(actual);
        }
    }
}
