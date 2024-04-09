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
        IMode mode;
        public QREncoder() 
        {
            this.mode = new Numeric();
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
}
