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
            graphController = new GraphController(graphPanel, this.sender, this.receiver);
            graphController.OnRouterClick += GraphController_OnRouterClick;
            graphController.OnNodeTableUpdate += GraphController_OnNodeTableUpdate;
        }

        private void GraphController_OnNodeTableUpdate(object sender, EventArgs e)
        {
            NodeControl node = (NodeControl)sender;
            if (node.Highlighted)
            {
                RoutingTableView.DataSource = null;
                RoutingTableView.DataSource = node.RoutingTable.Routes;
            }
        }

        private void GraphController_OnRouterClick(object sender, EventArgs e)
        {
            RoutingTableView.DataSource = null;
            NodeControl node = (NodeControl)sender;
            RoutingTableView.DataSource = node.RoutingTable.Routes;
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

            graphController.SendPacket(this.textBoxMessage.Text, this.textBoxReceiver.Text);
        }

    }
}
