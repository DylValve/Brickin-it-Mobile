using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LegoMobile.Users
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            string nameEntry = NameEntry.Text;
            string emailEntry = EmailEntry.Text.ToLower();
            string passwordEntry = PasswordEntry.Text;
            string confirmPasswordEntry = ConfirmPasswordEntry.Text;
            bool success = await ((App)Application.Current).API.RegisterRequest(nameEntry, emailEntry, passwordEntry, confirmPasswordEntry);

            if (success)
            {
                Console.WriteLine("Login");
                MainPage();
            }
            else
            {
                Console.WriteLine("Entry Denied");
            }
        }

        public async void MainPage()
        {
            await Navigation.PopModalAsync();
        }
    }
}