using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing_simulator
{
    public class Node
    {
        public Point nodeLocation;

        private string IPAddress { get; set; }
        private string Type { get; set; }
        private RoutingTable Table { get; set; }



        public Node(string type, string ipAddress, Point loc)
        {
            this.IPAddress = ipAddress;
            this.Type = type;
            this.nodeLocation = loc;
        }
    }
}
