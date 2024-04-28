using QR_Creator.Core.QREncoding;
using System.Text;

var AEncoder = new QREncoder(Mode.Alphanumeric, ByteEncoders.ISO);
var NEncoder = new QREncoder(Mode.Numeric);
var BEncoder = new QREncoder(Mode.Byte);
