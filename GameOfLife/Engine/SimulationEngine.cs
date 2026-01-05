using GameOfLife.Core;
using GameOfLife.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Engine
{
    internal class SimulationEngine
    {
        private Grid _mainGrid;
        private Grid _bufferedGrid;
        private readonly IEvolutionRule _rule;
        public SimulationEngine(Grid grid, IEvolutionRule rule)
        {
            _mainGrid = grid;
            _rule = rule;

            _bufferedGrid = new Grid(grid.Width, grid.Height);
        }

        public void NextGeneration()
        {
            int width = _mainGrid.Width;
            int height = _mainGrid.Height;
            
            for (int x = 0; x < _mainGrid.Width; x++)
            {
                for (int y = 0; y < _mainGrid.Height; y++)
                {
                    int neighbors = _mainGrid.CountLivingNeighbours(x, y);
                    CellState currentState = _mainGrid.GetCellState(x, y);
                    CellState nextState = _rule.GetNextState(currentState, neighbors);
                    _bufferedGrid.SetCellState(x,y,nextState);
                }
            }

            Grid temp = _mainGrid;
            _mainGrid = _bufferedGrid;
            _bufferedGrid = temp;

        }

        public Grid CurrentGrid => _mainGrid;

    }
}
