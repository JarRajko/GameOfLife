using GameOfLife.Core;
using System.Collections.Generic;
using System.Drawing;

namespace GameOfLife.Engine
{
    public class Grid
    {
        private Cell[,] _cells;
        public int Width { get; }
        public int Height { get; }

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            _cells = new Cell[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    _cells[x, y] = new Cell(false, Color.Black);
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
                return _cells[x, y];

            return new Cell(false, Color.Black);
        }

        public void SetCell(int x, int y, Cell cell)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                _cells[x, y] = cell;
            }
        }

        public List<Cell> GetNeighbors(int x, int y)
        {
            List<Cell> neighbors = new List<Cell>();

            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0) continue;

                    int nx = x + dx;
                    int ny = y + dy;

                    if (nx >= 0 && nx < Width && ny >= 0 && ny < Height)
                    {
                        neighbors.Add(_cells[nx, ny]);
                    }
                }
            }

            return neighbors;
        }

        public void Clear()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    _cells[x, y] = new Cell(false, Color.Black);
                }
            }
        }
    }
}