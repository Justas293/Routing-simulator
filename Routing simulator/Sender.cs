using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Routing_simulator
{
    public class Sender : NodeControl
    {
        public NodeControl connectedNode;
        ContextMenu mnuContextMenu;
        Image image;

        public Sender()
        {
            AddContextMenu();
            image = Routing_simulator.Properties.Resources.hostImage;
        }

        public void ConnectToNode(NodeControl node)
        {
            if(connectedNode != null)
            {
                throw new InvalidOperationException("Node is already connected!");
            }
            else
            {
                connectedNode = node;
            }
        }

        public void DisconnectRouter()
        {
            connectedNode = null;
            this.RoutingTable.Routes.Clear();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics gfx = pe.Graphics;
            Rectangle rec = ClientRectangle;
            rec.Size = new Size(80, 80);

            gfx.DrawImage(image, rec);
        }

        public override void AddContextMenu()
        {
            
        }

        private void MenuDisconnectRouter(object sender, EventArgs e)
        {
            DisconnectRouter();
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            drgevent.Effect = DragDropEffects.Move;
        }

        public void SendPacketTo(string message, string destination)
        {
            Packet packet = new Packet(message, destination);
            if (connectedNode != null && !connectedNode.Disabled) connectedNode.SendPacket(packet);
        }

        public override void SendUpdates()
        {
            
        }
    }
}
