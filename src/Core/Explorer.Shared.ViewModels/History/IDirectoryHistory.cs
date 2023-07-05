namespace Explorer.Shared.ViewModels.History
{
    internal interface IDirectoryHistory : IEnumerable<DirectoryNode>
    {
        bool CanMoveBack { get; }
        bool CanMoveForward { get; }

        DirectoryNode Current { get; }

        event EventHandler HistoryChanged;

        void AddNode(string filePath, string name);
        void MoveBack();
        void MoveForward();
    }
}
