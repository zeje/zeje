#define A
#undef B

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeje.CSharp
{

    /// <summary>
    /// 预处理
    /// </summary>
    class EYuChuLi
    {
        //#define
        //#undef
        //#if
        //#else
        //#endif

#if A
        void f1() { }
#else
        void f2(){}
#endif

#if B
        void f3(){}
#else
        void f4() { }
#endif


    }
}
