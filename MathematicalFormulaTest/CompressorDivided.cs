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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns>(compressedFile, compressionOperations, nonCompressibleValues)</returns>
        public static (byte[], byte[], byte[]) CompressByteArray(byte[] byteArray)
        {
            List<short> shorts = new List<short>();
            for (int i = 0; i < byteArray.Length; i++)
            {
                shorts.Add(byteArray[i]);
            }
            CompressingInProgressFile = shorts.ToArray();
            List<byte> compressionOperations = new List<byte>();
            List<byte> restFromCompressionOperations = new List<byte>();
            byte j = 0;
            while (6 <= CompressingInProgressFile.Length) //find the best value for this
            {
                if (CompressingInProgressFile[CompressingInProgressFile.Length - 1] % 5 == 0)
                {
                    Divide(5);
                    compressionOperations.Add(5);
                }
                //else if (CompressingInProgressFile.IsDividsableByThree())
                //Divide(3);
                else if (CompressingInProgressFile[CompressingInProgressFile.Length - 1] % 2 == 0)
                {
                    Divide(2);
                    compressionOperations.Add(2);
                }
                else
                {
                    CompressingInProgressFile[CompressingInProgressFile.Length - 1] -= 1;
                    restFromCompressionOperations.Add(j);
                }
                j++;
            }
            return (CompressingInProgressFile.ToByteArray(), compressionOperations.ToArray(), restFromCompressionOperations.ToArray());
        }
        private static void Divide(byte divider)
        {
            List<short> compressedFile = new List<short>();
            short result;
            byte reminder = 0;
            short additionalValue = 0;
            foreach (var i in CompressingInProgressFile)
            {
                if (reminder != 0)
                {
                    additionalValue += (short)(reminder * 1000);
                }
                result = (short)((i + additionalValue) / divider);
                reminder = (byte)((i + additionalValue) % divider);
                compressedFile.Add(result);
                additionalValue = 0;
            }
            while (compressedFile[0] == 0)
            { 
                compressedFile.RemoveAt(0);
            }
            CompressingInProgressFile = compressedFile.ToArray();
        }
    }
}
