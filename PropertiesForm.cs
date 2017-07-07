using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentContructor
{
    public partial class PropertiesForm : Form
    {
        private object control;
        private string controlType;
        public object Control
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
                Update();

            }
        }

        public PropertiesForm()
        {
            InitializeComponent();
            /*for(int i = 0; i < 20; i++)
            {
                propertyBindingSource.Add(new Property("Test", i));
            }
            propertyBindingSource.Add(new Property("Test", 2));*/
            dataGridView1.Width = Width - 16;
            dataGridView1.Columns[0].Width = (dataGridView1.Width - 20) / 2;
            dataGridView1.Columns[1].Width = (dataGridView1.Width - 20) / 2;
            /*listView1.Columns.Add("", listView1.Width / 2, HorizontalAlignment.Left);
            listView1.Columns.Add("", listView1.Width / 2, HorizontalAlignment.Left);
            ListViewItem i = new ListViewItem("Test");
            i.SubItems.Add("Tast");
            listView1.Items.Add(i);*/

        }

        private void UpdateProperties()
        {
            propertyBindingSource.Clear();
            Line line;
            TextLabel text;
            switch(controlType)
            {
                case "Line":
                    line = (Line)Control;
                    foreach (Property p in line.Properties)
                    {
                        propertyBindingSource.Add(p);
                    }
                    break;
                case "TextLabel":
                    text = (TextLabel)Control;
                    foreach (Property p in text.Properties)
                    {
                        Console.WriteLine(p.Value);
                        propertyBindingSource.Add(p);
                    }
                    break;
                default:
                    break;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Console.WriteLine(controlType);
                Property p = (Property) propertyBindingSource[e.RowIndex];
                Line line;
                TextLabel text;
                switch (controlType)
                {
                    case "Line":
                        line = (Line)Control;
                        line.Properties = (List<Property>)propertyBindingSource.List;
                        break;
                    case "TextLabel":
                        text = (TextLabel)Control;
                        List<Property> properties = new List<Property>();
                        foreach(Property p1 in propertyBindingSource)
                        {
                            properties.Add(p1);
                        }
                        text.Properties = properties;
                        Global.DocumentConstructor.Update();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public class Property
    {
        public Property(string name, object value, string controlType)
        {
            Name = name;
            Value = value;
            Type = value.GetType();
            ControlType = controlType;
        }

        public string Name
        {
            get;
            set;
        }

        public object Value
        {
            get;
            set;
        }

        public Type Type
        {
            get;
            set;
        }

        public string ControlType
        {
            get;
            set;
        }

        public List<string> Alternatives
        {
            get;
            set;
        }
    }

    public class TextLabel : Label
    {
        private List<Property> properties;
        private string text;

        public TextLabel() : base()
        {
            MouseDown += new MouseEventHandler(ControlFunction.MouseDown);
            MouseUp += new MouseEventHandler(ControlFunction.MouseUp);
            MouseMove += new MouseEventHandler(ControlFunction.Move);
            Click += new EventHandler(ControlFunction.Click);
            Properties = new List<Property>();
            text = "";
            Properties.Add(new Property("Text", Text, "Text"));
        }

        public override string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                foreach(Property p in Properties)
                {
                    if (p.Name.Equals("Text"))
                    {
                        p.Value = value;
                        Console.WriteLine(p.Value);
                        break;
                    }
                }
            }
        }

        public List<Property> Properties
        {
            get
            {
                return properties;
            }
            set
            {
                properties = value;
                UpdateProperties();
            }
        }

        private void UpdateProperties()
        {
            foreach (Property p in properties)
            {
                switch (p.Name)
                {
                    case "Text":
                        text = (string)p.Value;
                        
                        break;
                }
            }
        }
    }
}
