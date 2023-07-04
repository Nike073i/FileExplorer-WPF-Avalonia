using Explorer.Shared.ViewModels.FileEntities.Base;

namespace Explorer.Shared.ViewModels.FileEntities
{
    public sealed class DirectoryViewModel : FileEntityViewModel
    {
        public DirectoryViewModel(string directoryName, string fullName) : base(directoryName, fullName) { }
        public DirectoryViewModel(DirectoryInfo directoryInfo) : base(directoryInfo.Name, directoryInfo.FullName) { }
    }
}