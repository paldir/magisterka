using System;
using System.Globalization;
using System.Windows.Data;

namespace ProgramowanieKlockami.Widok.Konwertery
{
    public class ObiektNaNowyObiektKonwerter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? null : Activator.CreateInstance(value.GetType());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}