using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CrackingTheCodeInterview.DataStructures;

namespace CrackingCodeInterviewTests.DataStructures
{
    public class StackTests
    {

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void ShouldPushElement(int number)
        {
            //Assign
            var stack = CrackingTheCodeInterview.DataStructures.Stack<int>.Create(100);
            //Act
            stack.Push(number);
            //Assert
            Assert.Equal(number, stack.Peek());
        }

        [Theory]
        [InlineData(new int[] {1,2,3,4,5,6,7,8,9,10 })]
        [InlineData(new int[] {100,1231,1548,64561,11546,121321 })]
        [InlineData(new int[] { 1,2,444,566,480})]
        [InlineData(new int[] { 1,9})]
        [InlineData(new int[] { 1 })]
        public void IsEmptyShouldReturnTrue(int[] array)
        {
            //Assign
            var stack = CrackingTheCodeInterview.DataStructures.Stack<int>.Create(array);
            //Act
            while(!stack.IsEmpty())
            {
                stack.Pop();
            }
            //Assert
            Assert.True(stack.IsEmpty());
            Assert.True(stack.Top == null);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [InlineData(new int[] { 100, 1231, 1548, 64561, 11546, 121321 })]
        [InlineData(new int[] { 1, 2, 444, 566, 480 })]
        [InlineData(new int[] { 1, 9 })]
        [InlineData(new int[] { 1 })]
        public void IsEmptyShouldReturnFalse(int[] array)
        {
            //Assign
            var stack = CrackingTheCodeInterview.DataStructures.Stack<int>.Create(array);
            //Act
            //Assert
            Assert.False(stack.IsEmpty());
            Assert.NotNull(stack.Top);
        }

        [Theory]
        [InlineData(new int[] { 1 }, 1)]
        [InlineData(new int[] { 1,2,3,4,5,6,7,8,9,10 }, 10)]
        [InlineData(new int[] { 1,111,222,33,444,556 }, 556)]
        [InlineData(new int[] { 999,4445,111,223 }, 223)]
        [InlineData(new int[] { 1,0 }, 0)]
        public void PeekShouldReturnTopData(int[] array, int expected)
        {
            //Assign
            var stack = CrackingTheCodeInterview.DataStructures.Stack<int>.Create(array);
            //Act
            var res = stack.Peek();
            //Assert
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(new int[] { 1 }, 1)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 10)]
        [InlineData(new int[] { 1, 111, 222, 33, 444, 556 }, 556)]
        [InlineData(new int[] { 999, 4445, 111, 223 }, 223)]
        [InlineData(new int[] { 1, 0 }, 0)]
        public void PeekNodeShouldReturnTopNode(int[] array, int number)
        {
            //Assign
            var node = new StackNode<int>(number);
            var stack = CrackingTheCodeInterview.DataStructures.Stack<int>.Create(array);
            //Act
            stack.Push(node);
            //Assert
            Assert.Equal(node, stack.PeekNode());
        }

        [Theory]
        [InlineData(new int[] { 1 }, 2)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 15)]
        [InlineData(new int[] { 1, 111, 222, 33, 444, 556 }, 66)]
        [InlineData(new int[] { 999, 4445, 111, 223 }, 9)]
        [InlineData(new int[] { 1, 0 }, 3)]
        public void PopNodeShouldTakeTopNode(int[] array, int number)
        {
            //Assign
            var node = new StackNode<int>(number);
            var stack = CrackingTheCodeInterview.DataStructures.Stack<int>.Create(array);
            //Act
            stack.Push(node);
            var res = stack.PopNode();
            //Assert
            Assert.Equal(node, res);
            Assert.NotEqual(node, stack.Top);
        }

        [Theory]
        [InlineData(new int[] { 1 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [InlineData(new int[] { 1, 111, 222, 33, 444, 556 })]
        [InlineData(new int[] { 999, 4445, 111, 223 })]
        [InlineData(new int[] { 1, 0 })]
        public void ShouldBeEnumerable(int[] array)
        {
            //Assign
            var stack = CrackingTheCodeInterview.DataStructures.Stack<int>.Create(array);
            //Act
            //Assert
            foreach(int number in stack)
            {
                Assert.Equal(number, stack.Pop());
            }
        }
    }
}
