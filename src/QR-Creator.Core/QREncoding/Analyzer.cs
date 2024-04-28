using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QR_Creator.Core.QREncoding
{
    public static class Analyzer
    {
        public static Mode Analyze(string data)
        {
            if(IsNumeric(data)) return Mode.Numeric;
            if(IsAlphanumeric(data)) return Mode.Alphanumeric;
            if(IsByteISO(data)) return Mode.ByteISO; //ISO has priority because most Readers can read ISO characters rather than UTF8 characters
            if(IsByteUTF8(data)) return Mode.ByteUTF8;
            else return Mode.Invalid;
        }

        public static bool IsNumeric(string data)
        {
            return int.TryParse(data, out _);
        }
        public static bool IsAlphanumeric(string data)
        {
            bool result = false;
            foreach(char c in data)
            {
                if (AlphanumericTable.Contains(c))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public static bool IsByteISO(string data)
        {
            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            byte[] isoBytes = iso.GetBytes(data);
            string isoString = iso.GetString(isoBytes);
            if (isoString == data) return true;
            else return false;
        }

        public static bool IsByteUTF8(string data)
        {
            Encoding utf8 = Encoding.UTF8;
            byte[] utf8Bytes = utf8.GetBytes(data);
            string utf8String = utf8.GetString(utf8Bytes);
            if (utf8String == data) return true;
            else return false;
        }

        private static readonly List<char> AlphanumericTable =
        [
            '0',
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9',
            'A',
            'B',
            'C',
            'D',
            'E',
            'F',
            'G',
            'H',
            'I',
            'J',
            'K',
            'L',
            'M',
            'N',
            'O',
            'P',
            'Q',
            'R',
            'S',
            'T',
            'U',
            'V',
            'W',
            'X',
            'Y',
            'Z',
            ' ',
            '$',
            '%',
            '*',
            '+',
            '-',
            '.',
            '/',
            ':'
        ];
    }
}
