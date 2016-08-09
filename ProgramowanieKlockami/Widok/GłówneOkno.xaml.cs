using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Forms;
using ProgramowanieKlockami.ModelWidoku;

namespace ProgramowanieKlockami.Widok
{
    /// <summary>
    /// Interaction logic for GłówneOkno.xaml
    /// </summary>
    public partial class GłówneOkno
    {
        private Główny ModelWidoku => (Główny) DataContext;

        public GłówneOkno()
        {
            InitializeComponent();
        }

        private void Nowy_OnClick(object sender, RoutedEventArgs e)
        {
            ModelWidoku.ŚcieżkaPliku = null;

            ModelWidoku.RozpoczęcieProgramu.Zawartość.Clear();
            ModelWidoku.Zmienne.Clear();
            ModelWidoku.MagazynZmian.Wyczyść();
        }

        private void Otwórz_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog okno = new OpenFileDialog();

            okno.ShowDialog();

            ModelWidoku.ŚcieżkaPliku = okno.FileName;
        }

        private void Zapisz_OnClick(object sender, RoutedEventArgs e)
        {
            string ścieżkaPliku = ModelWidoku.ŚcieżkaPliku;
            string zawartośćPliku = Serializuj();

            if (File.Exists(ścieżkaPliku))
                File.WriteAllText(ścieżkaPliku, zawartośćPliku);
            else
            {
                SaveFileDialog okno = new SaveFileDialog();

                if (okno.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    File.WriteAllText(ścieżkaPliku, zawartośćPliku);
            }
        }

        private void ZapiszJako_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private string Serializuj()
        {
            BinaryFormatter serializer = new BinaryFormatter();

            using (MemoryStream strumień = new MemoryStream())
            using (StreamReader czytacz = new StreamReader(strumień))
            {
                serializer.Serialize(strumień, ModelWidoku.RozpoczęcieProgramu);

                return czytacz.ReadToEnd();
            }
        }
    }
}