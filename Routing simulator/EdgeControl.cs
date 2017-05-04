using AwesomeShapeControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Routing_simulator
{
    public partial class EdgeControl : Line
    {
        private NodeControl _sourceNode;
        public NodeControl SourceNode
        {
            get { return _sourceNode; }
            set
            {
                if (value == _sourceNode)
                    return;
                _sourceNode = value;
                Point p = new Point(value.Location.X + 45, value.Location.Y + 30);
                StartPoint = p;
                _sourceNode.LocationChanged += sourceNode_LocationChanged;
            }
        }


        private NodeControl _destinationNode;
        public NodeControl DestinationNode
        {
            get { return _destinationNode; }
            set
            {
                if (value == _destinationNode)
                    return;
                _destinationNode = value;
                Point p = new Point(value.Location.X + 45, value.Location.Y + 30);
                EndPoint = p;
                _destinationNode.LocationChanged += destinationNode_LocationChanged;
            }
        }

       

        public EdgeControl()
        {
            InitializeComponent();
        }


        private void sourceNode_LocationChanged(object sender, EventArgs e)
        {
            NodeControl node = (NodeControl)sender;
            if(node != null)
            {
                Point p = new Point(node.Location.X + 45, node.Location.Y + 30);
                StartPoint = p;
            }
        }

        private void destinationNode_LocationChanged(object sender, EventArgs e)
        {
            NodeControl node = (NodeControl)sender;
            if (node != null)
            {
                Point p = new Point(node.Location.X + 45, node.Location.Y + 30);
                EndPoint = p;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void AddContextMenu()
        {
            ContextMenu mnuContextMenu = new ContextMenu();
            mnuContextMenu.MenuItems.Add("Remove edge", new EventHandler(RemoveEdge));
            this.ContextMenu = mnuContextMenu;
            this.ContextMenu = mnuContextMenu;
        }

        private void RemoveEdge(object sender, EventArgs e)
        {

            base.Dispose();
            
        }

    }
}
