using System;
using Xunit;
using System.Reflection;
using MathematicalFormulaTest;

namespace MathematicalFormulaTest_Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            byte[] tab = new byte[] { 9, 223, 37, 20, 36, 85, 47, 75, 80, 6 };
            string expected = ((long.MaxValue - 1) / 2).ToString();
            //Act
            var method = typeof(CompressorDivided).GetMethod("DivideByTwo", BindingFlags.Static | BindingFlags.NonPublic);
            var field = typeof(CompressorDivided).GetField("FileByteArray", BindingFlags.Static | BindingFlags.NonPublic);
            field.SetValue(null, tab);
            method.Invoke(null, null);
            //Assert
            string actual = "";
            foreach (var i in (byte[])field.GetValue(null))
            {
                actual += i;
            }
            Assert.Equal(expected, actual);
        }
    }
}
