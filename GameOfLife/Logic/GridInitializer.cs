using GameOfLife.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Logic
{
    internal class GridInitializer
    {
        private Grid grid;
        public GridInitializer(Grid grid) 
        {
            this.grid = grid;
        }

        public void InitializeGridRandomly(double aliveProbability)
        {
            Random rand = new Random();
            int width = grid.Width;
            int height = grid.Height;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (rand.NextDouble() < aliveProbability)
                    {
                        grid.SetCellState(x, y, Core.CellState.Alive);
                    }
                    else
                    {
                        grid.SetCellState(x, y, Core.CellState.Dead);
                    }
                }
            }
        }
    }
}
