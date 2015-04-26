using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeje.CSharp.MianShi
{
    /// <summary>
    /// 编程遍历页面上所有TextBox控件并给它赋值为string.Empty？
    /// </summary>
    public class BBianLiControls
    {
        /// <summary>
        /// 遍历WinForm中的控件
        /// </summary>
        /// <param name="Controls"></param>
        public void BianLi(System.Windows.Forms.Control.ControlCollection Controls)
        {
            foreach (System.Windows.Forms.Control item in Controls)
            {
                if (item is System.Windows.Forms.TextBox)
                {
                    ((System.Windows.Forms.TextBox)item).Text = string.Empty;
                }
            }
        }
        /// <summary>
        /// 遍历WebForm中的控件
        /// </summary>
        /// <param name="Controls"></param>
        public void BianLi(System.Web.UI.ControlCollection Controls)
        {
            foreach (System.Web.UI.Control item in Controls)
            {
                if (item is System.Web.UI.WebControls.TextBox)
                {
                    ((System.Web.UI.WebControls.TextBox)item).Text = string.Empty;
                }
            }
        }
    }
}
