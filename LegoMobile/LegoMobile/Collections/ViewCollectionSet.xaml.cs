using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LegoMobile.Collections
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewCollectionSet : ContentPage
    {
        string currentCollectionId;

        Sets.Set set;
        public ViewCollectionSet(Sets.Set APISet, string collectionId)
        {
            InitializeComponent();

            currentCollectionId = collectionId;

            set = APISet;

            FillTextBoxes(APISet);
        }

        async void FillTextBoxes(Sets.Set APISet)
        {
            Collection collection = await ((App)Application.Current).API.ShowCollection(currentCollectionId);

            CurrentCollectionTitle.Text = collection.Name;

            fetchSetName.Text = APISet.Name;
            fetchSetNumber.Text = APISet.SetNumber;
            SetImage.Source = "https://brickin-it.herokuapp.com/images/" + APISet.Picture;
            fetchthemeId.Text = APISet.themeId.ToString();
            fetchBarcode.Text = APISet.Barcode;
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            int Id = await ((App)Application.Current).API.ShowCollectionSetId(set.Id.ToString(), currentCollectionId);

            await ((App)Application.Current).API.DeleteCollectionSet(Id);
            
            await Navigation.PopModalAsync();
        }

        private async void backArrow_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}