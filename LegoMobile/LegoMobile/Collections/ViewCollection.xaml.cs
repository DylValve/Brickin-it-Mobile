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
    public partial class ViewCollection : ContentPage
    {
        public ViewCollection()
        {
            InitializeComponent();
        }
        public async void ViewColletionSet()
        {
            ViewCollectionSet viewCollectionSet = new ViewCollectionSet();
            await Navigation.PushModalAsync(viewCollectionSet);
        }



        private void ViewSet1Button_Clicked(object sender, EventArgs e)
        {
            ViewColletionSet();
        }
        public async void AddSettoColletion()
        {
            AddSetToCollection.CollectionLookUpSet addSettoColletion = new AddSetToCollection.CollectionLookUpSet();
            await Navigation.PushModalAsync(addSettoColletion);
        }

        private void AddSetButton_Clicked(object sender, EventArgs e)
        {
            AddSettoColletion();
        }
    }
}