using System;
using System.Globalization;
using System.Windows.Data;
using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.Widok.Konwertery
{
    public class SkupienieNaKolorObramowaniaKonwerter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Klocek klocek = (Klocek) value;

            return klocek.PosiadaSkupienie ? Kolory.Skupienie : klocek.Kolor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}