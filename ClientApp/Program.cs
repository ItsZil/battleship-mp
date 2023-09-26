using ClientApp.Forms;
using ClientApp.Utilities;
using Microsoft.AspNetCore.SignalR.Client;
using SharedLibrary.Models;
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