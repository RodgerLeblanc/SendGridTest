using Xamarin.Forms;

namespace SendGridTest.ViewModels
{
    /// <summary>
    /// MainPageViewModel
    /// </summary>
    public class MainPageViewModel : BaseViewModel<MainPageViewModel>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MainPageViewModel() : base()
        {
            PropertyChangedManager
                .AddPropertyChanged(vm => vm.To, (s, o) => SendEmailCommand.ChangeCanExecute())
                .AddPropertyChanged(vm => vm.Subject, (s, o) => SendEmailCommand.ChangeCanExecute())
                .AddPropertyChanged(vm => vm.Body, (s, o) => SendEmailCommand.ChangeCanExecute());
        }

        /// <summary>
        /// To
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Body
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// SendEmailCommand
        /// </summary>
        public Command SendEmailCommand { get; set; }

        /// <summary>
        /// Initialize commands
        /// </summary>
        protected override void InitializeCommands()
        {
            base.InitializeCommands();

            SendEmailCommand = new Command(SendEmail, CanSendEmail);
        }

        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="obj"></param>
        private void SendEmail(object obj)
        {
        }

        /// <summary>
        /// SendEmailCommand can execute
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool CanSendEmail(object arg)
        {
            return !string.IsNullOrWhiteSpace(To) &&
                !string.IsNullOrWhiteSpace(Subject) &&
                !string.IsNullOrWhiteSpace(Body);
        }
    }
}
