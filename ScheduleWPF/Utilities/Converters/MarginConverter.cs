﻿using System;
using System.Windows.Data;
using System.Windows;

namespace ScheduleWPF.Utilities.Converters
{
    public class MarginConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            => new Thickness(System.Convert.ToDouble(value) / 2, 10, 0, 0);

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            => throw new NotImplementedException();
    }
}
