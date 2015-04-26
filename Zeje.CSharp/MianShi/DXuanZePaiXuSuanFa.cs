using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeje.CSharp.MianShi
{
    public class DXuanZePaiXuSuanFa
    {
        public void XuanZePaiXu(bool IsMaxFirst)
        {
            int[] array = new int[] { 3, 6, 2, 7, 9, 34, 6, 755, 23, 0 };

            int intCFlag = 0;
            int temp = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                intCFlag = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[intCFlag] < array[j] == IsMaxFirst)
                    {
                        intCFlag = j;
                    }
                }

                if (intCFlag != i)
                {
                    temp = array[i];
                    array[i] = array[intCFlag];
                    array[intCFlag] = temp;
                }

            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
