using GameOfLife.Core;
using GameOfLife.Engine;
using GameOfLife.Logic;
using GameOfLife.Rendering;

namespace GameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {         
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

        }
    }
}
