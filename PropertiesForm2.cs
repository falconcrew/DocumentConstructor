using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace DocumentContructor
{
    public partial class PropertiesForm2 : Form
    {
        public PropertiesForm2()
        {
            InitializeComponent();
            PropertyInfo[] pis = label1.GetType().GetProperties();
            /*Font f = (Font)pi.GetValue(label1);
            Console.WriteLine(f.FontFamily);
            pi.SetValue(label1, new Font("Times New Roman", 40, FontStyle.Bold));*/

            tableLayoutPanel1.RowCount = pis.Length;
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
            }
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

        public class Property2
        {
            public Property2(string name, Type type, Type controlType)
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
}
