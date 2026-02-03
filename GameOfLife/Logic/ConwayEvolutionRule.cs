using GameOfLife.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Logic
{
    public class ConwayEvolutionRule : IEvolutionRule
    {
        public Cell GetNextState(Cell currentCell, List<Cell> neighbors)
        {
            int aliveCount = neighbors.Count(n => n.IsAlive);

            if (currentCell.IsAlive)
            {
                bool staysAlive = (aliveCount == 2 || aliveCount == 3);
                return new Cell(staysAlive, currentCell.Color);
            }
            else
            {
                bool becomesAlive = (aliveCount == 3);
                return new Cell(becomesAlive, becomesAlive ? Color.LimeGreen : Color.Black);
            }
        }
    }
}
