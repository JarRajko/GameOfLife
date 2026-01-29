using GameOfLife.Core;
using GameOfLife.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Logic
{
    public class GridInitializer
    {
        private Grid grid;
        public GridInitializer(Grid grid) 
        {
            this.grid = grid;
        }

        public static void InitializeGridRandomly(Grid grid, double aliveProbability)
        {
            Random rand = new Random();
            for (int x = 0; x < grid.Width; x++)
            {
                for (int y = 0; y < grid.Height; y++)
                {
                    var state = rand.NextDouble() < aliveProbability ? CellState.Alive : CellState.Dead;
                    grid.SetCellState(x, y, state);
                }
            }
        }
    }
}
