using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace LegoMobile.Sets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddManuallySet : ContentPage
    {
        Stream imageSource;
        string barcodeNum;
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
            string barcode = barcodeNum;
            await ((App)Application.Current).API.CreateSet(setName, setNumber, picture, themeId, barcode);

            LookUpSet LookUpSet = new LookUpSet();
            await Navigation.PushModalAsync(LookUpSet);
        }

        private async void OnPickPhotoButton_Clicked(object sender, EventArgs e)
        {
            /*
            var result = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
            {
                Title = "Please Take a Photo"
            });

            imageSource = await result.OpenReadAsync();
            */

            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please Pick a Photo"
            });

            imageSource = await result.OpenReadAsync();
        }

        private async void BarcodeButton_Clicked(object sender, EventArgs e)
        {
            BarcodeScanner.IsVisible = true;
            AddSetMenu.IsVisible = false;

            await delay();
        }

        public void scanView_OnScanResult(Result result)
        {
            barcodeNum = result.Text;

            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Scanned result", "The barcode's text is " + result.Text + ". The barcode's format is " + result.BarcodeFormat, "OK");
            });
        }

        public async Task delay()
        {
            await Task.Delay(3000);
            AddSetMenu.IsVisible = true;
            BarcodeScanner.IsVisible = false;
        }
    }
}