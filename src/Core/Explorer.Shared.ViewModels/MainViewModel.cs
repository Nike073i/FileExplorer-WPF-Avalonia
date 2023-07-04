using Explorer.Shared.ViewModels.Commands;
using Explorer.Shared.ViewModels.Core;
using System.Collections.ObjectModel;

namespace Explorer.Shared.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Public Properties

        public ObservableCollection<DirectoryTabItemViewModel> DirectoryTabItems { get; set; }
        public DirectoryTabItemViewModel? CurrentDirectoryTabItem { get; set; }

        #endregion

        #region Commands

        public DelegateCommand AddTabItemCommand { get; }

        #endregion

        #region Constructors

        public MainViewModel()
        {
            AddTabItemCommand = new DelegateCommand(OnAddTabItem);

            DirectoryTabItems = new ObservableCollection<DirectoryTabItemViewModel>();
            AddTabItemViewModel();
        }

        #endregion

        #region Private Methods

        private void AddTabItemViewModel()
        {
            var tab = new DirectoryTabItemViewModel();
            DirectoryTabItems.Add(tab);
            tab.Closed += OnTabClosed;
            CurrentDirectoryTabItem = tab;
        }

        private void OnTabClosed(object? sender, EventArgs args)
        {
            if (sender is DirectoryTabItemViewModel directoryTabItemViewModel)
            {
                CloseTab(directoryTabItemViewModel);
            }
        }

        private void CloseTab(DirectoryTabItemViewModel directoryTabItemViewModel)
        {
            directoryTabItemViewModel.Closed -= OnTabClosed;
            DirectoryTabItems.Remove(directoryTabItemViewModel);
            CurrentDirectoryTabItem = DirectoryTabItems.FirstOrDefault();
        }

        #endregion

        #region Commands Methods

        private void OnAddTabItem(object? obj)
        {
            AddTabItemViewModel();
        }

        #endregion
    }
}