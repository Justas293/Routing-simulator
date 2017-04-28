﻿using System;
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
        private Point MouseDownLocation;
        private Point MousePosition;

        private bool _Hovering = false;
        private bool Hovering
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
        private bool Pressed
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

        public NodeControl()
        {
            InitializeComponent();
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
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Hovering = true;
            MousePosition = e.Location;

            if (Pressed)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Hovering = false;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Pressed = true;
                MouseDownLocation = e.Location;
            }
                
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Pressed = false;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics gfx = pe.Graphics;
            Rectangle rec = ClientRectangle;

            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(rec);
            Region rg = new Region(gp);
            
            this.Region = rg;

            rec.Width -= 1;
            rec.Height -= 1;

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
