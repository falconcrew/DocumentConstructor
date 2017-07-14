using System;
using System.Windows.Forms;

namespace DocumentConstructor
{
    public class Property
    {
        public Property(string name, Type type, Type controlType)
        {
            Name = name;
            Type = type;
            ControlType = controlType;
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
    }
}
