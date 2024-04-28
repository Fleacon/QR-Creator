using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_Creator.Core.QREncoding.Modes
{
    public interface IMode
    {
        public string Encode(string data);
    }
}
