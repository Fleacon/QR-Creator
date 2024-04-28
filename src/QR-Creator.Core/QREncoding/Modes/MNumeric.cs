using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QR_Creator.Core.QREncoding.Modes
{
    internal class MNumeric : IMode
    {

        private const string ModeIndicator = "0001";
        private bool isMultipleOfThree;

        public MNumeric() 
        {
            
        }

        public string Encode(string data)
        {
            isMultipleOfThree = data.Length % 3 == 0;
            return ToFullBinary(BreakUpThree(data));
        }

        private List<string> BreakUpThree(string fullString)
        {
            List<string> groups = [];
            string buffer = "";
            for (int i = 0; i < fullString.Length; i++)
            {
                if (i + 1 == fullString.Length)
                {
                    if (buffer.Length == 3)
                    {
                        groups.Add(buffer);
                        buffer = "";
                    }
                    buffer += fullString[i];
                    groups.Add(buffer);
                }
                else if (i % 3 != 0 || i == 0)
                {
                    buffer += fullString[i];
                }
                else
                {
                    groups.Add(buffer);
                    buffer = "";
                    buffer += fullString[i];
                }
            }
            return groups;
        }

        private string ToFullBinary(List<string> list)
        {
            string binary = "";

            int i = 0;
            foreach (string num in list)
            {
                if (!isMultipleOfThree && list.Count == i + 1)
                {
                    if(num.Length == 1)
                    {
                        binary += ToBinary(num, 4);
                    }
                    else if (num.Length == 2)
                    {

                        binary += ToBinary(num, 7);
                    }
                }
                else
                {
                    binary += ToBinary(num, 10);
                }
                i++;
            }
            return binary;
        }

        private string ToBinary(string data, int padding)
        {
            int intnum = int.Parse(data);
            return Convert.ToString(intnum, 2).PadLeft(padding, '0');
        }
    }
}
