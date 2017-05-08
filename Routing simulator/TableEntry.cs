using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing_simulator
{
    public class TableEntry
    {
        private string _destinationNode;
        private int _metric;
        private string _nextHop;

        public string DestinationNode
        {
            get { return _destinationNode; }
            set
            {
                if (value == _destinationNode)
                    return;
                _destinationNode = value;
            }
            
        }

        public int Metric
        {
            get { return _metric; }
            set
            {
                if (value == _metric)
                    return;
                _metric = value;
            }
        }

        public string NextHop
        {
            get { return _nextHop; }
            set
            {
                if (value == _nextHop)
                    return;
                _nextHop = value;
            }
       }

        public TableEntry()
        {

        }
    }
}
