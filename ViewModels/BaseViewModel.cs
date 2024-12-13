using ACSVisualization.Common;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ACSVisualization.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel()
        {
            EventAggregator.Instance.Subsribe(this);
        }

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
