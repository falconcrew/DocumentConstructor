using System;
using System.Drawing;
using System.Windows.Forms;

namespace DocumentContructor
{
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
            if (mouseDown)
            {
                Control control = (Control)sender;
                control.Location = new Point((control.Location.X - lastLocation.X) + e.X, (control.Location.Y - lastLocation.Y) + e.Y);
            }
        }

        public static void Click(object sender, EventArgs e)
        {
            Console.WriteLine("Click");
            Global.PropertiesForm.Control = (Control)sender;
        }

        public static void ChangeValue(object sender, EventArgs e)
        {
            
        }
    }
}
