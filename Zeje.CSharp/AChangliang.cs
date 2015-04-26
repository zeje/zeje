using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeje.CSharp
{
    /// <summary>
    /// 在C#中定义常量的方式有两种
    /// 一种叫做静态常量（Compile-time constant），另一种叫做动态常量（Runtime constant）。
    /// 前者用“const”来定义，后者用“readonly”来定义。
    /// </summary>
    public class AChangliang
    {

        /// <summary>
        /// 常量是其值不变的量
        /// </summary>
        const int x1 = 0;
        public const double pressurePoint = 30000.56641D;

        //对于引用类型的常量，可能的值是string和null

        public void Excute()
        {
            //MyMathClass.PI = 323.2D;
            double dbl = MyMathClass.PI;
        }

    }

    public class MyMathClass
    {
        //定义为常量数据
        public const double PI = 3.14;
        public readonly int MAX_VALUE = 10;
    }
}
