using CrackingTheCodeInterview.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingTheCodeInterview.LinkedLists
{
    public class InterviewQuestions
    {
        #region Remove Dups
        /*
         Write code to remove duplicates from an unsorted linked list. FOLLOW UP: how would you solve this problem if a temporary buffer is not allowed.
         */

        public DataStructures.LinkedList<T> RemoveDuplicates<T>(DataStructures.LinkedList<T> linkedList) 
        {
            var node = linkedList.Head;
            Dictionary<int, T> dictionary = new Dictionary<int, T>();

            var previousNode = node;
            while (node.Next != null)
            {
                if (dictionary.ContainsKey(node.Data.GetHashCode()))
                {
                    previousNode.Next = node.Next;
                    node.Next = null;
                    node = previousNode;
                }
                else
                    dictionary.Add(node.Data.GetHashCode(), node.Data);
                previousNode = node;
                node = node.Next;
            }

            if (dictionary.ContainsKey(node.Data.GetHashCode()))
            {
                previousNode.Next = node.Next;
                node.Next = null;
                node = previousNode;
            }
            else
                dictionary.Add(node.Data.GetHashCode(), node.Data);

            return linkedList;
        }

        public DataStructures.LinkedList<T> RemoveDuplicatesWithNoBuffer<T>(DataStructures.LinkedList<T> linkedList) 
        {
            var node = linkedList.Head;
            while(node.Next != null)
            {
                CheckForDuplicates(node, node, node.Next);

                if(node.Next != null)
                    node = node.Next;
            }
            return linkedList;
        }

        public void CheckForDuplicates<T>(DataStructures.LinkedListNode<T> distinctNode, DataStructures.LinkedListNode<T> previousNode, DataStructures.LinkedListNode<T> node)
        {
            bool duplicateFound = false;

            if(distinctNode.Data.GetHashCode() == node.Data.GetHashCode())
            {
                duplicateFound = true;
                previousNode.Next = node.Next;
            }

            if (node.Next != null)
            {
                if (duplicateFound)
                {
                    CheckForDuplicates(distinctNode, previousNode, previousNode.Next);
                    node.Next = null;
                }
                else
                    CheckForDuplicates(distinctNode, node, node.Next);            
            }
        }

        #endregion

        #region Return Kth to Last
        /*
         Implement an algoritm to delete a node in  the middle (i.e., any node but the first and last node, not necessarily the exact middle) of a singly linked list, given only access to that node.
         */

        public DataStructures.LinkedList<T> FindKthToLast<T>(DataStructures.LinkedList<T> linkedList, int count, DataStructures.LinkedListNode<T> nodeToDelete) 
        {
            var node = linkedList.Head;
            var res = FindNode(node, count, 1);

            if(res != null)
            {
                if (res.Next.Equals(nodeToDelete))
                {
                    if (res.Next.Next != null)
                    {
                        res.Next = res.Next.Next;
                    }
                    else
                        res.Next = null;
                }
            }

            return linkedList;

            DataStructures.LinkedListNode<T> FindNode(DataStructures.LinkedListNode<T> node, int count, int kthNode)
            {
                if (node == null)
                    return null;

                if (kthNode == count)
                    return node;

                return FindNode(node.Next, count, ++kthNode);
            }
        }
        #endregion

        #region Delete Middle Node
        /*
         Implement an algoritim to delete a node in the middle (i.e. any node but the first and last node, not necessarily the exact middle of a singly linked list,
        given only access to that node

        input: the node from c from the linked list a -> b -> c -> d -> e -> f
        output: nothing is returned but the new linked list looks like a -> b -> d -> e -> f
         */

        public bool DeleteMiddleNode<T>(DataStructures.LinkedListNode<T> node)
        {
            if (node.Next == null || node == null)
                return false;

            node.Data = node.Next.Data;
            node.Next = node.Next.Next;

            return true;
        }
        #endregion

        #region Partition
        /*
         Write code to partition a linked list around a value x, such that all nodes less than x come before all nodes greater than or equal to x. (IMPORTANT: The partition element x can appear anywhere in the "right partition"; it does not need to appear between the left and right partitions. The additional spacing the example below indicates the partition.
            
         input:    3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1 [partition = 5]
         output: 3 -> 1 -> 2 -> 10 -> 5 -> 5 -> 8

         */

        public DataStructures.LinkedList<int> Partition(DataStructures.LinkedList<int> linkedList, int partitionPoint)
        {
            DataStructures.LinkedList<int> lessThanList = null;
            DataStructures.LinkedList<int> greaterThanList = null;
            var node = linkedList.Head;
            while(node.Next != null)
            {
                if(node.Data < partitionPoint)
                {
                    if (lessThanList == null)
                        lessThanList = new DataStructures.LinkedList<int>(new DataStructures.LinkedListNode<int>(node.Data));
                    else
                        lessThanList.Add(new DataStructures.LinkedListNode<int>(node.Data));
                }

                if(node.Data >= partitionPoint)
                {
                    if (greaterThanList == null)
                        greaterThanList = new DataStructures.LinkedList<int>(new DataStructures.LinkedListNode<int>(node.Data));
                    else
                        greaterThanList.Add(new DataStructures.LinkedListNode<int>(node.Data));
                }

                node = node.Next;
            }

            if (node.Data < partitionPoint)
            {
                if (lessThanList == null)
                    lessThanList = new DataStructures.LinkedList<int>(new DataStructures.LinkedListNode<int>(node.Data));
                else
                    lessThanList.Add(new DataStructures.LinkedListNode<int>(node.Data));
            }

            if (node.Data >= partitionPoint)
            {
                if (greaterThanList == null)
                    greaterThanList = new DataStructures.LinkedList<int>(new DataStructures.LinkedListNode<int>(node.Data));
                else
                    greaterThanList.Add(new DataStructures.LinkedListNode<int>(node.Data));
            }
            node = lessThanList.Head;
            
            while(node.Next != null)
            {
                node = node.Next;
            }
            node.Next = greaterThanList.Head;
            return lessThanList;
        }

        #endregion

        #region Sum Lists
        /*
         You have two numbers repesented by a linked list, where each node contains a single digit. The digits are stored in reverse order, such that the 1's digit is at the head of the list. Write a function that adds the two numbers and returns the sumas a linked list. (You are not allowed to "cheat" and just convert the linked list to an integer.)
         */

        #endregion

        #region Palindrome
        /*
         Implement a function to check if a linked list is a palindrome.
         */

        public bool IsPalindrome(DoublyLinkedList<char> linkedList)
        {
            bool isPalindrome = true;

            var forwardNode = linkedList.Head;
            var backwardNode = linkedList.Tail;

            while(forwardNode.Next != null)
            {
                if (forwardNode.Data != backwardNode.Data)
                {
                    isPalindrome = false; 
                    break;
                }

                forwardNode = forwardNode.Next;
                backwardNode = backwardNode.Previous;
            }
            if(isPalindrome && forwardNode.Next == null && backwardNode.Previous == null)
            {
                if (forwardNode.Data != backwardNode.Data)
                    isPalindrome = false;
            }

            return isPalindrome;
        }

        public bool IsPalidrome(DataStructures.LinkedList<char> linkedList)
        {
            DataStructures.Stack<char> reversedString = new DataStructures.Stack<char>();
            foreach(char c in linkedList)
            {
                reversedString.Push(c);
            }
            foreach(char c in linkedList)
            {
                if (c != reversedString.Pop())
                    return false;
            }

            return true;
        }

        #endregion

        #region Intersection
        /*
         Given two (singly) linked lists, determine if the two lists intersect. Return the intersecting node. Note that the intersection is defined based on reference, not value. That is, if the kth node of the first linked list is the exact same node (by reference) as the jth node of the second linked list, then they are intersecting.
         */

        public DataStructures.LinkedListNode<T> FindIntersectingNode<T>(DataStructures.LinkedList<T> firstLinkedList, DataStructures.LinkedList<T> secondLinkedList)
        {
            //find the length of each linked list
            //whichever is longer, move through the list until both have the same starting point
            var firstNode = firstLinkedList.Head;
            var secondNode = secondLinkedList.Head;
            DataStructures.LinkedListNode<T> intersectingNode = null;
            int firstLength = GetLinkedListLength(firstLinkedList);
            int secondLength = GetLinkedListLength(secondLinkedList);

            if ( firstLength > secondLength)
            {
                for (int count = 0; count < firstLength - secondLength; count++)
                {
                    firstNode = firstNode.Next;
                }
            }

            if(firstLength < secondLength)
            {
                for (int count = 0; count < secondLength - firstLength; count++)
                {
                    secondNode = secondNode.Next;
                }
            }

            //then interate through the list at the same time until you find a match

            while(firstNode.Next != null)
            {
                if (firstNode.Equals(secondNode))
                {
                    intersectingNode = firstNode;
                    break;
                }

                firstNode = firstNode.Next;
                secondNode = secondNode.Next;
            }

            return intersectingNode;

            static int GetLinkedListLength(DataStructures.LinkedList<T> linkedList)
            {
                if (linkedList == null)
                    return 0;
                if (linkedList.Head == null)
                    return 0;

                var node = linkedList.Head;
                int count = 1;
                while(node.Next != null)
                {
                    count++;
                    node = node.Next;
                }
                return count;
            }
        }

        #endregion

        #region Loop Detection
        /*
         Given a linked list which might contain a loop, implement an algorithm that returns the node at the beginning of the loop (if one exists).
         */

        public DataStructures.LinkedListNode<T> ReturnLoopStart<T>(DataStructures.LinkedList<T> linkedList)
        {
            //This solution doesn't use Runner Technique and is O(n) in time and O(n) space
            var node = linkedList.Head;
            
            Dictionary<int, DataStructures.LinkedListNode<T>> linkedListNodes = new Dictionary<int, DataStructures.LinkedListNode<T>>();
            int loopStartHash = -1;
            
            while(node.Next != null)
            {
                if (linkedListNodes.ContainsKey(node.GetHashCode()))
                {
                    loopStartHash = node.GetHashCode();
                    break;
                }
                else
                    linkedListNodes.Add(node.GetHashCode(), node);

                node = node.Next;
            }

            return loopStartHash != -1 ? linkedListNodes[loopStartHash] : null;
        }

        public DataStructures.LinkedListNode<T> ReturnLoopStart2<T>(DataStructures.LinkedList<T> linkedList)
        {



            return null;
        }

        #endregion

        #region Runner Technique
        /*
         Implement an example(s) of the runner technique
            The runner technique is when you iterate through a linked list simultaneously with two pointers. One "slow" node that moves one by one and one "fast" node that moves ahead by a fixed amount of the "slow" node.
            This is also known as the Tortoise and Hare Algorithim
         */

        public void RunnerTechniqueExample<T>(DataStructures.LinkedList<T> linkedList)
        {
            var fast = linkedList.Head;
            var slow = linkedList.Head;

            while(fast != null && fast.Next != null)
            {
                //logic here

                //pointers moved at a set increment
                //fast moves at 2 nodes per iteration
                fast = fast.Next.Next;
                //slow moves at 1
                slow = slow.Next;
            }
        }
        
        #endregion
    }
}
