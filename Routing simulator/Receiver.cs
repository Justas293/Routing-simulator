using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Routing_simulator
{
    public class Receiver : NodeControl
    {
        ContextMenu mnuContextMenu;
        public NodeControl connectedNode;
        Image image;

        public Receiver()
        {
            AddContextMenu();
            image = Routing_simulator.Properties.Resources.host2Image;
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

        public void DisconnectRouter()
        {
            connectedNode = null;
            this.RoutingTable.Routes.Clear();
        }

        public void ConnectToNode(NodeControl node)
        {
            if (connectedNode != null)
            {
                throw new InvalidOperationException("Node is already connected!");
            }
            else
            {
                connectedNode = node;
            }
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            drgevent.Effect = DragDropEffects.Move;
        }

        public override void SendUpdates()
        {

        }
    }
}
