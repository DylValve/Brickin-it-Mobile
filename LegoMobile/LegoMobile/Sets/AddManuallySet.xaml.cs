using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LegoMobile.NewFolder2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddManuallySet : ContentPage
    {
        public AddManuallySet()
        {
            InitializeComponent();
        }


        private async void AddSetButton_Clicked(object sender, EventArgs e)
        {
            
            string add_set = AddSetName.Text;
            string add_set_number = AddSetNumber.Text;
            string add_picture = AddPicture.Text;
            int add_theme_id = Convert.ToInt32(AddthemeId.Text);
            string add_barcode = AddBarcode.Text;
            await ((App)Application.Current).API.CreateSet(add_set, add_set_number, add_picture, add_theme_id, add_barcode);
            
            LookUpSet LookUpSet = new LookUpSet();
            await Navigation.PushModalAsync(LookUpSet);

        }
    }
}