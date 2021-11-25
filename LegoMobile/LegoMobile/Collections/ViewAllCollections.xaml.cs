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
            InitialiseUIFromCode();
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
        public async void ViewCollection1(string collectionId)
        {
            ViewCollection viewCollection = new ViewCollection(collectionId);
            await Navigation.PushModalAsync(viewCollection);

        }
        private void ViewCollection1Button_Clicked(object sender, EventArgs e)
        {

        }

        public async void InitialiseUIFromCode()
        {
            List<Collection> collectionList = await ((App)Application.Current).API.ShowCollections();
            StackCollection.Children.Clear();
            foreach (Collection userCollection in collectionList)
            {
                StackLayout stack = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,

                };

                Label collectionLabel = new Label()
                {
                    Text = $"{userCollection.Name}",
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    FontSize = 23,
                };
                stack.Children.Add(collectionLabel);

                Button collectionViewButton = new Button()
                {
                    Text = "View Sets",
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    StyleId = userCollection.Id.ToString(),
                    TextColor = Color.White,
                    BackgroundColor = Color.FromHex("#f2b705"),
                    CornerRadius = 25,
                    Margin = 5
                };             
                collectionViewButton.Clicked += DynamicViewBtn_Clicked;
                stack.Children.Add(collectionViewButton);
                
                Button DeleteButton = new Button()
                {
                    Text = "Delete",
                    HorizontalOptions = LayoutOptions.End,
                    StyleId = userCollection.Id.ToString(),
                    TextColor = Color.White,
                    BackgroundColor = Color.Red,
                    CornerRadius = 25,
                    Margin = 5
                };
                DeleteButton.Clicked += DynamicDeleteBtn_Clicked;
                stack.Children.Add(DeleteButton);

                StackCollection.Children.Add(stack);
            }
        }

        

        private async void DynamicDeleteBtn_Clicked(object sender, EventArgs e)
        {
            var myBtn = sender as Button;
            // who called me?
            var myId = myBtn.StyleId; //this was set during dynamic creation

            await ((App)Application.Current).API.DeleteCollections(myId);

            InitialiseUIFromCode();
        }

        private void DynamicViewBtn_Clicked(object sender, EventArgs e)
        {
            var myBtn = sender as Button;
            // who called me?
            var myId = myBtn.StyleId; //this was set during dynamic creation

            ViewCollection1(myId);
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