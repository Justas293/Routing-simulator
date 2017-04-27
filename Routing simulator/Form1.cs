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
        Node node;

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
            if(e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show();
            }
            else if (e.Button == MouseButtons.Left)
            {
                contextMenuStrip1.Hide();
                
            }
        }


        private void toolStripMenuRouter_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Hide();
            
        }

        private void graphPanel_MouseMove(object sender, MouseEventArgs e)
        {
            point = e.Location;
            
        }

        private void graphPanel_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void graphPanel_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void rectangle_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("opaa");
        }

        
    }
}
