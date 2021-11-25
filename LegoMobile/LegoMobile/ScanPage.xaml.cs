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

            newSet = set;
        }

        public void scanView_OnScanResult(Result result)
        {
            newSet.Barcode = result.Text;

            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Scanned result", "The barcode's text is " + result.Text + ". The barcode's format is " + result.BarcodeFormat, "OK");
                await Navigation.PopModalAsync();
            });
        }
    }
}