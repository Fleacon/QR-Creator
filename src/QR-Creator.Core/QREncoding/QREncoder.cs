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
        public IMode ?Mode {  get; private set; }

        public QREncoder()
        {

        }
        public QREncoder(Mode mode) 
        {
            SetMode(mode);
        }

        public string Encode(string data)
        {
            if (Mode != null)
            {
                return Mode.Encode(data);
            }
            else
            {
                SetMode(AnalyzeData(data));
                return Mode.Encode(data);
            }
        }

        public void SetMode(Mode mode)
        {
            Mode = mode switch
            {
                QREncoding.Mode.ByteUTF8 => new MByte(ByteEncoders.UTF8),
                QREncoding.Mode.ByteISO => new MByte(ByteEncoders.ISO),
                QREncoding.Mode.Alphanumeric => new MAlphanumeric(),
                QREncoding.Mode.Numeric => new MNumeric(),
                _ => throw new NotSupportedException(),
            };
        }

        private Mode AnalyzeData(string data)
        {
            return Analyzer.Analyze(data);
        }
    }
    public enum Mode
    {
        ByteUTF8,
        ByteISO,
        Alphanumeric,
        Numeric,
        Invalid
    }
    public enum ByteEncoders
    {
        ISO,
        UTF8
    }
}
