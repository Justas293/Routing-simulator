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
        GraphDrawer graphDrawer;

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
            graphDrawer = new GraphDrawer(graphPanel);
        }

        private void graphPanel_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void toolStripMenuRouter_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Hide();
            NodeControl nc = new NodeControl();
            nc.Size = new Size(100, 60);
            nc.Location = new Point(point.X - nc.Width / 2, point.Y - nc.Height / 2);
            
            nc.Text = "1";
            nc.MouseClick += NodeControl_MouseClick;
            nc.DragDrop += NodeControl_DragDrop;
            nc.MouseDown += NodeControl_MouseDown;
            nc.LocationChanged += NodeControl_LocationChanged;
            nc.OnEdgeRemove += NodeControl_OnEdgeRemove;
            
            graphPanel.Controls.Add(nc);
        }

        private void NodeControl_OnEdgeRemove(object sender, EventArgs e)
        {
            NodeControl node = (NodeControl)sender;
            graphDrawer.RemoveNodeEdges(node);
        }

        private void NodeControl_LocationChanged(object sender, EventArgs e)
        {
            graphDrawer.DrawEdges();
        }

        private void NodeControl_DragDrop(object sender, DragEventArgs e)
        {
            
            NodeControl sourceNode = (NodeControl)e.Data.GetData(typeof(NodeControl));
            NodeControl destNode = (NodeControl)sender;

            EdgeVisual edge = new EdgeVisual(sourceNode, destNode);
            graphDrawer.AddEdge(edge);

        }


        private void NodeControl_MouseClick(object sender, MouseEventArgs e)
        {
            NodeControl node = (NodeControl)sender;
            node.Highlighted = true;
        }

        private void NodeControl_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void NodeControl_MouseDown(object sender, MouseEventArgs e)
        {
            NodeControl node = (NodeControl)sender;
            if (e.Button == MouseButtons.Left)
            {

                if(ModifierKeys == Keys.Shift)
                {
                    DoDragDrop(node, DragDropEffects.Move);
                }
                else
                {
                    node.Pressed = true;
                    node.MouseDownLocation = e.Location;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                
            }
        }

        private void graphPanel_MouseMove(object sender, MouseEventArgs e)
        {
            point = e.Location;
            if (drawingEdge) graphPanel.Invalidate();
        }

        private void graphPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }



    }
}
