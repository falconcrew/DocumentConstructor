using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentConstructor
{
    class Picture : PictureBox
    {
        public Picture() : base()
        {
            MouseDown += new MouseEventHandler(ControlFunction.MouseDown);
            MouseUp += new MouseEventHandler(ControlFunction.MouseUp);
            MouseMove += new MouseEventHandler(ControlFunction.Move);
            Click += new EventHandler(ControlFunction.Click);
            Properties = new List<Property>();
            Name = "picture" + Global.PictureNumber;
            SetProperties();
        }

        public void SetProperties()
        {

        }

        public List<Property> Properties
        {
            get;
            private set;
        }
    }
}
