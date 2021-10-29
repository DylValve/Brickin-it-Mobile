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
            string emailEntry = EmailEntry.Text;
            string passwordEntry = PasswordEntry.Text;
            bool success = await ((App)Application.Current).API.LoginRequest(emailEntry, passwordEntry);

            if (success)
            {
                Console.WriteLine("Login");
            }
            else
            {
                Console.WriteLine("Entry Denied");
            }
        }

        public async void MainPage()
        {
            await Navigation.PopAsync();
        }
    }
}