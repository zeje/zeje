using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeje.CSharp
{
    class DShuZu
    {
        /// <summary>
        /// 枚举
        /// </summary>
        public enum WeekDays
        {
            Monday,//默认情况下第一个枚举元素的值为0
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
        /// <summary>
        /// 使用基类选线来声明元素类型是long的枚举类型
        /// </summary>
        public enum range : long { MinInt32 = -2147483648L, MaxInt32 = 2147483647L }

        public void GetRangeValue()
        {
            long x = (long)range.MinInt32;
            long y = (long)range.MaxInt32;
        }

        public void ArrayFunction()
        {
            //1、定义数据
            int[] intArray;
            intArray = new int[5];
            //2、初始化数组元素
            int[] intArrayInit = new int[2] { 3, 4 };
            int[] intArrayInit2 = { 3, 4 };

            int[,] array2 = new int[2, 3];
            int[,] array22 = { { 2, 3 }, { 3, 4 } };
            int[, ,] array3 = new int[3, 4, 5];

            int[,] a = new int[3,3];


            int[][] jaggedArray = new int[2][];
            jaggedArray[0] = new int[4];
            jaggedArray[1] = new int[3];

        }

    }
}
