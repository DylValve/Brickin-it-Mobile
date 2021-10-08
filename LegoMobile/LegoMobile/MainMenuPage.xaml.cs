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
            NewFolder2.LookUpSet LookUpSet = new NewFolder2.LookUpSet();
            await Navigation.PushModalAsync(LookUpSet);
        }

        private void LookUpSetButton_Clicked(object sender, EventArgs e)
        {
            LookUpSetPage();
        }

        public async void ViewAllCollections()
        {
            NewFolder1.ViewAllCollections viewCollections = new NewFolder1.ViewAllCollections();
            await Navigation.PushModalAsync(viewCollections);

        }
        private void ViewCollectionsButton_Clicked(object sender, EventArgs e)
        {
            ViewAllCollections();
        }

        private void ViewWhishlistsButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}