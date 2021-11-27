﻿using System;
using System.Collections.Generic;
using System.Linq;
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


        public async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            try
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
                    if (nameEntry == null || emailEntry == null || passwordEntry == null || confirmPasswordEntry == null)
                    {
                        await DisplayAlert("Alert", "Missing one or more parameters", "ok");
                        return;
                    }
                    if (passwordEntry != confirmPasswordEntry)
                    {
                        await DisplayAlert("Alert", "Passwords don't match", "ok");
                        PasswordEntry.Text = "";
                        ConfirmPasswordEntry.Text = "";
                        return;
                    }

                    Console.WriteLine("Entry Denied");
                    return;
                }
            }
            catch
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Alert", "An error has occurred. Cannot register an account.", "OK");
                    return;
                });
            }
        }

        public async void MainPage()
        {
            await Navigation.PopModalAsync();
        }

/*        public async void AlrtUser()
        {
            string nameEntry = NameEntry.Text;
            string emailEntry = EmailEntry.Text.ToLower();
            string passwordEntry = PasswordEntry.Text;
            string confirmPasswordEntry = ConfirmPasswordEntry.Text;

            // will not catch the  name

            if (nameEntry == null)
            {
                await DisplayAlert("Alert", "Enter your username", "ok");
                return;
            }
            // will not catch the emial if null  
            else if (emailEntry == null)
            {
                await DisplayAlert("Alert", "Enter your Email", "ok");
                return;
            }
            // will not catch the passwordEntry if null  
            else if (passwordEntry == null)
            {
                await DisplayAlert("Alert", "Enter your password", "ok");
                return;
            }
            // will not catch the 
            else if (confirmPasswordEntry == null)
            {
                await DisplayAlert("Alert", "Confirm your password", "ok");
                return;
            }

        }*/
    }
}