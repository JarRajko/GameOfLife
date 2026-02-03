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

            _engine = new SimulationEngine(grid, new MultiColorRule());
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

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X / _settings.CellSize;
            int y = e.Y / _settings.CellSize;

            if (e.Button == MouseButtons.Left)
            {
                _engine.CurrentGrid.SetCell(x, y, new Cell(true, Color.DodgerBlue));
            }
            else if (e.Button == MouseButtons.Right)
            {
                _engine.CurrentGrid.SetCell(x, y, new Cell(true, Color.Crimson));
            }

            pictureBox1.Invalidate();
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (_timer.Enabled)
            {
                _timer.Stop();
                btnStartStop.Text = "Start";
                btnStartStop.BackColor = Color.LightGreen;
            }
            else
            {
                _timer.Start();
                btnStartStop.Text = "Stop";
                btnStartStop.BackColor = Color.LightCoral;
            }
        }
    }
}
