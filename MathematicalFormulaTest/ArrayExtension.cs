using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public static byte[] ToByteArray(this short[] tab) //where T : INumber (.NET 7.0)
        {
            List<byte> byteList = new List<byte>();
            string tabElements = null;
            foreach (var i in tab)
            {
                tabElements += i;
            }
            byte element;
            while (tabElements != String.Empty)
            {
                try
                {
                    if (tabElements[0] == '0')
                    {
                        byteList.Add(byte.Parse("0"));
                        tabElements = tabElements.Remove(0, 1);
                        continue;
                    }
                    if (!byte.TryParse(tabElements[0..3], out element))
                    {
                        element = byte.Parse(tabElements[0..2]);
                        tabElements = tabElements.Remove(0, 2);
                    }
                    else
                        tabElements = tabElements.Remove(0, 3);
                    byteList.Add(element);
                }
                catch (ArgumentOutOfRangeException)
                {
                    byteList.Add(byte.Parse(tabElements));
                    tabElements = String.Empty;
                }
            }
            return byteList.ToArray();
        }
    }
}
