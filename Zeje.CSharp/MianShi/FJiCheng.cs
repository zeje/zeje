using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeje.CSharp.MianShi
{
    public class FJiCheng
    {

        public class A
        {
            public A()
            {
                Print();
            }
            public virtual void Print()
            {
                Console.WriteLine("虚拟Print");
            }

        }

        public class B : A
        {
            int x = 1;
            int y;
            public B()
            {
                y = 1;
            }

            public override void Print()
            {
                Console.WriteLine(string.Format("x:{0},y:{1}", x, y));
                //base.Print();
            }
        }

        public void Show()
        {
            B bb = new B();
            Console.WriteLine("bb");
            bb.Print();
            Console.WriteLine("--------");
            A ab = new B();
            Console.WriteLine("ab");
            ab.Print();
            Console.WriteLine("--------");
            A aa = new A(); ;
            Console.WriteLine("aa");
            aa.Print();
        }
    }
}
