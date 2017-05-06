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
        public event EventHandler OnEdgeRemove;

        private ContextMenuStrip menu = new ContextMenuStrip();

        public Point MouseDownLocation;

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
            
        }


        public new string Text
        {
            get { return base.Text; }
            set
            {
                if (value == base.Text)
                    return;
                base.Text = value;

                Invalidate();
                AddContextMenu();
            }
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
        /*
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Pressed = true;
                MouseDownLocation = e.Location;
            }
            else if (e.Button == MouseButtons.Right)
            {
                
            }

        }
*/
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Pressed = false;
        }
        /*
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if (Highlighted)
                {
                    Highlighted = false;
                }
                else
                    Highlighted = true;

                
            }
            else if (e.Button == MouseButtons.Right)
            {
                menu.Show();
            }
        }
        */
        public void AddContextMenu()
        {
            ContextMenu mnuContextMenu = new ContextMenu();
            mnuContextMenu.MenuItems.Add("Add edge", new EventHandler(AddEdge));
            mnuContextMenu.MenuItems.Add("Show routing table", new EventHandler(ClearEdges));
            mnuContextMenu.MenuItems.Add("Remove edges", new EventHandler(RemoveEdges));
            mnuContextMenu.MenuItems.Add("Remove router", new EventHandler(RemoveRouter));
            this.ContextMenu = mnuContextMenu;
            this.ContextMenu = mnuContextMenu;
        }

        private void RemoveEdges(object sender, EventArgs e)
        {
            OnEdgeRemove(this, new EventArgs());
        }

        private void AddEdge(object sender, EventArgs e)
        {
            
        }

        private void ClearEdges(object sender, EventArgs e)
        {
            ////
        }

        private void RemoveRouter(object sender, EventArgs e)
        {
            //clear edges...TO DO
            this.Dispose();
            MessageBox.Show("Router removed");
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics gfx = CreateGraphics();
            Rectangle rec = ClientRectangle;

            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(rec);
            Region rg = new Region(gp);
            
            this.Region = rg;

            //rec.Width -= 1;
            //rec.Height -= 1;

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
