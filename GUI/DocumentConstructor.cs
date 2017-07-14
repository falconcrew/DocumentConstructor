using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentConstructor
{
    public partial class DocumentConstructor : Form
    {
        public List<Label> Document;

        public DocumentConstructor()
        {
            Global.Init();
            ControlFunction.Init();
            InitializeComponent();
            Global.PropertiesForm.Show();
            //PropertiesForm pf = new PropertiesForm();
            //pf.Show();
            /*Document = new List<Label>();*/

            Line l = new Line();
            l.Location = new Point(10, 100);
            l.Angle = 0;
            Controls.Add(l);

            /*Document.Add(l);
            Global.Init();
            Global.DocumentConstructor = this;
            PropertiesForm pf = Global.PropertiesForm;
            pf.Show();*/
            Global.DocumentConstructor = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Invalidate(true);
            Update();
        }
    }
}
