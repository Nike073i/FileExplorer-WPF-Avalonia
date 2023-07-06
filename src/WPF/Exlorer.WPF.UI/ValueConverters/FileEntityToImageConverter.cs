using Explorer.Shared.ViewModels.FileEntities;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Exlorer.WPF.UI
{
    internal class FileEntityToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                DirectoryViewModel => Application.Current.TryFindResource("FolderIconImage"),
                FileViewModel => Application.Current.TryFindResource("FileIconImage"),
                _ => new DrawingImage()
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
