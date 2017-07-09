namespace DocumentContructor
{
    public class Global
    {
        public static void Init()
        {
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
    }
}
