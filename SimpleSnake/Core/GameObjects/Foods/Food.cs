using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.Core.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private readonly Wall wall;
        private readonly Random random;
        private readonly char foodSymbol;

        protected Food(Wall wall, char foodSymbol, int points)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            FoodPoints = points;
            random = new Random();
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snakeBody)
        {
            while (true)
            {
                LeftX = random.Next(1, wall.LeftX - 1);
                TopY = random.Next(1, wall.TopY - 1);

                bool isPointOfSnake = snakeBody
                    .Any(p => p.LeftX == LeftX && p.TopY == TopY);

                if (!isPointOfSnake)
                {
                    break;
                }
            }

            Console.BackgroundColor = ConsoleColor.Red;
            Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsOnSnakeHead(Point snakeHead) => 
            snakeHead.LeftX == LeftX && snakeHead.TopY == TopY;
    }
}
