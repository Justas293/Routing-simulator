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
    public partial class NodeControl : Control
    {
        public string Key;

        public event EventHandler OnEdgeRemove;
        public event EventHandler OnNodeRemove;
        public event EventHandler OnSendUpdate;

        private List<NodeControl> Neighbors;

        public RoutingTable RoutingTable;

        private Timer timer;

        private ContextMenuStrip menu = new ContextMenuStrip();

        public Point MouseDownLocation;

        ContextMenu mnuContextMenu;

        private bool _disabled = false;
        public bool Disabled
        {
            get { return _disabled; }
            set
            {
                if (value == _disabled)
                    return;

                _disabled = value;

                Invalidate();
            }
        }

        private bool _drawingEdge = false;
        public bool DrawingEdge
        {
            get { return _drawingEdge; }
            set
            {
                if (value == _drawingEdge)
                    return;

                _drawingEdge = value;

                Invalidate();
            }
        }

        private bool _Hovering = false;
        public bool Hovering
        {
            get { return _Hovering; }
            set
            {
                if (value == _Hovering)
                    return;

                _Hovering = value;

                Invalidate();
            }
        }

        private bool _Pressed = false;
        public bool Pressed
        {
            get { return _Pressed; }
            set
            {
                if (value == _Pressed)
                    return;

                _Pressed = value;

                Invalidate();
            }
        }

        private bool _Highlighted = false;
        public bool Highlighted
        {
            get { return _Highlighted; }
            set
            {
                if (value == _Highlighted)
                    return;

                _Highlighted = value;

                Invalidate();
            }
        }

        public NodeControl()
        {
            InitializeComponent();
            this.AllowDrop = true;

            timer = new Timer();
            timer.Interval = 10000;
            timer.Tick += Timer_Tick;
            timer.Start();

            Neighbors = new List<NodeControl>();
            
            this.Key = this.Text;
            RoutingTable = new RoutingTable(this.Key);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            SendUpdates();
        }

        private void SendUpdates()
        {
            OnSendUpdate(this, new EventArgs());
            foreach (NodeControl neighbor in Neighbors)
            {
                if (neighbor.Disabled)
                {
                    this.RoutingTable.Routes.Where(x => x.DestinationNode == neighbor.Key).First().Metric = 16;
                    TableEntry en = this.RoutingTable.Routes.Where(x => x.DestinationNode == neighbor.Key).First();
                    SendTriggeredUpdate(en);
                }
                neighbor.UpdateTable(this, this.RoutingTable);
            }
        }

        private void SendTriggeredUpdate(TableEntry entry)
        {
            if(Neighbors != null)
            {
                foreach(NodeControl neighbor in Neighbors)
                {
                    neighbor.SendTriggeredUpdate(entry);
                }
            }
            
        }

        public new string Text
        {
            get { return base.Text; }
            set
            {
                if (value == base.Text)
                    return;
                base.Text = value;
                this.Key = value;
                this.RoutingTable.NodeKey = value;

                Invalidate();
                AddContextMenu();
            }
        }

        public void UpdateTable(NodeControl sender, RoutingTable table)
        {
            this.RoutingTable.Update(table);
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            drgevent.Effect = DragDropEffects.Move;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Hovering = true;

            if (Pressed)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }

            if (DrawingEdge)
            {
                Graphics g = Parent.CreateGraphics();
                
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Hovering = false;
        }
 
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Pressed = false;
        }
        
        public void AddContextMenu()
        {
            mnuContextMenu = new ContextMenu();
            mnuContextMenu.MenuItems.Add("Disable router", new EventHandler(DisableRouter));
            mnuContextMenu.MenuItems.Add("Remove edges", new EventHandler(RemoveEdges));
            mnuContextMenu.MenuItems.Add("Remove router", new EventHandler(RemoveRouter));
            this.ContextMenu = mnuContextMenu;
            this.ContextMenu = mnuContextMenu;
        }

        private void DisableRouter(object sender, EventArgs e)
        {
            if (Disabled)
            {
                Disabled = false;
                this.timer.Start();
                this.ContextMenu.MenuItems[0].Text = "Disable router";
            }
            else
            {
                Disabled = true;
                this.timer.Stop();
                this.ContextMenu.MenuItems[0].Text = "Enable router";
            }
            
        }

        private void RemoveEdges(object sender, EventArgs e)
        {
            OnEdgeRemove(this, new EventArgs());
        }

        private void RemoveRouter(object sender, EventArgs e)
        {
            OnNodeRemove(this, new EventArgs());
            this.Dispose();
        }

        public void AddNeighbor(NodeControl node)
        {
            Neighbors.Add(node);
            RoutingTable.AddRouteToNeighbor(node);
        }

        public void RemoveNeighbor(NodeControl node)
        {
            Neighbors.Remove(node);
        }

        public bool IsNeighbor(NodeControl node)
        {
            if (Neighbors.Contains(node)) return true;
            else return false;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics gfx = CreateGraphics();
            Rectangle rec = ClientRectangle;

            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(rec);
            Region rg = new Region(gp);
            
            this.Region = rg;

            gfx.FillRectangle(new SolidBrush(Color.Transparent), ClientRectangle);           
                      
            Color fill;
            float border;
            if (Pressed)
            {
                fill = Color.Blue;
                border = 2.0f;
            }
            else if (Hovering)
            {
                fill = Color.RoyalBlue;
                border = 3.0f;
            }
            else
            {
                fill = Color.Blue;
                border = 2.0f;
            }

            if (Highlighted)
            {
                fill = Color.Orange;
            }
            if (Disabled) fill = Color.Red;

            gfx.FillEllipse(new SolidBrush(fill), rec);
            gfx.DrawEllipse(new Pen(Color.Black, border), rec);

            Font fnt = new Font("Verdana", (float)rec.Height * 0.3f, FontStyle.Bold, GraphicsUnit.Pixel);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            gfx.DrawString(Text, fnt, new SolidBrush(Color.Black), new RectangleF((float)rec.Left, (float)rec.Top, (float)rec.Width, (float)rec.Height), sf);
        }

    }
}
