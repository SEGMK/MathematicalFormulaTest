using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

namespace MathematicalFormulaTest
{
    static class LoadFile
    {
        public static byte[] FileToByteArray(string filePath = "Ducks.jpg")
        {
            return File.ReadAllBytes(filePath);
        }
    }
}
