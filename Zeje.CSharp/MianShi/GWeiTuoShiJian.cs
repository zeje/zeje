using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeje.CSharp.MianShi
{
    public class GWeiTuoShiJian
    {
        public delegate void dlg(int i);

        public void DLG(int i)
        {
            Console.WriteLine("我是被委托的方法,传入参数是" + i);
        }

        public void RunDelegateMethod()
        {
            dlg dlgObj = new dlg(DLG);
            dlgObj(100);
        }
    }
}
