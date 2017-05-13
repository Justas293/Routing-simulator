using AwesomeShapeControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Routing_simulator
{
    public class GraphController: UserControl
    {
        public event EventHandler OnRouterClick;

        Panel panel;
        Sender sender;
        Receiver receiver;
        List<EdgeVisual> edgeList;
        List<NodeControl> nodeList;

        private int nodeKey = 1;


        public GraphController(Panel panel, Sender sender, Receiver receiver)
        {
            this.panel = panel;
            this.panel.Paint += Panel_Paint;

            this.sender = sender;
            this.receiver = receiver;

            this.sender.DragDrop += Sender_DragDrop;
            this.receiver.DragDrop += Receiver_DragDrop;

            edgeList = new List<EdgeVisual>();
            nodeList = new List<NodeControl>();
            
        }

        public void SendPacket(string message, string destination)
        {
            this.sender.SendPacketTo(message, destination);
        }

        private void Receiver_DragDrop(object sender, DragEventArgs e)
        {
            NodeControl sourceNode = (NodeControl)e.Data.GetData(typeof(NodeControl));
            EdgeVisual edge = new EdgeVisual(sourceNode, this.receiver);
            try
            {
                this.receiver.ConnectToNode(sourceNode);
                AddEdge(edge);
            }
            catch(InvalidOperationException ex)
            {
                MessageBox.Show("Only one router can be connected to host!");
            }
            
        }

        private void Sender_DragDrop(object sender, DragEventArgs e)
        {
            NodeControl sourceNode = (NodeControl)e.Data.GetData(typeof(NodeControl));
            EdgeVisual edge = new EdgeVisual(sourceNode, this.sender);
            try
            {
                this.sender.ConnectToNode(sourceNode);
                AddEdge(edge);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Only one router can be connected to host!");
            }
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel.CreateGraphics();
            foreach (var edge in edgeList)
            {
                Point p1 = new Point(edge.SourceNode.Location.X + edge.SourceNode.Width / 2, edge.SourceNode.Location.Y + edge.SourceNode.Height / 2);
                Point p2 = new Point(edge.DestinationNode.Location.X + edge.DestinationNode.Width / 2, edge.DestinationNode.Location.Y + edge.DestinationNode.Height / 2);
                g.DrawLine(new Pen(Color.Black, 4.0f), p1, p2);
            }
        }

        public void AddEdge(EdgeVisual edge)
        {
            edgeList.Add(edge);
            edge.SourceNode.AddNeighbor(edge.DestinationNode);
            edge.DestinationNode.AddNeighbor(edge.SourceNode);
            DrawEdges();
        }

        public void RemoveNodeEdges(NodeControl node)
        {
            for(int i = 0; i < edgeList.Count; i++)
            {
                if(edgeList[i].SourceNode == node || edgeList[i].DestinationNode == node)
                {
                    edgeList[i].SourceNode.RemoveNeighbor(edgeList[i].DestinationNode);
                    edgeList[i].DestinationNode.RemoveNeighbor(edgeList[i].SourceNode);
                    edgeList.Remove(edgeList[i]);
                    i--;
                }
            }
            DrawEdges();
        }

        public void DrawEdges()
        {
            panel.Invalidate();
        }

        public void AddRouter(Point point)
        {
            if (nodeList.Count < 15)
            {
                NodeControl nc = new NodeControl();
                nc.Size = new Size(100, 60);
                nc.Location = new Point(point.X - nc.Width / 2, point.Y - nc.Height / 2);

                nc.Text = FindNextNodeKey().ToString();
                nc.MouseClick += NodeControl_MouseClick;
                nc.DragDrop += NodeControl_DragDrop;
                nc.MouseDown += NodeControl_MouseDown;
                nc.LocationChanged += NodeControl_LocationChanged;
                nc.OnEdgeRemove += NodeControl_OnEdgeRemove;
                nc.OnNodeRemove += Nc_OnNodeRemove;
                nc.Disposed += NodeControl_Disposed;
                nc.OnSendUpdate += NodeControl_OnSendUpdate;

                panel.Controls.Add(nc);
                nodeList.Add(nc);

                FindNextNodeKey();
            }
            else MessageBox.Show("Only 15 routers are avaivable in RIPv2!");
        }

        private void NodeControl_OnSendUpdate(object sender, EventArgs e)
        {
            
        }

        private void Nc_OnNodeRemove(object sender, EventArgs e)
        {
            NodeControl node = (NodeControl)sender;
            RemoveNodeEdges(node);
            if(node == this.sender.connectedNode)
            {
                this.sender.DisconnectRouter();
            }
            else if(node == this.receiver.connectedNode)
            {
                this.receiver.DisconnectRouter();
            }
        }

        private int FindNextNodeKey()
        {
            int max = 1;

            if (nodeList.Count() == 0) return 1;

            foreach(var node in nodeList)
            {
                if (int.Parse(node.Key) > max) max = int.Parse(node.Key);
            }
            nodeKey = max + 1;
            return nodeKey;
        }

        private void NodeControl_Disposed(object sender, EventArgs e)
        {
            NodeControl node = (NodeControl)sender;
            nodeList.Remove(node);
        }

        private void NodeControl_OnEdgeRemove(object sender, EventArgs e)
        {
            NodeControl node = (NodeControl)sender;
            RemoveNodeEdges(node);
        }

        private void NodeControl_LocationChanged(object sender, EventArgs e)
        {
            DrawEdges();
        }

        private void NodeControl_MouseDown(object sender, MouseEventArgs e)
        {
            NodeControl node = (NodeControl)sender;
            if (e.Button == MouseButtons.Left)
            {

                if (ModifierKeys == Keys.Shift)
                {
                    DoDragDrop(node, DragDropEffects.Move);
                }
                else
                {
                    node.Pressed = true;
                    node.MouseDownLocation = e.Location;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {

            }
        }

        private void NodeControl_DragDrop(object sender, DragEventArgs e)
        {
            NodeControl sourceNode = (NodeControl)e.Data.GetData(typeof(NodeControl));
            NodeControl destNode = (NodeControl)sender;

            EdgeVisual edge = new EdgeVisual(sourceNode, destNode);
            AddEdge(edge);
        }

        private void NodeControl_MouseClick(object sender, MouseEventArgs e)
        {
            NodeControl node = (NodeControl)sender;

            foreach(NodeControl nd in nodeList)
            {
                nd.Highlighted = false;
            }
            node.Highlighted = true;
            OnRouterClick(node, new EventArgs());
        }

        public void RemoveHighlights()
        {
            foreach(var node in nodeList)
            {
                node.Highlighted = false;                
            }
        }
    }
}
