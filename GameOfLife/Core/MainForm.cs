using GameOfLife.Engine;
using GameOfLife.Logic;
using GameOfLife.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife.Core
{
    public partial class MainForm : Form
    {

        private int _width = 100;
        private int _height = 80;
        private int _simulationSpeed = 50; // in milliseconds
        private SimulationEngine _engine;
        private WinFormsRenderer _renderer;
        private RenderSettings _settings;
        private System.Windows.Forms.Timer _timer;

        public MainForm()
        {
            InitializeComponent();

            _settings = new RenderSettings();
            _renderer = new WinFormsRenderer(_settings);

            trackBarZoom.Value = _settings.CellSize;

            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.BackColor = Color.Black;

            var grid = new Grid(100, 80);
            GridInitializer.InitializeGridRandomly(grid, 0.2);

            _engine = new SimulationEngine(grid, new ConwayEvolutionRule());
            _renderer = new WinFormsRenderer(_settings);

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = _simulationSpeed;
            _timer.Tick += (s, e) =>
            {
                _engine.NextGeneration();
                pictureBox1.Invalidate();
            };
            _timer.Start();

            pictureBox1.Paint += (s, e) =>
            {
                _renderer.Render(e.Graphics, _engine.CurrentGrid);
            };
        }

        private void trackBarZoom_Scroll_1(object sender, EventArgs e)
        {
            _settings.CellSize = trackBarZoom.Value;
            pictureBox1.Invalidate();
        }
    }
}
