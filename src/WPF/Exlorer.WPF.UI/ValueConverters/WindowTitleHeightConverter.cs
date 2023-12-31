﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Exlorer.WPF.UI
{
    internal class WindowTitleHeightConverter : MarkupExtension, IValueConverter
    {
        private const int NormalTitleBarHeight = 42;
        private const int MaximazedWindowBorderThicknes = 32;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is WindowState windowState)
            {
                return windowState == WindowState.Normal ? NormalTitleBarHeight : MaximazedWindowBorderThicknes;
            }
            return NormalTitleBarHeight;
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
