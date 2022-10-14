using System;
using System.Collections.Generic;

namespace MathematicalFormulaTest
{
    class Program
    {
        //2 147 483 647
        //13 950 991 169 621 486 829
        // sqrt 3 735 102 564
        static ulong DecompressedByteArray;
        static ulong OriginalByteArray;
        static void Main(string[] args)
        {
            Console.WriteLine("Wprowadź kompresowaną wartość");
            OriginalByteArray = ulong.Parse(Console.ReadLine());
            //CompressFileBySqrt();
            CompressFileByDividing();
        }
        public static void CompressFileByDividing()
        { 
            (byte, List<byte>) compressedFile = CompressorDivided.CompressByteArray(OriginalByteArray);
            DecompressedByteArray = CompressorDivided.DecompressByteArray(compressedFile.Item1, compressedFile.Item2);
            PrintOutCompressionResoult(compressedFile.Item1, "CompressorDivided");
        }
        public static void CompressFileBySqrt()
        {
            (int, ulong, List<ulong>) compressedFile = CompressorSqrt.CompressByteArray(OriginalByteArray);
            DecompressedByteArray = CompressorSqrt.DecompressByteArray(compressedFile.Item1, compressedFile.Item2, compressedFile.Item3);
            PrintOutCompressionResoult((byte)compressedFile.Item1, "CompressorSqrt");
        }
        public static void PrintOutCompressionResoult(byte compressedFile, string compressionMethod)
        {
            Console.WriteLine(compressionMethod);
            Console.WriteLine($"Sucessfull compression and decompression: {DecompressedByteArray == OriginalByteArray}");
            Console.WriteLine($"Original value: \t {OriginalByteArray}");
            Console.WriteLine($"Decopressed value: \t {DecompressedByteArray}");
            Console.WriteLine($"Compressed value: \t {compressedFile}");
            Console.WriteLine();
        }
    }
}
