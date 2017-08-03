using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentConstructor
{
    class Tool : Label
    {
        public Tool() : base()
        {
            Text = "Tool";
            Height = 30;
            Image = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("DocumentConstructor.Images.DefaultImage.png"));
            Paint += new PaintEventHandler(PaintTool);
            Click += new EventHandler(ClickTool);
        }

        public new Image Image
        {
            get;
            set;
        }

        private void PaintTool(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            gfx.Clear(Color.White);

            double pixelsPerPoint = gfx.DpiX / 72;
            gfx.DrawImage(Image, 2, 2, 26, 26);
            Point p = new Point(34, (int)(30 - 14 * pixelsPerPoint) / 2 - 1);
            gfx.DrawString(Text, new Font("Times New Roman", 14), Brushes.Black, p);
        }

        private void ClickTool(object sender, EventArgs e)
        {
            Global.DocumentConstructor.AddControl = true;
            Global.DocumentConstructor.ControlType = Text;
            Global.DocumentConstructor.SetCursor(Text);
        }
    }
}
