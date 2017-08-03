using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentConstructor
{
    class Block : Label
    {
        public Block() : base()
        {
            AutoSize = false;
            Width = 100;
            Height = 50;
            Radius = 20;
            Color = Color.Black;
            fill = true;
            fillColor = Color.Black;
            Location = new Point(10, 10);
            BorderStyle = BorderStyle.None;
            borderWidth = 3;
            MouseDown += new MouseEventHandler(ControlFunction.MouseDown);
            MouseUp += new MouseEventHandler(ControlFunction.MouseUp);
            MouseMove += new MouseEventHandler(ControlFunction.Move);
            Click += new EventHandler(ControlFunction.Click);
            Paint += new PaintEventHandler(PaintRectangle);
            SetupProperties();
        }

        private void SetupProperties()
        {
            Properties = new List<Property>();
            Properties.Add(new Property("Height", typeof(int), typeof(TextInput)));
            Properties.Add(new Property("Width", typeof(int), typeof(TextInput)));
            Properties.Add(new Property("Radius", typeof(int), typeof(TextInput)));
            Properties.Add(new Property("Color", typeof(Color), typeof(SelectColor)));
            Properties.Add(new Property("BorderWidth", typeof(int), typeof(TextInput)));
            Properties.Add(new Property("Fill", typeof(bool), typeof(BoolBox)));
            Properties.Add(new Property("FillColor", typeof(Color), typeof(SelectColor)));

        }

        public List<Property> Properties
        {
            get;
            set;
        }

        private Color color;
        public Color Color
        {
            get { return color; }
            set
            {
                color = value;
                Invalidate();
            }
        }

        private bool fill;
        public bool Fill
        {
            get { return fill; }
            set
            {
                fill = value;
                Invalidate();
            }
        }

        private Color fillColor;
        public Color FillColor
        {
            get { return fillColor; }
            set
            {
                fillColor = value;
                Invalidate();
            }
        }

        public bool RadiusChecked
        {
            get;
            set;
        }

        private int radius;
        public int Radius
        {  
            get { return radius; }
            set
            {
                radius = value;
                if (radius > Math.Min(Width, Height) / 2)
                {
                    radius = Math.Min(Width, Height) / 2;
                }
                Invalidate();
            }
        }

        private float borderWidth;
        public float BorderWidth
        {
            get { return borderWidth; }
            set
            {
                borderWidth = value;
                Invalidate();
            }
        }

        private void PaintRectangle(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            if (!RadiusChecked) {
                Radius = radius;
                Global.PropertiesForm.UpdateProperties();
                RadiusChecked = true;
            }

            Brush brush = new SolidBrush(fillColor);
            Pen pen = new Pen(color, BorderWidth);
            Pen pen2 = new Pen(Color.Chocolate, BorderWidth);
            float margin = borderWidth / 2;
            if (fill)
            {
                try
                {
                    gfx.FillRectangle(brush, radius, 0, Width - 2 * radius, Height);
                    gfx.FillRectangle(brush, 0, radius, radius, Height - 2 * radius);
                    gfx.FillRectangle(brush, Width - radius, radius, radius, Height - 2 * radius);
                    gfx.FillPie(brush, 0, 0, 2 * radius, 2 * radius, 180, 90);
                    gfx.FillPie(brush, 0, Height - 2 * radius, 2 * radius, 2 * radius, 90, 90);
                    gfx.FillPie(brush, Width - 2 * radius, 0, 2 * radius, 2 * radius, 270, 90);
                    gfx.FillPie(brush, Width - 2 * radius, Height - 2 * radius, 2 * radius, 2 * radius, 0, 90);
                }
                catch
                {
                    gfx.FillRectangle(brush, 0, 0, Width, Height);
                }
            }
            try
            {
                gfx.DrawLine(pen, radius, margin, Width - radius, margin);
                gfx.DrawLine(pen, radius, Height - margin, Width - radius, Height - margin);
                gfx.DrawLine(pen, margin, radius, margin, Height - radius);
                gfx.DrawLine(pen, Width - margin, radius, Width - margin, Height - radius);
                float arcsize = 2 * radius - 2 * margin;
                gfx.DrawArc(pen, margin, margin, arcsize, arcsize, 175, 100);
                gfx.DrawArc(pen, margin, Height - 2 * radius + margin, arcsize, arcsize, 85, 100);
                gfx.DrawArc(pen, Width - 2 * radius + margin, margin, arcsize, arcsize, 265, 100);
                gfx.DrawArc(pen, Width - 2 * radius + margin, Height - 2 * radius + margin, arcsize, arcsize, -5, 100);
            }
            catch
            {
                gfx.DrawRectangle(pen, 0, 0, Width, Height);
            }
        }
    }
}
