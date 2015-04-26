using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeje.CSharp
{
    class GJiHe
    {
        public void UseArray()
        {
            Array arr = Array.CreateInstance(typeof(int), 3);
            arr.SetValue("Marry", 0);
            arr.SetValue("John", 1);
            arr.SetValue("Tom", 2);
            Console.WriteLine("数组arr的维数是：");
            Console.WriteLine(arr.Rank);

            Console.WriteLine("数组arr中元素总数是：");
            Console.WriteLine(arr.Length);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr.GetValue(i));
            }

            Array.Sort(arr);
            Console.WriteLine("排序后数组arr中的元素");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr.GetValue(i));
            }
            Array.Reverse(arr);

            Console.WriteLine("");


        }
    }
}
