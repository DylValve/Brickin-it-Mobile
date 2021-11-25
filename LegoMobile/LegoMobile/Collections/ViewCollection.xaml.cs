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
        string currentCollectionId;
        public ViewCollection(string collectionId)
        {
            InitializeComponent();

            currentCollectionId = collectionId;

            InitialiseUIFromCode();
        }

        public async void AddSettoColletion()
        {
            AddSetToCollection.CollectionLookUpSet addSettoColletion = new AddSetToCollection.CollectionLookUpSet(currentCollectionId);
            await Navigation.PushModalAsync(addSettoColletion);
        }

        private void AddSetButton_Clicked(object sender, EventArgs e)
        {
            AddSettoColletion();
        }

        public async void InitialiseUIFromCode()
        {
            Collection collection = await ((App)Application.Current).API.ShowCollection(currentCollectionId);

            CurrentCollectionTitle.Text = collection.Name;

            List<Sets.Set> setList = await ((App)Application.Current).API.ShowCollectionSets(currentCollectionId);
            StackSet.Children.Clear();
            foreach (Sets.Set collectionSet in setList)
            {
                StackLayout stack = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };

                Label collectionSetLabel = new Label()
                {
                    Text = $"{collectionSet.Name}",
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    FontSize = 23,
                };

                stack.Children.Add(collectionSetLabel);
                Button collectionSetButton = new Button()
                {
                    Text = "View Set",
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    StyleId = collectionSet.Id.ToString(),
                    TextColor = Color.White,
                    BackgroundColor = Color.FromHex("#f2b705"),
                    CornerRadius = 25,
                    Margin = 5
                };
                collectionSetButton.Clicked += DynamicViewBtn_Clicked;
                stack.Children.Add(collectionSetButton);

                Button DeleteButton = new Button()
                {
                    Text = "Delete",
                    HorizontalOptions = LayoutOptions.End,
                    StyleId = collectionSet.Id.ToString(),
                    TextColor = Color.White,
                    BackgroundColor = Color.Red,
                    CornerRadius = 25,
                    Margin= 5
                };
                DeleteButton.Clicked += DynamicDeleteBtn_Clicked;
                stack.Children.Add(DeleteButton);

                StackSet.Children.Add(stack);
            }
        }

        private async void DynamicDeleteBtn_Clicked(object sender, EventArgs e)
        {
            var myBtn = sender as Button;
            // who called me?
            var setId = myBtn.StyleId; //this was set during dynamic creation

            int Id = await ((App)Application.Current).API.ShowCollectionSetId(setId, currentCollectionId);

            await ((App)Application.Current).API.DeleteCollectionSet(Id);

            InitialiseUIFromCode();
        }

        private async void DynamicViewBtn_Clicked(object sender, EventArgs e)
        {
            var myBtn = sender as Button;
            // who called me?
            var setId = myBtn.StyleId; //this was set during dynamic creation


            Sets.Set set = await ((App)Application.Current).API.ShowSetInCollection(setId);

            ViewCollectionSet viewCollectionSet = new ViewCollectionSet(set, currentCollectionId);
            await Navigation.PushModalAsync(viewCollectionSet);
        }

        protected override void OnAppearing()
        {
            InitialiseUIFromCode();

            base.OnAppearing();
        }

        private async void backArrow_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}