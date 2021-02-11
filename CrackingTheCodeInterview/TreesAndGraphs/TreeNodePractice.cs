using CrackingTheCodeInterview.DataStructures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace CrackingTheCodeInterview.TreesAndGraphs
{
    public class TreeNodePractice
    {
        /*Get the sum of a passed in tree*/
        public int SumOfChildren(TreeNode<int> node)
        {
            //A flaw of this is obviously going to be the amount of memory this requires
            //As the tree grows larger then this is going to require more memory
            if (node.Children.IsNullOrEmpty())
                return node.Data;
            int sumOfChildren = 0;
            foreach(var child in node.Children)
            {
                sumOfChildren += SumOfChildren(child);
            }

            return node.Data + sumOfChildren;
        }

        /*Get the min of a tree*/
        public int GetMinOfTree(TreeNode<int> node)
        {
            if (node.Children.IsNullOrEmpty())
                return node.Data;

            int currentMin = node.Data;
            foreach(var child in node.Children)
            {
                int res = GetMinOfTree(child);
                if (currentMin > res)
                    currentMin = res;
            }

            return currentMin;
        }
    }
}
