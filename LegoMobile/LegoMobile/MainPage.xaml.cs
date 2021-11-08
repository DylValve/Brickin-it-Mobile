using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LegoMobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        APIService API = ((App)Application.Current).API;

        public MainPage()
        {
            InitializeComponent();

            SwitchMenu();
        }

        public void SwitchMenu()
        {
            if (API.loggedIn == true)
            {
                LoginButton.IsVisible = false;
                SignUpButton.IsVisible = false;
                LogOutButton.IsVisible = true;
                MainMenuButton.IsVisible = true;
            }
            else
            {
                LoginButton.IsVisible = true;
                SignUpButton.IsVisible = true;
                LogOutButton.IsVisible = false;
                MainMenuButton.IsVisible = false;
            }
        }

        public async void LoginPage()
        {
            Users.Login getLoginPage = new Users.Login();
            await Navigation.PushModalAsync(getLoginPage);
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            LoginPage();
        }

        public async void SignUpPage()
        {
            Users.SignUp getSignUpPage = new Users.SignUp();
            await Navigation.PushModalAsync(getSignUpPage);
        }
        private void SignUpButton_Clicked(object sender, EventArgs e)
        {
            SignUpPage();
        }

        public async void MainMenuPage()
        {
            MainMenuPage MainMenu = new MainMenuPage();
            await Navigation.PushModalAsync(MainMenu);
        }

        private void MainMenu_Clicked(object sender, EventArgs e)
        {
            if (API.loggedIn == true)
            {
                MainMenuPage();
            }
            else
            {
                Console.WriteLine("Entry Denied");
            }
        }

        private async void LogOutButton_Clicked(object sender, EventArgs e)
        {
            bool success = await API.LogoutRequest();
            if (success){
                SwitchMenu();
            }
        }

        protected override void OnAppearing()
        {
            SwitchMenu();

            base.OnAppearing();
        }
    }
}
