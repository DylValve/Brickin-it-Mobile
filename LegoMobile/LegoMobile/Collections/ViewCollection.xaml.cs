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

        /// <summary>
        /// This will create a Label and 2 buttons for every objacet in the list on collections
        /// The lable will be the Set Name 
        /// One Button wil be for view sets inforamtion 
        /// The last on is to delete button
        /// style is also applied to in C# for the labe and button
        /// </summary>
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

        /// <summary>
        /// Will Delete the Colletion for the users list of colections
        /// if pressed an alert will dispaly as a confimation for the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DynamicDeleteBtn_Clicked(object sender, EventArgs e)
        {
            var myBtn = sender as Button;
            // who called me?
            var myId = myBtn.StyleId; //this was set during dynamic creation

            await ((App)Application.Current).API.DeleteCollections(myId);

            InitialiseUIFromCode();

        }
        /// <summary>
        /// Used to get the list of sets associated to the collections
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DynamicViewBtn_Clicked(object sender, EventArgs e)
        {
            var myBtn = sender as Button;
            //This is the button sending a signal
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

        /// <summary>
        /// To allow the top bar back button to pop back to the previous page 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void backArrow_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}