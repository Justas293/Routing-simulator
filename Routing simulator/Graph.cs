using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing_simulator
{
    public class Graph
    {
        private NodeList nodes;

        public Graph()
        {
            this.nodes = new NodeList();
        }

        public virtual Node AddNode(string key)
        {
            if (!nodes.ContainsKey(key))
            {
                Node n = new Node();
                nodes.Add(n);
                return n;
            }
            else
                throw new ArgumentException("There already exists a node in the graph with key " + key);
        }

        public virtual void AddNode(Node n)
        {
            if (!nodes.ContainsKey(n.Key))
            {
                nodes.Add(n);
            }
            else
                throw new ArgumentException("There already exists a node in the graph with key " + n.Key);
        }

        public virtual void AddDirectedEdge(string aKey, string bKey)
        {
            AddDirectedEdge(aKey, bKey, 0);
        }

        public virtual void AddDirectedEdge(string aKey, string bKey, int cost)
        {
            if (nodes.ContainsKey(aKey) && nodes.ContainsKey(bKey))
            {
                AddDirectedEdge(nodes[aKey], nodes[bKey], cost);
            }
        }

        public virtual void AddDirectedEdge(Node a, Node b)
        {
            AddDirectedEdge(a, b, 0);
        }

        public virtual void AddDirectedEdge(Node a, Node b, int cost)
        {
            if(nodes.ContainsKey(a.Key) && nodes.ContainsKey(b.Key))
            {
                a.AddDirected(b, cost);
            }
            else
                throw new ArgumentException("One or both of the nodes supplied were not members of the graph.");
        }

        public virtual void AddUndirectedEdge(string aKey, string bKey)
        {
            AddUndirectedEdge(aKey, bKey, 0);
        }

        public virtual void AddUndirectedEdge(string aKey, string bKey, int cost)
        {
            if(nodes.ContainsKey(aKey) && nodes.ContainsKey(bKey))
            {
                AddUndirectedEdge(nodes[aKey], nodes[bKey], cost);
            }
            else
                throw new ArgumentException("One or both of the nodes supplied were not members of the graph.");
        }

        public virtual void AddUndirectedEdge(Node a, Node b)
        {
            AddUndirectedEdge(a, b, 0);
        }

        public virtual void AddUndirectedEdge(Node a, Node b, int cost)
        {
            if(nodes.ContainsKey(a.Key) && nodes.ContainsKey(b.Key))
            {
                a.AddDirected(b, cost);
                b.AddDirected(a, cost);
            }
            else
                throw new ArgumentException("One or both of the nodes supplied were not members of the graph.");
        }

        public virtual bool Contains(Node n)
        {
            return Contains(n.Key);
        }

        public virtual bool Contains(string key)
        {
            return nodes.ContainsKey(key);
        }

        public virtual NodeList Nodes
        {
            get
            {
                return this.nodes;
            }
        }
    }
}
