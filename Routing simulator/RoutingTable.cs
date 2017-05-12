using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing_simulator
{
    public class RoutingTable
    {
        public event EventHandler OnMetricChanged;

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
                foreach (TableEntry myEntry in this.Routes)
                {
                    if (neighborEntry.DestinationNode == myEntry.DestinationNode)
                    {
                        if (myEntry.NextHop == neighborTable.NodeKey && myEntry.Metric != neighborEntry.Metric + 1)
                        {
                            if (neighborEntry.Metric == 16)
                            {
                                myEntry.Metric = 16;

                                IEnumerable<TableEntry> unreachableEntries = this.Routes.Where(x => x.NextHop == myEntry.DestinationNode);
                                foreach(var route in unreachableEntries)
                                {
                                    route.Metric = 16;
                                }
                            }
                            else
                            {
                                myEntry.Metric = neighborEntry.Metric + 1;
                                OnMetricChanged(this, new EventArgs());
                            }
                        }
                        else
                        {
                            if (myEntry.Metric > neighborEntry.Metric + 1)
                            {
                                myEntry.NextHop = neighborTable.NodeKey;
                                myEntry.Metric = neighborEntry.Metric + 1;
                            }
                        }
                    }
                }
                if (!ContainsRoute(this, neighborEntry) && neighborEntry.DestinationNode != this.NodeKey)
                {
                     TableEntry entry = new TableEntry();
                     entry.DestinationNode = neighborEntry.DestinationNode;
                     entry.NextHop = neighborTable.NodeKey;
                     entry.Metric = neighborEntry.Metric + 1;
                     this.Routes.Add(entry);
                }
                if(this.Routes.Any(x => x.DestinationNode == neighborTable.NodeKey))
                {
                    this.Routes.Where(x => x.DestinationNode == neighborTable.NodeKey).First().Metric = 1;
                }
                
            }
        }

        public void UpdateTriggered(TableEntry entry)
        {
            TableEntry en = this.Routes.Where(x => x.DestinationNode == entry.DestinationNode).First();
            if(en.Metric != 16)
            {
                en.Metric = entry.Metric;
                OnMetricChanged(this, new EventArgs());
            }
                
        }

        public void AddRouteToNeighbor(NodeControl node)
        {
            TableEntry entry = new TableEntry
            {
                DestinationNode = node.Key,
                Metric = 1,
                NextHop = node.Key
            };
            IEnumerable<TableEntry> entriesToRemove = this.Routes.Where(x => x.DestinationNode == node.Key);
            if(entriesToRemove != null) this.Routes.Remove(entriesToRemove.FirstOrDefault());
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
