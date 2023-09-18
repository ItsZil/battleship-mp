using System.Net.Http;
using System.Text.Json;
using System.Timers;
using ClientApp.Utilities;
using SharedLibrary.Models;

using Timer = System.Timers.Timer;

namespace ClientApp
{
    public partial class StartForm : Form
    {
        private static HttpUtility httpUtility = new HttpUtility();
        
        public StartForm()
        {
            InitializeComponent();
        }

        private async void GetTestMessageButton_Click(object sender, EventArgs e)
        {
            try
            {
                //var testMessage = await httpUtility.GetAsync<TestMessage>("TestMessage");
            }
            catch (HttpRequestException ex)
            {
            }
        }
    }
}