using GameOfLife.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Logic
{
    internal interface IEvolutionRule
    {

        CellState GetNextState(CellState currentState, int liveNeighbors);

    }
}
