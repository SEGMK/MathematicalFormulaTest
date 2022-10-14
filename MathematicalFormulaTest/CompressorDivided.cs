using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalFormulaTest
{
    internal static class CompressorDivided
    {
        public static (byte, List<byte>, List<(byte, byte)>) CompressByteArray(ulong byteArray)
        {
            List<byte> compressionOperations = new List<byte>();
            List<(byte, byte)> restFromPrimeNumbersWithPositionsOfCompression 
                = new List<(byte, byte)>();
            byte i = 0;
            while (100 < byteArray)
            {
                if (byteArray % 5 == 0)
                {
                    CompressingOperation(ref byteArray, ref compressionOperations, 5);
                }
                else if (byteArray % 3 == 0)
                {
                    CompressingOperation(ref byteArray, ref compressionOperations, 3);
                }
                else if (byteArray % 2 == 0)
                {
                    CompressingOperation(ref byteArray, ref compressionOperations, 2);
                }
                else //prime number
                {
                    byteArray--;
                    restFromPrimeNumbersWithPositionsOfCompression.Add((1, i));
                }
                i++;
            }
            return ((byte)byteArray, compressionOperations, restFromPrimeNumbersWithPositionsOfCompression);
        }
        private static void CompressingOperation(ref ulong byteArray, 
            ref List<byte> compressionOperations, byte divider)
        {
            byteArray = byteArray / divider;
            compressionOperations.Add(divider);
        }
    }
}
