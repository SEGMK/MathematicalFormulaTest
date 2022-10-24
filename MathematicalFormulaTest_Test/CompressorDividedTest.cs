using System;
using Xunit;
using System.Reflection;
using MathematicalFormulaTest;

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
    }
}
