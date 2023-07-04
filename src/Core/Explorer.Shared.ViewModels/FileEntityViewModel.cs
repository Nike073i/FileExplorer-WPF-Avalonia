namespace Explorer.Shared.ViewModels
{
    public abstract class FileEntityViewModel : BaseViewModel
    {
        public string FullName { get; set; }
        public string Name { get; }

        protected FileEntityViewModel(string name, string fullName)
        {
            Name = name;
            FullName = fullName;
        }
    }
}