using GameOfLife.Core;
using GameOfLife.Logic;
using System;
using System.Collections.Generic;

namespace GameOfLife.Engine
{
    public class SimulationEngine
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
            for (int x = 0; x < _mainGrid.Width; x++)
            {
                for (int y = 0; y < _mainGrid.Height; y++)
                {
                    Cell currentCell = _mainGrid.GetCell(x, y);
                    List<Cell> neighbors = _mainGrid.GetNeighbors(x, y);

                    Cell nextCell = _rule.GetNextState(currentCell, neighbors);

                    _bufferedGrid.SetCell(x, y, nextCell);
                }
            }

            Grid temp = _mainGrid;
            _mainGrid = _bufferedGrid;
            _bufferedGrid = temp;
        }

        public Grid CurrentGrid => _mainGrid;
    }
}