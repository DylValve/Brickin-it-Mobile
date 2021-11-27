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
    public partial class CollectionFoundSet : ContentPage
    {
        string currentCollectionId;

        Sets.Set set;
        public CollectionFoundSet(Sets.Set APISet, string collectionId)
        {
            InitializeComponent();

            currentCollectionId = collectionId;

            set = APISet;

            FillTextBoxes(APISet);
        }
        /// <summary>
        /// Fill all the labels with the information about the selected set 
        /// </summary>
        /// <param name="APISet"></param>
        void FillTextBoxes(Sets.Set APISet)
        {
            fetchSetName.Text = APISet.Name;
            fetchSetNumber.Text = APISet.SetNumber;
            fetchPicture.Text = APISet.Picture;
            fetchthemeId.Text = APISet.themeId.ToString();
            fetchBarcode.Text = APISet.Barcode;
        }
        /// <summary>
        /// Will Add the found set to the collection 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AddToCollectionButton_Clicked(object sender, EventArgs e)
        {
            await ((App)Application.Current).API.CreateSetInCollection(set.Id.ToString(), currentCollectionId);

            await Navigation.PopModalAsync();
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