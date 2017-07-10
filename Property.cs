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
            switch (controlType.Name)
            {
                case "TextInput":
                    Control = new TextInput("Text");
                    break;
                case "SelectBox":
                    Control = new SelectBox(name);
                    break;
            }
            Label = new NameLabel(name);
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

        public NameLabel Label
        {
            get;
            set;
        }
    }
}
