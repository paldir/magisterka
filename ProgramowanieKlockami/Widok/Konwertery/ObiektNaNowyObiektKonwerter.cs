using System;
using System.Globalization;
using System.Windows.Data;
using ProgramowanieKlockami.ModelWidoku.Zmienne;

namespace ProgramowanieKlockami.Widok.Konwertery
{
    public class ObiektNaNowyObiektKonwerter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            object nowyObiekt = Activator.CreateInstance(value.GetType());

            return nowyObiekt;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}