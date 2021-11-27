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

        /// <summary>
        /// creating a new set and send through via API
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// open the gallery on the device with picture to choose and added to theset we are creating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnPickPhotoButton_Clicked(object sender, EventArgs e)
        {
           
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
        /// <summary>
        /// allow to scan barcode on the set we like to retrive information 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BarcodeButton_Clicked(object sender, EventArgs e)
        {
            ScanPage scanPage = new ScanPage(newSet);
            await Navigation.PushModalAsync(scanPage);
        }
        /// <summary>
        /// allow the user to navigate back pages 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void backArrow_Clicked(object sender, EventArgs e)
        {
          
            await Navigation.PopModalAsync();
        }
    }
}
