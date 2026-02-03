using System.Drawing;
using GameOfLife.Engine;
using GameOfLife.Core;

namespace GameOfLife.Rendering
{
    public class WinFormsRenderer
    {
        private readonly RenderSettings _settings;

        public WinFormsRenderer(RenderSettings settings)
        {
            _settings = settings;
        }

        public void Render(Graphics g, Grid grid)
        {
            g.Clear(Color.FromArgb(30, 30, 30));

            for (int y = 0; y < grid.Height; y++)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    Cell cell = grid.GetCell(x, y);

                    if (cell.IsAlive)
                    {
                        using (Brush cellBrush = new SolidBrush(cell.Color))
                        {
                            g.FillRectangle(cellBrush,
                                x * _settings.CellSize,
                                y * _settings.CellSize,
                                _settings.CellSize - 1,
                                _settings.CellSize - 1);
                        }
                    }
                }
            }
        }
    }
}