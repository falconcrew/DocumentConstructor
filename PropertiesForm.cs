using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System;

namespace DocumentContructor
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
                //Invalidate();

            }
        }

        public PropertiesForm()
        {
            InitializeComponent();
            //PropertyInfo[] pis = label1.GetType().GetProperties();
            /*Font f = (Font)pi.GetValue(label1);
            Console.WriteLine(f.FontFamily);
            pi.SetValue(label1, new Font("Times New Roman", 40, FontStyle.Bold));*/

            /*tableLayoutPanel1.RowCount = pis.Length;
            for(int i = 0; i < pis.Length; i++)
            {
                try
                {
                    PropertyInfo pi = pis[i];
                    Label l = new Label() { Text = pi.Name, Font = new Font("Times New Roman", 10) };
                    TextBox m = new TextBox() { Text = pi.GetValue(label1).ToString(), Font = new Font("Times New Roman", 10) };
                    tableLayoutPanel1.Controls.Add(l, 0, i);
                    tableLayoutPanel1.Controls.Add(m, 1, i);
                }
                catch
                {

                }
            }*/
            /*foreach(PropertyInfo pi in pis)
            {
                Console.Write(pi + "\t" + pi.GetValue(l));
                Console.WriteLine();
            }*/
            /*for(int i = 0; i < 20; i++)
            {
                Label l = new Label() { Text = "Label" + 0 + "," + i, Font = new Font("Times New Roman", 14) };
                TextBox m = new TextBox() { Text = "Label" + 1 + "," + i, Font = new Font("Times New Roman", 14) };
                tableLayoutPanel1.Controls.Add(l, 0, i);
                tableLayoutPanel1.Controls.Add(m, 1, i);
            }*/
        }

        private void UpdateProperties()
        {
            Line line;
            TextField text;
            tableLayoutPanel1.Controls.Clear();
            int row = 0;
            switch (controlType)
            {
                case "Line":
                    line = (Line)Control;
                    foreach (Property p in line.Properties)
                    {
                        NameLabel label = new NameLabel(p.Name);
                        tableLayoutPanel1.Controls.Add(label, 0, row);
                        tableLayoutPanel1.Controls.Add(p.Control, 1, row);
                        row++;
                    }
                    break;
                case "TextField":
                    text = (TextField)Control;
                    foreach (Property p in text.Properties)
                    {
                        tableLayoutPanel1.Controls.Add(p.Label, 0, row);
                        tableLayoutPanel1.Controls.Add(p.Control, 1, row);
                        row++;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
