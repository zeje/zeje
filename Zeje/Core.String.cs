using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Zeje
{
    /// <summary>类型转换
    /// </summary>
    public static partial class Core
    {
        /// <summary>替换数据库中的换行符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToBRString_(string str)
        {
            return str == null ? "" : str.Replace("\r\n", "<br />").Replace("\n", "<br />");
        }
        /// <summary>返回字符串真实长度, 1个汉字长度为2
        /// </summary>
        /// <returns></returns>
        public static int TrueLength_(this string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }
        /// <summary>替换第一个符合条件的字符
        /// </summary>
        /// <param name="p_Str"></param>
        /// <param name="p_Search"></param>
        /// <param name="p_Replace"></param>
        /// <returns></returns>
        public static string ReplaceFirst_(this string p_Str, string p_Search, string p_Replace)
        {
            int intPositon = p_Str.IndexOf(p_Search);
            if (intPositon < 0)
            {
                return p_Str;
            }
            return p_Str.Substring(0, intPositon) + p_Replace + p_Str.Substring(intPositon + p_Search.Length);
        }
    }
}
