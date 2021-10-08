using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        public MainPage()
        {
            InitializeComponent();
        }
        public async void LoginPage()
        {
            Users.Login getloginPage = new Users.Login();
            await Navigation.PushModalAsync(getloginPage);
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            LoginPage();
        }


        public async void SighupPage()
        {
            Users.SignUp getsighupPage = new Users.SignUp();
            await Navigation.PushModalAsync(getsighupPage);
        }
        private void SignupButton_Clicked(object sender, EventArgs e)
        {
            SighupPage();
        }

        public async void MainMenuPage()
        {
            MainMenuPage MainMenu = new MainMenuPage();
            await Navigation.PushModalAsync(MainMenu);
        }

        private void MainMenu_Clicked(object sender, EventArgs e)
        {
            MainMenuPage();
        }
    }
}
