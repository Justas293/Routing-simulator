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

        public RoutingTable()
        {
            Routes = new List<TableEntry>();
        }

        public void Update(List<TableEntry> neighborTable)
        {

        }

        public void TriggeredUpdate(TableEntry entry)
        {

        }

        public TableEntry GetBestRoute()
        {
            TableEntry bestRoute = null;

            return bestRoute;
        }

    }
}
