using GameOfLife.Engine;
using GameOfLife.Logic;
using GameOfLife.Rendering;

namespace GameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = 40;
            int height = 20;

            Grid myGrid = new Grid(width, height);
            GridInitializer initializer = new GridInitializer(myGrid);
            IEvolutionRule rule = new ConwayEvolutionRule();
            SimulationEngine engine = new SimulationEngine(myGrid, rule);
            ConsoleRenderer renderer = new ConsoleRenderer();

            initializer.InitializeGridRandomly(0.3);
            Console.CursorVisible = false;

            while (true)
            {
                renderer.Render(engine.CurrentGrid);
                engine.NextGeneration();
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
