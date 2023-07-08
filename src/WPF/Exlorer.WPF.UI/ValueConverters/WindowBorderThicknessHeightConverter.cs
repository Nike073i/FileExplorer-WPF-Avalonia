using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Exlorer.WPF.UI
{
    internal class WindowBorderThicknessHeightConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double thickness = 1;
            if (parameter is string length)
            {
                double.TryParse(length, out thickness);
            }
            if (value is WindowState windowState)
            {
                return windowState == WindowState.Normal ? new Thickness(thickness) : new Thickness(thickness, 0, thickness, thickness);
            }
            return new Thickness(thickness);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
