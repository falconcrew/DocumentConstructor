using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Windows.Forms;

namespace DocumentConstructor
{
    public class TextField : Label
    {
        public TextField() : base()
        {
            MouseDown += new MouseEventHandler(ControlFunction.MouseDown);
            MouseUp += new MouseEventHandler(ControlFunction.MouseUp);
            MouseMove += new MouseEventHandler(ControlFunction.Move);
            Click += new EventHandler(ControlFunction.Click);
            Properties = new List<Property>();
            Name = "textField" + Global.TextFieldNumber;
            SetProperties();
            Font = new Font("Times New Roman", 12);
        }

        private void SetProperties()
        {
            Properties.Add(new Property("Name", typeof(string), typeof(TextInput)));
            Properties.Add(new Property("Text", typeof(string), typeof(TextInput)));
            Properties.Add(new Property("Font", typeof(string), typeof(SelectBox)));
            Properties.Add(new Property("Fontsize", typeof(string), typeof(TextInput)));
            Properties.Add(new Property("Bold", typeof(string), typeof(BoolBox)));
            Properties.Add(new Property("Italic", typeof(string), typeof(BoolBox)));
            Properties.Add(new Property("ForeColor", typeof(string), typeof(SelectColor)));
            Properties.Add(new Property("Location", typeof(string), typeof(TextInput)));
        }

        public List<Property> Properties
        {
            get;
            private set;
        }

        public override Image BackgroundImage
        {
            get;
            set;
        }
    }
}
