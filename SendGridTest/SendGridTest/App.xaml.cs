using SendGridTest.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SendGridTest
{
    /// <summary>
    /// App
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        /// <summary>
        /// OnStart override
        /// </summary>
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        /// <summary>
        /// OnSleep override
        /// </summary>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        /// <summary>
        /// OnResume override
        /// </summary>
        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
