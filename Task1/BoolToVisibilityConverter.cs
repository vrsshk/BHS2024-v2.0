using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace GeometryApp.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool && (bool)value;  // true - элемент виден, false - скрыт
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool && (bool)value;
        }
    }
}