using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Iterator
{
    // Custom iterator in any sense !!!
    public class TreeNode<T> : IEnumerable<TreeNode<T>>
    {
        public TreeNode(T value)
        {
            Value = value;
        }

        public T Value { get; }

        public List<TreeNode<T>> Children { get; set; }

        public bool HasChildren => Children != null && Children.Any();


        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            return new TreeWidthEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    // Defines the enumerator for the tree collection/data structure.
    // Some prefer this class nested in the collection class.
    public class TreeWidthEnumerator<T> : IEnumerator<TreeNode<T>>
    {
        private TreeNode<T> rootTreeNode;
        private readonly Queue<TreeNode<T>> treeNodeQueue = new Queue<TreeNode<T>>();

        public TreeWidthEnumerator(TreeNode<T> rootTreeNode)
        {
            this.Current = null;
            this.rootTreeNode = rootTreeNode;
            treeNodeQueue.Enqueue(rootTreeNode);
        }

        public TreeNode<T> Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            if (treeNodeQueue.Any())
            {
                Current = treeNodeQueue.Dequeue();

                if (Current.HasChildren)
                {
                    foreach (var child in Current.Children)
                    {
                        treeNodeQueue.Enqueue(child);
                    }
                }
            }
            else
            {
                Current = null;
            }

            return Current != null;
        }

        public void Reset()
        {
            this.Current = null;
            treeNodeQueue.Clear();
            treeNodeQueue.Enqueue(rootTreeNode);
        }
    }
}
