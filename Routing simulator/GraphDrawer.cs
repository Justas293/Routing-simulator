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
        Panel panel;
        List<EdgeVisual> edgeList;
        List<NodeControl> nodeList;

        public GraphDrawer(Panel panel)
        {
            this.panel = panel;
            this.panel.Paint += Panel_Paint;
            edgeList = new List<EdgeVisual>();
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel.CreateGraphics();
            foreach (var edge in edgeList)
            {
                Point p1 = new Point(edge.SourceNode.Location.X + edge.SourceNode.Width / 2, edge.SourceNode.Location.Y + edge.SourceNode.Height / 2);
                Point p2 = new Point(edge.DestinationNode.Location.X + edge.DestinationNode.Width / 2, edge.DestinationNode.Location.Y + edge.DestinationNode.Height / 2);
                g.DrawLine(new Pen(Color.Black, 2.0f), p1, p2);
            }
        }

        public void DrawNode(Node node)
        {
            
        }

        public void AddEdge(EdgeVisual edge)
        {
            edgeList.Add(edge);
            DrawEdges();
        }

        public void RemoveNodeEdges(NodeControl node)
        {
            for(int i = 0; i < edgeList.Count; i++)
            {
                if(edgeList[i].SourceNode == node || edgeList[i].DestinationNode == node)
                {
                    edgeList.Remove(edgeList[i]);
                }
            }
            DrawEdges();
        }

        public void DrawEdges()
        {
            panel.Invalidate();
        }

        
    }
}
