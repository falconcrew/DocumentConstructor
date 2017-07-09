using System.Drawing;
using System.Windows.Forms;

namespace DocumentContructor
{
    public class TextInput : TextBox
    {
        public TextInput(string text) : base()
        {
            Text = text;
            Font = new Font("Times New Roman", 10);
        }
    }
}
