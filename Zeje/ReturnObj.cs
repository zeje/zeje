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
        public override string ToString()
        {
            string returnValue = string.Empty;
            if (this.Count > 0)
            {
                this.All(msg =>
                {
                    returnValue += msg + Environment.NewLine;
                    return true;
                });
            }
            return returnValue;
        }
        public string ToAlertString()
        {
            string returnValue = string.Empty;
            if (this.Count > 0)
            {

                this.All(msg =>
                {
                    returnValue += msg + "<br/>";
                    return true;
                });
            }
            return returnValue;
        }
    }
}
