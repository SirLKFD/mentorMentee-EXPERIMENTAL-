using mentorMentee.Models;

namespace mentorMentee
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {

        }

        private void btnCreate_Clicked(object sender, EventArgs e)
        {

        }

        // Check Database Connection Button
        private async void btnTest_Clicked(object sender, EventArgs e)
        {
            // Check if WiFi or internet connectivity is available
            var current = Connectivity.NetworkAccess;
            if (current != NetworkAccess.Internet)
            {
                await DisplayAlert("Connection Test", "No internet connection found. Please enable WiFi or connect to the internet and try again.", "OK");
                return;
            }

            // Test database connection
            bool isConnected = await Database.TestConnectionAsync();
            if (isConnected)
            {
                await DisplayAlert("Connection Test", "Connection successful!", "OK");
            }
            else
            {
                await DisplayAlert("Connection Test", "Connection failed.", "OK");
            }
        }

        private async void btnInsert_Clicked(object sender, EventArgs e)
        {
            // Check if WiFi or internet connectivity is available
            var current = Connectivity.NetworkAccess;
            if (current != NetworkAccess.Internet)
            {
                await DisplayAlert("Insert Data", "No internet connection found. Please enable WiFi or connect to the internet and try again.", "OK");
                return;
            }

            // Get data from Entry field
            string dataToInsert = entryInsertData.Text;

            if (string.IsNullOrWhiteSpace(dataToInsert))
            {
                await DisplayAlert("Insert Data", "Please enter data to insert.", "OK");
                return;
            }

            bool isInserted = await Database.InsertDataAsync(dataToInsert);
            if (isInserted)
            {
                await DisplayAlert("Insert Data", "Data inserted successfully!", "OK");
            }
            else
            {
                await DisplayAlert("Insert Data", "Failed to insert data.", "OK");
            }
        }











    }

}
