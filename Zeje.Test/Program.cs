using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeje.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //CSharp.MianShi.ADiGui DiGui = new CSharp.MianShi.ADiGui();
            //for (int i = 0; i <= 30; i++)
            //{
            //    Console.WriteLine(DiGui.Foo1(i) + " vs " + DiGui.Foo2(i));
            //}

            //Zeje.CSharp.MianShi.CMaoPaoSuanFa CPSF = new CSharp.MianShi.CMaoPaoSuanFa();
            //CPSF.MaoPao(true);

            //Zeje.CSharp.MianShi.DXuanZePaiXuSuanFa XZPXSF = new CSharp.MianShi.DXuanZePaiXuSuanFa();
            //XZPXSF.XuanZePaiXu(true);

            //Zeje.CSharp.MianShi.EQiuHe EQH = new CSharp.MianShi.EQiuHe();
            //EQH.Show(new int[] { 5, 8, 9, 10 });

            //Zeje.CSharp.MianShi.FJiCheng FJC = new CSharp.MianShi.FJiCheng();
            //FJC.Show();

            //Zeje.CSharp.MianShi.GWeiTuoShiJian WTSJ = new CSharp.MianShi.GWeiTuoShiJian();
            //WTSJ.RunDelegateMethod();

            //Zeje.CSharp.MianShi.HSuiJiChaRu SJCR = new CSharp.MianShi.HSuiJiChaRu();
            //SJCR.Insert();

            string str = "Hello World";
            string strResult = string.Empty;

            string[] strs = str.Split(' ');

            for (int i = 0; i < strs.Length; i++)
            {
                foreach (char item in strs[i])
                {
                    strResult = item + strResult;
                }
                strResult = " " + strResult;
            }
            Console.WriteLine(strResult.TrimStart());

            Console.ReadLine();
        }
    }
}
