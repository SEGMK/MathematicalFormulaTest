using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalFormulaTest
{
    public static class CompressorDivided
    {
        private static short[] CompressingInProgressFile;
        public static (byte, List<byte>) CompressByteArray(byte[] byteArray)
        {

            List<byte> compressionOperations = new List<byte>();
            throw new Exception("Not implemented");
        }
        public static ulong DecompressByteArray(byte compressedFile, List<byte> operation)
        {
            ulong decopressedFile = compressedFile;
            operation.Reverse();
            foreach (byte i in operation)
            {
                if (i == 1)
                {
                    decopressedFile += i;
                    continue;
                }
                decopressedFile = decopressedFile * i;
            }
            return decopressedFile;
        }
        private static void DivideByTwo()
        {
            List<short> compressedFile = new List<short>();
            byte divider = 2;
            short result;
            bool isRemainderOfDivision = false;
            foreach (var i in CompressingInProgressFile)
            {
                result = (short)(i / divider);
                if (isRemainderOfDivision)
                {
                    result += 500;
                }
                isRemainderOfDivision = i % divider != 0;
                compressedFile.Add(result);
            }
            CompressingInProgressFile = compressedFile.ToArray();
        }
    }
}
