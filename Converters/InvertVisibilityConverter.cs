using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Probel.Reactor.Converters
{
    internal class InvertVisibilityConverter : IValueConverter
    {
        #region Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                switch (visibility)
                {
                    case Visibility.Visible: 
                        return Visibility.Collapsed;
                    default:
                        return Visibility.Visible;
                }
            }
            else { return Visibility.Visible; }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion Methods
    }
}