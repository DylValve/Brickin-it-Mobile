using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace LegoMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanPage : ContentPage
    {
        public string barcodeValue;

        Sets.Set newSet; 
        public ScanPage(Sets.Set set)
        {
            InitializeComponent();

            newSet = set; // Makes the newSet value equal the set reference
        }

        public void scanView_OnScanResult(Result result)
        {
            newSet.Barcode = result.Text; // Gets the barcode scan result number

            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Scanned result", "The barcode's text is " + result.Text + ". The barcode's format is " + result.BarcodeFormat, "OK"); // Displays alert about the scanned barcode
                await Navigation.PopModalAsync();
            });
        }
    }
}
