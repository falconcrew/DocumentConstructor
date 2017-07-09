using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentContructor
{
    public partial class DocumentConstructor : Form
    {
        public List<Label> Document;

        public DocumentConstructor()
        {
            InitializeComponent();
            Global.Init();
            PropertiesForm pf2 = new PropertiesForm();
            pf2.Show();
            /*Document = new List<Label>();
            Line l = new Line();
            l.Location = new Point(30, 10);
            l.Size = new Size(150, 10);
            Controls.Add(l);
            Document.Add(l);
            Global.Init();
            Global.DocumentConstructor = this;
            PropertiesForm pf = Global.PropertiesForm;
            pf.Show();*/
        }
    }
}
