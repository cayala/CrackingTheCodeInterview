using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingTheCodeInterview.DataStructures
{
    public class TreeNode<T>
    {
        public T Data { get; }
        public LinkedList<TreeNode<T>> Children { get; private set; }

        public TreeNode(T data)
        {
            Data = data;
            Children = new LinkedList<TreeNode<T>>();
        }

        public TreeNode(T data, IEnumerable<T> enumerable)
        {
            Data = data;
            Children = new LinkedList<TreeNode<T>>();
            foreach(var e in enumerable)
            {
                Children.Add(new TreeNode<T>(e));
            }
        }

        public T GetData()
            => Data;
        public LinkedList<TreeNode<T>> GetChildren()
            => Children;
    }
}
