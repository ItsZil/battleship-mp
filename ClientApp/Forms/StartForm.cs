using System.Net.Http;
using System.Text.Json;
using ClientApp.Utilities;
using SharedLibrary.Models;

namespace ClientApp
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private async void GetTestMessageButton_Click(object sender, EventArgs e)
        {
            HttpUtility httpClient = new HttpUtility();
            try
            {
                var testMessage = await httpClient.GetAsync<TestMessage>("TestMessage");
            }
            catch (HttpRequestException ex)
            {
            }
        }
    }
}