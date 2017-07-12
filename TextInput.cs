using System;
using System.Drawing;
using System.Windows.Forms;

namespace DocumentContructor
{
    public class TextInput : TextBox
    {
        public TextInput(string text) : base()
        {
            Text = text;
            Font = new Font("Times New Roman", 12);
            Dock = DockStyle.Fill;
            Margin = new Padding(0);
            BorderStyle = BorderStyle.None;
            Enter += new EventHandler(ChangeValue);
        }

        private void ChangeValue(object sender, EventArgs e)
        {
            
        }
    }
}
