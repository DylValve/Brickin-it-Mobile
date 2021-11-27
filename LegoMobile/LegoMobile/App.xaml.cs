using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LegoMobile
{
    public partial class App : Application
    {
        // references the API service
        public APIService API { get; set; }

        public App()
        {
            InitializeComponent();
            // creates new reference of API service
            API = new APIService();
            // creates new reference of main page
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
