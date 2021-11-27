using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LegoMobile
{
    public partial class MainPage : ContentPage
    {
        APIService API = ((App)Application.Current).API; // Reference to the API requests that can be called

        public MainPage()
        {
            InitializeComponent();

            SwitchMenu(); // triggers the switch menu function
        }

        public void SwitchMenu()
        {
            // changes the buttons that appear on the main menu
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
            // navigates to the login page
            Users.Login getLoginPage = new Users.Login();
            await Navigation.PushModalAsync(getLoginPage);
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            // triggers login page function
            LoginPage();
        }

        public async void SignUpPage()
        {
            // navigates to the sign up page
            Users.SignUp getSignUpPage = new Users.SignUp();
            await Navigation.PushModalAsync(getSignUpPage);
        }
        private void SignUpButton_Clicked(object sender, EventArgs e)
        {
            // triggers the sign up page funtion
            SignUpPage();
        }

        public async void MainMenuPage()
        {
            // navigates to the main menu page
            MainMenuPage MainMenu = new MainMenuPage();
            await Navigation.PushModalAsync(MainMenu);
        }

        private void MainMenu_Clicked(object sender, EventArgs e)
        {
            // triggers the main menu page function after checking if a user is logged in
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
            // logs the user out
            bool success = await API.LogoutRequest();
            if (success) // triggers the switch menu function
            {
                SwitchMenu();
            }
        }

        protected override void OnAppearing()
        {
            // triggers the switch menu function
            SwitchMenu();

            base.OnAppearing();
        }
    }
}
