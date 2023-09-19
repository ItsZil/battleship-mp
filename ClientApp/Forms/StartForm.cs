using ClientApp.Utilities;

namespace ClientApp
{
    public partial class StartForm : Form
    {
        private static HttpUtility _httpUtility = new HttpUtility();

        public StartForm(Client client)
        {
            InitializeComponent();
        }
    }
}