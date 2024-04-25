using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QR_Creator.Core.QREncoding.Modes
{
    /**
     * This class contains all the logic for converting a string of Uppercase letters,
     * into a string of bits 
     */
    internal class Alphanumeric : IMode
    {
        string modeIndicator = "0010";
        private bool hasOddNumberOfCharacters = false;

        public Alphanumeric()
        {
            
        }

        public string encode(string data)
        {   
            hasOddNumberOfCharacters = data.Length % 2 != 0;
            return convertToBinary(combinePair(breakUpPairs(data)));
        }

        private List<string> breakUpPairs(string fullString)
        {
            List<string> pairs = new List<string>();

            string buffer = "";
            for (int i = 0; i < fullString.Length; i++)
            {
                if (i + 1 == fullString.Length)
                {
                    buffer += fullString[i];
                    pairs.Add(buffer);
                }
                else if (i % 2 != 0 || i == 0)
                {
                    buffer += fullString[i];
                } 
                else
                {
                    pairs.Add(buffer);
                    buffer = "";
                    buffer += fullString[i]; 
                }
            }
            return pairs;
        }

        private List<int> combinePair(List<string> pairs)
        {
            List<int> numbers = new List<int>();
            int i = 0;
            foreach (string pair in pairs)
            {
                if(hasOddNumberOfCharacters && pairs.Count == i + 1)
                {
                    numbers.Add(alphanumericTable[pair[0]]);
                }
                else
                {
                    char firstChar = pair[0];
                    char secondChar = pair[1];
                    numbers.Add((alphanumericTable[firstChar] * 45) + alphanumericTable[secondChar]);
                }
                i++;
            }
            return numbers;
        }

        private string convertToBinary(List<int> list)
        {
            string binary = "";
            int i = 0;
            foreach (int num in list)
            {
                if (hasOddNumberOfCharacters && list.Count == i + 1)
                {
                    binary += toBinary(num, 6);
                }
                else
                {
                    binary += toBinary(num, 11);
                }
                i++;
            }
            return binary;
        }

        private string toBinary(int data, int padding)
        {
            return Convert.ToString(data, 2).PadLeft(padding, '0');
        }

        /**
         * This Dictionary contains every Character that can be encoded using Alphanumeric mode.
         * Every Character corresponds to a int Value
         */
        Dictionary<char, int> alphanumericTable = new Dictionary<char, int>()
        {
            {'0', 0},
            {'1', 1},
            {'2', 2},
            {'3', 3},
            {'4', 4},
            {'5', 5},
            {'6', 6},
            {'7', 7},
            {'8', 8},
            {'9', 9},
            {'A', 10},
            {'B', 11},
            {'C', 12},
            {'D', 13},
            {'E', 14},
            {'F', 15},
            {'G', 16},
            {'H', 17},
            {'I', 18},
            {'J', 19},
            {'K', 20},
            {'L', 21},
            {'M', 22},
            {'N', 23},
            {'O', 24},
            {'P', 25},
            {'Q', 26},
            {'R', 27},
            {'S', 28},
            {'T', 29},
            {'U', 30},
            {'V', 31},
            {'W', 32},
            {'X', 33},
            {'Y', 34},
            {'Z', 35},
            {' ', 36},
            {'$', 37},
            {'%', 38},
            {'*', 39},
            {'+', 40},
            {'-', 41},
            {'.', 42},
            {'/', 43},
            {':', 44}
        };
    }

}
