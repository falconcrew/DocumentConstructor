using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DocumentContructor
{
    public class Global
    {
        public static void Init()
        {
            SetupAllColors();
            PropertiesForm = new PropertiesForm();
        }

        public static PropertiesForm PropertiesForm
        {
            get;
            private set;
        }

        public static DocumentConstructor DocumentConstructor
        {
            get;
            set;
        }

        private static int lineNumber;
        public static int LineNumber
        {
            get
            {
                return lineNumber++;
            }
        }

        public static List<string> ColorNames
        {
            get;
            set;
        }

        private static void SetupAllColors()
        {
            ColorNames = new List<string>();
            foreach (PropertyInfo property in typeof(Color).GetProperties())
            {
                if (property.PropertyType == typeof(Color))
                {
                    Color c = (Color)property.GetValue(null);
                    ColorNames.Add(c.Name);
                }
            }
        }
    }
}
