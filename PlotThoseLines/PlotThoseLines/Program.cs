namespace PlotThoseLines
{
    internal static class Program
    {
        public static List<Serie> series = new List<Serie>();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //https://github.com/ExcelDataReader/ExcelDataReader?tab=readme-ov-file#important-note-on-net-core
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new HomeForm());
        }
    }
}