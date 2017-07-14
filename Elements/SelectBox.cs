using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentConstructor
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
            }

        }

        public void SetText()
        {
            switch (Property)
            {
                case "Font":
                    Font f = (Font)Global.PropertiesForm.Control.GetType().GetProperty(Property).GetValue(Global.PropertiesForm.Control);
                    Text = f.FontFamily.Name;
                    break;
            }
        }

        private void ChangeValue(object sender, EventArgs e)
        {
            switch (Property)
            {
                case "Font":
                    Font f = (Font)Global.PropertiesForm.Control.GetType().GetProperty(Property).GetValue(Global.PropertiesForm.Control);
                    FontStyle fs = FontStyle.Regular;
                    if (f.Bold)
                    {
                        fs |= FontStyle.Bold;
                    }
                    if (f.Italic)
                    {
                        fs |= FontStyle.Italic;
                    }
                    f = new Font(Text, f.Size, fs);
                    
                    Global.PropertiesForm.Control.GetType().GetProperty(Property).SetValue(Global.PropertiesForm.Control, f);
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
