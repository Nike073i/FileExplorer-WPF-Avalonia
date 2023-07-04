using Explorer.Shared.ViewModels.FileEntities.Base;

namespace Explorer.Shared.ViewModels.FileEntities
{
    public sealed class FileViewModel : FileEntityViewModel
    {
        public FileViewModel(string name, string fullName) : base(name, fullName) { }

        public FileViewModel(FileInfo file) : base(file.Name, file.FullName) { }
    }
}