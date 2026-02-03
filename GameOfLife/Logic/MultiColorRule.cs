using GameOfLife.Logic;

public class MultiColorRule : IEvolutionRule
{
    public Cell GetNextState(Cell currentCell, List<Cell> neighbors)
    {
        int aliveCount = neighbors.Count(n => n.IsAlive);

        if (currentCell.IsAlive)
        {
            bool staysAlive = aliveCount == 2 || aliveCount == 3;
            return new Cell(staysAlive, currentCell.Color, currentCell.Species);
        }
        else
        {
            if (aliveCount == 3)
            {
                var dominantColor = neighbors
                    .Where(n => n.IsAlive)
                    .GroupBy(n => n.Color)
                    .OrderByDescending(g => g.Count())
                    .First().Key;

                return new Cell(true, dominantColor);
            }
        }
        return new Cell(false, Color.Black);
    }
}