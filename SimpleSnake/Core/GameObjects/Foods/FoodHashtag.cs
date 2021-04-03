using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.Core.GameObjects.Foods
{
    public class FoodHashtag : Food
    {
        private const char foodSymbol = '#';
        private const int points = 3;

        public FoodHashtag(Wall wall) 
            : base(wall, foodSymbol, points)
        {
        }
    }
}
