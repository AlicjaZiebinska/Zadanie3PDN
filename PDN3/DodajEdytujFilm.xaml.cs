using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PDN3
{
    /// <summary>
    /// Logika interakcji dla klasy DodajEdytujFilm.xaml
    /// </summary>
    public partial class DodajEdytujFilm : Window
    {
        private List<string> poprawneNosniki = new List<string>
        {
            "DVD", "VHS", "BlueRay"
        };

        public DodajEdytujFilm(Film film = null)
        {
            InitializeComponent();
            if(film == null)
            {
                film = new Film();
            }
            else
            {
                film = (Film)film.Clone();
            }

            this.DataContext = film;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            var film = this.DataContext as Film;
            if (!poprawneNosniki.Contains(film.Nosnik))
            {
                MessageBox.Show("Wprowadz poprawny nosnik");
                return;
            }
            GetWindow(this).DialogResult = true;
            GetWindow(this).Close();
        }
    }
}
