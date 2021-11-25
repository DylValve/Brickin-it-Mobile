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
        Set newSet = new Set();
        public AddManuallySet()
        {
            InitializeComponent();
        }


        private async void AddSetButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                newSet.Name = AddSetName.Text;
                newSet.SetNumber = AddSetNumber.Text;

                Stream picture = imageSource;

                newSet.themeId = Convert.ToInt32(AddthemeId.Text);

                await ((App)Application.Current).API.CreateSet(newSet.Name, newSet.SetNumber, picture, newSet.themeId, newSet.Barcode);

                await Navigation.PopModalAsync();
            }
            catch (Exception exc)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    Console.WriteLine(exc);

                    await DisplayAlert("Invalid Values", "Please fill all the information", "OK");
                });
            }
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


            try
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Please Pick a Photo"
                });

                if (result != null)
                {
                    imageSource = await result.OpenReadAsync();
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

        }

        private async void BarcodeButton_Clicked(object sender, EventArgs e)
        {
            ScanPage scanPage = new ScanPage(newSet);
            await Navigation.PushModalAsync(scanPage);
        }

        private async void backArrow_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
