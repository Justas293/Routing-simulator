using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing_simulator
{
    public class NodeList : IEnumerable
    {
        private Hashtable data = new Hashtable();

        public virtual void Add(Node n)
        {
            data.Add(n.Key, n);
        }

        public virtual void Remove(Node n)
        {
            data.Remove(n.Key);
        }

        public virtual bool ContainsKey(string key)
        {
            return data.ContainsKey(key);
        }

        public virtual void Clear()
        {
            data.Clear();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public virtual Node this[string key]
        {
            get
            {
                return (Node)data[key];
            }
        }

       
    }
}
