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
        public List<Label> Document;

        public DocumentConstructor()
        {
            InitializeComponent();
            PropertiesForm2 pf2 = new PropertiesForm2();
            pf2.Show();
            /*Document = new List<Label>();
            Line l = new Line();
            l.Location = new Point(30, 10);
            l.Size = new Size(150, 10);
            Controls.Add(l);
            Document.Add(l);
            Global.Init();
            Global.DocumentConstructor = this;
            PropertiesForm pf = Global.PropertiesForm;
            pf.Show();*/
        }
    }

    public class Line : Label
    {
        private List<Property> properties;
        public Line() : base()
        {
            BackColor = Color.Black;
            BorderStyle = BorderStyle.FixedSingle;
            MouseDown += new MouseEventHandler(ControlFunction.MouseDown);
            MouseUp += new MouseEventHandler(ControlFunction.MouseUp);
            MouseMove += new MouseEventHandler(ControlFunction.Move);
            Click += new EventHandler(ControlFunction.Click);
            Name = "Line" + Global.LineNumber;
            Properties = new List<Property>();
            Properties.Add(new Property("Color", BackColor, "List"));
        }

        public Color Color
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

        public List<Property> Properties
        {
            get
            {
                return properties;
            }
            set
            {
                properties = value;
                UpdateProperties();
            }
        }

        private void UpdateProperties()
        {
            foreach(Property p in properties)
            {
                switch (p.Name)
                {
                    case "Color":
                        Color = (Color)p.Value;
                        break;
                }
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

        public static void Click(object sender, EventArgs e)
        {
            Console.WriteLine("Click");
            Global.PropertiesForm.Control = sender;
        }
    }

    public class Global
    {
        public static void Init()
        {
            PropertiesForm = new PropertiesForm();
        }

        public static PropertiesForm PropertiesForm
        {
            get;
            private set;
        }

        public static DocumentConstructor DocumentConstructor
        {
            get;
            set;
        }

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
