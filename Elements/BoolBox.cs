using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentConstructor
{
    class BoolBox : ComboBox
    {
        public BoolBox(string property) : base()
        {
            Property = property;
            Dock = DockStyle.Fill;
            Font = new Font("Times New Roman", 10);
            Margin = new Padding(0);
            AutoCompleteMode = AutoCompleteMode.Append;
            AutoCompleteSource = AutoCompleteSource.ListItems;
            FlatStyle = FlatStyle.Flat;
            Items.Add(true);
            Items.Add(false);
            SelectedIndexChanged += new EventHandler(ChangeValue);
        }

        private void ChangeValue(object sender, EventArgs e)
        {
            Font f = (Font)Global.PropertiesForm.Control.GetType().GetProperty("Font").GetValue(Global.PropertiesForm.Control);
            FontStyle fs = FontStyle.Regular;
            switch (Property)
            {
                case "Bold":
                    if ((bool)SelectedItem)
                    {
                        fs |= FontStyle.Bold;
                    }
                    if (f.Italic)
                    {
                        fs |= FontStyle.Italic;
                    }
                    f = new Font(f.FontFamily, f.Size, fs);
                    Global.PropertiesForm.Control.GetType().GetProperty("Font").SetValue(Global.PropertiesForm.Control, f);
                    break;
                case "Italic":
                    if ((bool)SelectedItem)
                    {
                        fs |= FontStyle.Italic;
                    }
                    if (f.Bold)
                    {
                        fs |= FontStyle.Bold;
                    }
                    f = new Font(f.FontFamily, f.Size, fs);
                    Global.PropertiesForm.Control.GetType().GetProperty("Font").SetValue(Global.PropertiesForm.Control, f);
                    break;
                default:
                    Global.PropertiesForm.Control.GetType().GetProperty(Property).SetValue(Global.PropertiesForm.Control, SelectedItem);
                    break;
            }
        }

        public void SetText()
        {
            Font f = (Font)Global.PropertiesForm.Control.GetType().GetProperty("Font").GetValue(Global.PropertiesForm.Control);
            switch (Property)
            {
                case "Bold":
                    Text = f.Bold.ToString();
                    break;
                case "Italic":
                    Text = f.Italic.ToString();
                    break;
            }
        }

        public string Property
        {
            get;
            set;
        }
    }
}
