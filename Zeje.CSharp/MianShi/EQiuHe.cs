using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeje.CSharp.MianShi
{
    /// <summary>
    /// 求以下表达式的值，写出您想到的一种或几种实现方法： 1-2+3-4+……+m
    /// </summary>
    public class EQiuHe
    {
        public int Sum(int m, ref string p_Show)
        {
            int result = 0;
            for (int i = 1; i < m + 1; i++)
            {
                if (i % 2 == 0)
                {
                    result -= i;
                    p_Show += "-" + i.ToString();
                }
                else
                {
                    result += i;
                    p_Show += "+" + i.ToString();
                }
            }
            return result;
        }

        public void Show(int[] Ms)
        {
            string strShow = string.Empty;
            for (int i = 0; i < Ms.Length; i++)
            {
                strShow = string.Empty;
                int result = Sum(Ms[i], ref strShow);
                Console.WriteLine(strShow.TrimStart('-').TrimStart('+') + "=" + result);
            }
        }
    }
}
