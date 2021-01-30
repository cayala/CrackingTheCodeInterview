using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CrackingTheCodeInterview.DataStructures;

namespace CrackingCodeInterviewTests.DataStructures
{
    public class LinkedListTests
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
            var linkedList = new CrackingTheCodeInterview.DataStructures.LinkedList<int>(new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(100));
            //Action
            var rand = new Random();
            for(int index = 0; index < rand.Next(1, 100); index++)
            {
                linkedList.Add(new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(rand.Next(1, 100)));
            }
            linkedList.Add(new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(data));
            //Assert
            var node = linkedList.Head;

            while (node.Next != null)
            {
                node = node.Next;
            }

            Assert.Equal(data, node.Data);
            Assert.IsType<int>(node.Data);
            Assert.IsType< CrackingTheCodeInterview.DataStructures.LinkedListNode<int>>(node);
            Assert.IsType< CrackingTheCodeInterview.DataStructures.LinkedList<int>>(linkedList);
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
            var linkedList = new CrackingTheCodeInterview.DataStructures.LinkedList<int>(new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(100));
            //Action
            var rand = new Random();
            for (int index = 0; index < rand.Next(1, 100); index++)
            {
                linkedList.Add(new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(rand.Next(1, 100)));
            }
            var nodeToDelete = new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(data);
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
            Assert.IsType<CrackingTheCodeInterview.DataStructures.LinkedListNode<int>>(node);
            Assert.IsType<CrackingTheCodeInterview.DataStructures.LinkedList<int>>(linkedList);
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
            var linkedList = new CrackingTheCodeInterview.DataStructures.LinkedList<int>(new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(100));
            var nodeToDelete = new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(data);
            var rand = new Random();

            //Action

            for (int index = 0; index < 20; index++)
            {
                if (index == 10)
                    linkedList.Add(nodeToDelete);

                linkedList.Add(new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(rand.Next(1, 100)));
            }

            linkedList.Delete(nodeToDelete);
            //Assert
            var node = linkedList.Head;

            while (node.Next != null)
            {
                Assert.NotEqual(data, node.Data);
                Assert.IsType<int>(node.Data);
                Assert.IsType<CrackingTheCodeInterview.DataStructures.LinkedListNode<int>>(node);
                Assert.IsType<CrackingTheCodeInterview.DataStructures.LinkedList<int>>(linkedList);
                node = node.Next;
            }

            Assert.NotEqual(data, node.Data);
            Assert.IsType<int>(node.Data);
            Assert.IsType<CrackingTheCodeInterview.DataStructures.LinkedListNode<int>>(node);
            Assert.IsType<CrackingTheCodeInterview.DataStructures.LinkedList<int>>(linkedList);
        }

        [Theory]
        [InlineData(321)]
        [InlineData(987)]
        [InlineData(654)]
        [InlineData(8985)]
        [InlineData(1529)]
        public void ReplaceNodeAtMiddleSuccessful(int data)
        {
            //Assign
            var linkedList = new CrackingTheCodeInterview.DataStructures.LinkedList<int>(new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(100));
            var nodeToReplace = new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(400);
            var rand = new Random();

            //Act
            for (int index = 0; index < 20; index++)
            {
                if (index == 10)
                    linkedList.Add(nodeToReplace);
                else
                    linkedList.Add(new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(rand.Next(1, 100)));
            }

            linkedList.Replace(nodeToReplace, new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(data));

            //Asert
            var node = linkedList.Head;

            for (int index = 0; index < 20; index++)
            {
                if(index == 11)
                {
                    Assert.Equal(data, node.Data);
                    Assert.IsType<int>(node.Data);
                    Assert.IsType<CrackingTheCodeInterview.DataStructures.LinkedListNode<int>>(node);
                    Assert.IsType<CrackingTheCodeInterview.DataStructures.LinkedList<int>>(linkedList);
                    break;
                }
                node = node.Next;
            }
        }

        [Theory]
        [InlineData(321)]
        [InlineData(987)]
        [InlineData(654)]
        [InlineData(8985)]
        [InlineData(1529)]
        public void ReplaceNodeAtEndSuccessful(int data)
        {
            //Assign
            var linkedList = new CrackingTheCodeInterview.DataStructures.LinkedList<int>(new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(100));
            var nodeToReplace = new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(400);
            var rand = new Random();

            //Act
            for (int index = 0; index < 20; index++)
            {
                linkedList.Add(new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(rand.Next(1, 100)));
            }
            linkedList.Add(nodeToReplace);
            linkedList.Replace(nodeToReplace, new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(data));

            //Asert
            var node = linkedList.Head;

            while(node.Next != null)
            {
                node = node.Next;
            }

            Assert.Equal(data, node.Data);
            Assert.IsType<int>(node.Data);
            Assert.IsType<CrackingTheCodeInterview.DataStructures.LinkedListNode<int>>(node);
            Assert.IsType<CrackingTheCodeInterview.DataStructures.LinkedList<int>>(linkedList);
        }
    }
}
