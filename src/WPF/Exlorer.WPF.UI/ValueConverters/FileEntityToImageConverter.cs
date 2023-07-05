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
            object? iconResource = null;
            switch (value)
            {
                case DirectoryViewModel:
                    iconResource = Application.Current.TryFindResource("FolderIconImage");
                    break;
                case FileViewModel:
                    iconResource = Application.Current.TryFindResource("FileIconImage");
                    break;
            }
            return iconResource as ImageSource ?? new DrawingImage();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
