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
                DisplayAlert("Fuck");
            }
            else
            {
                FoundSet foundSet = new FoundSet(APISet);
                DisplayAlert(APISet.Name);
                await Navigation.PushModalAsync(foundSet);
            }
        }

        private void DisplayAlert(string name)
        {
            throw new NotImplementedException();
        }

        private async void FetchAPIButton_Clicked(object sender, EventArgs e)
        {
            string setNumer = setEntryName.Text;
            Set APISet = await ((App)Application.Current).API.viewSet(setNumer);
            
            APIFoundSet(APISet);

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
    }
}