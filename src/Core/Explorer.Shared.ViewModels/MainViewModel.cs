using Explorer.Shared.ViewModels.Commands;
using Explorer.Shared.ViewModels.Core;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Explorer.Shared.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Public Properties

        public ObservableCollection<DirectoryTabItemViewModel> DirectoryTabItems { get; set; }
        public DirectoryTabItemViewModel? CurrentDirectoryTabItem { get; set; }

        #endregion

        #region Commands

        public ICommand AddTabItemCommand { get; }
        public ICommand CloseCommand { get; }

        #endregion

        #region Constructors

        public MainViewModel()
        {
            AddTabItemCommand = new DelegateCommand(OnAddTabItem);
            CloseCommand = new DelegateCommand(OnCloseTabItem);

            DirectoryTabItems = new ObservableCollection<DirectoryTabItemViewModel>();
            AddTabItemViewModel();
        }

        #endregion

        #region Private Methods

        private void AddTabItemViewModel()
        {
            var tab = new DirectoryTabItemViewModel();
            DirectoryTabItems.Add(tab);
            CurrentDirectoryTabItem = tab;
        }

        private void CloseTab(DirectoryTabItemViewModel directoryTabItemViewModel)
        {
            DirectoryTabItems.Remove(directoryTabItemViewModel);
            CurrentDirectoryTabItem = DirectoryTabItems.FirstOrDefault();
        }

        #endregion

        #region Commands Methods

        private void OnAddTabItem(object? obj)
        {
            AddTabItemViewModel();
        }

        private void OnCloseTabItem(object? obj)
        {
            if (obj is DirectoryTabItemViewModel directoryTabItemViewModel)
            {
                CloseTab(directoryTabItemViewModel);
            }
        }

        #endregion
    }
}