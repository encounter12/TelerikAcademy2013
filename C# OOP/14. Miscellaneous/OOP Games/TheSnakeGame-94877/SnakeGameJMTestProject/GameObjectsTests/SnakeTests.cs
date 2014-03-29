using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using SnakeGame.GameObjects;
using SnakeGame.Helpers;

namespace SnakeGameJMTestProject.GameObjectsTests
{
    [TestClass]
    public class SnakeTests
    {
        private Snake CreateSnake(int x, int y, int size, int speed)
        {
            var pos = new Position(x, y);
            var snake = new Snake(pos, size, speed);
            return snake;
        }

        [TestMethod]
        public void CreateSnake_WhenSpeedIsValid_ShouldUpdateSpeed()
        {
            int speed = 5;

            var snake = CreateSnake(400, 5, 5, speed);
            var expected = speed;
            var actual = snake.Speed;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateSnake_WhenSizeIs5_ShouldInitializeArrayOf5SnakeParts()
        {
            int size = 5;
            var snake = CreateSnake(400, 7, size, 10);

            var expected = size;
            var actual = snake.Size;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Destroy_WhenSnakeIsInitialized_ShouldUpdateIsDestroyedToTrue()
        {
            var snake = CreateSnake(400, 7, 5, 10);
            snake.Destroy();

            Assert.IsTrue(snake.IsDestroyed);
        }

        [TestMethod]
        public void CreateSnake_ShouldSetDestroyedToFalse()
        {
            int x = 400;
            int y = 7;
            var pos = new Position(x, y);
            int size = 5;
            int speed = 10;
            var snake = new Snake(pos, size, speed);

            Assert.IsFalse(snake.IsDestroyed);
        }

        [TestMethod]
        public void GrowSnake_WhenCurrentSizeIs5_ShouldGenerateNewElementAtTheTail()
        {
            int x = 400;
            int y = 7;
            var pos = new Position(x, y);
            int size = 5;
            int speed = 10;
            var snake = new Snake(pos, size, speed);
            snake.Grow();

            var expected = size + 1;
            var actual = snake.Size;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ChangeDirectionToUp_WhenDirectionIsRight_ShouldUpdateDirectionToUp()
        {
            var snake = CreateSnake(400, 100, 5, 10);
            snake.ChangeDirection(MoveDirections.Up);

            var expected = MoveDirections.Up;
            var actual = snake.Direction;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ChangeDirectionToLeft_WhenDirectionIsRight_ShouldNotUpdateDirection()
        {
            var snake = CreateSnake(400, 100, 5, 10);
            snake.ChangeDirection(MoveDirections.Left);

            var expected = MoveDirections.Right;
            var actual = snake.Direction;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Move_WhenDirectionIsRight_ShouldIncreaseX()
        {
            int x = 400;
            int speed = 11;
            var snake = CreateSnake(x, 5, 5, speed);

            snake.Move();

            var expected = x + speed;
            var actual = snake.Position.X;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Move_WhenDirectionIsRight_ShouldUpdatePositionsOfAllParts()
        {
            int x = 400;
            int y = 400;
            int speed = 11;
            var snake = CreateSnake(x, y, 5, speed);

            Position[] positions = new Position[snake.Size];
            for (int i = 0; i < snake.Size; i++)
            {
                var currentPosition = snake.Parts[i].Position;
                positions[i] = new Position(currentPosition.X, currentPosition.Y);
            }

            snake.Move();

            for (int i = 0; i < snake.Size; i++)
            {
                var position = positions[i];
                MoveDirections partDirection = snake.Parts[i].Direction;
                int xOffset = snake.Speed * Constants.DX[partDirection];
                var newX = position.X + xOffset;

                int yOffset = snake.Speed * Constants.DY[partDirection];
                var newY = position.Y + yOffset;

                var expected = new Position(newX, newY);
                var actual = snake.Parts[i].Position;

                Assert.AreEqual(expected, actual);
            }
        }
    }
}
