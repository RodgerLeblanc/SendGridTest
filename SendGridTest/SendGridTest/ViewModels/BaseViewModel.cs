using SendGridTest.Helpers;
using System.ComponentModel;

namespace SendGridTest.ViewModels
{
    /// <summary>
    /// BaseViewModel
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            InitializeCommands();
        }

        /// <summary>
        /// Initialize commands
        /// </summary>
        protected virtual void InitializeCommands()
        {
        }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// IsBusy
        /// </summary>
        public bool IsBusy { get; set; }

        /// <summary>
        /// PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raise PropertyChanged event for the specified property
        /// </summary>
        /// <param name="propertyName"></param>
        protected void RaisePropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// BaseViewModel
    /// </summary>
    public abstract class BaseViewModel<TModel> : BaseViewModel
        where TModel : BaseViewModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BaseViewModel() : base()
        {
            PropertyChangedManager = new PropertyChangedManager<TModel>();
            PropertyChanged += PropertyChangedManager.OnPropertyChanged;
        }

        /// <summary>
        /// PropertyChangedManager
        /// </summary>
        public PropertyChangedManager<TModel> PropertyChangedManager { get; }
    }
}
