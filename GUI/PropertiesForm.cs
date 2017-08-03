using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System;
using System.Drawing;

namespace DocumentConstructor
{
    public partial class PropertiesForm : Form
    {
        private Control control;
        private string controlType;
        public Control Control
        {
            get
            {
                return control;
            }
            set
            {
                control = value;
                controlType = value.GetType().Name;
                UpdateProperties();
                Text = Control.Name;
            }
        }

        public PropertiesForm()
        {
            InitializeComponent();
            tableLayoutPanel1.Controls.Add(new BoolBox("Bold"), 0, 0);
        }

        public void UpdateProperties()
        {
            tableLayoutPanel1.Controls.Clear();
            List<Property> properties = new List<Property>();
            switch (controlType)
            {
                case "Line":
                    Line line = (Line)Control;
                    properties = line.Properties;
                    break;
                case "TextField":
                    TextField text = (TextField)Control;
                    properties = text.Properties;
                    break;
                case "Block":
                    Block block = (Block)Control;
                    properties = block.Properties;
                    break;
                default:
                    break;
            }

            int row = 0;
            foreach (Property p in properties)
            {
                NameLabel label = new NameLabel(p.Name);
                tableLayoutPanel1.Controls.Add(label, 0, row);
                switch (p.ControlType.Name)
                {
                    case "TextInput":
                        TextInput ti = new TextInput(p.Name);
                        ti.SetText();
                        tableLayoutPanel1.Controls.Add(ti, 1, row);
                        break;
                    case "SelectBox":
                        SelectBox sb = new SelectBox(p.Name);
                        sb.SetText();
                        tableLayoutPanel1.Controls.Add(sb, 1, row);
                        break;
                    case "BoolBox":
                        BoolBox bb = new BoolBox(p.Name);
                        bb.SetText();
                        tableLayoutPanel1.Controls.Add(bb, 1, row);
                        break;
                    case "SelectColor":
                        SelectColor sc = new SelectColor(p.Name);
                        sc.SetText();
                        tableLayoutPanel1.Controls.Add(sc, 1, row);
                        break;
                }
                row++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = Control.Font;
            DialogResult result = fd.ShowDialog();
            if (result == DialogResult.OK)
            {
                Control.Font = fd.Font;
            }
            UpdateProperties();
        }
    }
}
