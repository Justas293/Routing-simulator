using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Routing_simulator
{
    public class GraphDrawer
    {
        Graphics graphics;
        Pen pen;
        SolidBrush brush;
        Image image;
        Rectangle rec;

        public GraphDrawer(Panel panel)
        {
            graphics = panel.CreateGraphics();
            pen = new Pen(Color.Red);
            brush = new SolidBrush(Color.Red);
            image = Routing_simulator.Properties.Resources.RouterImage;
        }

        public void DrawNode(Node node)
        {
            Rectangle rec = new Rectangle(node.nodeLocation, new Size(40, 40));

            graphics.DrawImage(image, rec);
        }

        public void UpdateNodePosition(Node node)
        {
            rec.X = node.nodeLocation.X;
            rec.Y = node.nodeLocation.Y;
        }

    }
}
