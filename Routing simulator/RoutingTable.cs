using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing_simulator
{
    public class RoutingTable
    {
        public List<TableEntry> Routes;
        public string NodeKey;

        public RoutingTable(string key)
        {
            Routes = new List<TableEntry>();
            NodeKey = key;
        }

        public void Update(RoutingTable neighborTable)
        {
            foreach(TableEntry neighborEntry in neighborTable.Routes)
            {
                foreach(TableEntry myEntry in this.Routes)
                {
                    if(neighborEntry.DestinationNode == myEntry.DestinationNode)
                    {
                        int newMetric = Min(myEntry.Metric, neighborEntry.Metric + 1);
                        myEntry.Metric = newMetric;
                        myEntry.NextHop = neighborTable.NodeKey;
                    }
                }
                if(!ContainsRoute(this, neighborEntry))
                {
                    TableEntry entry = new TableEntry();
                    entry.DestinationNode = neighborEntry.DestinationNode;
                    entry.NextHop = neighborTable.NodeKey;
                    entry.Metric = neighborEntry.Metric + 1;
                    this.Routes.Add(entry);
                }
            }
        }


        public TableEntry GetBestRoute()
        {
            TableEntry bestRoute = null;

            return bestRoute;
        }

        public void AddRouteToNeighbor(Node node)
        {
            TableEntry entry = new TableEntry
            {
                DestinationNode = node.Key,
                Metric = 1,
                NextHop = node.Key
            };
            this.Routes.Add(entry);
        }

        private int Min(int a, int b)
        {
            if (a > b)
            {
                return b;
            }
            else return a;
        }

        private bool ContainsRoute(RoutingTable table, TableEntry route)
        {
            foreach (var entry in table.Routes)
            {
                if (entry.DestinationNode == route.DestinationNode) return true;
            }

            return false;
        }

    }
}
