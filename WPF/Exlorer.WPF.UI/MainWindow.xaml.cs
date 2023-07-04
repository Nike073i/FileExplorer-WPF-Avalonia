using Explorer.Shared.ViewModels;

namespace Exlorer.WPF.UI
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
