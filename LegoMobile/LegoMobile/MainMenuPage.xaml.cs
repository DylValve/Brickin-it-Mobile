using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LegoMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }
        public async void LookUpSetPage()
        {
            Sets.LookUpSet lookUpSet = new Sets.LookUpSet();
            await Navigation.PushModalAsync(lookUpSet);
        }

        private void LookUpSetButton_Clicked(object sender, EventArgs e)
        {
            LookUpSetPage();
        }

        public async void ViewAllCollections()
        {
            List<Collections.Collection> collections = await ((App)Application.Current).API.ShowCollections();
            Collections.ViewAllCollections viewCollections = new Collections.ViewAllCollections();
            await Navigation.PushModalAsync(viewCollections);
        }
        private void ViewCollectionsButton_Clicked(object sender, EventArgs e)
        {
            ViewAllCollections();
        }

        private void BarcodeButton_Clicked(object sender, EventArgs e)
        {
            ScanPage();
        }

        public async void ScanPage()
        {
            ScanPage scanPage = new ScanPage();
            await Navigation.PushModalAsync(scanPage);
        }
    }
}