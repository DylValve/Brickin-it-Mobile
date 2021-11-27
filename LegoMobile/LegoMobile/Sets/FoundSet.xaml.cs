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
        /// <summary>
        /// fetching  the parametra from the database and display on the rispective lable
        /// </summary>
        /// <param name="APISet"></param>

        void FillTextBoxes(Set APISet)
        {   
            fetchSetName.Text = APISet.Name;
            fetchSetNumber.Text = APISet.SetNumber;
            SetImage.Source = "https://brickin-it.herokuapp.com/images/" + APISet.Picture;
            fetchthemeId.Text = APISet.themeId.ToString();
            fetchBarcode.Text = APISet.Barcode;
        }
        /// <summary>
        /// delete the set we no longer wish to have
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async void DeleteSetButton_Clicked(object sender, EventArgs e)
        {
            await((App)Application.Current).API.DeleteSet(set.Id.ToString());

            await Navigation.PopModalAsync();
        }
        /// <summary>
        /// return the priewes page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void backArrow_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
