
using System.ComponentModel;

namespace Zeje.Common
{
    /// <summary>应用
    /// </summary>
    public enum SysApp
    {
        /// <summary>后台:1
        /// </summary>
        [Sort(1)]
        [Description("后台")]
        Admin = 1 ,
        /// <summary>博客:2
        /// </summary>
        [Sort(2)]
        [Description("博客")]
        Blog = 2 ,
        /// <summary>人事:3
        /// </summary>
        [Sort(3)]
        [Description("人事")]
        Hr = 3 ,
    }
}

