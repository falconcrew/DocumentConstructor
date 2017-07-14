using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DocumentConstructor
{
    public class Line : Label
    {
        public Line() : base()
        {
            Angle = 0;
            Color = Color.Black;
            Length = 200;
            LineWidth = 4;
            InitializeComponent();
            AutoSize = false;
            BackColor = Color.Transparent;
            BorderStyle = BorderStyle.None;
            MouseDown += new MouseEventHandler(ControlFunction.MouseDown);
            MouseUp += new MouseEventHandler(ControlFunction.MouseUp);
            MouseMove += new MouseEventHandler(ControlFunction.Move);
            Click += new EventHandler(ControlFunction.Click);
            Name = "line" + Global.LineNumber;
            Properties = new List<Property>();
            SetProperties();
        }

        private void SetProperties()
        {
            Properties.Add(new Property("Color", BackColor.GetType(), typeof(SelectColor)));
            Properties.Add(new Property("Length", typeof(int), typeof(TextInput)));
            Properties.Add(new Property("LineWidth", typeof(int), typeof(TextInput)));
            Properties.Add(new Property("Angle", typeof(int), typeof(TextInput)));
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

        private double angle;
        public double Angle
        {
            get { return angle; }
            set
            {
                angle = value;
                Width = Math.Abs((int)(Length * Math.Cos(Angle / 180 * Math.PI))) + 2 * LineWidth;
                Height = Math.Abs((int)(Length * Math.Sin(Angle / 180 * Math.PI))) + 2 * LineWidth;
                Invalidate();
            }
        }

        private int length;
        public int Length
        {
            get { return length; }
            set
            {
                length = value;
                Invalidate();
            }
        }

        public List<Property> Properties { get; private set; }

        private int lineWidth;
        public int LineWidth
        {
            get { return lineWidth; }
            set
            {
                lineWidth = value;
                Width = Math.Abs((int)(Length * Math.Cos(Angle / 180 * Math.PI))) + 2 * LineWidth;
                Height = Math.Abs((int)(Length * Math.Sin(Angle / 180 * Math.PI))) + 2 * LineWidth;
                Invalidate();
            }
        }

        private void PaintLine(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Brush brush = new SolidBrush(Color);
            
            double angle = (Angle / 180) * Math.PI;
            Point p1, p2;
            if (angle >= 0)
            {
                int offsetX = (int)(LineWidth / 2 * (2 - Math.Cos(angle)));
                int offsetY = (int)(LineWidth / 2 * (2 - Math.Sin(angle)));
                p1 = new Point(offsetX, offsetY);
                p2 = new Point((int)(Length * Math.Cos(angle)) + offsetX, (int)(Length * Math.Sin(angle)) + offsetY);
            }
            else
            {
                int offsetX = (int)(LineWidth / 2 * (2 - Math.Cos(angle)));
                int offsetY = Height - (int)(LineWidth / 2 * (2 - Math.Sin(angle)));
                p1 = new Point(offsetX, offsetY);
                p2 = new Point((int)(Length * Math.Cos(angle)) + offsetX, (int)(Length * Math.Sin(angle)) + offsetY);
            }
            Pen pen = new Pen(Color, LineWidth);
            gfx.DrawLine(pen, p1, p2);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Line
            // 
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintLine);
            this.ResumeLayout(false);

        }
    }
}
