using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeje.CSharp.MianShi
{
    /// <summary>
    /// 
    /// </summary>
    public class CMaoPaoSuanFa
    {
        public void MaoPao(bool IsMaxFirst)
        {
            int[] array1 = new int[10] { 2, 3, 6, 4, 8, 9, 2, 4, 0, 1 };

            MaoPao(array1, IsMaxFirst);
        }

        public void MaoPao(int[] array1, bool IsMaxFirst)
        {
            int intTemp = 0;

            for (int i = 0; i < array1.Length - 1; i++)
            {
                for (int j = i + 1; j < array1.Length; j++)
                {
                    if (array1[i] < array1[j] == IsMaxFirst)
                    {
                        intTemp = array1[i];
                        array1[i] = array1[j];
                        array1[j] = intTemp;
                    }
                }
            }

            for (int i = 0; i < array1.Length; i++)
            {
                Console.WriteLine(array1[i]);
            }
        }
    }
}
