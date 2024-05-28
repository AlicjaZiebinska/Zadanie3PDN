using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace PDN3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new ViewModel();
        }

        

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            var noweOkno = new DodajEdytujFilm();
            var result = noweOkno.ShowDialog();
            if (result == true)
            {
                var nowy = (Film)noweOkno.DataContext;
                var lista = ((ViewModel)this.DataContext).Filmy;
                lista.Add(nowy);
            }
        }

        private void ImportujButton_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer serializator = new XmlSerializer(typeof(Collection<Film>));
            try
            {
                var stream = new FileStream("filmy.xml", FileMode.Open);
                IEnumerable<Film> filmy = serializator.Deserialize(stream) as Collection<Film>;
                var lista = ((ViewModel)this.DataContext).Filmy;
                lista.Clear();
                foreach (var film in filmy)
                    lista.Add(film);
                stream.Close();
            }
            catch (FileNotFoundException ex) { }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void EksportujButton_Click(object sender, RoutedEventArgs e)
        {
            var serializator = new XmlSerializer(typeof(ObservableCollection<Film>));
            TextWriter stream = new StreamWriter("filmy.xml");
            var lista = ((ViewModel)this.DataContext).Filmy;
            serializator.Serialize(stream, lista);
            stream.Close();
        }

        private void UsunButton_Click(object sender, RoutedEventArgs e)
        {
            var usuwana = ListaFilmow.SelectedItem as Film;
            var lista = ((ViewModel)this.DataContext).Filmy;
            lista.Remove(usuwana);
        }

        private void EdytujButton_Click(object sender, RoutedEventArgs e)
        {
            var edytowana = ListaFilmow.SelectedItem as Film;

            var noweOkno = new DodajEdytujFilm(edytowana);
            var result = noweOkno.ShowDialog();
            if (result == true)
            {
                var nowy = (Film)noweOkno.DataContext;
                edytowana.Nosnik = nowy.Nosnik;
                edytowana.Wydawca = nowy.Wydawca;
                edytowana.Tytul = nowy.Tytul;
                edytowana.Rezyser = nowy.Rezyser;
            }
        }
    }
}