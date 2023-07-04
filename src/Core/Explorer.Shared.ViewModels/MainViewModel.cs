using System.Collections.ObjectModel;
using System.Windows.Input;
using Explorer.Shared.ViewModels.Commands;
using Explorer.Shared.ViewModels.Core;
using Explorer.Shared.ViewModels.FileEntities;
using Explorer.Shared.ViewModels.FileEntities.Base;

namespace Explorer.Shared.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Public Properties

        public string FilePath { get; set; }
        public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles { get; set; }
        public FileEntityViewModel? SelectedFileEntity { get; set; }

        #endregion

        #region Commands

        public ICommand OpenCommand { get; }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            OpenCommand = new DelegateCommand(Open);
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

        #endregion
    }
}