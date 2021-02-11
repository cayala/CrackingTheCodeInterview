using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace CrackingTheCodeInterview.DataStructures
{
    public class LinkedList<T>: IEnumerable<T>
    {
        public int Count 
        { 
            get
            {
                int count = 0;
                var node = Head;
                while(node != null)
                {
                    count++;
                    node = node.Next;
                }
                return count;
            } 
        }

        public LinkedListNode<T> Head { get; set; }

        public LinkedList() { }
        public LinkedList(LinkedListNode<T> head)
            => Head = head;

        public static LinkedList<T> Create(T data)
            => new LinkedList<T>(new LinkedListNode<T>(data));

        public static LinkedList<T> Create(IEnumerable<T> enumerableData)
        {
            if (enumerableData == null)
                throw new ArgumentException("Unable to create new linked list due to enumerable data being null");

            LinkedList<T> linkedList = null;

            foreach(var data in enumerableData)
            {
                if (linkedList == null)
                    linkedList = Create(data);
                else
                    linkedList.Add(new LinkedListNode<T>(data));
            }

            return linkedList;
        }

        public IEnumerator<T> GetEnumerator()
            => new LinkedListEnumerator<T>(this);

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }

    public class LinkedListEnumerator<T> : IEnumerator<T>
    {
        private LinkedListNode<T> _Head { get; }
        private LinkedListNode<T> _Node { get; set; }

        public LinkedListEnumerator(LinkedList<T> data)
        {
            if (data == null)
                throw new ArgumentException("Linked List to enumerate over is null");
            if (data.Head == null)
                throw new ArgumentException("Linked List head is null and cannot be enumerated over");

            _Node = _Head = data.Head;
        }
        
        private T _Current { get; set; }

        public T Current => _Current;

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            if (_Node == null)
                return false;

            _Current = _Node.Data;
            _Node = _Node.Next;
            return true;
        }

        public void Reset()
            => _Node = _Head;
        
    }

    public static class LinkedListExtentions 
    {
        public static void Add<T>(this LinkedList<T> linkedList, LinkedListNode<T> newNode) 
        {
            if (linkedList.Head == null)
                linkedList.Head = newNode;
            else
            {
                var node = linkedList.Head;

                while (node.Next != null) 
                {
                    node = node.Next;
                }
                node.Next = newNode;
            }
        }

        public static void Add<T>(this LinkedList<T> linkedList, T data)
        {
            if(linkedList.Head == null)
                linkedList.Head = new LinkedListNode<T>(data);
            else
            {
                var node = linkedList.Head;

                while (node.Next != null)
                {
                    node = node.Next;
                }
                node.Next = new LinkedListNode<T>(data);
            }
        }

        public static LinkedList<T> Delete<T>(this LinkedList<T> linkedList, LinkedListNode<T> nodeToDelete)
        {
            var node = linkedList.Head;
            LinkedListNode<T> previousNode = node;
            bool deleted = false;

            while(node.Next != null)
            {
                if(node.Equals(nodeToDelete))
                {
                    deleted = true;
                    previousNode.Next = node.Next;
                    break;
                }
                previousNode = node;
                node = node.Next;
            }

            if (!deleted && node.Equals(nodeToDelete))
                previousNode.Next = null;

            return new LinkedList<T>(linkedList.Head);
        }

        public static LinkedList<T> Replace<T>(this LinkedList<T> linkedList, LinkedListNode<T> oldNode, LinkedListNode<T> newNode)
        {
            var node = linkedList.Head;
            LinkedListNode<T> previousNode = node;
            bool replaced = false;
            while(node.Next != null)
            {
                if (node.Equals(oldNode))
                {
                    replaced = true;
                    previousNode.Next = newNode;
                    newNode.Next = node.Next;
                    node.Next = null;
                    break;
                }
                previousNode = node;
                node = node.Next;
            }
            if (!replaced && node.Equals(oldNode))
                previousNode.Next = newNode;

            return new LinkedList<T>(linkedList.Head);
        }

        /// <summary>
        /// This is a zero-based index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="linkedList"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static LinkedListNode<T> GetNodeAt<T>(this LinkedList<T> linkedList, int position)
        {
            if (linkedList.IsNullOrEmpty())
                throw new ArgumentException("Cannot get position from a null or empty list");
            if (position <= 0)
                return linkedList.Head;
            
            int count = 0;
            var node = linkedList.Head;
            LinkedListNode<T> res = null;
            
            while(node != null)
            {
                if (count == position - 1)
                    res = node;

                count++;
                node = node.Next;
            }
            return res;
        }

        public static bool IsNullOrEmpty<T>(this LinkedList<T> linkedList)
            => linkedList?.Head == null;
    }

    public class LinkedListNode<T>
    {
        public T Data { get; set; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T data)
            => Data = data;
    }
}
