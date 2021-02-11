using CrackingTheCodeInterview.DataStructures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrackingTheCodeInterview.TreesAndGraphs
{
    class InterviewQuestions
    {
        #region Route Between Nodes
        /*
         Given a directed fraph and two nodes (S and E), design an algorithim to find out whether there is a route from S to E.
         */
        #endregion

        #region Minimal Tree
        /*
         Given a sorted (increasing order) array with unique integer elements, write an algorithm to create a binary search tree with minimal height
         */

        public BinaryTreeNode<int> CreateBinarySearchTree(int[] sortedArray)
        {
            var treeNode = new MinHeightTreeNode(sortedArray[0], sortedArray);

            return null;
        }
        #endregion

        #region List of Depths
        /*
         Give a binary tree, design an algorithm which creates a linked list of all the nodes at each depth (e.g., if you have a tree with depth D, you'll have D linked lists
         */

        public DataStructures.LinkedList<DataStructures.LinkedList<T>> GetTreeNodesAtEachDepth<T>(TreeNode<T> treeNode, DataStructures.LinkedList<DataStructures.LinkedList<T>> list, int depth) 
        {
            if(treeNode.Children == null)
            {
                list.GetNodeAt(depth).Data.Add(new DataStructures.LinkedListNode<T>(treeNode.Data));
                return list;
            }

            foreach(var child in treeNode.Children)
            {
                GetTreeNodesAtEachDepth(child, list, depth + 1);
            }

            list.GetNodeAt(depth).Data.Add(new DataStructures.LinkedListNode<T>(treeNode.Data));
            return list;
        } 

        #endregion

        #region Check Balanced
        /*
         Implement a function to check if a binary tree is balanced. For the purposes of this question, a balanced tree is defined to be a tree such that the heights of the two subtrees of any node never differ by more than one.
         */
        #endregion

        #region Validate BST
        /*
         Implement a function to check if a binary tree is a binary search tree
         */
        #endregion

        #region Successor
        /*
         Write an algorithm to find the "next" node (i.e., in-order successor) of a given node in a binary search tree. You may assume that each node has al link to its parent.
         */
        #endregion

        #region Build Order
        /*
         You are given a list of projects and a list of dependencies (which is a list of pairs of projects, where the second project is dependent on the first project). All of a projects's dependencies must be built before the project is.
        Find a build order that will allow the projects to be built. If there is no valid build order, return an error.
         */
        #endregion

        #region First Common Ancestor
        /*
         Design an algorithm and write code to find the first common ancestor of two nodes in a binary tree. Avoid storing the additional nodes in a stat structure.
        NOTE: this is not necessarily a binary search tree.
         */
        #endregion

        #region BST Sequences
        /*
         A binary search tree was created by traversing through an array from left to right and insertingeach element. Given a binary search tree with distinct elements, print all possible arrays that could have led to this tree.
         */
        #endregion

        #region Check Subtree
        /*
         T1 and T2 are two very large binary trees, with T1 much bigger than T2. Create an algorithm to determine if T2 is a subtree of T1
         */
        #endregion

        #region Random Node
        /*
         You are implementing a binary search tree class from scratch which, in addition to insert, find, and delete has a method getRandomNode() which returns a random node from the tree.
        All nodes should be equally likely to be chose.
        Design and implement an alforithm for getRandomNode, and explain how you would implement the rest of the methods
         */
        #endregion

        #region Paths with Sum
        /*
        You are given a binary tree in which each node contains an integer value (which might be positive or negative).
        Design an algorithm to count the number of paths that sum to a given value.
        The path does not need to start or end at the root or a leaf, but it must go downwards (traveling only from parent nodes to child nodes).
         */
        #endregion
    }
}
