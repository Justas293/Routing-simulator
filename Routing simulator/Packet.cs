using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing_simulator
{
    public class Packet
    {
        public string message;
        public string destination;

        public Packet(string message, string destination)
        {
            this.message = message;
            this.destination = destination; 
        }
    }
}
