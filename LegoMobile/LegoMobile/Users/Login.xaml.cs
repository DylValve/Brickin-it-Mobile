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

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            string UsernameAPI = "test";
            string PasswordAPI = "test";
            string Token = "test";
            string NewToken = "NewToken";
            string EnteredUsername = UsernameEntry.Text;
            string EnteredPassword = PasswordEntry.Text;

            if (EnteredUsername == UsernameAPI)
            {
                if (EnteredPassword == PasswordAPI)
                {
                    Console.WriteLine("Login");
                    Token = NewToken;
                    if (Token == NewToken)
                    {
                        MainPage();
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect Password");
                }
            }
            else
            {
                Console.WriteLine("Invalid User");
            }
        }

        public async void MainPage()
        {
            await Navigation.PopAsync();
        }
    }
}