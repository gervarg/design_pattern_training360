using System.Collections.Generic;
using System.Linq;

namespace Strategy
{
    class TreeNode<T>
    {        
        public TreeNode(T value)
        {
            Value = value;
        }

        public T Value { get; }

        public List<TreeNode<T>> Children { get; set; }

        internal IEnumerable<T> GetValues(ITreeIterator<T> treeIterator)
        {
            return treeIterator.GetValues(this);
        }
    }

    interface ITreeIterator<T>
    {
        IEnumerable<T> GetValues(TreeNode<T> treeNode);
    }

    class DepthIterator<T> : ITreeIterator<T>
    {
        public IEnumerable<T> GetValues(TreeNode<T> treeNode)
        {
            var values = new List<T>();
            
            values.Add(treeNode.Value);

            if (treeNode.Children == null || !treeNode.Children.Any())
            {
                return values;
            }

            foreach (var treeNodeChild in treeNode.Children)
            {
                values.AddRange(GetValues(treeNodeChild));
            }

            return values;
        }
    }

    class WidthIterator<T> : ITreeIterator<T>
    {
        public IEnumerable<T> GetValues(TreeNode<T> treeNode)
        {
            var values = new List<T>();
            var treeNodeQueue = new Queue<TreeNode<T>>();
            
            treeNodeQueue.Enqueue(treeNode);
            while (treeNodeQueue.Any())
            {
                var currentTreeNode = treeNodeQueue.Dequeue();
                values.Add(currentTreeNode.Value);
                
                if (currentTreeNode.Children != null && currentTreeNode.Children.Any())
                {
                    foreach (var child in currentTreeNode.Children)
                    {
                        treeNodeQueue.Enqueue(child);
                    }
                }
            }

            return values;
        }
    }
}
