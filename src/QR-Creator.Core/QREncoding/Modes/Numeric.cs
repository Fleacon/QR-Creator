using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_Creator.Core.QREncoding.Modes
{
    internal class Numeric : IMode
    {

        string modeIndicator = "0001";
        private bool isMultipleOfThree;

        public Numeric() 
        {
            
        }

        public string encode(string data)
        {
            isMultipleOfThree = data.Length % 3 == 0;
            return convertToBinary(breakUpThree(data));
        }

        private List<string> breakUpThree(string fullString)
        {
            List<string> groups = new List<string>();
            string buffer = "";
            for (int i = 0; i < fullString.Length; i++)
            {
                if (i + 1 == fullString.Length)
                {
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

        private string convertToBinary(List<string> list)
        {
            string binary = "";

            int i = 0;
            foreach (string num in list)
            {
                int intNum = int.Parse(num);
                if (!isMultipleOfThree && list.Count == i + 1)
                {
                    if(num.Length == 1)
                    {
                        binary += Convert.ToString(intNum, 2).PadLeft(4, '0');
                    }
                    else if (num.Length == 2)
                    {
                        binary += Convert.ToString(intNum, 2).PadLeft(7, '0');
                    }
                }
                else
                {
                    binary += Convert.ToString(intNum, 2).PadLeft(10, '0');
                }
                i++;
            }
            return binary;
        }
    }
}
