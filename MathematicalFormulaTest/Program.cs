using System;
using System.Collections.Generic;

namespace MathematicalFormulaTest
{
    class Program
    {
        //2 147 483 647
        //13 950 991 169 621 486 829
        // sqrt 3 735 102 564
        static void Main(string[] args)
        {
            Console.WriteLine("Wprowadź kompresowaną wartość");
            ulong OriginalByteArray = ulong.Parse(Console.ReadLine());
            (int, ulong, List<ulong>) compressedFile = Compressor.CompressByteArray(OriginalByteArray);
            ulong decompressedByteArray;
            decompressedByteArray = Compressor.DecompressByteArray(compressedFile.Item1, compressedFile.Item2, compressedFile.Item3);
            Console.WriteLine($"Sucessfull compression and decompression: {decompressedByteArray == OriginalByteArray}");
            Console.WriteLine($"Original value: \t {OriginalByteArray}");
            Console.WriteLine($"Decopressed value: \t {decompressedByteArray}");
            Console.WriteLine($"Compressed value: \t {compressedFile.Item2}");
        }
    }
}
