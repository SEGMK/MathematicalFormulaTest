using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalFormulaTest
{
    static class Compressor
    {
        public static (int, ulong, List<ulong>) CompressByteArray(ulong originalByteArray)
        {
            ulong byteArray = originalByteArray;
            List<ulong> restFromSqrtEnumerable = new List<ulong>();
            int powerOfTheCompression = 0;
            do
            {
                //zmiana reszty z Sqrt(byteArray) na reprezentacje tej reszty w byteArray i zapisanie roznicy ByteArray i reprezentacji reszty w strukturze danych
                ulong resoult = (ulong)Math.Sqrt(byteArray);
                ulong test = resoult * resoult;
                ulong restFromSqrt = byteArray - (resoult * resoult);
                restFromSqrtEnumerable.Add(restFromSqrt);
                //odjecie reszty i kompresja
                byteArray -= restFromSqrt;
                //zapisanie liczby do daleszej kompresacji
                byteArray = (ulong)Math.Sqrt(byteArray);
                //zapisanie potegi kopresjii
                powerOfTheCompression += 2;

            } while (100 <= byteArray);
            return (powerOfTheCompression, byteArray, restFromSqrtEnumerable);
        }
        public static ulong DecompressByteArray(int compressionPower, ulong compressedByteArray, List<ulong> restFromCompression)
        {
            restFromCompression.Reverse();
            for (int i = 0; i < restFromCompression.Count; i++)
            {
                compressedByteArray = compressedByteArray * compressedByteArray;
                compressedByteArray += restFromCompression[i];
            }
            return compressedByteArray;
        }
    }
}
