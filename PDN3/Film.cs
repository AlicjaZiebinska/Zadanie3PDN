using System.ComponentModel;

namespace PDN3
{
    public class Film : ICloneable, INotifyPropertyChanged
    {
        private string tytul;
        private string rezyser;
        private string wydawca;
        private string nosnik;

        public string Tytul { get => tytul; set
            {
                tytul = value;
                OnPropertyChanged(nameof(Tytul));
            }
        }

        public string Rezyser { get => rezyser; set
            {
                rezyser = value;
                OnPropertyChanged(nameof(Rezyser));
            }
        }
        public string Wydawca { get => wydawca; set
            {
                wydawca = value;
                OnPropertyChanged(nameof(Wydawca));
            }
        }
        public string Nosnik { get => nosnik; set
            {
                nosnik = value;
                OnPropertyChanged(nameof(Nosnik));
            }
        }

        public string Info => $"Tytul:{Tytul}, Rezyser:{Rezyser}, Wydawca:{Wydawca}, Nosnik:{Nosnik}";

        public event PropertyChangedEventHandler? PropertyChanged;

        public object Clone()
        {
            return new Film
            {
                Tytul = this.Tytul,
                Rezyser = this.Rezyser,
                Wydawca = this.Wydawca,
                Nosnik = this.Nosnik
            };
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Info)));

        }
    }
}
