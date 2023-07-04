using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Explorer.Shared.ViewModels;

namespace Explorer.Avalonia.UI
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _mainViewModel;
        private readonly IClassicDesktopStyleApplicationLifetime _desktopLifeTime;

#nullable disable
        public MainWindow() { }
#nullable enable

        public MainWindow(MainViewModel mainViewModel, IClassicDesktopStyleApplicationLifetime desktopLifeTime)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;
            DataContext = _mainViewModel;
            _desktopLifeTime = desktopLifeTime;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            _desktopLifeTime.Shutdown();
        }

        private void ExpandButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        private void CollapseButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}