using SimpleSnake.Core.GameObjects.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.Core.GameObjects
{
    public class Snake
    {
        private Queue<Point> snakeBody;
        private readonly Food[] food;
        private readonly Wall wall;
        private const char snakeSymbol = '\u25CF';
        private const char emptySpace = ' ';

        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;

        public Snake(Wall wall)
        {
            this.wall = wall;
            snakeBody = new Queue<Point>();
            food = new Food[3];
            foodIndex = RandomFoodNumber;
            GetFoods();
            CreateSnake();
            GenerateFood();
        }

        public int LeftX { get; private set; }
        public int TopY { get; private set; }
        private int RandomFoodNumber => new Random().Next(0, food.Length);

        public bool IsMoving(Point direction)
        {
            Point currSnakeHead = snakeBody.Last();

            GetNextPoint(direction, currSnakeHead);

            bool isPointOfSnake = snakeBody
                .Any(p => p.LeftX == nextLeftX && p.TopY == nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point newSnakeHead = new Point(nextLeftX, nextTopY);

            if (wall.IsPointOfWall(newSnakeHead))
            {
                return false;
            }

            snakeBody.Enqueue(newSnakeHead);
            Console.BackgroundColor = ConsoleColor.Green;
            newSnakeHead.Draw(snakeSymbol);
            Console.BackgroundColor = ConsoleColor.White;

            Point snakeTail = snakeBody.Dequeue();
            snakeTail.Draw(emptySpace);

            if (food[foodIndex].IsOnSnakeHead(newSnakeHead))
            {
                Eat(direction, currSnakeHead);
            }

            return true;
        }

        private void Eat(Point direction, Point currSnakeHead)
        {
            int length = food[foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                snakeBody.Enqueue(new Point(nextLeftX, nextTopY));

                GetNextPoint(direction, currSnakeHead);
            }

            GenerateFood();
        }

        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                Point currSnakePoint = new Point(1, topY);
                snakeBody.Enqueue(currSnakePoint);

                Console.BackgroundColor = ConsoleColor.Green;
                currSnakePoint.Draw(snakeSymbol);
                Console.BackgroundColor = ConsoleColor.White;
            }
        }

        private void GetFoods()
        {
            food[0] = new FoodDollar(wall);
            food[1] = new FoodAsterisk(wall);
            food[2] = new FoodHashtag(wall);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            nextLeftX = snakeHead.LeftX + direction.LeftX;
            nextTopY = snakeHead.TopY + direction.TopY;
        }

        private void GenerateFood()
        {
            foodIndex = RandomFoodNumber;
            food[foodIndex].SetRandomPosition(snakeBody);
        }
    }
}
