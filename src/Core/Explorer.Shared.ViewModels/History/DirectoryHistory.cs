using System.Collections;

namespace Explorer.Shared.ViewModels.History
{
    public class DirectoryHistory : IDirectoryHistory
    {
        #region Private Fields

        private DirectoryNode _head = null!;

        #endregion

        #region Public Properties

        public bool CanMoveBack => Current.Previous != null;
        public bool CanMoveForward => Current.Next != null;
        public DirectoryNode Current { get; private set; }

        #endregion

        #region Events

        public event EventHandler? HistoryChanged;

        #endregion

        #region Constructors

        public DirectoryHistory(string directoryPath, string directoryName)
        {
            _head = new DirectoryNode(directoryPath, directoryName);
            Current = _head;
        }

        #endregion

        #region Public Methods

        public void AddNode(string filePath, string name)
        {
            var node = new DirectoryNode(filePath, name);
            Current.Next = node;
            node.Previous = Current;
            Current = node;
            RaiseHistoryChanged();
        }

        public void MoveBack()
        {
            Current = Current.Previous!;
            RaiseHistoryChanged();
        }

        public void MoveForward()
        {
            Current = Current.Next!;
            RaiseHistoryChanged();
        }

        #endregion

        #region Enumerator

        IEnumerator<DirectoryNode> IEnumerable<DirectoryNode>.GetEnumerator()
        {
            var temp = _head;
            while (temp != null)
            {
                yield return temp;
                temp = temp.Next;
            }
        }

        public IEnumerator GetEnumerator() => GetEnumerator();

        #endregion

        #region Private Methods

        private void RaiseHistoryChanged() => HistoryChanged?.Invoke(this, EventArgs.Empty);

        #endregion
    }
}
