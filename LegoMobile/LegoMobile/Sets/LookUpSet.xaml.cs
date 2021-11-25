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
    public partial class LookUpSet : ContentPage
    {
        public LookUpSet()
        {
            InitializeComponent();
        }
        public async void APIFoundSet(Set APISet)
        {
            if (APISet == null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Alert", "Set not found", "OK");
                    return;
                });
            }
            else
            {
                FoundSet foundSet = new FoundSet(APISet);

                await Navigation.PushModalAsync(foundSet);
            }
        }



        private async void FetchAPIButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                string setNumer = setEntryName.Text;
                if (setEntryName.Text == null)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await DisplayAlert("Alert", "Set not found.", "OK");
                        return;
                    });
                }
                else
                {
                    Set APISet = await ((App)Application.Current).API.ShowSet(setNumer);

                    APIFoundSet(APISet);
                }
            }
            catch (Exception exc)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Alert", "Set not found.", "OK");
                    return;
                });
            }
        }

        public async void AddManuallyPage()
        {
            AddManuallySet addManuall = new AddManuallySet();
            await Navigation.PushModalAsync(addManuall);
        }


        private void AddManuallyButton_Clicked(object sender, EventArgs e)
        {
            AddManuallyPage();
        }
        private void ScanBarcodeButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "Set not Found", "OK");
        }

        private async void backArrow_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
