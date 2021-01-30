using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CrackingTheCodeInterview.ArraysAndStrings
{
    public class InterviewQuestions
    {
        #region Is Unique
        /*
         Implement an algorithim to determine if a string has all unique characters. What if you cannot use additional data structures
         */
        //public bool IsStringUniqueCharacters(string str) 
        //{
        //    //O(n^2)
        //    string copy = str.ToLower();
        //    for (int idx = 0; idx < copy.Length - 1; idx++) 
        //    {
        //        for (int innerIdx = idx + 1; innerIdx < copy.Length; innerIdx++) 
        //        {
        //            if (copy[idx] == copy[innerIdx])
        //                return false;
        //        }
        //    }

        //    return true;
        //}

        public bool IsStringUniqueCharacters(string str)
        {
            //O(n)
            string copy = str.ToLower();
            Dictionary<char, char> chars = new Dictionary<char, char>();
            for (int idx = 0; idx < str.Length; idx++) 
            {
                if (chars.ContainsKey(str[idx]))
                    return false;
                else
                    chars.Add(str[idx], str[idx]);
            }
            return true;
        }
        #endregion

        #region Check Permutation
        /*
         Given two strings, write a method to decide if one is a permutation of the other (contains all characters but in a different order)
         */
        public bool IsPermutation(string baseStr, string permStr) 
        {
            //O(N)
            string baseCopy = baseStr.ToLower();
            string permCopy = permStr.ToLower();
            Dictionary<char, char> baseDict = new Dictionary<char, char>();

            if (baseCopy.Length == permCopy.Length) 
            {
                for (int idx = 0; idx < baseStr.Length; idx++) 
                {
                    baseDict.Add(baseCopy[idx], baseCopy[idx]);
                }

                for (int idx = 0; idx < baseCopy.Length; idx++) 
                {
                    if (!baseDict.ContainsKey(baseCopy[idx]))
                        return false;
                }
                return true;
            }

            return false;
        }
        #endregion

        #region Urlify
        /*
         Write a method to replace all spaces in a string with '%20'. You may assume that the string has sufficient space at the end to hold the additional characters, and that you are given the "true" length of the string.
         */
        //public string Urlify(string str) 
        //{
        //    //O(n)
        //    if (str.Contains(' '))
        //        str = str.Replace(" ", "%20");

        //    return str;
        //}

        public string Urlify(string str)
        {
            //O(n)
            if (str.Contains(' '))
            {
                string copy = string.Empty;

                int subStrBeginning = 0;
                for (int index = 0; index < str.Length; index++)
                {
                    if (str[index] == ' ')
                    {
                        copy += str.Substring(subStrBeginning + 1, CalculateSubStrLength(index, subStrBeginning)) + "%20";
                        subStrBeginning = index;
                    }
                }

                return copy;
            }
            else
                return str;

            static int CalculateSubStrLength(int index, int subStrBegin) 
            {
                int res = index - subStrBegin - 1;
                if (res <= 0)
                    return 0;
                else
                    return res;
            }
        }
        #endregion

        #region Panidrome Permutation
        /*
         Given a string, write a function to check if it is a permutation of a palindrome. A paindrome is a word or phrase that is the same forwards and backwards. A permutation is a rearrangement of letters. The palindrome does not need to be limited to just dictionary words. You can ignore casing and non-letter characters.
         */
        public bool IsPalindrome(string str) 
        {
            str = str.ToLower();
            char[] backwardsStr = new char[str.Length];

            int backwaredsStrIdx = 0;
            for (int index = str.Length - 1; index > -1; index--) 
            {
                backwardsStr[backwaredsStrIdx] = str[index];
                backwaredsStrIdx++;
            }
            if (new string(backwardsStr) == str)
                return true;
            else
                return false;
        }
        #endregion

        #region One Away
        /*
         There are three types of edits that can be performed on strings: insert a character, remove a character, or replace a character. Given two strings, write a function to check if they are one edit (or zero edits) away.
         */

        public bool IsOneOrZeroEditsAway(string expected, string str) 
        {
            if (str == expected) return true;

            List<char> insertCopy, replaceCopy, deleteCopy;
            insertCopy = str.ToList();
            replaceCopy = str.ToList(); 
            deleteCopy = str.ToList();

            int length = expected.Length > str.Length ? expected.Length : str.Length;
            for (int index = 0; index < length; index++) 
            {
                if(index == expected.Length)
                {
                    insertCopy.Insert(index, str[index]);
                    deleteCopy.RemoveAt(index);
                    break;
                }

                if(index == str.Length)
                {
                    insertCopy.Insert(index, expected[index]);
                    break;
                }

                if(expected[index] != str[index])
                {
                    insertCopy.Insert(index, expected[index]);
                    replaceCopy[index] = expected[index];
                    deleteCopy.RemoveAt(index);
                    break;
                }
            }

            if (new string(insertCopy.ToArray()) == expected || new string(replaceCopy.ToArray()) == expected || new string(deleteCopy.ToArray()) == expected) return true;
            else return false;
        }
        #endregion

        #region String Compression
        /*
         Implement a method to perform basic string compression using the counts of repeated characters. For example, the string aabcccccaaa would become a2b1c5a3. If the "compressed" string would not become smaller than the original string, your method should return the original string. You  can assume the string has only uppercase and lowercase letters (a - z).
         */

        public string CompressString(string str) 
        {
            string compressedString = string.Empty;

            int length = 0;
            char lastChar = char.MinValue;
            for (int index = 0; index < str.Length; index++) 
            {
                if(lastChar != str[index])
                {
                    if(index > 0)
                    {
                        compressedString += new string(lastChar, 1) + length.ToString();
                    }

                    lastChar = str[index];
                    length = 1;
                }
                else if(index == str.Length - 1)
                {
                    ++length;
                    compressedString += new string(lastChar, 1) + length.ToString();
                }
                else
                    length++;
            }

            if (str.Length == 1) return str;
            
            return compressedString.Length < str.Length ? compressedString : str;
        }
        #endregion

        #region Rotate Matrix
        /*
         * Given an image represented by an N x N matrix, where each pixel in the image is represented by an integer, write a method to rotate the image by 90 degrees. Can you do this in place?
         */

        public int[,] RotateImageNintyDegrees(int[,] image) 
        {
            int gridIndex = image.GetLength(0);
            int[,] rotatedImage = new int[image.GetLength(0), image.GetLength(1)];
            for (int outterIdx = 0; outterIdx < image.GetLength(0); outterIdx++) 
            {
                for (int innerIdx = 0; innerIdx < image.GetLength(0); innerIdx++) 
                {
                    rotatedImage[outterIdx,innerIdx] = image[(gridIndex - 1), outterIdx];
                    gridIndex--;
                }
                gridIndex = image.GetLength(0);
            }
            return rotatedImage;
        }
        #endregion

        #region Zero Matrix
        /*
         * Write an algorithm such that if an element in an M x N matrix is 0, its entire row and column are set to 0
         */

        public int[,] ZeroMatrix(int[,] array)
        {
            //loop through and alter all horizontal arrays
            //save the index for the column to alter
            //loop through the rows again and change that column
            //gonna require 2 nested loops for each shift

            //this will only handle on column for instance, it can be updated to handle 2+ with a few extra changes
            int columnIdx = -1;

            for (int outterIdx = 0; outterIdx < array.GetLength(0); outterIdx++) 
            {
                bool setToZero = false;
                for (int innerIdx = array.GetLength(1) - 1; -1 < innerIdx; innerIdx--) 
                {
                    if(array[outterIdx, innerIdx] == 0)
                    {
                        innerIdx = array.GetLength(1) - 1;
                        setToZero = true;
                        columnIdx = innerIdx;
                    }
                    if (setToZero)
                        array[outterIdx, innerIdx] = 0;
                }
                setToZero = false;
            }

            for (int outterIdx = 0; outterIdx < array.GetLength(0); outterIdx++) 
            {
                if(columnIdx > -1)
                {
                    array[outterIdx, columnIdx] = 0;
                }
            }

            return array;
        }
        #endregion

        #region String Rotation:
        /* 
         * Assume you have a method isSubstring which checks if one word is a substring of another.
         * Given two strings, s1 and s2, write code to check if s2 is a rotation of s1 using only one call to isSubstring (e.g., "waterbottle" is a rotation of "erbottlewat").
         */

        public bool IsSubString(string expected, string actual) 
        {
            //Rotate the characters through the array until you get a match
            //Every rotation then check for a match
            //Another way to do this is use a queue and just pull from the end to the front for the length of the string
            bool isMatch = false;
            char[] newStr = new char[actual.Length];

            for (int index = 0; index < actual.Length; index++) 
            {
                newStr[index] = actual[index];
            }

            if (actual == expected)
                isMatch = true;
            else
            {
                for (int index = 0; index < actual.Length; index++)
                {
                    if (isMatch)
                        break;
                    else
                    {
                        char lastChar = newStr[0];
                        char newChar = newStr[actual.Length - 1];
                        newStr[0] = newChar;
                        for (int strIdx = 1; strIdx < actual.Length; strIdx++) 
                        {
                            newChar = lastChar;
                            lastChar = newStr[strIdx];
                            newStr[strIdx] = newChar;
                        }

                        if (new String(newStr) == expected)
                            isMatch = true;
                    }
                }
            }
            return isMatch;
        }
        #endregion
    }
}
