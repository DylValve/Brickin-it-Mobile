using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LegoMobile.NewFolder1.AddSetToCollection
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionLookUpSet : ContentPage
    {
        public CollectionLookUpSet()
        {
            InitializeComponent();
        }

        public async void CollectionAPIFoundSet()
        {
            CollectionFoundSet collectionSetfoundSet = new CollectionFoundSet();
            await Navigation.PushModalAsync(collectionSetfoundSet);
        }
        private void CollectionFetchAPIButton_Clicked(object sender, EventArgs e)
        {
            CollectionAPIFoundSet();
        }

        public async void CollectionAddManuallyPage()
        {
            CollectionAddManuallySet collectionfoundSet = new CollectionAddManuallySet();
            await Navigation.PushModalAsync(collectionfoundSet);
        }
        private void CollectionAddManuallyButton_Clicked(object sender, EventArgs e)
        {
            CollectionAddManuallyPage();
        }

        public async void CollectionScanBarcode()
        {
            CollectionAddManuallySet collectionfoundSet = new CollectionAddManuallySet();
            await Navigation.PushModalAsync(collectionfoundSet);
        }
        private void CollectionScanBarcodeButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "Set not Found", "OK");
        }
    }
}