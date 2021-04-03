using SimpleSnake.Core.GameObjects;
using SimpleSnake.Core.GameObjects.Foods;
using System.Collections.Generic;
using SimpleSnake.Utilities;
using SimpleSnake.Core;

namespace SimpleSnake
{
    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(80,40);

            Snake snake = new Snake(wall);

            Engine engine = new Engine(wall, snake);
            engine.Run();
        }
    }
}
