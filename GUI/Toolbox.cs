using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentConstructor
{
    public partial class Toolbox : Form
    {
        public Toolbox()
        {
            InitializeComponent();
            Tool TextTool = new Tool();
            TextTool.Text = "Text";
            TextTool.Image = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("DocumentConstructor.Images.TextTool.png"));
            Tool LineTool = new Tool();
            LineTool.Text = "Line";
            LineTool.Image = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("DocumentConstructor.Images.LineTool.png"));
            Tool BlockTool = new Tool();
            BlockTool.Text = "Block";
            BlockTool.Image = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("DocumentConstructor.Images.BlockTool.png"));
            tableLayoutPanel1.Controls.Add(TextTool);
            tableLayoutPanel1.Controls.Add(LineTool);
            tableLayoutPanel1.Controls.Add(BlockTool);
        }
    }
}
