using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentConstructor
{
    public partial class DocumentConstructor : Form
    {
        public List<Label> Document;
        public bool AddControl;
        public string ControlType;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr LoadCursorFromFile(string fileName);

        public void SetCursor(string type)
        {
            string path = Directory.GetCurrentDirectory() + "\\temp.cur";
            var fileStream = File.Create(path);
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DocumentConstructor.Images." + type + "Cursor.cur");
            stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(fileStream);
            fileStream.Close();
            Cursor = new Cursor(LoadCursorFromFile(path));
            File.Delete(path);
        }

        public DocumentConstructor()
        {
            Global.Init();
            ControlFunction.Init();
            InitializeComponent();
            Global.PropertiesForm.Show();
            Toolbox tb = new Toolbox();
            tb.Show();

            Block block = new Block();
            Controls.Add(block);
            Line line = new Line();
            Controls.Add(line);
            Global.DocumentConstructor = this;
        }

        private void FormClick(object sender, EventArgs e)
        {
            if (AddControl)
            {
                Control control = new Control();
                switch (ControlType)
                {
                    case "Text":
                        control = new TextField();
                        break;
                    case "Line":
                        control = new Line();
                        break;
                    case "Block":
                        control = new Block();
                        break;
                }
                control.Location = new Point(MousePosition.X - Location.X-6, MousePosition.Y - Location.Y-32);
                Controls.Add(control);
                Cursor = Cursors.Default;
                Invalidate();
            }
            AddControl = false;

        }
    }
}
