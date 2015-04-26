using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeje.CSharp
{
    public sealed class ZString
    {
        public void Test()
        {
            string a = "";
            string b = a;
            b = "abc";

            string A = new String(new char[] { '1', '3' });
            string B = A;
            B = new String(new char[] { 'a' });
        }
    }
}
