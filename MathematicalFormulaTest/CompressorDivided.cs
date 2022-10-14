using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalFormulaTest
{
    internal static class CompressorDivided
    {
        public static (byte, List<byte>, Dictionary<byte, byte>) CompressByteArray(ulong byteArray)
        {
            List<byte> compressionOperations = new List<byte>();
            Dictionary<byte, byte> restFromPrimeNumbersWithPositionsOfCompression 
                = new Dictionary<byte, byte>();
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
                    restFromPrimeNumbersWithPositionsOfCompression.Add(i, 1);
                }
                i++;
            }
            return ((byte)byteArray, compressionOperations, restFromPrimeNumbersWithPositionsOfCompression);
        }
        public static ulong DecompressByteArray(byte compressedFile, List<byte> operation,
            Dictionary<byte, byte> restFromPrimes)
        {
            ulong decopressedFile = compressedFile;
            operation.Reverse();
            byte howManyOperations = (byte)operation.Count;
            for (byte i = 0; i < howManyOperations; i++)
            {
                if (restFromPrimes.ContainsKey(i))
                {
                    decopressedFile += restFromPrimes[i];
                }
                decopressedFile = decopressedFile * operation[i];
            }
            return decopressedFile;
        }
        private static void CompressingOperation(ref ulong byteArray, 
            ref List<byte> compressionOperations, byte divider)
        {
            byteArray = byteArray / divider;
            compressionOperations.Add(divider);
        }
    }
}
