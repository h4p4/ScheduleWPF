﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace ScheduleWPF.Utilities.Converters
{
    public class DivideByTwoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (double)value / 2;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}