using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Nevala
{
    /// <summary>
    /// A base view model that fires Property Changed events as needed
    /// </summary>
    //[ImplementPropertyChanged]
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged<T>(ref T property, T value, [CallerMemberName] string propertyName = "")
        {
            property = value;
            var Handler = PropertyChanged;
            if (Handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
