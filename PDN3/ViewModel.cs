using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PDN3
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Film> Filmy { get; set; }

        public ViewModel() 
        {
            Filmy =
            [
                new Film
                {

                },
            ];
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
