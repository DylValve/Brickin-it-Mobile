using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LegoMobile.Sets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddManuallySet : ContentPage
    {
        Stream imageSource;
        public AddManuallySet()
        {
            InitializeComponent();
        }


        private async void AddSetButton_Clicked(object sender, EventArgs e)
        {
            string setName = AddSetName.Text;
            string setNumber = AddSetNumber.Text;
            Stream picture = imageSource;
            int themeId = Convert.ToInt32(AddthemeId.Text);
            string barcode = AddBarcode.Text;
            await ((App)Application.Current).API.CreateSet(setName, setNumber, picture, themeId, barcode);

            LookUpSet LookUpSet = new LookUpSet();
            await Navigation.PushModalAsync(LookUpSet);
        }

        private async void OnPickPhotoButton_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
            {
                Title = "Please Take a Photo"
            });

            imageSource = await result.OpenReadAsync();
        }
    }
}