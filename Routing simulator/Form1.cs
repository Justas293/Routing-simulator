using AwesomeShapeControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Routing_simulator
{
    public partial class Form1 :Form
    {
        Point point;
        Graphics graphics;
        GraphController graphController;

        public bool ShiftDown = false;
        public bool drawingEdge = false;
        
        public Form1()
        {
            InitializeComponent();           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            graphics = graphPanel.CreateGraphics();
            point = new Point(0, 0);
            graphController = new GraphController(graphPanel);
        }

        private void graphPanel_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void toolStripMenuRouter_Click(object sender, EventArgs e)
        {
            graphController.AddRouter(point);
        }
        
        private void graphPanel_MouseMove(object sender, MouseEventArgs e)
        {
            point = e.Location;
            
        }

        private void graphPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            graphController.RemoveHighlights();
        }
    }
}
