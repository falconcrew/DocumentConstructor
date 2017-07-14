using System;
using System.Drawing;
using System.Windows.Forms;

namespace DocumentConstructor
{
    public class TextInput : TextBox
    {
        private string Property;

        public TextInput(string property) : base()
        {
            Property = property;
            Font = new Font("Times New Roman", 12);
            Dock = DockStyle.Fill;
            Anchor = AnchorStyles.Left;
            Margin = new Padding(3,0,0,0);
            BorderStyle = BorderStyle.None;
            KeyPress += new KeyPressEventHandler(ChangeValue);
        }

        private void ChangeValue(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                switch (Property)
                {
                    case "Location":
                        char[] splitChars = { ',', ' ' };
                        string[] xy = Text.Split(splitChars);
                        int[] l = { Convert.ToInt32(Text.Split(splitChars)[0]), Convert.ToInt32(Text.Split(splitChars)[2]) };
                        Global.PropertiesForm.Control.GetType().GetProperty(Property).SetValue(Global.PropertiesForm.Control, new Point(l[0], l[1]));
                        break;
                    case "Fontsize":
                        Font f = (Font)Global.PropertiesForm.Control.GetType().GetProperty("Font").GetValue(Global.PropertiesForm.Control);
                        f = new Font(f.FontFamily.Name, (float)Convert.ToDouble(Text));
                        Global.PropertiesForm.Control.GetType().GetProperty("Font").SetValue(Global.PropertiesForm.Control, f);
                        break;
                    case "Name":
                        string name = (string)Global.PropertiesForm.Control.GetType().GetProperty("Name").GetValue(Global.PropertiesForm.Control);
                        int index = name.Length - 1;
                        while (char.IsNumber(name,index))
                        {
                            index--;
                        }
                        int num = Convert.ToInt32(name.Substring(index + 1));
                        name = name.Substring(0, index+1);
                        Console.WriteLine(name + "      " + num);
                        switch (name)
                        {
                            case "textField":
                                Global.TextFieldNumber = num;
                                break;
                            case "picture":
                                Global.PictureNumber = num;
                                break;
                            case "line":
                                Global.LineNumber = num;
                                break;
                        }
                        Global.PropertiesForm.Control.GetType().GetProperty("Name").SetValue(Global.PropertiesForm.Control, Text);
                        break;
                    case "Angle":
                    case "Length":
                    case "LineWidth":
                        int val = int.Parse(Text);
                        Global.PropertiesForm.Control.GetType().GetProperty(Property).SetValue(Global.PropertiesForm.Control, val);
                        break;
                    default:
                        Global.PropertiesForm.Control.GetType().GetProperty(Property).SetValue(Global.PropertiesForm.Control, Text);
                        break;
                }
                e.Handled = true;
            }
        }

        private bool IsControlName(string name)
        {

            return false;
        }

        public void SetText()
        {
            switch (Property)
            {
                case "Location":
                    Point p = (Point)Global.PropertiesForm.Control.GetType().GetProperty(Property).GetValue(Global.PropertiesForm.Control);
                    Text = "" + p.X + ", " + p.Y;
                    break;
                case "Fontsize":
                    Font f = (Font)Global.PropertiesForm.Control.GetType().GetProperty("Font").GetValue(Global.PropertiesForm.Control);
                    Text = f.Size.ToString();
                    break;
                default:
                    Text = Global.PropertiesForm.Control.GetType().GetProperty(Property).GetValue(Global.PropertiesForm.Control).ToString();
                    break;
            }
        }
    }
}
