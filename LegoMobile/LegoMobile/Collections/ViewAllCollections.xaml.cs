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
    public partial class ViewAllCollections : ContentPage
    {
        public ViewAllCollections()
        {
            InitializeComponent();
        }

        public async void addCollection()
        {
            AddCollection addCollection = new AddCollection();
            await Navigation.PushModalAsync(addCollection);

        }
        private void AddCollectionsButton_Clicked(object sender, EventArgs e)
        {
            addCollection();

        }
        public async void ViewCollection1()
        {
            ViewCollection viewCollection = new ViewCollection();
            await Navigation.PushModalAsync(viewCollection);

        }
        private void ViewCollection1Button_Clicked(object sender, EventArgs e)
        {
            ViewCollection1();
        }
    }
}