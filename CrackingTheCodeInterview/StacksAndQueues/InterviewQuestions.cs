using System;
using System.Collections.Generic;
using System.Text;
using CrackingTheCodeInterview.DataStructures;


namespace CrackingTheCodeInterview.StacksAndQueues
{
    public class InterviewQuestions
    {
        #region Three in One
        /*
         Describe how you could use a single array to implement three stacks
         */

        public class ThreeInOne<T>
        {
            public DataStructures.Stack<T> FirstStack { get; set; }
            public DataStructures.Stack<T> SecondStack { get; set; }
            public DataStructures.Stack<T> ThirdStack { get; set; } 
            public ThreeInOne(T [] array)
            {
                int stackIndex = 1;
                FirstStack = SecondStack = ThirdStack = new DataStructures.Stack<T>();
                for (int index = 0; index < array.Length; index++) 
                {
                    if(stackIndex == 1)
                    {
                        FirstStack.Push(array[index]);
                        stackIndex++;
                        continue;
                    }
                    else if (stackIndex == 2)
                    {
                        FirstStack.Push(array[index]);
                        stackIndex++;
                        continue;
                    }
                    else if (stackIndex == 3)
                    {
                        FirstStack.Push(array[index]);
                        stackIndex = 1;
                        continue;
                    }
                }
            }
        }

        #endregion

        #region Stack Min

        /*
         How would you design a stack which, in addition to push and pop, has a function min which returns the minimum element? Push, pop, and min should all operate in O(1) time.
         */

        public class MinStack 
        {
            public int MinimumElement => CurrentMin.Value;
            private Min CurrentMin { get; set; }
            private DataStructures.Stack<int> Stack { get; set; }
            public MinStack(IEnumerable<int> enumerable)
            {
                Stack = new DataStructures.Stack<int>();
                foreach(int number in enumerable)
                {
                    if (CurrentMin == null)
                    {
                        CurrentMin = new Min(number);
                        continue;
                    }

                    if (number < CurrentMin.Value)
                    {
                        CurrentMin.Push(CurrentMin.Value);
                        CurrentMin.Value = number;
                    }
                    Stack.Push(number);
                }
            }

            public void Push(int number)
            {
                if(number < CurrentMin.Value)
                {
                    CurrentMin.Push(CurrentMin.Value);
                    CurrentMin.Value = number;
                }

                Stack.Push(number);
            }

            public int Pop() 
            {
                int value = Stack.Pop();
                if (value == CurrentMin.Value)
                    CurrentMin.Pop();
                return value;
            }

            public class Min
            {
                private DataStructures.Stack<int> PreviousMins = new DataStructures.Stack<int>();
                public int Value { get; set; }

                public Min(int min)
                    => (Value, PreviousMins) = (min, new DataStructures.Stack<int>());

                public void Push(int number)
                    => PreviousMins.Push(number);
                public void Pop()
                => Value = PreviousMins.Pop();
            }
        }

        #endregion

        #region Stack of Plates
        /*
         * Imagine a (literal) stack of plates. If the stack gets too high, it might topple. 
         * Therefore, in real life, we would likely start a new stack when the previous stack exceeds some threshold. 
         * Implement a data structure SetOfStacks that mimics this.
         * SetOfStacks should be composed of push() and SetOfStacks.pop() should behave identically to a single stack 
         * (that is, pop() should return the same values as it would if there were just a single stack).
         * 
         * FOLLOW UP 
         * Implement a function popAt(int index) which performs on a specific sub-stack.
         */

        public class SetOfStacks<T>
        {
            public int MaxStackSize { get; }

            /// <summary>
            /// Current number of nodes sitting on the stack
            /// </summary>
            public int CurrentStackSize 
            { 
                get 
                {
                    if (CurrentStack == null)
                        return 0;
                    else if (CurrentStack.IsEmpty())
                        return 0;
                    else
                    {
                        int count = 0;
                        foreach(var node in CurrentStack)
                        {
                            count++;
                        }
                        return count;
                    }

                } 
            }
            private DataStructures.Stack<T> CurrentStack { get; set; }
            private DataStructures.LinkedList<DataStructures.Stack<T>> Stacks { get; set; }

            public int CountOfStacks 
            {
                get 
                {
                    int size = 0;
                    DataStructures.LinkedListNode<DataStructures.Stack<T>> node = Stacks?.Head;
                    while(node != null)
                    {
                        size++;
                        node = node.Next;
                    }

                    if (CurrentStack != null)
                        size++;

                    return size;
                }
            }

            public SetOfStacks(T data, int size)
            {
                MaxStackSize = size;
                CurrentStack = DataStructures.Stack<T>.Create(data);
            }

            public SetOfStacks(IEnumerable<T> enumerable, int size)
            {
                if (size <= 0)
                    throw new ArgumentException("Size cannot be lower than 1");

                MaxStackSize = size;
                CurrentStack = null;

                foreach (var data in enumerable)
                {
                    if (CurrentStack == null)
                        CurrentStack = DataStructures.Stack<T>.Create(data);
                    else
                    {
                        PushOnToStackUntilFilled(data);
                    }
                }
            }

            public T Pop()
                => CurrentStack.Pop();

            /// <summary>
            /// This does not run under a zero-based index
            /// </summary>
            /// <param name="index"></param>
            /// <returns>Takes the data that sits onto of the stack at the passed in index</returns>
            public T PopAt(int index)
            {
                if (index > (Stacks?.Count + (CurrentStack != null ? 1 : 0)))
                    throw new ArgumentException("Error index requested is greater than linked list size");

                int count = 1;
                DataStructures.LinkedListNode<DataStructures.Stack<T>> node = Stacks.Head;
                T data = default(T);

                if(index == CountOfStacks)
                    return CurrentStack.Pop();

                while (count < index && node != null)
                {
                    count++;
                    node = node.Next;
                }
                   
                if (node != null) data = node.Data.Pop();


                return data;
            }

            public void Push(T data)
                => PushOnToStackUntilFilled(data);

            private void PushOnToStackUntilFilled(T data)
            {
                if (CurrentStackSize < MaxStackSize)
                {
                    //push data onto current stack
                    if (CurrentStack == null)
                        CurrentStack = DataStructures.Stack<T>.Create(data);
                    else
                        CurrentStack.Push(data);
                }
                else
                {
                    //move stack to the end of the list
                    var node = new DataStructures.LinkedListNode<DataStructures.Stack<T>>(CurrentStack);
                    
                    if (Stacks == null) Stacks = new DataStructures.LinkedList<DataStructures.Stack<T>>(node);
                    else Stacks.Add(node);
                    //create a new stack
                    //push data onto new stack
                    CurrentStack = DataStructures.Stack<T>.Create(data);
                }
            }

        }

        #endregion

        #region Queue via Stacks
        /*
         Implement a MyQueue class which implements a queue using two stacks.
         */

        public class MyQueue<T>
        {
            private DataStructures.Stack<T> Dequeue { get; set; }
            private DataStructures.Stack<T> Enqueue { get; set; }

            public MyQueue(T data)
                => (Dequeue, Enqueue) = (DataStructures.Stack<T>.Create(data), DataStructures.Stack<T>.Create(data));
            public MyQueue(IEnumerable<T> enumerable)
            {
                Dequeue = new DataStructures.Stack<T>();
                DataStructures.Stack<T> enqueue = null;

                foreach (var data in enumerable)
                {
                    if (enqueue == null)
                        enqueue = DataStructures.Stack<T>.Create(data);
                    else
                        enqueue.Push(data);
                }
                Enqueue = enqueue;
            }

            public void Add(T data)
            {
                Enqueue.Push(data);
            }

            public T Remove()
            {
                if (!Dequeue.IsEmpty())
                    return Dequeue.Pop();
                else
                {
                    if (!Enqueue.IsEmpty())
                    {
                        foreach (var data in Enqueue)
                        {
                            Dequeue.Push(data);
                        }
                        return Dequeue.Pop();
                    }
                    else
                        return default(T);
                }
            }
        }

        #endregion

        #region Sort Stack
        /*
         Write a program to sort a stack such that the smallest items are on the top. 
        You can use an additional temporary stack, but you may not copy the elements into any other data structure (such as an array). 
        Then stack supports the following operations: push, pop, peek, and isEmpty.
         */

        public class MinSortedStack
        {
            public DataStructures.Stack<int> SortedStack => _StortedStack;
            private DataStructures.Stack<int> _StortedStack { get; }
            public MinSortedStack(IEnumerable<int> enumerable)
            {
                DataStructures.Stack<int> stack = null;

                foreach(int number in enumerable)
                {
                    if (stack.IsEmpty())
                        stack = DataStructures.Stack<int>.Create(number);
                    else
                        stack.Push(number);
                }
                if (stack != null)
                    _StortedStack = SortStack(stack);
                else
                    _StortedStack = new DataStructures.Stack<int>();
            }

            private DataStructures.Stack<int> SortStack(DataStructures.Stack<int> stack)
            {
                int currentNode = stack.Pop();
                int nextNode = default(int);

                DataStructures.Stack<int> newlySortedStack = new DataStructures.Stack<int>();
                
                while (!stack.IsEmpty())
                {
                    nextNode = stack.Pop();
                    if (currentNode > nextNode) 
                        newlySortedStack.Push(nextNode);
                    
                    else
                    {
                        newlySortedStack.Push(currentNode);
                        currentNode = nextNode;
                    }
                }
                stack.Push(currentNode);

                //reverse
                bool isUnsorted = false;

                foreach (int num in newlySortedStack)
                {
                    if (!stack.IsEmpty() && !isUnsorted)
                        isUnsorted = !(num < stack.Peek());

                    stack.Push(num);
                }

                return isUnsorted ? SortStack(stack) : stack;
            }

            public void Push(int newNumber) 
            {
                var tempStack = new DataStructures.Stack<int>();
                bool wasAdded = false;
                foreach(int number in _StortedStack)
                {
                    if(newNumber < number && !wasAdded)
                    {
                        tempStack.Push(newNumber);
                        tempStack.Push(number);
                        wasAdded = true;
                        continue;
                    }
                    tempStack.Push(number);
                }

                if (!wasAdded)
                    tempStack.Push(newNumber);

                _StortedStack.Clear();

                foreach(int number in tempStack)
                {
                    _StortedStack.Push(number);
                }
            }

            public int Pop() 
                => _StortedStack.Pop();
            public int Peek()
                => _StortedStack.Peek();
            public bool IsEmpty()
                => _StortedStack.IsEmpty();
            
        }

        #endregion

        #region AnimalSheter
        /*
         An animal shelter, which holds only dogs and cats, operates on a strictly "first in, first out" basis. 
        People must adopt either the "oldest" (based on arrival time) of all animals at the shelter, or they can select whether they would prefer a dog or a cat (and will receive the oldest animal of that type).
        They cannot select which specific animal they would like. Create the data structures to maintain this system and implement operations such as enqueue, dequeueAny, dequeueDog, and dequeueCat. 
        You may use the built-in LinkedList data structure.
         */

        public class AnimalShelter
        {
            private DataStructures.Queue<AnimalQueueNode> CatQueue { get; set; }
            private DataStructures.Queue<AnimalQueueNode> DogQueue { get; set; }

            public AnimalShelter(IEnumerable<AnimalType> enumerable)
            {
                foreach(AnimalType animal in enumerable)
                {
                    SortAnimal(animal);
                }
            }

            public void Enqueue(AnimalType animal) 
                => SortAnimal(animal);
            
            public AnimalQueueNode DequeueAny() 
            {
                if (CatQueue == null && DogQueue == null)
                    throw new NullReferenceException("Cannot dequeue if both the cat queue and dog queue are null");
                else if (CatQueue == null)
                    return DogQueue.Remove();
                else if (DogQueue == null)
                    return CatQueue.Remove();
                else
                    return CatQueue.Peek().RegisteredDate < DogQueue.Peek().RegisteredDate ? CatQueue.Remove() : DogQueue.Remove();
            }
            public AnimalQueueNode DequeueDog()
                => DogQueue.Remove();
            public AnimalQueueNode DequeueCat()
                => CatQueue.Remove();

            public void SortAnimal(AnimalType animal)
            {
                if (animal == AnimalType.Dog)
                {
                    var node = new AnimalQueueNode(animal);
                    if (DogQueue.IsEmpty())
                        DogQueue = DataStructures.Queue<AnimalQueueNode>.Create(node);
                    else
                        DogQueue.Add(node);
                }
                else if (animal == AnimalType.Cat)
                {
                    var node = new AnimalQueueNode(animal);
                    if (CatQueue.IsEmpty())
                        CatQueue = DataStructures.Queue<AnimalQueueNode>.Create(node);
                    else
                        CatQueue.Add(node);
                }
            }

        }

        public class AnimalQueueNode
        {
            public AnimalType Animal { get;}
            public AnimalQueueNode Next { get; set; }
            public DateTime RegisteredDate { get; set; }

            public AnimalQueueNode(AnimalType animal)
                => (Animal, RegisteredDate) = (animal, DateTime.UtcNow);
        }

        public enum AnimalType
        {
            Dog = 1,
            Cat = 2
        }

        #endregion
    }
}