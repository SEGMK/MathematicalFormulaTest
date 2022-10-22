﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalFormulaTest
{
    public static class CompressorDivided
    {
        private static byte[] FileByteArray;
        public static (byte, List<byte>) CompressByteArray(ulong byteArray)
        {
            List<byte> compressionOperations = new List<byte>();
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
                    compressionOperations.Add(1);
                }
            }
            return ((byte)byteArray, compressionOperations);
        }
        public static ulong DecompressByteArray(byte compressedFile, List<byte> operation)
        {
            ulong decopressedFile = compressedFile;
            operation.Reverse();
            foreach(byte i in operation)
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
        private static void CompressingOperation(ref ulong byteArray, 
            ref List<byte> compressionOperations, byte divider)
        {
            byteArray = byteArray / divider;
            compressionOperations.Add(divider);
        }
        private static void DivideByTwo()
        {
            List<byte> compressedFile = new List<byte>();
            byte divider = 2;
            short result;
            bool isRemainderOfDivision = false;
            foreach (var i in FileByteArray)
            {
                result = (short)(i / divider);
                if (isRemainderOfDivision)
                {
                    if (result < 10)
                    {
                        result += 5;
                    }
                    else if (result < 100)
                    {
                        result += 50;
                    }
                    else
                    {
                        result += 500;
                    }
                }
                isRemainderOfDivision = i % divider != 0;
                if (byte.MaxValue < result)
                {
                    byte moduloValue;
                    moduloValue = (byte)(result % 10);
                    result = (short)(result / 10);
                    compressedFile.Add((byte)result);
                    compressedFile.Add(moduloValue);
                }
                else
                {
                    compressedFile.Add((byte)result);
                }
            }
        }
    }
}
