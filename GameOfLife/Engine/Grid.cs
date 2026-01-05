using GameOfLife.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Engine
{
    internal class Grid
    {
        public int Width { get; }
        public int Height { get; }
        private CellState[,] Cells;

        public Grid(int width, int height) 
        {
            this.Width = width;
            this.Height = height;

            Cells = new CellState[width, height];
        }

        public CellState GetCellState(int x, int y)
        {
            return Cells[x, y];
        }

        public void SetCellState(int x, int y, CellState state)
        {
            Cells[x, y] = state;
        }

        public int CountLivingNeighbours(int x, int y)
        {
            int liveCount = 0;
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0) continue; // Skip the cell itself
                    int neighborX = x + dx;
                    int neighborY = y + dy;
                    // Check bounds
                    if (neighborX >= 0 && neighborX < Width && neighborY >= 0 && neighborY < Height)
                    {
                        if (Cells[neighborX, neighborY] == CellState.Alive)
                        {
                            liveCount++;
                        }
                    }
                }
            }
            return liveCount;
        }
    }
}
