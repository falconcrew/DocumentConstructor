using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DocumentContructor
{
    public class TextLabel : Label
    {
        private List<Property> properties;
        private string text;

        public TextLabel() : base()
        {
            MouseDown += new MouseEventHandler(ControlFunction.MouseDown);
            MouseUp += new MouseEventHandler(ControlFunction.MouseUp);
            MouseMove += new MouseEventHandler(ControlFunction.Move);
            Click += new EventHandler(ControlFunction.Click);
            Properties = new List<Property>();
            text = "";
            Properties.Add(new Property("Text", typeof(string), typeof(TextBox)));
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
