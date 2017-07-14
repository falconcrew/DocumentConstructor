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
            tableLayoutPanel1.Controls.Clear();
            int row = 0;
            switch (controlType)
            {
                case "Line":
                    Line line = (Line)Control;
                    foreach (Property p in line.Properties)
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
                    break;
                case "TextField":
                    TextField text = (TextField)Control;
                    foreach (Property p in text.Properties)
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
                    break;
                default:
                    break;
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
