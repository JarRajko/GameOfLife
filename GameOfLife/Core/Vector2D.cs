using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Core
{
    public readonly struct Vector2D
    {
        public int X { get; }
        public int Y { get; }

        public Vector2D(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}