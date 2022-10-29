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
        public void Divide_Test()
        {
            //Arrange
            short[] tab = new short[] { 240, 69, 213, 7, 0};
            short[] expected = new short[] { 120, 34, 606, 503, 500};
            byte divider = 2;
            short[] actual;
            //Act
            var method = typeof(CompressorDivided).GetMethod("Divide", BindingFlags.Static | BindingFlags.NonPublic);
            var field = typeof(CompressorDivided).GetField("CompressingInProgressFile", BindingFlags.Static | BindingFlags.NonPublic);
            field.SetValue(null, tab);
            method.Invoke(null, new object[] { divider });
            actual = (short[])field.GetValue(null);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
