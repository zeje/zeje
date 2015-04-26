using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeje.CSharp.MianShi
{
    public class HSuiJiChaRu
    {
        public void Insert()
        {
            List<int> lstInt = new List<int>();

            Random rdm = new Random(110);
            while (lstInt.Count < 100)
            {
                int temp = rdm.Next(1,101);
                if (!lstInt.Contains(temp))
                {
                    lstInt.Add(temp);
                }
            }


            for (int i = 0; i < lstInt.Count; i++)
            {
                Console.WriteLine(lstInt[i]);
            }

            Console.WriteLine("-----------");

            CMaoPaoSuanFa MPSF = new CMaoPaoSuanFa();
            MPSF.MaoPao(lstInt.ToArray(), true);
        }
    }
}
