using MathematicalFormulaTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MathematicalFormulaTest_Test
{
    public class ArrayExtensionTest
    {
        [Fact]
        public void IsDividsableByThree_Test()
        {
            //Arrange
            short[] tab = new short[] { 2, 524, 25, 5252, 41, 3, 4 };
            ulong num = 25242552524134;
            //Act
            bool expected = num % 3 == 0;
            bool actual = tab.IsDividsableByThree();
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToByteArray_Test()
        {
            //Arrange
            short[] tab = new short[] { 4215, 5255, 6311, 10442 };
            byte[] expected = new byte[] { 42, 155, 255, 63, 111, 0, 44, 2};
            //Act
            byte[] actual = tab.ToByteArray();
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
