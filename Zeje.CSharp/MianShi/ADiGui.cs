using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeje.CSharp.MianShi
{
    /// <summary>
    /// 递归算法
    /// </summary>
    public class ADiGui
    {
        /*
        一列数的规则如下: 1、1、2、3、5、8、13、21、34...... 求第30位数是多少， 用递归算法实现。 
        */

        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int Foo1(int i)
        {
            if (i <= 0)
            {
                return 0;
            }
            else if (i <= 1)
            {
                return 1;
            }
            else { return Foo1(i - 1) + Foo1(i - 2); }
        }
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        public int Foo2(int Num)
        {
            int tmp1 = 1;
            int tmp2 = 1;
            int result = 1;

            for (int i = 1; i <= Num; i++)
            {
                if (i > 2)
                {
                    tmp1 = tmp2;
                    tmp2 = result;
                    result = tmp1 + tmp2;
                }
            }
            return result;
        }

        public void Compare()
        {
            for (int i = 0; i <= 30; i++)
            {
                Console.WriteLine(Foo1(i) + " vs " + Foo2(i));
            }
            Console.ReadLine();
        }
    }
}
