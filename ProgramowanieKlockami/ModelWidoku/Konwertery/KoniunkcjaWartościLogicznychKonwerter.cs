﻿using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace ProgramowanieKlockami.ModelWidoku.Konwertery
{
    public class KoniunkcjaWartościLogicznychKonwerter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.All(wartość => (bool) wartość);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}