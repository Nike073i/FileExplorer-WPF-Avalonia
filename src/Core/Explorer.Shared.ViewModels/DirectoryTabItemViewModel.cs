using Explorer.Shared.ViewModels.Commands;
using Explorer.Shared.ViewModels.Core;
using Explorer.Shared.ViewModels.FileEntities;
using Explorer.Shared.ViewModels.FileEntities.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Explorer.Shared.ViewModels
{
    public class DirectoryTabItemViewModel : BaseViewModel
    {
        #region Public Properties

        public string FilePath { get; set; }
        public string Name { get; set; }
        public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles { get; set; }
        public FileEntityViewModel? SelectedFileEntity { get; set; }

        #endregion

        #region Commands

        public ICommand OpenCommand { get; }
        public ICommand CloseCommand { get; }


        #endregion

        #region Events

        public event EventHandler? Closed;

        #endregion

        #region Constructor

        public DirectoryTabItemViewModel()
        {
            Name = "Мой компьютер";
            OpenCommand = new DelegateCommand(Open);
            CloseCommand = new DelegateCommand(OnClose);
            var files = Directory.GetLogicalDrives();
            DirectoriesAndFiles = new ObservableCollection<FileEntityViewModel>(
                files.Select(directory => new DirectoryViewModel(directory, directory)));
            FilePath = "/";
        }

        #endregion

        #region Commands Methods

        private void Open(object? parameter)
        {
            if (parameter is DirectoryViewModel directoryViewModel)
            {
                FilePath = directoryViewModel.FullName;
                Name = directoryViewModel.Name;
                DirectoriesAndFiles.Clear();
                var directoryInfo = new DirectoryInfo(FilePath);
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    DirectoriesAndFiles.Add(new DirectoryViewModel(directory));
                }
                foreach (var file in directoryInfo.GetFiles())
                {
                    DirectoriesAndFiles.Add(new FileViewModel(file));
                }
            }
        }

        private void OnClose(object? parameter)
        {
            Closed?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}