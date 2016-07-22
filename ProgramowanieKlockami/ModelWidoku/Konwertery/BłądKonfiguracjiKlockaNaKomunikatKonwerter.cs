using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using ProgramowanieKlockami.ModelWidoku.Debugowanie;

namespace ProgramowanieKlockami.ModelWidoku.Konwertery
{
    public class BłądKonfiguracjiKlockaNaKomunikatKonwerter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BłądKonfiguracjiKlocka błąd = (BłądKonfiguracjiKlocka) value;

            return $"oczekiwany: {TypNaNazwę(błąd.OczekiwanyTyp)}, umieszczony: {TypNaNazwę(błąd.UmieszczonyTyp)}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static string TypNaNazwę(Type typ)
        {
            if (typ == null)
                return "brak";

            if (typ == typeof(ZmiennaTypuListowego))
                return "lista";

            if (typ == typeof(bool))
                return "wartość logiczna";

            if (typ == typeof(double))
                return "liczba";

            if (typ == typeof(string))
                return "napis";

            return typ == typeof(object) ? "dowolny" : "NIEOKREŚLONY";
        }
    }
}