using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CrackingTheCodeInterview.DataStructures;

namespace CrackingCodeInterviewTests.DataStructures
{
    public class QueueTests
    {
        [Theory]
        [InlineData(new int[] { 1 })]
        [InlineData(new int[] { 1,2,3,4,5,6,7,8,9 })]
        [InlineData(new int[] { 1,100,22,3,4445,6,88,4,5,77,89,9, })]
        [InlineData(new int[] { 1,123,321,456,654,789,987 })]
        [InlineData(new int[] { 1,2 })]
        public void QueueShouldBeEnumerable(int[] array)
        {
            //Assign
            var queue = CrackingTheCodeInterview.DataStructures.Queue<int>.Create(array);
            //Act
            //Assert
            foreach(var node in queue)
            {
                Assert.Equal(node, queue.Remove());
            }
        }

        [Theory]
        [InlineData(new int[] { 1 }, 3)]
        [InlineData(new int[] { 1,2,3,4,56,777,8885,4 }, 1100)]
        [InlineData(new int[] { 1,333,444,55 }, 6)]
        [InlineData(new int[] { 1,789,321,654 }, 44)]
        [InlineData(new int[] { 1,2 }, 3)]
        public void QueueShouldAddData(int[] array, int expected) 
        {
            //Assign
            var queue = CrackingTheCodeInterview.DataStructures.Queue<int>.Create(array);
            //Act
            queue.Add(expected);
            //Assert
            Assert.Equal(expected, queue.Last.Data);
        }

        [Theory]
        [InlineData(new int[] { 1 }, 3)]
        [InlineData(new int[] { 1, 2, 3, 4, 56, 777, 8885, 4 }, 1100)]
        [InlineData(new int[] { 1, 333, 444, 55 }, 6)]
        [InlineData(new int[] { 1, 789, 321, 654 }, 44)]
        [InlineData(new int[] { 1, 2 }, 3)]
        public void QueueShouldAddNode(int[] array, int expected)
        {
            //Assign
            var queue = CrackingTheCodeInterview.DataStructures.Queue<int>.Create(array);
            var node = new QueueNode<int>(expected);
            //Act
            queue.Add(node);
            //Assert
            Assert.Equal(node, queue.Last);
            Assert.Equal(node.Data, queue.Last.Data);
        }

        [Theory]
        [InlineData(new int[] { 1 })]
        [InlineData(new int[] { 1,2,3,4,5,6,7,8,9})]
        [InlineData(new int[] { 111,11,22,33,44,55,66,77,88,99})]
        [InlineData(new int[] { 5,6})]
        [InlineData(new int[] { 1000,222,4546,749})]
        public void IsEmptyShouldBeTrue(int[] array)
        {
            //Assign
            var queue = CrackingTheCodeInterview.DataStructures.Queue<int>.Create(array);
            //Act
            foreach(int number in queue)
            {
                queue.Remove();
            }
            //Assert
            Assert.Empty(queue);
            Assert.True(queue.IsEmpty());
        }

        [Theory]
        [InlineData(new int[] {1,2,3,4,5,6,7,8,9 }, 1)]
        [InlineData(new int[] {9,8,7,6,5,4,3,2,1 }, 9)]
        [InlineData(new int[] { 111,22,33,456,745}, 111)]
        [InlineData(new int[] { 5}, 5)]
        [InlineData(new int[] { 0,1}, 0)]
        public void PeekShouldReturnTrue(int[] array, int expected)
        {
            //Assign
            var queue = CrackingTheCodeInterview.DataStructures.Queue<int>.Create(expected);
            //Act
            foreach(int number in array)
            {
                queue.Add(number);
            }
            //Assert
            Assert.Equal(expected, queue.Peek());
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1)]
        [InlineData(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 }, 9)]
        [InlineData(new int[] { 111, 22, 33, 456, 745 }, 111)]
        [InlineData(new int[] { 5 }, 5)]
        [InlineData(new int[] { 0, 1 }, 0)]
        public void PeekNodeShouldReturnTrue(int[] array, int expected)
        {
            //Assign
            var node = new QueueNode<int>(expected);
            var queue = CrackingTheCodeInterview.DataStructures.Queue<int>.Create(node);
            //Act
            foreach(int number in array)
            {
                queue.Add(number);
            }
            //Assert
            Assert.Equal(node, queue.PeekNode());
            Assert.Equal(queue.PeekNode().Data, expected);
        }

        [Theory]
        [InlineData(new int[] { 1,2,3,4,5,6,7,8,9}, 6)]
        [InlineData(new int[] { 555,444,66,3,1,22,77}, 4)]
        [InlineData(new int[] { 2,333,4,22,4}, 777)]
        [InlineData(new int[] { 888,7}, 2)]
        [InlineData(new int[] { 0}, 1)]
        public void ShouldRemoveFirstAndMatchExpected(int[] array, int expected)
        {
            //Assign
            var queue = CrackingTheCodeInterview.DataStructures.Queue<int>.Create(expected);
            //Act
            foreach(int number in array)
            {
                queue.Add(number);
            }
            //Assert
            Assert.Equal(expected, queue.Remove());
            Assert.NotEqual(expected, queue.Remove());
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 33)]
        [InlineData(new int[] { 555, 444, 66, 3, 1, 22, 77 }, 4)]
        [InlineData(new int[] { 2, 333, 4, 22, 4 }, 7)]
        [InlineData(new int[] { 888, 7 }, 9)]
        [InlineData(new int[] { 0 }, 5)]
        public void ShouldRemoveFirstNode(int[] array, int expected)
        {
            //Assign
            var node = new QueueNode<int>(expected);
            var queue = CrackingTheCodeInterview.DataStructures.Queue<int>.Create(node);
            //Act
            foreach (int number in array)
            {
                queue.Add(number);
            }
            //Assert
            Assert.Equal(node, queue.RemoveNode());
            Assert.NotEqual(node, queue.RemoveNode());
        }
    }
}
