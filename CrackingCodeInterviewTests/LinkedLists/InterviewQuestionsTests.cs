using CrackingTheCodeInterview.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CrackingCodeInterviewTests.LinkedLists
{
    public class InterviewQuestionsTests
    {
        private CrackingTheCodeInterview.LinkedLists.InterviewQuestions _methods = new CrackingTheCodeInterview.LinkedLists.InterviewQuestions();

        [Theory]
        [InlineData(new int[] { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 9, 9 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [InlineData(new int[] { 1, 555, 44, 6, 77, 77, 89, 5, 6, 4 }, new int[] { 1, 555, 44, 6, 77, 89, 5, 4 })]
        [InlineData(new int[] { 3, 2, 2, 44, 6, 8, 79, 5, 1, 2, 1 }, new int[] { 3, 2, 44, 6, 8, 79, 5, 1 })]
        [InlineData(new int[] { 777, 888, 999, 456, 1532, 777, 556, 123, 666, 777 }, new int[] { 777, 888, 999, 456, 1532, 556, 123, 666 })]
        public void LinkedListHasNoDuplicates(int[] array, int[] expected)
        {
            //assign
            var linkedList = new CrackingTheCodeInterview.DataStructures.LinkedList<int>(new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(array[0]));

            for (int index = 1; index < array.Length; index++)
            {
                linkedList.Add(new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(array[index]));
            }
            //act
            var res = _methods.RemoveDuplicates(linkedList);
            //assert
            var node = res.Head;
            int idx = 0;
            while (node.Next != null)
            {
                Assert.Equal(expected[idx], node.Data);
                idx++;
                node = node.Next;
            }

            Assert.Equal(expected[idx], node.Data);
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 9, 9 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [InlineData(new int[] { 1, 555, 44, 6, 77, 77, 89, 5, 6, 4 }, new int[] { 1, 555, 44, 6, 77, 89, 5, 4 })]
        [InlineData(new int[] { 3, 2, 2, 44, 6, 8, 79, 5, 1, 2, 1 }, new int[] { 3, 2, 44, 6, 8, 79, 5, 1 })]
        [InlineData(new int[] { 777, 888, 999, 456, 1532, 777, 556, 123, 666, 777 }, new int[] { 777, 888, 999, 456, 1532, 556, 123, 666 })]
        public void LinkedListHasNoDuplicatesOrBuffer(int[] array, int[] expected)
        {
            //assign
            var linkedList = new CrackingTheCodeInterview.DataStructures.LinkedList<int>(new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(array[0]));

            for (int index = 1; index < array.Length; index++)
            {
                linkedList.Add(new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(array[index]));
            }
            //act
            var res = _methods.RemoveDuplicatesWithNoBuffer(linkedList);
            //assert
            var node = res.Head;
            int idx = 0;
            while (node.Next != null)
            {
                Assert.Equal(expected[idx], node.Data);
                idx++;
                node = node.Next;
            }

            Assert.Equal(expected[idx], node.Data);
        }

        [Theory]
        [InlineData("racecar")]
        [InlineData("civic")]
        [InlineData("kayak")]
        [InlineData("level")]
        [InlineData("solos")]
        [InlineData("wow")]
        public void IsPalindromeReturnsTrue(string str)
        {
            //Assign
            var linkedList = new DoublyLinkedList<char>(new DoublyLinkedListNode<char>(str[0]));
            for(int index = 1; index < str.Length; index++)
            {
                linkedList.Add(new DoublyLinkedListNode<char>(str[index]));
            }
            //Act
            bool res = _methods.IsPalindrome(linkedList);
            //Assert
            Assert.True(res);
        }

        [Theory]
        [InlineData("racecar")]
        [InlineData("civic")]
        [InlineData("kayak")]
        [InlineData("level")]
        [InlineData("solos")]
        [InlineData("wow")]
        public void StackIsPalindromeReturnsTrue(string str)
        {
            //Assign
            var linkedList = CrackingTheCodeInterview.DataStructures.LinkedList<char>.Create(str);
            //Act
            bool res = _methods.IsPalidrome(linkedList);
            //Assert
            Assert.True(res);
        }

        [Theory]
        [InlineData("racecars")]
        [InlineData("wowzers")]
        [InlineData("radars")]
        [InlineData("levels")]
        [InlineData("civics")]
        public void StackIsPalindromeReturnsFalse(string str)
        {
            //Assign
            var linkedList = CrackingTheCodeInterview.DataStructures.LinkedList<char>.Create(str);
            //Act
            bool res = _methods.IsPalidrome(linkedList);
            //Assert
            Assert.False(res);
        }

        [Theory]
        [InlineData("racecars")]
        [InlineData("wowzers")]
        [InlineData("radars")]
        [InlineData("levels")]
        [InlineData("civics")]
        public void IsPalindromeReturnsFalse(string str)
        {
            //Assign
            var linkedList = new DoublyLinkedList<char>(new DoublyLinkedListNode<char>(str[0]));
            for (int index = 1; index < str.Length; index++)
            {
                linkedList.Add(new DoublyLinkedListNode<char>(str[index]));
            }
            //Act
            bool res = _methods.IsPalindrome(linkedList);
            //Assert
            Assert.False(res);
        }



        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 5, 6 , 7, 8, 9 }, 5)]
        [InlineData(new int[] { 25,75,80,88,91,91,92,101,102,405 }, 100)]
        [InlineData(new int[] { 1000,1001,5000,4000,6544,500,456,777,666,111 }, 3522)]
        [InlineData(new int[] {-10,1,2,3,-4,-5,-11,100,-100,6 }, 0)]
        public void ArrayShouldBePartitionedLessThanToGreaterThan(int[] array, int partition)
        {
            //Assign
            var linkedList = new CrackingTheCodeInterview.DataStructures.LinkedList<int>(new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(array[0]));
            for(int index = 1; index < array.Length; index++)
            {
                linkedList.Add<int>(new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(array[index]));
            }
            //Act
            var res = _methods.Partition(linkedList, partition);
            //Assert
            var node = res.Head;
            while(node.Next != null)
            {
                if (node.Data >= partition)
                    break;
                else
                    Assert.True(node.Data < partition);

                node = node.Next;
            }

            while(node.Next != null)
            {
                Assert.True(node.Data >= partition);
                node = node.Next;
            }

            Assert.True(node.Data >= partition);
        }

        //[Theory]
        //[InlineData(new int[] { 1, 2, 3, 4, 5 })]
        //[InlineData(new int[] { 1, 2, 3, 4, 5, 6 })]
        //[InlineData(new int[] { 1, 4, 100, 5000, 1326, 4568, 785, 44 , 666 , 123 })]
        //public void (int[] array) 
        //{
        //    //Assign
        //    var linkedList = new CrackingTheCodeInterview.DataStructures.LinkedList<int>(new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(array[0]));
        //    CrackingTheCodeInterview.DataStructures.LinkedListNode<int> nodeToDelete = null;
        //    for (int index = 1; index < array.Length; index++)
        //    {
        //        var node = new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(array[index]);
        //        if (index == index - 2)
        //            nodeToDelete = node;
        //        linkedList.Add<int>(node);
        //    }

        //    //Act
        //    var res = _methods.FindKthToLast<int>(linkedList, array.Length + 1, nodeToDelete);

        //    //Assign
        //    Assert.Null(res);
        //}

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 5, 6 }, new int[] { 10, 11, 5, 6 }, 5)]
        [InlineData(new int[] { 1, 4, 5, 6, 7 }, new int[] { 10, 4, 5, 6, 7 }, 4)]
        [InlineData(new int[] { 11 ,12 ,13 , 1, 2, 3, 6, 7, 8, 9, 10 }, new int[] { 30, 11, 5, 6, 7, 8, 9, 10 }, 6)]
        [InlineData(new int[] { 1, 2, 3, 5, 6, 10, 11, 13, 15, 49, 75, 46, 12, 123 }, new int[] { 100,200,131,1354,111,222,333, 11, 5, 10,11,13,15,49,75,46,12,123 }, 10)]
        public void ShouldReturnIntersectingNode(int[] firstList, int[] secondList, int matchingNumber)
        {
            //Assign
            var intersectingNode = new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(matchingNumber);
            CrackingTheCodeInterview.DataStructures.LinkedList<int> firstLinkedList = null;
            CrackingTheCodeInterview.DataStructures.LinkedList<int> secondLinkedList = null;

            foreach(int num in firstList) 
            {
                if (firstLinkedList == null)
                {
                    if(num == matchingNumber)
                        firstLinkedList = new CrackingTheCodeInterview.DataStructures.LinkedList<int>(intersectingNode);
                    else
                        firstLinkedList = CrackingTheCodeInterview.DataStructures.LinkedList<int>.Create(num);
                    continue;
                }

                if (num == matchingNumber)
                {
                    firstLinkedList.Add(intersectingNode);
                }
                else
                    firstLinkedList.Add(new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(num));
            }
            foreach(int num in secondList) 
            {
                if (secondLinkedList == null)  
                {
                    if (num == matchingNumber)
                        secondLinkedList = new CrackingTheCodeInterview.DataStructures.LinkedList<int>(intersectingNode);
                    else
                        secondLinkedList = CrackingTheCodeInterview.DataStructures.LinkedList<int>.Create(num);
                    continue;
                }

                if(num == matchingNumber)
                {
                    secondLinkedList.Add(intersectingNode);
                }

                else 
                    secondLinkedList.Add(new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(num));
            }

            //Act
            var res = _methods.FindIntersectingNode(firstLinkedList, secondLinkedList);
            //Assert
            Assert.Equal(intersectingNode, res);
        }

        [Theory]
        [InlineData(new int[] {1,2,3,4,5,6,7,8,9,10 }, 5)]
        [InlineData(new int[] {100,200,300 }, 200)]
        [InlineData(new int[] { 111,123,546,548,3}, 546)]
        [InlineData(new int[] { 7895,154621,1321354,1,2,3,4,5,6,7,8,9,10}, 1)]
        public void ShouldReturnLoopStart(int[] array, int loopStart)
        {
            //Assign
            var linkedList = CrackingTheCodeInterview.DataStructures.LinkedList<int>.Create(array[0]);
            var loopStartNode = new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(loopStart);
            for(int index = 1; index < array.Length; index++)
            {
                if (array[index] == loopStart)
                    linkedList.Add(loopStartNode);
                else
                {
                    if (index == array.Length - 1)
                    {
                        var loopEndNode = new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(array[index]);
                        loopEndNode.Next = loopStartNode;
                        linkedList.Add(loopEndNode);
                    }
                    else
                        linkedList.Add(new CrackingTheCodeInterview.DataStructures.LinkedListNode<int>(array[index]));
                }
            }

            //Act
            var res = _methods.ReturnLoopStart(linkedList);
            //Assert
            Assert.Equal(res, loopStartNode);
        }
    }
}
