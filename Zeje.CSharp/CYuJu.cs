using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeje.CSharp
{
    class CYuJu
    {
        //条件语句if else,switch case
        //循环语句while do,for,foreach
        //跳转语句break,continue,goto,return,throw

        public void XiaoLu()
        {
            //在C中有区别，在java中效率相当，在C#中不知，怎么获得其字节码指令

            // C#语言经编译后得到的是CIL中间语言指令   即字节码

            int count = 0;
            int num = 10000;

            count = 0;
            for (int i = 0; i < num; i++)
            {
            }
            //执行效率低于
            for (; (num--) > 0; )
            {
            }
            //等于
            while ((num--) > 0)
            {
            }
        }

    }
}
