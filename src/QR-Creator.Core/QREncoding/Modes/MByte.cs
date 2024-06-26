﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Encodings;
using System.Text.Unicode;

namespace QR_Creator.Core.QREncoding.Modes
{
    internal class MByte : IMode
    {
        private const string ModeIndicator = "0100";
        private readonly Encoding enc;

        public MByte(ByteEncoders encoders = ByteEncoders.ISO)
        {
            enc = encoders switch
            {
                ByteEncoders.UTF8 => Encoding.UTF8,
                ByteEncoders.ISO => Encoding.GetEncoding("ISO-8859-1"),
                _ => throw new NotSupportedException(),
            };
        }

        public string Encode(string data)
        {
            return ToFullBinary(data);
        }

        private string ToFullBinary(string data)
        {
            string binary = "";
            foreach (char symbol in data)
            {
                binary += ToBinary(symbol, 8, enc);
            }
            return binary;
        }

        private string ToBinary(char symbol, int padding, Encoding encoder)
        {
            string value = "";
            byte[] bytes = encoder.GetBytes(symbol.ToString());
            foreach (byte b in bytes)
            {
                value += Convert.ToString(b, 2).PadLeft(padding, '0');
            }
            return value;
        }
    }

}
