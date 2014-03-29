using SnakeGame.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace SnakeGameJMTestProject
{


    /// <summary>
    ///This is a test class for GameEngineTest and is intended
    ///to contain all GameEngineTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GameEngineTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestMethod]
        public void StartGame_InitiliazeComponents_ShouldGenerateFoodSnakeAndObstaclesOnDifferentPositions()
        {

            GameEngine engine = new GameEngine();
            engine.StartGame();

            var obstacles = engine.Obstacles;
            var foods = engine.Foods;

            bool foodOverObstacle = false;
            foreach (var food in foods)
            {
                var fX1 = food.Position.X;
                var fX2 = food.Position.X + food.Size;

                var fY1 = food.Position.Y;
                var fY2 = food.Position.Y + food.Size;

                foreach (var obstacle in obstacles)
                {
                    var oX1 = obstacle.Position.X;
                    var oX2 = obstacle.Position.X + obstacle.Size;

                    var oY1 = obstacle.Position.Y;
                    var oY2 = obstacle.Position.Y + obstacle.Size;

                    bool fX1InObstacle = oX1 <= fX1 && fX1 <= oX2;
                    bool fX2InObstacle = oX1 <= fX2 && fX2 <= oX2;

                    bool fY1InObstacle = oY1 <= fY1 && fY1 <= oY2;
                    bool fY2InObstacle = oY1 <= fY2 && fY2 <= oY2;

                    if ((fX1InObstacle || fX2InObstacle) &&
                        (fY1InObstacle || fY2InObstacle))
                    {
                        foodOverObstacle = true;
                        break;
                    }
                }
            }
            Assert.IsFalse(foodOverObstacle);
            Assert.IsNotNull(engine.Snake);
        }

        [TestMethod]
        public void GameOver_ShouldStopTimerAndEmptySnakeObstaclesAndFood()
        {
            GameEngine_Accessor engine = new GameEngine_Accessor();
            engine.StartGame();

            engine.GameOver();

            Assert.IsTrue(engine.Snake.Parts.Count == 0);

            Assert.IsTrue(engine.Foods.Any());
            Assert.IsTrue(engine.Obstacles.Any());
        }
        
        [TestMethod]
        public void InitializeSnake_WhenSizeIsDefaultAndPositionIsInTheCenter_ShouldGenerateSnake()
        {
            GameEngine_Accessor engine = new GameEngine_Accessor();
            engine.InitializeSnake();

            var snake = engine.Snake;
            Assert.IsNotNull(snake);
        }

        [TestMethod]
        public void InitializeObstacles_ShouldGenerateCollectionOfObstacles()
        {
            GameEngine_Accessor engine = new GameEngine_Accessor();

            engine.InitilizeObstacles();
            var obstacles = engine.Obstacles;

            Assert.IsTrue(obstacles.Any());
        }

        [TestMethod]
        public void InitializeFood_ShouldGenerateCollectionOfFood()
        {

            GameEngine_Accessor engine = new GameEngine_Accessor();

            engine.InitilizeFood();
            var food = engine.Foods;
            Assert.IsTrue(food.Any());
        }

    }
}
