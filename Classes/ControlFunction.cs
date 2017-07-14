using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Collections.Generic;

namespace DocumentConstructor
{
    public class ControlFunction
    {
        private static Point lastLocation;
        private static bool mouseDown;

        public static void Init()
        {
            SetupColorList();
        }

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
               /* try
                {
                    Bitmap bmp = new Bitmap(control.Width, control.Height);
                    Global.DocumentConstructor.DrawToBitmap(bmp, new Rectangle(control.Location, bmp.Size));
                    control.BackgroundImage = bmp;
                }
                catch { }*/
                control.Location = new Point((control.Location.X - lastLocation.X) + e.X, (control.Location.Y - lastLocation.Y) + e.Y);
            }
        }

        public static void Click(object sender, EventArgs e)
        {
            Global.PropertiesForm.Control = (Control)sender;
            Global.PropertiesForm.Control.Invalidate();
        }

        private static List<Color> colors = new List<Color>();
        private static void SetupColorList()
        {
            PropertyInfo[] pis = typeof(Color).GetProperties();
            foreach (PropertyInfo pi in pis)
            {
                if (pi.PropertyType == typeof(Color))
                {
                    colors.Add((Color)pi.GetValue(null));
                }
            }
            Color c = colors[0];
            colors.Remove(colors[0]);
            colors.Insert(133, c);
        }

        public static List<Color> Colors
        {
            get
            {
                return colors;
            }
        }
    }
}
