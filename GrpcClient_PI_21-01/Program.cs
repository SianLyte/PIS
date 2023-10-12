namespace GrpcClient_PI_21_01
{
    internal static class Program
    {
        readonly static bool DevTest = false; // instead of opening the main form
                                              // it will open sample form for testing

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            if (DevTest)
                Application.Run(new Form1());
            else Application.Run(new AutorizationForm());
        }
    }
}