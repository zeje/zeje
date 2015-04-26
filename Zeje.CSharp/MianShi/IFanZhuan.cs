using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeje.CSharp.MianShi
{
    public class IFanZhuan
    {

        public string Reverse(string str)
        {
            string strReturn = "";
            foreach (char c in str)
            {
                strReturn = c + strReturn;
            }
            return strReturn;
        }  
    }
}
