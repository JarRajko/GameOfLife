using GameOfLife.Core;
using GameOfLife.Engine;
using GameOfLife.Rendering;

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
                if (grid.GetCellState(x, y) == CellState.Alive)
                {
                    g.FillRectangle(Brushes.LimeGreen,
                        x * _settings.CellSize,
                        y * _settings.CellSize,
                        _settings.CellSize - 1,
                        _settings.CellSize - 1);
                }
            }
        }
    }
}