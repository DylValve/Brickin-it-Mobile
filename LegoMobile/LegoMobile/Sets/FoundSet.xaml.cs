using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LegoMobile.Sets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoundSet : ContentPage
    {
        Set set;
        public FoundSet(Set APISet)
        {
            InitializeComponent();

            set = APISet;

            FillTextBoxes(APISet);
        }

        void FillTextBoxes(Set APISet)
        {
            fetchSetName.Text = APISet.Name;
            fetchSetNumber.Text = APISet.SetNumber;
            SetImage.Source = "https://brickin-it.herokuapp.com/images/" + APISet.Picture;
            fetchthemeId.Text = APISet.themeId.ToString();
            fetchBarcode.Text = APISet.Barcode;
        }

        private async void DeleteSetButton_Clicked(object sender, EventArgs e)
        {
            await((App)Application.Current).API.DeleteSet(set.Id.ToString());

            await Navigation.PopModalAsync();
        }

        private async void backArrow_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}