using System;
using System.Drawing;
using GameOfLife.Core;

namespace GameOfLife.Engine
{
    public class GridInitializer
    {
        public static void InitializeGridRandomly(Grid grid, double aliveProbability)
        {
            Random rand = new Random();

            for (int x = 0; x < grid.Width; x++)
            {
                for (int y = 0; y < grid.Height; y++)
                {
                    bool isAlive = rand.NextDouble() < aliveProbability;

                    if (isAlive)
                    {
                        Color teamColor = rand.Next(2) == 0 ? Color.DodgerBlue : Color.Crimson;
                        grid.SetCell(x, y, new Cell(true, teamColor));
                    }
                    else
                    {
                        grid.SetCell(x, y, new Cell(false, Color.Black));
                    }
                }
            }
        }
    }
}