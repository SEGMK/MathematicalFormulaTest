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
        public static (ulong, List<byte>, List<byte>) CompressByteArray(byte[] byteArray)
        {
            for (int i = 0; i < byteArray.Length; i++)
            {
                CompressingInProgressFile[i] = byteArray[i];
            }
            List<byte> compressionOperations = new List<byte>();
            List<byte> restFromCompressionOperations = new List<byte>();
            byte j = 0;
            while (6 <= CompressingInProgressFile.Length) //find the best value for this
            {
                if (CompressingInProgressFile[CompressingInProgressFile.Length] % 5 == 0)
                    Divide(5);
                else if (CompressingInProgressFile.IsDividsableByThree())
                    Divide(3);
                else if (CompressingInProgressFile[CompressingInProgressFile.Length] % 2 == 0)
                    Divide(2);
                else
                    restFromCompressionOperations.Add(j);
                j++;
            }
            string compressedFileString = null;
            foreach (var i in CompressingInProgressFile)
            {
                compressedFileString += i;
            }
            ulong compressedFile = ulong.Parse(compressedFileString);
            return (compressedFile, compressionOperations, restFromCompressionOperations);
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
