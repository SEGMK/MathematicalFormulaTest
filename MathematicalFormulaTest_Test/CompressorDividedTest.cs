using System;
using Xunit;
using System.Reflection;
using MathematicalFormulaTest;
using System.Collections.Generic;
using System.Linq;

namespace MathematicalFormulaTest_Test
{
    public class CompressorDividedTest
    {
        [Fact]
        public void DivideByTwo_Test()
        {
            //Arrange
            short[] tab = new short[] { 9, 223, 37, 20, 36, 84 };
            string expected = (9223037020036084 / 2).ToString();
            //Act
            var method = typeof(CompressorDivided).GetMethod("DivideByTwo", BindingFlags.Static | BindingFlags.NonPublic);
            var field = typeof(CompressorDivided).GetField("CompressingInProgressFile", BindingFlags.Static | BindingFlags.NonPublic);
            field.SetValue(null, tab);
            method.Invoke(null, null);
            //Assert
            string actual = "";
            foreach (var i in (short[])field.GetValue(null))
            {
                actual += i;
            }
            actual = actual.Replace("0", "");
            expected = expected.Replace("0", "");
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CompressionAndDecompressionTest()
        {
            //Arrange
            int compressionLoops = 8;
            short[] originalArray = new short[] { 9, 223, 37, 20, 36, 84 };
            short[] workArray;
            List<int> restFromDivision = new List<int>();
            //Act
            workArray = Compression(ref restFromDivision, compressionLoops, originalArray);
            workArray = Decompress(compressionLoops, restFromDivision, workArray, 2);
            //Assert
            string actual = "";
            string expected = "";
            foreach (var i in  originalArray)
            {
                expected += i;
            }
            foreach (var i in workArray)
            {
                actual += i;
            }
            actual = actual.Replace("0", "");
            expected = expected.Replace("0", "");
            Assert.Equal(expected, actual);
        }
        private short[] Decompress(int compressionLoops, List<int> restFromDivision, short[] fileToDecompress, int multiplicator)
        {
            fileToDecompress.Reverse();
            var method = typeof(DecompressDivided).GetMethod("DecompressByteArray", BindingFlags.Static | BindingFlags.NonPublic);
            var field = typeof(DecompressDivided).GetField("DecompressingInProgressFile", BindingFlags.Static | BindingFlags.NonPublic);
            field.SetValue(null, fileToDecompress);
            short[] fieldCopy;
            for (var i = 0; i <= compressionLoops; i++)
            {
                method.Invoke(null, new object[] { multiplicator });
                if (i == Math.Abs(restFromDivision[0] - compressionLoops))
                {
                    fieldCopy = (short[])field.GetValue(null);
                    fieldCopy[fieldCopy.Length] -= 1;
                    field.SetValue(null, fieldCopy);
                }
            }
            fileToDecompress.Reverse();
            return fileToDecompress;
        }
        private short[] Compression(ref List<int> restFromDivision, int compressionLoops, short[] fileToCompress)
        {
            var method = typeof(CompressorDivided).GetMethod("DivideByTwo", BindingFlags.Static | BindingFlags.NonPublic);
            var field = typeof(CompressorDivided).GetField("CompressingInProgressFile", BindingFlags.Static | BindingFlags.NonPublic);
            field.SetValue(null, fileToCompress);
            short[] fieldCopy;
            for (var i = 0; i <= compressionLoops; i++)
            {
                if (((short[])field.GetValue(null))[((short[])field.GetValue(null)).Length] % 2 != 0)
                {
                    fieldCopy = (short[])field.GetValue(null);
                    fieldCopy[fieldCopy.Length] -= 1;
                    field.SetValue(null, fieldCopy);
                    restFromDivision.Add(i);
                }
                method.Invoke(null, null);
            }
            return (short[])field.GetValue(null);
        }
    }
}
