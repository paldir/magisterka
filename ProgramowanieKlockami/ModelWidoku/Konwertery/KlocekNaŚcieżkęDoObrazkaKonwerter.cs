using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace ProgramowanieKlockami.ModelWidoku.Konwertery
{
    public class KlocekNaŚcieżkęDoObrazkaKonwerter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string nazwaKlocka = value.GetType().Name;
            string ścieżka = Path.GetFullPath(Path.Combine("Obrazki", string.Concat(nazwaKlocka, ".png")));

            if (!File.Exists(ścieżka))
                throw new Exception();

            return new Uri(ścieżka);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}