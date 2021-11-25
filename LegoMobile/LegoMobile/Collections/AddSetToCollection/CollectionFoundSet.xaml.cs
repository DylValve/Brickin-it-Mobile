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

        void FillTextBoxes(Sets.Set APISet)
        {
            fetchSetName.Text = APISet.Name;
            fetchSetNumber.Text = APISet.SetNumber;
            fetchPicture.Text = APISet.Picture;
            fetchthemeId.Text = APISet.themeId.ToString();
            fetchBarcode.Text = APISet.Barcode;
        }

        private async void AddToCollectionButton_Clicked(object sender, EventArgs e)
        {
            await ((App)Application.Current).API.CreateSetInCollection(set.Id.ToString(), currentCollectionId);

            await Navigation.PopModalAsync();
        }

        private async void backArrow_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}