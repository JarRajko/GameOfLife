using GameOfLife.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Rendering
{
    internal class ConsoleRenderer
    {
        private readonly char aliveChar = '■';
        private readonly char deadChar = ' ';

        public void Render(Grid grid)
        {
            Console.SetCursorPosition(0, 0);

            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < grid.Height; y++)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    var cellState = grid.GetCellState(x, y);
                    sb.Append(cellState == Core.CellState.Alive ? aliveChar : deadChar);
                    sb.Append(' ');
                }
                sb.AppendLine();
            }
            Console.Write(sb.ToString());
        }
    }
}
