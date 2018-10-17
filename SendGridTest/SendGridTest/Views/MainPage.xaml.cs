using SendGridTest.ViewModels;
using Xamarin.Forms;

namespace SendGridTest.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }
}
