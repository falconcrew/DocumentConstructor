using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DocumentContructor
{
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
            Properties.Add(new Property("Color", BackColor.GetType(), typeof(ComboBox)));
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
                        //Color = (Color)p.Value;
                        break;
                }
            }
        }
    }
}
