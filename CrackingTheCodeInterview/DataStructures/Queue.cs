using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CrackingTheCodeInterview.DataStructures
{
    public class Queue<T>: IEnumerable<T>
    {
        public QueueNode<T> Last { get; set; }
        public QueueNode<T> First { get; set; }

        public Queue(T data) 
            => Last = First = new QueueNode<T>(data);

        public Queue(QueueNode<T> node)
            => Last = First = node;

        //Add in method to accept Enumerables

        public static Queue<T> Create(T data)
            => new Queue<T>(data);
        public static Queue<T> Create(QueueNode<T> node)
            => new Queue<T>(node);
        public static Queue<T> Create(IEnumerable<T> enumerable)
        {
            Queue<T> queue = null;

            foreach(var data in enumerable)
            {
                if (queue == null)
                    queue = Create(data);
                else
                    queue.Add(data);
            }
            return queue;
        }

        public IEnumerator<T> GetEnumerator()
            => new QueueEnumerator<T>(this);

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

    }

    public class QueueEnumerator<T> : IEnumerator<T>
    {
        private QueueNode<T> _Node { get; set; }
        private Queue<T> _CurrentQueue { get; }
        public QueueEnumerator(Queue<T> queue)
            => (_CurrentQueue, _Node) = (queue, queue.First);

        private T _Current { get; set; }
        public T Current => _Current;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _Node = null;
        }

        public bool MoveNext()
        {
            if (_Node == null)
                return false;
            
            _Current = _Node.Data;
            _Node = _Node.Next;
            return true;
        }

        public void Reset()
            => _Node = _CurrentQueue.Last;
    }

    public static class QueueExtentions
    {
        //add
        public static void Add<T>(this Queue<T> queue, T data)
        {
            var node = new QueueNode<T>(data);
            queue.Last.Next = node;
            queue.Last = node;
        }

        public static void Add<T>(this Queue<T> queue, QueueNode<T> node)
        {
            node.Next = null;
            queue.Last.Next = node;
            queue.Last = node;
        }
        //remove
        public static QueueNode<T> RemoveNode<T>(this Queue<T> queue)
        {
            var node = queue.First;
            queue.First = node.Next;
            node.Next = null;

            if (queue.First == null)
                queue.Last = null;

            return node;
        }

        public static T Remove<T>(this Queue<T> queue)
        {
            var node = queue.First;
            queue.First = node.Next;
            node.Next = null;

            if (queue.First == null)
                queue.Last = null;

            return node.Data;
        }
        //peek
        /// <summary>
        /// This will return the default value of the type in order to prevent a null exception
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queue"></param>
        /// <returns></returns>
        public static T Peek<T>(this Queue<T> queue)
            => queue.First != null ? queue.First.Data : default(T);

        public static QueueNode<T> PeekNode<T>(this Queue<T> queue)
            => queue.First;
        //isEmpty
        public static bool IsEmpty<T>(this Queue<T> queue)
            => queue?.First == null && queue?.Last == null;
        
    }

    public class QueueNode<T> 
    {
        public T Data { get; }
        public QueueNode<T> Next { get; set; }
        public QueueNode(T data)
            => Data = data;
    }
}