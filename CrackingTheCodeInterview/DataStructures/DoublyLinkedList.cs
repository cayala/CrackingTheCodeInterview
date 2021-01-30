using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingTheCodeInterview.DataStructures
{
    public class DoublyLinkedList<T>
    {
        public DoublyLinkedListNode<T> Head { get; set; }
        public DoublyLinkedListNode<T> Tail { get; set; }

        public DoublyLinkedList(DoublyLinkedListNode<T> node)
        {
            Head = node;
            Tail = node;
        }
    }

    public static class DoublyLinkedListExtentions
    {
        public static DoublyLinkedList<T> Add<T>(this DoublyLinkedList<T> linkedList, DoublyLinkedListNode<T> newNode)
        {
            linkedList.Tail.Next = newNode;
            var oldNode = linkedList.Tail;
            linkedList.Tail = newNode;
            linkedList.Tail.Previous = oldNode;
            return linkedList;
        }

        public static DoublyLinkedList<T> Delete<T>(this DoublyLinkedList<T> linkedList, DoublyLinkedListNode<T> nodeToDelete)
        {
            bool deleted = false;
            var node = linkedList.Head;
            while(node.Next != null)
            {
                if (node.Equals(nodeToDelete))
                {
                    node.Previous.Next = node.Next;
                    node.Next.Previous = node.Previous;
                    var previousNode = node.Previous;
                    node.Next = null;
                    node.Previous = null;
                    node.Next = previousNode;
                    deleted = true;
                }
                node = node.Next;
            }

            if (!deleted && node.Equals(nodeToDelete))
            {
                node.Previous.Next = null;
                node.Previous = null;
            }

            return linkedList;
        }
    }

    public class DoublyLinkedListNode<T>
    {
        public T Data { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }
        public DoublyLinkedListNode<T> Previous { get; set; }

        public DoublyLinkedListNode(T data)
            => Data = data;
    }
}
