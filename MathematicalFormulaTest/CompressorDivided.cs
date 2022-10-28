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
            for (int i = 0; i < byteArray.Length; i++)
            {
                CompressingInProgressFile[i] = byteArray[i];
            }
            List<byte> compressionOperations = new List<byte>();
            List<byte> restFromCompressionOperations = new List<byte>();
            byte j = 0;
            while (20 <= CompressingInProgressFile.Length) //find the best value for this
            {
                if (CompressingInProgressFile[CompressingInProgressFile.Length] % 5 == 0)
                {
                    DivideByFive();
                }
                else if (CompressingInProgressFile.IsDividsableByThree())
                {
                    DivideByThree();
                }
                else if (CompressingInProgressFile[CompressingInProgressFile.Length] % 2 == 0)
                {
                    DivideByTwo();
                }
                else
                {
                    restFromCompressionOperations.Add(j);
                }
                j++;
            }
            throw new Exception("Not implemented");
        }
        private static void DivideByFive()
        {
            List<short> compressedFile = new List<short>();
            byte divider = 5;
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
        private static void DivideByThree()
        {
            List<short> compressedFile = new List<short>();
            byte divider = 3;
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
