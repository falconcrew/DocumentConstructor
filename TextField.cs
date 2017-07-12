using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace DocumentContructor
{
    public class TextField : Label
    {
        private List<Property> properties;
        private string text;

        public TextField() : base()
        {
            MouseDown += new MouseEventHandler(ControlFunction.MouseDown);
            MouseUp += new MouseEventHandler(ControlFunction.MouseUp);
            MouseMove += new MouseEventHandler(ControlFunction.Move);
            Click += new EventHandler(ControlFunction.Click);
            Properties = new List<Property>();
            SetProperties();
            Font = new Font("Times New Roman", 12);
        }

        private void SetProperties()
        {
            Properties.Add(new Property("Text", typeof(string), typeof(TextInput)));
            Properties.Add(new Property("Font", typeof(string), typeof(SelectBox)));
            Properties.Add(new Property("Fontsize", typeof(string), typeof(TextInput)));
            Properties.Add(new Property("ForeColor", typeof(string), typeof(SelectColor)));
        }

        public override string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
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
            foreach (Property p in properties)
            {
                switch (p.Name)
                {
                    case "Text":
                        //text = (string)p.Value;
                        
                        break;
                }
            }
        }
    }
}
