using System.Drawing;
using System.Windows.Forms;

namespace DocumentContructor
{
    public class NameLabel : Label
    {
        public NameLabel(string text) : base()
        {
            Font = new Font("Times New Roman", 10);
            Text = text;
            TextAlign = ContentAlignment.MiddleLeft;
            Dock = DockStyle.Fill;
        }
    }
}
