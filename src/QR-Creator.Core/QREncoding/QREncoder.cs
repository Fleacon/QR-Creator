using QR_Creator.Core.QREncoding.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_Creator.Core.QREncoding
{
    /**
     * This class abstracts the different encoding modes
     */
    public class QREncoder
    {
        readonly IMode mode;
        public QREncoder(Mode mode) 
        {
            this.mode = mode switch
            {
                Mode.Byte => new MByte(),
                Mode.Alphanumeric => new MAlphanumeric(),
                Mode.Numeric => new MNumeric(),
                _ => throw new NotSupportedException(),
            };
        }

        public QREncoder(Mode mode, ByteEncoders byteEncoder)
        {
            if (mode != Mode.Byte) 
            {
                throw new Exception("Only Byte Mode can use byteEncoder"); 
            } 
            else
            {
                this.mode = new MByte(byteEncoder);
            }
        }

        public string encode(string data)
        {
            return mode.encode(data);
        }

        private void decideMode(string data)
        {
            throw new NotImplementedException();
        }
    }
    public enum Mode
    {
        Byte,
        Alphanumeric,
        Numeric
    }
    public enum ByteEncoders
    {
        ISO,
        UTF8
    }
}
