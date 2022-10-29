using System;
using System.Collections.Generic;
using System.IO;

namespace MathematicalFormulaTest
{
    class Program
    {
        //2 147 483 647
        //13 950 991 169 621 486 829
        // sqrt 3 735 102 564
        static ulong DecompressedByteArray;
        static ulong OriginalByteArray;
        static byte[] FileInByteArray;
        static void Main(string[] args)
        {
            FileInByteArray = LoadFile.FileToByteArray();
            var file = CompressorDivided.CompressByteArray(FileInByteArray);
            List<byte> compressedFileList = new List<byte>();
            foreach (var i in file.Item1)
            { 
                compressedFileList.Add(i);
            }
            foreach (var i in file.Item2)
            {
                compressedFileList.Add(i);
            }
            foreach (var i in file.Item3)
            {
                compressedFileList.Add(i);
            }
            byte[] compressedFileTab = compressedFileList.ToArray();
            using var writer = new BinaryWriter(File.OpenWrite("CompressedFile"));
            writer.Write(compressedFileTab);
        }
        public static void CompressFileByDividing()
        { 

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
