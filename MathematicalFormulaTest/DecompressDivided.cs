using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalFormulaTest
{
    static class DecompressDivided
    {
        static byte[] DecompressingInProgressFile;
        public static void DecompressByteArray(byte[] fileByteArray, byte[] compressingFunctionValues)
        {
            DecompressingInProgressFile = fileByteArray;
            DecompressingInProgressFile.Reverse();
        }
        private static void DecompressByteArray(int multiplicator)
        {
            List<short> decompressedFile = new List<short>();
            short result;
            bool isRemainderOfMultiplication = false;
            short reminder = 0;
            foreach (var i in DecompressingInProgressFile)
            {
                result = (short)(i * multiplicator);
                if (isRemainderOfMultiplication)
                {
                    result += reminder;
                }
                if (1000 <= result)
                {
                    //recreate this if u will want to achive multiplication higher than (insert value one belowe u need)
                    reminder = (short)(result / 1000);
                    decompressedFile.Add((short)(result - 1000));
                    isRemainderOfMultiplication = true;
                }
                else
                {
                    decompressedFile.Add(result);
                }
            }
        }
    }
}
