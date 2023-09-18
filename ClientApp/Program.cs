using ClientApp.Utilities;
using SharedLibrary.Models;
using System.Diagnostics;
using System.Reflection;

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

            HttpUtility httpUtility = new HttpUtility();
            SharedLibrary.Models.Message result = httpUtility.Post<SharedLibrary.Models.Message>("api/server/SubscribeToObserver");
            MessageBox.Show(result.MessageText);

            Application.Run(new StartForm());
        }
    }
}