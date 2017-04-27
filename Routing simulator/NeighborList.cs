using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing_simulator
{
    public class NeighborList: CollectionBase
    {
        protected internal virtual void Add(EdgeToNeighbor e)
        {
            base.InnerList.Add(e);
        }

        public virtual EdgeToNeighbor this[int index]
        {
            get { return (EdgeToNeighbor)base.InnerList[index]; }
            set { base.InnerList[index] = value; }
        }
    }
}
