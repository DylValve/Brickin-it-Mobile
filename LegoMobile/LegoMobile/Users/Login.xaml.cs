using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            string emailEntry = EmailEntry.Text.ToLower();
            string passwordEntry = PasswordEntry.Text;
            //not picking up emails
            if (EmailEntry.Text == null || PasswordEntry.Text == null)
            {
                await DisplayAlert("Alert", "Missing one or more parameters", "OK");
                return;
            }
            bool success = await ((App)Application.Current).API.LoginRequest(emailEntry, passwordEntry);

            if (success)
            {
                Console.WriteLine("Login");
                MainPage();
            }
            else
            {
                await DisplayAlert("Alert", "Invalid account please try again", "OK");
                EmailEntry.Text = "";
                PasswordEntry.Text = "";

                Console.WriteLine("Entry Denied");
                return;
            }
        }

        public async void MainPage()
        {
            await Navigation.PopModalAsync();
        }
    }
}
