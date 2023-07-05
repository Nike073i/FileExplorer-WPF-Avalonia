using Explorer.Shared.ViewModels.Commands;
using Explorer.Shared.ViewModels.Core;
using Explorer.Shared.ViewModels.FileEntities;
using Explorer.Shared.ViewModels.FileEntities.Base;
using Explorer.Shared.ViewModels.History;
using System.Collections.ObjectModel;

namespace Explorer.Shared.ViewModels
{
    public class DirectoryTabItemViewModel : BaseViewModel
    {
        #region Private Fields

        private readonly IDirectoryHistory _history;

        #endregion

        #region Public Properties

        public string FilePath { get; set; } = null!;
        public string Name { get; set; } = null!;
        public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles { get; set; }
        public FileEntityViewModel? SelectedFileEntity { get; set; }

        #endregion

        #region Commands

        public DelegateCommand OpenCommand { get; }
        public DelegateCommand MoveBackCommand { get; }
        public DelegateCommand MoveForwardCommand { get; }
        public DelegateCommand RefreshCommand { get; }

        #endregion

        #region Constructor

        public DirectoryTabItemViewModel()
        {
            DirectoriesAndFiles = new();
            _history = new DirectoryHistory("\\", "Мой компьютер");

            OpenCommand = new DelegateCommand(Open);
            MoveBackCommand = new DelegateCommand(OnExecutedMoveBackCommand, CanExecuteMoveBackCommand);
            MoveForwardCommand = new DelegateCommand(OnExecutedMoveForwardCommand, CanExecuteMoveForwardCommand);
            RefreshCommand = new DelegateCommand(Refresh);

            OpenDirectory(_history.Current.DirectoryPath, _history.Current.DirectoryPathName);

            _history.HistoryChanged += OnHistoryChanged;
        }

        #endregion

        #region Private Methods

        private void OpenDirectory(string directoryPath, string directoryName)
        {
            Name = directoryName;
            FilePath = directoryPath;
            DirectoriesAndFiles.Clear();
            if (FilePath == "\\")
            {
                var drives = Directory.GetLogicalDrives();
                foreach (var drive in drives)
                {
                    DirectoriesAndFiles.Add(new DirectoryViewModel(drive, drive));
                }
            }
            else
            {
                var directoryInfo = new DirectoryInfo(directoryPath);
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

        private void OnHistoryChanged(object? sender, EventArgs e)
        {
            MoveBackCommand?.RaiseCanExecuteChanged();
            MoveForwardCommand?.RaiseCanExecuteChanged();
        }

        #endregion

        #region Commands Methods

        private void Open(object? parameter)
        {
            if (parameter is DirectoryViewModel directoryViewModel)
            {
                OpenDirectory(directoryViewModel.FullName, directoryViewModel.Name);
                _history.AddNode(FilePath, Name);
            }
        }

        private void OnExecutedMoveBackCommand(object? parameter)
        {
            _history.MoveBack();
            var current = _history.Current;
            OpenDirectory(current.DirectoryPath, current.DirectoryPathName);
        }

        private bool CanExecuteMoveBackCommand(object? parameter) => _history.CanMoveBack;

        private void OnExecutedMoveForwardCommand(object? parameter)
        {
            _history.MoveForward();
            var current = _history.Current;
            OpenDirectory(current.DirectoryPath, current.DirectoryPathName);
        }

        private bool CanExecuteMoveForwardCommand(object? parameter) => _history.CanMoveForward;

        private void Refresh(object? parameter)
        {

        }

        #endregion
    }
}