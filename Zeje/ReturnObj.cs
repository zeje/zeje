using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Zeje
{
    /// <summary>返回多个信息的集合
    /// </summary>
    public class ReturnObj : List<string>
    {
        public ReturnObj()
        {
            Result = false;
        }
        /// <summary>是否成功
        /// </summary>
        public bool Result { get; set; }
        /// <summary>添加异常信息
        /// </summary>
        /// <param name="ex"></param>
        public void Add(Exception ex)
        {
            base.Add(GetExceptionMessage(ex));
        }
        /// <summary>添加异常信息
        /// </summary>
        /// <param name="errorPrex">前缀</param>
        /// <param name="ex"></param>
        public void Add(string errorPrex, Exception ex)
        {
            base.Add(errorPrex + GetExceptionMessage(ex));
        }
        /// <summary>获得深层次的错误提示
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private string GetExceptionMessage(Exception ex)
        {
            string str = string.Empty;
            if (ex.InnerException != null)
            {
                if (ex.InnerException.InnerException != null)
                {
                    str = ex.InnerException.InnerException.Message;
                }
                else
                {
                    str = ex.InnerException.Message;
                }
            }
            else
            {
                str = ex.Message;
            }
            return str;
        }
        /// <summary>转换为以换行隔开的字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Count > 0 ? string.Join(Environment.NewLine, this) : "";
        }
        /// <summary>转换<br/>以换行隔开的字符串
        /// </summary>
        /// <returns></returns>
        public string ToAlertString()
        {
            return this.Count > 0 ? string.Join("<br/>", this) : "";
        }
    }
}
