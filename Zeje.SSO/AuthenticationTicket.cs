using System;

namespace Zeje.SSO
{
    /// <summary>
    /// <remarks>蔡泽智 2014-10-21
    /// </remarks>
    /// </summary>
    public class AuthenticationTicket
    {
        #region 公有属性
        /// <summary>版本
        /// </summary>
        public string Version { get; set; }
        /// <summary>名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>口令
        /// </summary>
        public string Token
        {
            get
            {
                return Zeje.Utils.Encrypt_.DESEncrypt(Name);
            }
        }
        /// <summary>触发日期
        /// </summary>
        public DateTime IssueDate { get; set; }
        /// <summary>过期时间
        /// </summary>
        public DateTime Expiration { get; set; }
        /// <summary>是否持久化的
        /// </summary>
        public bool IsPersistent { get; set; }

        #endregion

        #region 构造函数
        /// <summary>票据存储
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="timeOut"></param>
        public AuthenticationTicket(string accountName, int timeOut)
        {
            Version = Utils.Config_.GetString(Common.EConfig.TicketVersion.ToString());
            Name = accountName;
            IsPersistent = false;
            IssueDate = DateTime.Now;
            Expiration = DateTime.Now.AddMinutes(timeOut);
        }

        /// <summary>票据存储
        /// </summary>
        /// <param name="accountName">名字</param>
        /// <param name="isSueDate">触发日期</param>
        /// <param name="expiration">过期时间</param>
        /// <param name="isPersistent">是否持久化的,默认为false</param>
        public AuthenticationTicket(string accountName, DateTime expiration, bool isPersistent = false)
        {
            Version = Utils.Config_.GetString(Common.EConfig.TicketVersion.ToString());
            Name = accountName;
            IssueDate = DateTime.Now;
            Expiration = expiration;
            IsPersistent = isPersistent;
        }

        public override string ToString()
        {
            return Utils.Json_.GetString(this);
        }
        #endregion
    }
}
