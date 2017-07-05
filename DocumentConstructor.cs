using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentContructor
{
    public partial class DocumentConstructor : Form
    {


        public DocumentConstructor()
        {
            InitializeComponent();
            Line l = new Line();
            l.Location = new Point(30, 10);
            l.Size = new Size(150, 10);
            Controls.Add(l);
            Console.WriteLine(Global.LineNumber);
            Console.WriteLine(Global.LineNumber);
            Console.WriteLine(Global.LineNumber);
            Console.WriteLine(Global.LineNumber);
            Console.WriteLine(Global.LineNumber);
        }
    }

    public class Line : Label
    {
        public Line() : base()
        {
            BackColor = Color.Black;
            BorderStyle = BorderStyle.FixedSingle;
            MouseDown += new MouseEventHandler(ControlFunction.MouseDown);
            MouseUp += new MouseEventHandler(ControlFunction.MouseUp);
            MouseMove += new MouseEventHandler(ControlFunction.Move);
            Name = "Line" + Global.LineNumber;
        }

        Color Color
        {
            get
            {
                return BackColor;
            }
            set
            {
                BackColor = value;
            }
        }


    }

    public class ControlFunction
    {
        private static Point lastLocation;
        private static bool mouseDown;

        public static void MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        public static void MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        public static void Move(object sender, MouseEventArgs e)
        {
            string type = sender.GetType().Name;
            if (type == "Label")
            {
                Label label = (Label)sender;
                if (mouseDown)
                {
                    label.Location = new Point((label.Location.X - lastLocation.X) + e.X, (label.Location.Y - lastLocation.Y) + e.Y);
                }
            }
            else if (type == "Line")
            {
                Line line = (Line)sender;
                if (mouseDown)
                {
                    line.Location = new Point((line.Location.X - lastLocation.X) + e.X, (line.Location.Y - lastLocation.Y) + e.Y);
                }
            }
        }
    }

    public class Global
    {
        private static int lineNumber;
        public static int LineNumber
        {
            get
            {
                return lineNumber++;
            }
        }
    }
}
