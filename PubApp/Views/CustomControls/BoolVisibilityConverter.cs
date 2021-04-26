using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PubApp.Views.CustomControls
{
    public class BoolVisibilityConverter:IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string hasText = (string) values[0];
            bool hasFocus = (bool) values[1];

            if (!String.IsNullOrWhiteSpace(hasText) || hasFocus)
                return Visibility.Collapsed;

            return Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}