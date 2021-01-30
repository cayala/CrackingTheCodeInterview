using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;
using Xunit;

namespace CrackingCodeInterviewTests.ArraysAndStrings
{
    public class InterviewQuestionsTests
    {
        private CrackingTheCodeInterview.ArraysAndStrings.InterviewQuestions _methods = new CrackingTheCodeInterview.ArraysAndStrings.InterviewQuestions();

        [Theory]
        [InlineData("Asdghjklka")]
        [InlineData("bbzxcvm")]
        [InlineData("wejklqqhl")]
        [InlineData("ss")]
        [InlineData("ASDFGHJKK")]
        [InlineData("ASDFqqGHJK")]
        public void IsUniqueReturnsFalse(string str) 
        {
            //Assign
            //Assert
            bool res = _methods.IsStringUniqueCharacters(str);
            //Act
            Assert.False(res);
        }

        [Theory]
        [InlineData("asdf")]
        [InlineData("ASDFZXCV")]
        [InlineData("asdfBWMN")]
        [InlineData("asdfMNlk")]
        [InlineData("QWertyUI")]
        public void IsUniqueReturnsTrue(string str)
        {
            //Assign
            //Assert
            bool res = _methods.IsStringUniqueCharacters(str);
            //Act
            Assert.True(res);
        }

        [Theory]
        [InlineData("asdf","fdsa")]
        [InlineData("QWER","WERQ")]
        [InlineData("QWcx","xcqw")]
        [InlineData("kljh","JKLH")]
        [InlineData("MnB","mNb")]
        public void IsPermutationReturnsTrue(string str, string str2) 
        {
            //Assign
            //Assert
            bool res = _methods.IsPermutation(str, str2);
            //Act
            Assert.True(res);
        }

        [Theory]
        [InlineData("asdfa", "fdsa")]
        [InlineData("QWERv", "WERQ")]
        [InlineData("QWcxc", "xcqw")]
        [InlineData("kljhb", "JKLH")]
        [InlineData("MnBa", "mNb")]
        public void IsPermutationReturnsFalse(string str, string str2)
        {
            //Assign
            //Assert
            bool res = _methods.IsPermutation(str, str2);
            //Act
            Assert.False(res);
        }

        [Theory]
        [InlineData("asdf qwer")]
        [InlineData("AZXCD VBNNG")]
        [InlineData("ASDF zxcv")]
        [InlineData("adfVW ASER ")]
        [InlineData(" zzzz vvvv ")]
        [InlineData("aaaaaaaaaaa")]
        public void UrlifyReplacedWhiteSpaces(string str) 
        {
            //Assign
            var arraysAndStrings = new CrackingTheCodeInterview.ArraysAndStrings.InterviewQuestions();
            List<int> indexOfWhiteSpace = new List<int>();
            //Act
            for(int index = 0; index < str.Length; index++)
            {
                if (str[index] == ' ')
                    indexOfWhiteSpace.Add(index);
            }
            string res = _methods.Urlify(str);
            //Assert
            Assert.IsType<string>(res);

            if (str.Contains(' '))
            {
                Assert.Contains("%20", res);
                Assert.DoesNotContain(" ", res);
            }
            else
                Assert.Equal(str, res);
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
            //Act
            bool res = _methods.IsPalindrome(str);
            //Assert
            Assert.True(res);
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
            //Act
            bool res = _methods.IsPalindrome(str);
            //Assert
            Assert.False(res);
        }

        [Theory]
        [InlineData("away ", "away")]
        [InlineData("way", "away")]
        [InlineData("az fd", "azfd")]
        [InlineData("assess", "assedss")]
        [InlineData("facts", "factsz")]
        public void IsOneOrZeroEditsAwayReturnsTrue(string expected, string str)
        {
            //Assign
            //Act
            bool res = _methods.IsOneOrZeroEditsAway(expected, str);
            //Assert
            Assert.True(res);
        }

        [Theory]
        [InlineData("aaaaa", "bbbbb")]
        [InlineData("zzzvv", "zzzvvas")]
        [InlineData("asdf", "asdfasdf")]
        [InlineData("asdf", "a")]
        [InlineData("zxcv", "qwer")]
        public void IsOneOrZeroEditsAwayReturnsFalse(string expected, string str) 
        {
            //Assign
            //Act
            bool res = _methods.IsOneOrZeroEditsAway(expected, str);
            //Assert
            Assert.False(res);
        }


        [Theory]
        [InlineData("aaaa", "a4")]
        [InlineData("abbcccdddd", "a1b2c3d4")]
        [InlineData("gggggqqqqwww", "g5q4w3")]
        [InlineData("ffffffffffaaaaa", "f10a5")]
        [InlineData("assssssss", "a1s8")]
        public void CompressStringShouldShorter(string str, string expected) 
        {
            //Assign
            //Act
            var res = _methods.CompressString(str);
            //Assert
            Assert.Equal(expected, res);
            Assert.True(res.Length < str.Length);
        }

        [Theory]
        [InlineData("a", "a")]
        [InlineData("ab", "ab")]
        [InlineData("asdf", "asdf")]
        [InlineData("qwerty", "qwerty")]
        [InlineData("HelloWorld", "HelloWorld")]
        public void CompressStringShouldBeSame(string expected, string str) 
        {
            //Assign
            //Act
            var res = _methods.CompressString(str);
            //Assert
            Assert.Equal(expected, res);
            Assert.True(res.Length == str.Length);
        }

        [Fact]
        public void ImageArrayShouldBeRotatedNintyDegrees()
        {
            //int[,] array = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            //int[,] expected = new int[,] { { 7, 4, 1 }, { 8, 5, 2 }, { 9, 6, 3 } };

            //int[,] array = new int[,] { { 1, 2 }, { 3, 4 }};
            //int[,] expected = new int[,] { { 3, 1 }, { 4, 2 } };

            int[,] array = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            int[,] expected = new int[,] { { 13, 9, 5, 1 }, { 14, 10, 6, 2 }, { 15, 11, 7, 3 }, { 16, 12, 8, 4 } };

            //Act
            var res = _methods.RotateImageNintyDegrees(array);
            //Assert
            Assert.Equal(expected, res);
        }

        [Fact]
        public void ZeroMatrixShouldZeroOutOneRowAndColumn() 
        {
            int[,] array = new int[,] { { 1, 2, 3, 4 }, { 5,6,7,8}, { 9, 10, 11, 0} };
            int[,] expected = new int[,] { { 1, 2, 3, 0 }, {5, 6, 7, 0 }, { 0,0,0,0 } };

            var res = _methods.ZeroMatrix(array);

            Assert.Equal(expected, array);
        }

        [Theory]
        [InlineData("waterbottle", "erbottlewat")]
        [InlineData("racecar", "carrace")]
        [InlineData("helloworld", "worldhello")]
        [InlineData("idontknowisonthird", "thirdidontknowison")]
        [InlineData("helloiamagnome", "gnomehelloiama")]
        public void IsSubStringShouldReturnTrue(string expected, string str) 
        {
            //Assign
            //Act
            var res = _methods.IsSubString(expected, str);
            //Assert
            Assert.True(res);
        }

        [Theory]
        [InlineData("qwerty", "qater")]
        [InlineData("asdf", "fghj")]
        [InlineData("zzzzzzzzzzzzzzzzz", "aaaaaaaaaaaaaaaaaaaa")]
        [InlineData("a", "q")]
        [InlineData("whosisonfirst", "whatsonsecond")]
        public void IsSubStringShouldReturnFalse(string expected, string str)
        {
            //Assign
            //Act
            var res = _methods.IsSubString(expected, str);
            //Assert
            Assert.False(res);
        }
    }
}
