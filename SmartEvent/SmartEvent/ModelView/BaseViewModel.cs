namespace SmartEvent.ModelView
{
    using SmartEvent.Helpers;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private bool isBusy;

        public WebServices restClient;

        public BaseViewModel()
        {
            restClient = new WebServices();
        }

        public bool IsBusy { get => isBusy; set { isBusy = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual Task LoadData()
        {
            return null;
        }
        public virtual Task PostData()
        {
            return null;
        }
            public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
