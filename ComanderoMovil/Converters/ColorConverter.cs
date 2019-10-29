using System;
using System.Globalization;
using Xamarin.Forms;

namespace ComanderoMovil.Converters
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valor = value?.ToString();
            switch(valor)
            {
                case "White":
                    return Color.White;
                case "Black":
                    return Color.Black;
                default:
                    return Color.Default;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
