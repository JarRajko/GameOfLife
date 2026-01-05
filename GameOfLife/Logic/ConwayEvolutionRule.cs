using GameOfLife.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Logic
{
    internal class ConwayEvolutionRule : IEvolutionRule
    {
        public CellState GetNextState(CellState currentState, int liveNeighbors)
        {
            if (currentState == CellState.Alive)
            {
                if (liveNeighbors < 2 || liveNeighbors > 3) return CellState.Dead; // Underpopulation or Overpopulation
                
                else return CellState.Alive; // Survival
                
            }
            else // currentState == CellState.Dead
            {
                if (liveNeighbors == 3) return CellState.Alive; // Reproduction
                
                else return CellState.Dead; // Remains dead
                
            }
        }
    }
}
