using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CrackingTheCodeInterview.StacksAndQueues;
using CrackingTheCodeInterview.DataStructures;
using System.Linq;
using static CrackingTheCodeInterview.StacksAndQueues.InterviewQuestions;

namespace CrackingCodeInterviewTests.StacksAndQueues
{
    public class InterviewQuestionsTests
    {
        #region Three in One

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [InlineData(new int[] { 1, 2, 3 })]
        public void ShouldBeSplitIntoThreeStacks(int[] array) 
        {
            //Assign
            var method = new InterviewQuestions.ThreeInOne<int>(array);
            //Act
            //Assert
            Assert.NotNull(method.FirstStack);
            Assert.NotNull(method.SecondStack);
            Assert.NotNull(method.ThirdStack);
            Assert.True(method.FirstStack.Count() > 0);
            Assert.True(method.FirstStack.Count() > 0);
            Assert.True(method.FirstStack.Count() > 0);
        }

        #endregion
        #region Sort Stack
        [Theory]
        [InlineData(new int[] { 9,5,1,3,2,4,6,7,8 }, new int[] {1,2,3,4,5,6,7,8,9 })]
        [InlineData(new int[] { 99,5,2,1}, new int[] { 1,2,5,99})]
        [InlineData(new int[] { 3,1 }, new int[] { 1,3 })]
        [InlineData(new int[] { 1 }, new int[] { 1 })]
        [InlineData(new int[] { -11,99,5,1000}, new int[] { -11,5,99,1000})]
        public void StackMinShouldOrderFromLeastToGreatest(int[] array, int[] expected)
        {
            //Assign
            var method = new InterviewQuestions.MinSortedStack(array);
            //Act
            var res = method.SortedStack;
            //Assert
            foreach(int number in expected)
            {
                Assert.Equal(number, res.Pop());
            }
        }

        [Theory]
        [InlineData(new int[] { 9, 5, 1, 3, 2, 4, 6, 7, 8 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 10)]
        [InlineData(new int[] { 99, 5, 2, 1 }, new int[] { 1, 2, 3 , 5, 99 }, 3)]
        [InlineData(new int[] { 3, 1 }, new int[] { 1, 2, 3 }, 2)]
        [InlineData(new int[] { 1 }, new int[] { -1, 1 }, -1)]
        [InlineData(new int[] { -11, 99, 5, 1000 }, new int[] { -11, 5, 99, 1000, 1001 }, 1001)]
        public void StackMinShouldPushNumberCorrectPosition(int[] array, int[] expected, int number) 
        {
            //Assign
            var method = new InterviewQuestions.MinSortedStack(array);
            //Act
            method.Push(number);
            var res = method.SortedStack;
            //Assert
            foreach(int num in expected)
            {
                Assert.Equal(num, res.Pop());
            }
        }

        [Theory]
        [InlineData(new int[] { })]
        public void StackMinIsEmptyShouldReturnTrue(int[] array) 
        {
            //Assign
            var method = new InterviewQuestions.MinSortedStack(array);
            //Act
            //Assert
            Assert.True(method.IsEmpty());
        }

        [Theory]
        [InlineData(new int[] { 1,2,3,4,5,6,7,8,9 }, 1)]
        [InlineData(new int[] { 44,22,33,7,8,9,45,1,2},1)]
        [InlineData(new int[] { 321,456,45,1,332,7,-1},-1)]
        [InlineData(new int[] { 1000,22222,33,45,67,8984,666},33)]
        [InlineData(new int[] { -50,-2,-3,-100,1},-100)]
        public void StackMinShouldPeekSmallestNumber(int[] array, int expected) 
        {
            //Assign
            var method = new InterviewQuestions.MinSortedStack(array);
            //Act
            //Assert
            Assert.Equal(expected, method.Peek());
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1)]
        [InlineData(new int[] { 44, 22, 33, 7, 8, 9, 45, 1, 2 }, 1)]
        [InlineData(new int[] { 321, 456, 45, 1, 332, 7, -1 }, -1)]
        [InlineData(new int[] { 1000, 22222, 33, 45, 67, 8984, 666 }, 33)]
        [InlineData(new int[] { -50, -2, -3, -100, 1 }, -100)]
        public void StackMinShouldPopSmallestNumber(int[] array, int expected) 
        {
            //Assign
            var method = new InterviewQuestions.MinSortedStack(array);
            //Act
            //Assert
            Assert.Equal(expected, method.Pop());
        }
        #endregion
        #region Stack of Plates

        [Theory]
        [InlineData(new int[] {  })]
        [InlineData(new int[] { 1 })]
        [InlineData(new int[] { 1,2,3,4 })]
        [InlineData(new int[] { 1,2,3,5,6 })]
        [InlineData(new int[] { 1,2,3,5,6,7,8,9 })]
        [InlineData(new int[] { 1,2,3,1,2,3,4,5,6,7,8,9,1,2,3,4,5,6,4,8,799 })]
        public void ShouldReturnProperSetOfStacks(int[] array)
        {
            //assign
            var method = new InterviewQuestions.SetOfStacks<int>(array, 1);
            //act
            int res = method.CountOfStacks;
            //Assert
            Assert.Equal(array.Length, res);
        }

        [Theory]
        [InlineData(new int[] { 5, 2, 3, 4 }, 5)]
        [InlineData(new int[] { 5, 2 }, 3)]
        [InlineData(new int[] {  }, 1)]
        [InlineData(new int[] { 2,3,4,5,6,7,8 }, 9)]
        [InlineData(new int[] { 2,1 }, 9)]
        public void ShouldPushToCurrentStack(int[] array, int size) 
        {
            //Assign
            var method = new InterviewQuestions.SetOfStacks<int>(array, size);
            //Act
            method.Push(1);
            //Assert
            Assert.Equal(1, method.Pop());
        }

        [Theory]
        [InlineData(new int[] { 4,5,6,7,8,9}, 6)]
        [InlineData(new int[] { 0,2,3,4}, 4)]
        [InlineData(new int[] { 999,888,555}, 3)]
        [InlineData(new int[] { 100 }, 1)]
        [InlineData(new int[] {2,3 }, 2)]
        public void ShouldPushToNewStack(int[] array, int size)
        {
            //Assign
            var method = new InterviewQuestions.SetOfStacks<int>(array, size);
            //Act
            method.Push(1);
            //Assert
            Assert.True(method.CurrentStackSize == 1);
            Assert.True(method.CountOfStacks > 1);
        }

        [Theory]
        [InlineData(new int[] { 2,3,4,5,6,7,8,9}, 10)]
        [InlineData(new int[] {44,55,66,2,3,1,4 }, 654)]
        [InlineData(new int[] { 7,8,9,6,5,4}, -999)]
        [InlineData(new int[] { 3,2}, 333)]
        [InlineData(new int[] { 0}, -1)]
        [InlineData(new int[] { }, 1)]
        public void ShouldPopSameValuesPushed(int[] array, int expected)
        {
            //Assign
            var method = new InterviewQuestions.SetOfStacks<int>(array, 10);
            //Act
            method.Push(expected);
            var res = method.Pop();
            //Assert
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(new int[] { 1,2,3,4,5,6,7,8,9}, 3, 3)]
        [InlineData(new int[] { 11,22,4,6,52,3,19,4}, 11, 1)]
        [InlineData(new int[] { 44,66,33,55}, 55, 4)]   
        public void ShouldPopAtSpecifiedIndex(int[] array, int expected, int index) 
        {
            //Assign
            var method = new InterviewQuestions.SetOfStacks<int>(array, 1);
            //Act
            var res = method.PopAt(index);
            //Assert
            Assert.Equal(expected, res);
        }

        #endregion
        #region Stack Min

        [Theory]
        [InlineData(new int[] {0,1,2,3,4,5,6,7,8,9 }, 0)]
        [InlineData(new int[] { 99,55,4,2,113,54,48,9648,-1}, -1)]
        [InlineData(new int[] { 3}, 3)]
        [InlineData(new int[] { -25,-100,-50,-1,0}, -100)]
        [InlineData(new int[] { 100000,1000, 1,100,10}, 1)]
        public void ShouldReturnMinNumber(int[] array, int expected)
        {
            //Assign
            var method = new MinStack(array);
            //Act
            var res = method.MinimumElement;
            //Assert
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(new int[] { 1,2,3,4,5,6,7,8,9 }, 0)]
        [InlineData(new int[] { 111,222,333,4,5,6}, 3)]
        [InlineData(new int[] { -110,-50,-10,0,1}, -1000)]
        [InlineData(new int[] { 2,3,4}, 1)]
        [InlineData(new int[] { 1}, 0)]
        public void ShouldUpdateMinimumElement(int[] array, int expected) 
        {
            //Assign
            var method = new MinStack(array);
            //Act
            method.Push(expected);
            //Assert
            Assert.Equal(expected, method.MinimumElement);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1,0)]
        [InlineData(new int[] { 111, 222, 333, 4, 5, 6 }, 4,3)]
        [InlineData(new int[] { -110, -50, -10, 0, 1 }, -110,-1000)]
        [InlineData(new int[] { 2, 3, 4 }, 2,1)]
        [InlineData(new int[] { 1 },1,0)]
        public void ShouldUpdateToPreviousMinimum(int[] array, int expected, int newMinimum) 
        {
            //Assign
            var method = new MinStack(array);
            //Act
            method.Push(newMinimum);
            method.Pop();
            //Assert
            Assert.Equal(expected, method.MinimumElement);
        }

        #endregion
        #region Queue via Stacks

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void ShouldPushElement(int number)
        {
            //Assign
            var stack = new MyQueue<int>(number);
            //Act
            stack.Add(number);
            //Assert
            Assert.Equal(number, stack.Remove());
        }

        [Theory]
        [InlineData(new int[] {1,2,3,4,5,6,7,8,9 }, 1)]
        [InlineData(new int[] { 100,665,44,5}, 100)]
        [InlineData(new int[] { -1 }, -1)]
        [InlineData(new int[] { 6,5,4}, 6)]
        [InlineData(new int[] { 0,1}, 0)]
        public void ShouldDequeueExpectedInt(int[] array, int expected)
        {
            //Assign
            var stack = new MyQueue<int>(array);
            //Act
            var res = stack.Remove();
            //Assert
            Assert.Equal(expected, res);
        }

        #endregion
        #region AnimalShelter

        [Theory]
        [InlineData(new AnimalType[] { AnimalType.Dog, AnimalType.Cat, AnimalType.Cat}, AnimalType.Dog)]
        [InlineData(new AnimalType[] { AnimalType.Cat, AnimalType.Dog, AnimalType.Dog}, AnimalType.Cat)]
        public void ShouldReturnOldestAnimal(AnimalType[] array, AnimalType expected)
        {
            //Assign
            var method = new AnimalShelter(array);
            //Act
            var res = method.DequeueAny();
            //Assert
            Assert.Equal(expected, res.Animal);
        }

        #endregion
    }
}