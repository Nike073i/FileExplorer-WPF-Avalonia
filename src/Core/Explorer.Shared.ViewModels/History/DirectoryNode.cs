namespace Explorer.Shared.ViewModels.History
{
    public class DirectoryNode
    {
        public DirectoryNode? Previous { get; set; }
        public DirectoryNode? Next { get; set; }

        public string DirectoryPath { get; }
        public string DirectoryPathName { get; }

        public DirectoryNode(string directoryPath, string directoryPathName)
        {
            DirectoryPath = directoryPath;
            DirectoryPathName = directoryPathName;
        }
    }
}
