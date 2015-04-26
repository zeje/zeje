using System;
using System.Reflection;

namespace Zeje.Common
{
    /// <summary>排序
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Enum, AllowMultiple = true)]
    public class SortAttribute : Attribute
    {
        int intSort;
        /// <summary>构造函数
        /// </summary>
        /// <param name="p_Sort"></param>
        public SortAttribute(int p_Sort)
        {
            intSort = p_Sort;
        }
        /// <summary>获得排序号
        /// </summary>
        /// <returns></returns>
        public int GetSort()
        {
            return intSort;
        }
        /// <summary>获得排序号
        /// </summary>
        /// <param name="tp"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int Get(Type tp, string name)
        {
            MemberInfo[] MI = tp.GetMember(name);
            if (MI != null && MI.Length > 0)
            {
                SortAttribute attr = Attribute.GetCustomAttribute(MI[0], typeof(SortAttribute)) as SortAttribute;
                if (attr != null)
                {
                    return attr.GetSort();
                }
            }
            return 0;
        }
        /// <summary>获得排序号
        /// </summary>
        /// <param name="enm"></param>
        /// <returns></returns>
        public static int Get(object enm)
        {
            if (enm != null)
            {
                MemberInfo[] mi = enm.GetType().GetMember(enm.ToString());
                if (mi != null && mi.Length > 0)
                {
                    SortAttribute attr = Attribute.GetCustomAttribute(mi[0], typeof(SortAttribute)) as SortAttribute;
                    if (attr != null)
                    {
                        return attr.GetSort();
                    }
                }
            }
            return 0;
        }
    }
}
