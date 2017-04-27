using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing_simulator
{
    public class EdgeToNeighbor
    {
        private int cost;
        private Node neighbor;

        public EdgeToNeighbor(Node neighbor): this(neighbor, 0) { }

        public EdgeToNeighbor(Node neighbor, int cost)
        {
            this.cost = cost;
            this.neighbor = neighbor;
        }

        public virtual int Cost
        {
            get
            {
                return this.cost;
            }
        }

        public virtual Node Neighbor
        {
            get
            {
                return this.neighbor;
            }
        }
    }
}
