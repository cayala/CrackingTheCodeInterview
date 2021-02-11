using CrackingTheCodeInterview.DataStructures;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Xunit;
using CrackingTheCodeInterview.TreesAndGraphs;

namespace CrackingCodeInterviewTests.TreesAndGraphs
{
    public class TreeNodePracticeTests
    {
        private TreeNodePractice _methods = new TreeNodePractice();

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 45)]
        public void ShouldGetSumOfTree(int[] array, int expected) 
        {
            var tree = MakeTree();
            var res = _methods.SumOfChildren(tree);
            Assert.Equal(expected, res);
            TreeNode<int> MakeTree()
            {
                var root = new TreeNode<int>(array[0]);

                root.Children.Add(new TreeNode<int>(array[1]));
                root.Children.Add(new TreeNode<int>(array[2]));
                root.Children.Head.Data.Children.Add(new TreeNode<int>(array[3]));
                root.Children.Head.Data.Children.Add(new TreeNode<int>(array[4]));
                root.Children.Head.Next.Data.Children.Add(new TreeNode<int>(array[5]));
                root.Children.Head.Next.Data.Children.Add(new TreeNode<int>(array[6]));
                root.Children.Head.Data.Children.Head.Data.Children.Add(new TreeNode<int>(array[7]));
                root.Children.Head.Data.Children.Head.Data.Children.Add(new TreeNode<int>(array[8]));               
                return root;
            }
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, -1 }, -1)]
        public void ShouldGetMinOfTree(int[] array, int expected)
        {
            var tree = MakeTree();
            var res = _methods.GetMinOfTree(tree);
            Assert.Equal(expected, res);
            TreeNode<int> MakeTree()
            {
                var root = new TreeNode<int>(array[0]);

                root.Children.Add(new TreeNode<int>(array[1]));
                root.Children.Add(new TreeNode<int>(array[2]));
                root.Children.Head.Data.Children.Add(new TreeNode<int>(array[3]));
                root.Children.Head.Data.Children.Add(new TreeNode<int>(array[4]));
                root.Children.Head.Next.Data.Children.Add(new TreeNode<int>(array[5]));
                root.Children.Head.Next.Data.Children.Add(new TreeNode<int>(array[6]));
                root.Children.Head.Data.Children.Head.Data.Children.Add(new TreeNode<int>(array[7]));
                root.Children.Head.Data.Children.Head.Data.Children.Add(new TreeNode<int>(array[8]));
                root.Children.Head.Data.Children.Head.Data.Children.Add(new TreeNode<int>(array[9]));
                return root;
            }
        }
    }
}
