using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.Core.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';

        public Wall(int leftX, int topY)
            : base(leftX, topY)
        {
            InitializeWallBorders();
        }

        public bool IsPointOfWall(Point snakeHead)
        {
            return snakeHead.TopY == 0 ||
                   snakeHead.LeftX == 0 ||
                   snakeHead.TopY == TopY ||
                   snakeHead.LeftX == LeftX;
        }

        private void InitializeWallBorders()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(TopY);

            SetVerticalLine(0);
            SetVerticalLine(LeftX);
        }

        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX <= LeftX; leftX++)
            {
                Draw(leftX, topY, wallSymbol);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY <= TopY; topY++)
            {
                Draw(leftX, topY, wallSymbol);
            }
        }
    }
}
