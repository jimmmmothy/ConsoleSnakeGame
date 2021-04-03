using SimpleSnake.Core.GameObjects;
using SimpleSnake.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Point[] pointsOfDirection;
        private Direction direction;
        private Wall wall;
        private Snake snake;
        private double sleepTime;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            pointsOfDirection = new Point[4];
            direction = Direction.Down;
            sleepTime = 100;
        }

        public void Run()
        {
            CreateDirections();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = snake.IsMoving(pointsOfDirection[(int)direction]);

                if (!isMoving)
                {
                    AskUserForRestart();
                }

                sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
            }
        }

        private void CreateDirections()
        {
            pointsOfDirection[0] = new Point(1, 0); //Right
            pointsOfDirection[1] = new Point(-1, 0); //Left
            pointsOfDirection[2] = new Point(0, 1); //Down
            pointsOfDirection[3] = new Point(0, -1); //Up
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            switch (userInput.Key)
            {
                case ConsoleKey.DownArrow:
                    if (direction != Direction.Up)
                    {
                        direction = Direction.Down;
                    }

                    break;
                case ConsoleKey.LeftArrow:
                    if (direction != Direction.Right)
                    {
                        direction = Direction.Left;
                    }

                    break;
                case ConsoleKey.UpArrow:
                    if (direction != Direction.Down)
                    {
                        direction = Direction.Up;
                    }

                    break;
                case ConsoleKey.RightArrow:
                    if (direction != Direction.Left)
                    {
                        direction = Direction.Right;
                    }

                    break;
                default:
                    break;
            }

            Console.CursorVisible = false;
        }

        private void AskUserForRestart()
        {
            int leftX = wall.LeftX + 3;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n");
            Console.SetCursorPosition(leftX, topY + 1);

            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game over!");
            Environment.Exit(0);
        }
    }
}
