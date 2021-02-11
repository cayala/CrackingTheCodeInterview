using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingTheCodeInterview.DataStructures
{
    public class BinaryTreeNode<T>
    {
        public T Data { get; }
        public BinaryTreeNode<T>[] Children { get; set; }
        public BinaryTreeNode(T data, IEnumerable<T> enumerable) 
        {
            Data = data;
            Children = new BinaryTreeNode<T>[2];
            int count = 0;
            foreach(var d in enumerable)
            {
                if (count < 2)
                    Children[count] = new BinaryTreeNode<T>(d);
                else if (count >= 2)
                    break;
            }
        }

        public BinaryTreeNode(T data)
            => Data = data;
    }

    public class MinHeightTreeNode : BinaryTreeNode<int>
    {
        public TreeMinValue MinimumVal { get; set; }
        public TreeMaxValue MaximumVal { get; set; }
        public MinHeightTreeNode(int data, IEnumerable<int> enumerable) : base(data, enumerable) 
        {
            MinimumVal = new TreeMinValue(data);
            MaximumVal = new TreeMaxValue(data);
            foreach(int number in enumerable)
            {
                if (number < MinimumVal.Value)
                    MinimumVal.Value = number;
                if (number > MaximumVal.Value)
                    MaximumVal.Value = number;
            }
        }

        public MinHeightTreeNode(IEnumerable<int> enumerable) : base(enumerable)
        {
        
        }

        public MinHeightTreeNode(int data) : base(data) 
        {
            MinimumVal = new TreeMinValue(data);
            MaximumVal = new TreeMaxValue(data);
        }

        public class TreeMinValue
        {
            public int Value { get; set; }

            public TreeMinValue(int value)
                => Value = value;
        }

        public class TreeMaxValue
        {
            public int Value { get; set; }
            public TreeMaxValue(int value)
                => Value = value;
        }
    }
}
