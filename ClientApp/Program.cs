using System.Diagnostics;

namespace ClientApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();


            // Wait 1.5 seconds to ensure both clients don't get the same ID
            Thread.Sleep(1500);

            // Launch a second instance
            if (args.Length > 0 && args[0] == "client1")
            {
                string client2ExecutableName = "ClientApp2.exe";
                if (File.Exists(client2ExecutableName))
                {
                    File.Delete(client2ExecutableName);
                }
                var fileLocation = Process.GetCurrentProcess().MainModule;
                if (fileLocation != null)
                {
                    File.Copy(fileLocation.FileName, client2ExecutableName);
                    Process.Start(client2ExecutableName, "client2");
                }
            }

            Client client = new Client();

            Application.Run(new StartForm(client));

            //Application.Run(new GameForm(client));
        }
    }
}