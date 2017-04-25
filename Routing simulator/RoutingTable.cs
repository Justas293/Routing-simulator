using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing_simulator
{
    public class RoutingTable
    {
        private List<string> DestinationIP { get; set; }
        private List<string> NetMask { get; set; }
        private List<string> NextHopIP { get; set; }
        private List<int> DistanceMetric { get; set; }
        private List<Node> NeighborNodes;

        public RoutingTable()
        {

        }

    }
}
