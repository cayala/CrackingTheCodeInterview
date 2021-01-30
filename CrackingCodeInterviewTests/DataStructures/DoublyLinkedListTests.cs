using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CrackingTheCodeInterview.DataStructures;

namespace CrackingCodeInterviewTests.DataStructures
{
    public class DoublyLinkedListTests
    {
        [Theory]
        [InlineData(1061)]
        [InlineData(200060)]
        [InlineData(45631256)]
        [InlineData(3360)]
        [InlineData(6666)]
        public void AddNewNodeIsSuccessful(int data)
        {
            //Assign
            var linkedList = new DoublyLinkedList<int>(new DoublyLinkedListNode<int>(100));
            //Action
            var rand = new Random();
            for (int index = 0; index < rand.Next(1, 100); index++)
            {
                linkedList.Add(new DoublyLinkedListNode<int>(rand.Next(1, 100)));
            }
            linkedList.Add(new DoublyLinkedListNode<int>(data));
            //Assert
            var node = linkedList.Head;

            while (node.Next != null)
            {
                node = node.Next;
            }

            Assert.Equal(data, node.Data);
            Assert.IsType<int>(node.Data);
            Assert.IsType<DoublyLinkedListNode<int>>(node);
            Assert.IsType<DoublyLinkedList<int>>(linkedList);
        }

        [Theory]
        [InlineData(1701)]
        [InlineData(204000)]
        [InlineData(45563125)]
        [InlineData(3351)]
        [InlineData(6646)]
        public void DeleteNodeAtEndIsSuccessful(int data)
        {
            //Assign
            var linkedList = new DoublyLinkedList<int>(new DoublyLinkedListNode<int>(100));
            //Action
            var rand = new Random();
            for (int index = 0; index < rand.Next(1, 100); index++)
            {
                linkedList.Add(new DoublyLinkedListNode<int>(rand.Next(1, 100)));
            }
            var nodeToDelete = new DoublyLinkedListNode<int>(data);
            linkedList.Add(nodeToDelete);

            linkedList.Delete(nodeToDelete);
            //Assert
            var node = linkedList.Head;

            while (node.Next != null)
            {
                node = node.Next;
            }

            Assert.NotEqual(data, node.Data);
            Assert.IsType<int>(node.Data);
            Assert.IsType<DoublyLinkedListNode<int>>(node);
            Assert.IsType<DoublyLinkedList<int>>(linkedList);
        }

        [Theory]
        [InlineData(1901)]
        [InlineData(209005)]
        [InlineData(45963125)]
        [InlineData(3395)]
        [InlineData(6966)]
        public void DeleteNodeAtMiddleIsSuccessful(int data)
        {
            //Assign
            var linkedList = new DoublyLinkedList<int>(new DoublyLinkedListNode<int>(100));
            var nodeToDelete = new DoublyLinkedListNode<int>(data);
            var rand = new Random();

            //Action

            for (int index = 0; index < 20; index++)
            {
                if (index == 10)
                    linkedList.Add(nodeToDelete);

                linkedList.Add(new DoublyLinkedListNode<int>(rand.Next(1, 100)));
            }

            linkedList.Delete(nodeToDelete);
            //Assert
            var node = linkedList.Head;

            while (node.Next != null)
            {
                Assert.NotEqual(data, node.Data);
                Assert.IsType<int>(node.Data);
                Assert.IsType<DoublyLinkedListNode<int>>(node);
                Assert.IsType<DoublyLinkedList<int>>(linkedList);
                node = node.Next;
            }

            Assert.NotEqual(data, node.Data);
            Assert.IsType<int>(node.Data);
            Assert.IsType<DoublyLinkedListNode<int>>(node);
            Assert.IsType<DoublyLinkedList<int>>(linkedList);
        }
    }
}
