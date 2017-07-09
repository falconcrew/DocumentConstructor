using System;
using System.Windows.Forms;

namespace DocumentContructor
{
    public class Property
    {
        public Property(string name, Type type, Type controlType)
        {
            Name = name;
            Type = type;
            ControlType = controlType;
            Control = new Label();
        }

        public string Name
        {
            get;
            set;
        }

        public Type Type
        {
            get;
            set;
        }

        public Type ControlType
        {
            get;
            set;
        }

        public Control Control
        {
            get;
            set;
        }
    }
}
