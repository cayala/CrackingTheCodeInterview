using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CrackingTheCodeInterview.DataStructures
{
    public class Stack<T>: IEnumerable<T>
    {
        public StackNode<T> Top { get; set; }

        public Stack(T data)
            => Top = new StackNode<T>(data);
        public Stack(StackNode<T> node)
            => Top = node;

        public Stack() { }

        public static Stack<T> Create(T data)
            => new Stack<T>(data);

        public static Stack<T> Create(StackNode<T> node)
            => new Stack<T>(node);

        public static Stack<T> Create(IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                throw new ArgumentException("Cannot instantiate a new Stack<T> with empty enumerable");

            Stack<T> stack = null;

            foreach(var item in enumerable)
            {
                if (stack == null)
                    stack = Create(item);
                else
                    stack.Push(item);
            }
            return stack;
        }

        public IEnumerator<T> GetEnumerator()
            => new StackEnumerator<T>(this);

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }

    public class StackEnumerator<T> : IEnumerator<T>
    {
        private StackNode<T> _Node { get; set; }
        private Stack<T> _CurrentStack { get; set; }

        public StackEnumerator(Stack<T> stack)
            => (_Node, _CurrentStack) = (stack.Top, stack);

        private T _Current { get; set; }
        public T Current => _Current;

        object IEnumerator.Current => Current;

        public void Dispose()
            => _Node = null;

        public bool MoveNext()
        {
            if (_Node == null)
                return false;

            _Current = _Node.Data;
            _Node = _Node.Next;
            return true;
        }

        public void Reset()
            => _Node = _CurrentStack.Top;
        
    }

    public static class StackExtentions
    {
        public static void Push<T>(this Stack<T> stack, T item)
        {
            if (stack.IsEmpty())
                stack.Top = new StackNode<T>(item);
            
            else
            {
                var node = new StackNode<T>(item);
                node.Next = stack.Top;
                stack.Top = node;
            }
        }

        public static void Push<T>(this Stack<T> stack, StackNode<T> node)
        {
            if (stack.IsEmpty())
            {
                node.Next = null;
                stack.Top = node;
            }
            else
            {
                node.Next = stack.Top;
                stack.Top = node;
            }
        }

        public static T Peek<T>(this Stack<T> stack)
            => stack.Top.Data;
        public static StackNode<T> PeekNode<T>(this Stack<T> stack)
            => stack.Top;

        public static bool IsEmpty<T>(this Stack<T> stack)
           => stack?.Top == null;

        public static T Pop<T>(this Stack<T> stack)
        {
            var data = stack.Top.Data;
            stack.Top = stack.Top.Next;
            return data;
        }

        public static void Clear<T>(this Stack<T> stack)
            => stack.Top = null;

        public static StackNode<T> PopNode<T>(this Stack<T> stack)
        {
            var topNode = stack.Top;
            stack.Top = stack.Top.Next;
            return topNode;
        }
    }

    public class StackNode<T>
    {
        public T Data;

        public StackNode<T> Next;

        public StackNode(T data)
            => Data = data;
    }
}
