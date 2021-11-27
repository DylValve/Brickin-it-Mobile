using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LegoMobile.Collections.AddSetToCollection
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionLookUpSet : ContentPage
    {
        string currentCollectionId;
        public CollectionLookUpSet(string collectionId)
        {
            InitializeComponent();

            currentCollectionId = collectionId;
        }
        /// <summary>
        /// looking for available sets
        /// </summary>
        /// <param name="APISet"></param>
        public async void APIFoundSet(Sets.Set APISet)
        {
            if (APISet == null)
            {
                DisplayAlert("NO working");
            }
            else
            {
                CollectionFoundSet foundSet = new CollectionFoundSet(APISet, currentCollectionId);

                await Navigation.PushModalAsync(foundSet);
            }
        }

        private void DisplayAlert(string name)
        {
            throw new NotImplementedException();
        }

        private async void CollectionFetchAPIButton_Clicked(object sender, EventArgs e)
        {
            string setNumer = setEntryNumber.Text;
            Sets.Set APISet = await ((App)Application.Current).API.ShowSet(setNumer);

            APIFoundSet(APISet);

        }

        public async void AddManuallyPage()
        {
            CollectionAddManuallySet addManuall = new CollectionAddManuallySet();
            await Navigation.PushModalAsync(addManuall);
        }


        private void CollectionAddManuallyButton_Clicked(object sender, EventArgs e)
        {
            AddManuallyPage();
        }
        private void CollectionScanBarcodeButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "Set not Found", "OK");
        }
        /// <summary>
        /// To allow the top bar back button to pop back to the previous page 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void backArrow_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}