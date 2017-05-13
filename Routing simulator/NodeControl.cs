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
        private Timer sendTimer;

        private Packet packet;

        private ContextMenuStrip menu = new ContextMenuStrip();

        public Point MouseDownLocation;

        ContextMenu mnuContextMenu;

        public bool messageSent = false;

        private bool _sendingMessage = false;
        public bool SendingMessage
        {
            get { return _sendingMessage; }
            set
            {
                if (value == _sendingMessage)
                    return;

                _sendingMessage = value;

                Invalidate();
            }
        }

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

            sendTimer = new Timer();
            sendTimer.Interval = 200;
            sendTimer.Tick += SendTimer_Tick1;

            Neighbors = new List<NodeControl>();
            
            this.Key = this.Text;
            RoutingTable = new RoutingTable(this.Key);
            RoutingTable.OnMetricChanged += RoutingTable_OnMetricChanged;
        }

        private void SendTimer_Tick1(object sender, EventArgs e)
        {
            if (packet.destination == this.Key)
            {
                StopTimer();
                SendingMessage = false;
                MessageBox.Show("Message received on router: " + this.Key + "! Message: " + packet.message);
                
            }
            else
            {
                try
                {
                    TableEntry entry = this.RoutingTable.Routes.Where(x => x.DestinationNode == packet.destination).First();
                    if (entry.Metric != 16)
                    {
                        NodeControl nextNode = this.Neighbors.Where(x => x.Key == entry.NextHop).First();
                        if (!nextNode.Disabled)
                        {
                            StopTimer();
                            SendingMessage = false;
                            nextNode.SendPacket(packet);
                        }
                    }
                    else
                    {

                    }
                }
                catch (InvalidOperationException ex)
                {
                    //resend
                }

            }
        }

        private void StopTimer()
        {
            sendTimer.Stop();
            sendTimer.Enabled = false;
        }

        private void RoutingTable_OnMetricChanged(object sender, EventArgs e)
        {
            SendTriggeredUpdates(this.RoutingTable);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            SendUpdates();
        }

        public virtual void SendUpdates()
        {
            //OnSendUpdate(this, new EventArgs());
            foreach (NodeControl neighbor in Neighbors)
            {
                if (neighbor.Disabled)
                {
                    this.RoutingTable.Routes.Where(x => x.DestinationNode == neighbor.Key).First().Metric = 16;
                    TableEntry en = this.RoutingTable.Routes.Where(x => x.DestinationNode == neighbor.Key).First();
                    IEnumerable<TableEntry> unreachableEntries = this.RoutingTable.Routes.Where(x => x.NextHop == en.DestinationNode);
                    foreach (var route in unreachableEntries)
                    {
                        route.Metric = 16;
                    }
                    SendTriggeredUpdates(this.RoutingTable);
                }
                neighbor.UpdateTable(this, this.RoutingTable);
            }
        }

        private void SendTriggeredUpdates(RoutingTable table)
        {
            foreach(NodeControl neighbor in Neighbors)
            {
                neighbor.UpdateTable(this, table);
            }
            
        }

        public void RemoveRouterFromTable(string routerName)
        {
            foreach(TableEntry entry in this.RoutingTable.Routes)
            {
                if(entry.DestinationNode == routerName)
                {
                    this.RoutingTable.Routes.Remove(entry);
                    foreach (var router in Neighbors)
                    {
                        router.RemoveRouterFromTable(routerName);
                    }
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

        public void SendPacket(Packet packet)
        {
            if (!messageSent)
            {
                this.packet = packet;
                SendingMessage = true;
                sendTimer.Start();
            }
            else
            {
                sendTimer.Stop();
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
        
        public virtual void AddContextMenu()
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
                this.Timer_Tick(this, new EventArgs());
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
            if (SendingMessage) fill = Color.Green;
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
