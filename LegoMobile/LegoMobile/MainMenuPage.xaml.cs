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
            // navigates to the look up page
            Sets.LookUpSet lookUpSet = new Sets.LookUpSet();
            await Navigation.PushModalAsync(lookUpSet);
        }

        private void LookUpSetButton_Clicked(object sender, EventArgs e)
        {
            // triggers the look up set page function
            LookUpSetPage();
        }

        public async void ViewAllCollections()
        {
            // navigates to the view collections page
            Collections.ViewAllCollections viewCollections = new Collections.ViewAllCollections();
            await Navigation.PushModalAsync(viewCollections);
        }
        private void ViewCollectionsButton_Clicked(object sender, EventArgs e)
        {
            // triggers the view collections function
            ViewAllCollections();
        }

        private void BarcodeButton_Clicked(object sender, EventArgs e)
        {
            // triggers the view scan page function
            ScanPage();
        }

        public async void ScanPage()
        {
            // navigates to the scan page
            Sets.Set set = new Sets.Set();
            ScanPage scanPage = new ScanPage(set);
            await Navigation.PushModalAsync(scanPage);
        }

        private async void backArrow_Clicked(object sender, EventArgs e)
        {
            // goes back to the previous page
            await Navigation.PopModalAsync();
        }
    }
}
