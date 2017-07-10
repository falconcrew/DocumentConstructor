using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentContructor
{
    public class SelectBox : ComboBox
    {
        public SelectBox(string property) : base()
        {
            Property = property;
            Dock = DockStyle.Fill;
            Font = new Font("Times New Roman", 10);
            Margin = new Padding(0);
            AutoCompleteMode = AutoCompleteMode.Append;
            AutoCompleteSource = AutoCompleteSource.ListItems;
            FlatStyle = FlatStyle.Flat;
            SelectedIndexChanged += new EventHandler(ChangeValue);
            switch (property)
            {
                case "Font":
                    FontFamily[] fontFamilies = new InstalledFontCollection().Families;
                    foreach (FontFamily fam in fontFamilies)
                    {
                        Items.Add(fam.Name);
                    }
                    break;
                /*case "Color":
                    foreach (Color c in Global.AllColors)
                    {
                        Items.Add(c.Name);
                    }
                    break;*/
            }

        }

        private void ChangeValue(object sender, EventArgs e)
        {
            switch (Property)
            {
                case "Font":
                    Font f = new Font(Text, 12);
                    Global.PropertiesForm.Control.GetType().GetProperty(Property).SetValue(Global.PropertiesForm.Control, f);
                    break;
            }
            //PropertyInfo pi = Global.PropertiesForm.Control.GetType().GetProperty(control.Property);
            //Console.WriteLine(Global.PropertiesForm.Control.GetType().GetProperty(control.Property).GetValue(Global.PropertiesForm.Control));
        }

        public string Property
        {
            get;
            set;
        }
    }
}
