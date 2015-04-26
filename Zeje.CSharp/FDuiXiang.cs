using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeje.CSharp
{
    class FDuiXiang
    {
        #region 修饰符
        //new
        //public
        //protected
        //internal 类中的成员变量和方法在整个项目中都可以被访问，项目外的其他代码不能被访问
        //private
        #endregion

        public void DuiXiang()
        {
            //装箱
            int x = 123;
            object ox = (object)x;
            //隐式装箱
            int y = 123;
            object oy = y;

            //取消装箱
            int z = (int)oy;
        }

        //构造函数

        //
    }
}
