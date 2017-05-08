using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Routing_simulator
{
    public class Node
    {
        public string Key { get; set; }
        public NeighborList neighbors;


        public Point nodeLocation;

        private string IPAddress { get; set; }
        private string Type { get; set; }
        public RoutingTable Table;

        public Node()
        {
            Table = new RoutingTable(this.Key);
            neighbors = new NeighborList();
        }

        public void UpdateLocation(Point loc)
        {
                      
        }

        protected internal virtual void AddDirected(Node n)
        {
            AddDirected(new EdgeToNeighbor(n));
        }

        protected internal virtual void AddDirected(Node n, int cost)
        {
            AddDirected(new EdgeToNeighbor(n, cost));
        }

        protected internal virtual void AddDirected(EdgeToNeighbor e)
        {
            neighbors.Add(e);
        }

        public void SendUpdates()
        {
            foreach(Node neighbor in neighbors)
            {
                neighbor.Table.Update(this.Table);
            }
        }

        
    }
}
