using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Routing_simulator
{
    public class EdgeVisual
    {
        private Point startPoint;
        private Point destinationPoint;

        public NodeControl SourceNode;
        public NodeControl DestinationNode;

        public EdgeVisual(NodeControl source, NodeControl dest)
        {
            SetNodes(source, dest);
        }

        public void UpdatePoints(Point source, Point dest)
        {
            startPoint = source;
            destinationPoint = dest;
        }

        public void SetNodes(NodeControl source, NodeControl dest)
        {
            SourceNode = source;
            DestinationNode = dest;
            startPoint = source.Location;
            destinationPoint = dest.Location;
        }

    }
}
