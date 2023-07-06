using Avalonia;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Explorer.Shared.ViewModels.FileEntities;
using System;
using System.Globalization;

namespace Explorer.Avalonia.UI
{
    internal class FileEntityToImageConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return  value switch
            {
                DirectoryViewModel => Application.Current?.FindResource("FolderIconImage"),
                FileViewModel => Application.Current?.FindResource("FileIconImage"),
                _ => null,
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
