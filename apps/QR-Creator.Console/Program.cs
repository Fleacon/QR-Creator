using QR_Creator.Core.QREncoding;
using QR_Creator.Core.QREncoding.Modes;
using System.Text;

var encoder = new QREncoder();

Console.WriteLine(encoder.encode("01234567"));
Console.WriteLine(encoder.encode("0123456789012345"));