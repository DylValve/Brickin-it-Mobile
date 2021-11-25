using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LegoMobile.Collections
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCollection : ContentPage
    {
        public AddCollection()
        {
            InitializeComponent();
        }

        private async void CollectionAddButton_Clicked(object sender, EventArgs e)
        {
            string collectionName = CollectionName.Text;

            await ((App)Application.Current).API.CreateCollections(collectionName);

            ViewAllCollections();
        }


        public async void ViewAllCollections()
        {
            await Navigation.PopModalAsync();
        }

        private async void backArrow_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}