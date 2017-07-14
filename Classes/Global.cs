using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DocumentConstructor
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

        private static List<int> lineNumber = new List<int>();
        public static int LineNumber
        {
            get
            {
                for (int i = 0; i < lineNumber.Count; i++)
                {
                    if (lineNumber[i] == 0)
                    {
                        lineNumber[i] = 1;
                        return i + 1;
                    }
                }
                lineNumber.Add(1);
                return lineNumber.Count;
            }
            set
            {
                lineNumber[value - 1] = 0;
            }
        }

        private static List<int> textFieldNumber = new List<int>();
        public static int TextFieldNumber
        {
            get
            {
                for(int i = 0; i < textFieldNumber.Count; i++)
                {
                    if (textFieldNumber[i] == 0)
                    {
                        textFieldNumber[i] = 1;
                        return i + 1;
                    }
                }
                textFieldNumber.Add(1);
                return textFieldNumber.Count;
            }
            set
            {
                textFieldNumber[value-1] = 0;
            }
        }

        private static List<int> pictureNumber = new List<int>();
        public static int PictureNumber
        {
            get
            {
                for (int i = 0; i < pictureNumber.Count; i++)
                {
                    if (pictureNumber[i] == 0)
                    {
                        pictureNumber[i] = 1;
                        return i + 1;
                    }
                }
                pictureNumber.Add(1);
                return pictureNumber.Count;
            }
            set
            {
                pictureNumber[value - 1] = 0;
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
