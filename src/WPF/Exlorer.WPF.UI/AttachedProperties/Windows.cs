using System.Windows;

namespace Exlorer.WPF.UI
{
    internal class Windows
    {
        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.RegisterAttached(
            "IsActive",
            typeof(bool),
            typeof(Windows),
            new PropertyMetadata(default(bool)));

        public static void SetIsActive(DependencyObject obj, bool value)
        {
            obj.SetValue(IsActiveProperty, value);
        }

        public static bool GetIsActive(DependencyObject element)
        {
            return (bool)element.GetValue(IsActiveProperty);
        }


        public static readonly DependencyProperty WindowStateProperty = DependencyProperty.RegisterAttached(
            "WindowState", 
            typeof(WindowState), 
            typeof(Windows), 
            new PropertyMetadata(default(WindowState)));

        public static void SetWindowState(DependencyObject obj, WindowState value)
        {
            obj.SetValue(WindowStateProperty, value);
        }

        public static WindowState GetWindowState(DependencyObject obj)
        {
            return (WindowState)obj.GetValue(WindowStateProperty);
        }
    }
}
