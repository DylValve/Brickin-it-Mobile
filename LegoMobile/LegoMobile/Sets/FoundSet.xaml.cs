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
    public partial class FoundSet : ContentPage
    {
        public FoundSet(Set APISet)
        {
            InitializeComponent();
            FillTextBoxes(APISet);
        }

        void FillTextBoxes(Set APISet)
        {
            fetchSetName.Text = APISet.Name;
            fetchSetNumber.Text = APISet.SetNumber;
            fetchPicture.Text = APISet.Picture;
            fetchthemeId.Text = APISet.themeId.ToString();
            fetchBarcode.Text = APISet.Barcode;
        }
    }
}