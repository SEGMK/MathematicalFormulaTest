using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalFormulaTest
{
    public static class ArrayExtension
    {
        public static bool IsDividsableByThree(this short[] tab) //where T : INumber (.NET 7.0)
        {
            ulong tryDivide = 0;
            List<short> list = tab.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                tryDivide += (ulong)list[i]; //possible exception
                if (tryDivide % 3 == 0)
                {
                    tryDivide = 0;
                    list.RemoveRange(0, i);
                    i = 0;
                }
            }
            return tryDivide == 0;
        }
    }
}
