using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LegoMobile
{
    public partial class App : Application
    {
        public APIService API { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            API = new APIService();
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
