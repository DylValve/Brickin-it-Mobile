using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LegoMobile.Users
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            // tests to see if the user has internet
            try
            {
                // gets the entry values
                string emailEntry = EmailEntry.Text.ToLower();
                string passwordEntry = PasswordEntry.Text;
                //not picking up emails 
                // tests to see if the entrys are empty
                if (EmailEntry.Text == null || PasswordEntry.Text == null)
                {
                    await DisplayAlert("Alert", "Missing one or more parameters", "OK");
                    return;
                }

                // triggers the LoginRequest API response call in the API service
                bool success = await ((App)Application.Current).API.LoginRequest(emailEntry, passwordEntry);

                // tests to see if it is a valid account
                if (success)
                {
                    Console.WriteLine("Login");
                    MainPage();
                }
                else
                {
                    // display alert for invalid account
                    await DisplayAlert("Alert", "Invalid account please try again", "OK");
                    EmailEntry.Text = "";
                    PasswordEntry.Text = "";

                    Console.WriteLine("Entry Denied");
                    return;
                }
            }
            catch
            {
                // display alert for no internet
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Alert", "An error has occurred. Cannot login.", "OK");
                    return;
                });
            }
        }

        public async void MainPage()
        {
            await Navigation.PopModalAsync();
        }
    }
}
