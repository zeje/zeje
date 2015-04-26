using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace Zeje.SSO
{
    public class SSOHelper
    {
        /// <summary>设置用户COOKIE
        /// </summary>
        /// <param name="accountName">用户信息</param>
        /// <param name="isPersistent">是否持久化</param>
        public static void SetAuthCookie(string accountName, bool isPersistent = false)
        {
            var _authTicket = new AuthenticationTicket(accountName, DateTime.Now.AddDays(15), isPersistent);
            var _jsonTicket = Utils.Encrypt_.DESEncrypt(_authTicket.ToString());
            var _authCookie = new HttpCookie(Common.ECookie.AuthCookieName.ToString(), _jsonTicket);

            string strDomain = Utils.Config_.GetString(Common.EConfig.WebSiteDomain.ToString());
            if (!string.IsNullOrWhiteSpace(strDomain))
            {
                _authCookie.Domain = strDomain;
            }
            if (isPersistent)
            {
                _authCookie.Expires = DateTime.Now.AddDays(15);
            }
            HttpContext.Current.Response.Cookies.Add(_authCookie);
        }

        /// <summary>清除用户Cookie
        /// </summary>
        public static void ClearAuthCookie()
        {
            var authCookie = HttpContext.Current.Response.Cookies[Common.ECookie.AuthCookieName.ToString()];
            if (authCookie != null)
            {
                authCookie.Expires = DateTime.Now.AddDays(-365);
            }
        }

        /// <summary>从Cookie获取票据
        /// </summary>
        /// <returns></returns>
        public static AuthenticationTicket GetTicket()
        {
            var hcc = HttpContext.Current.Request.Cookies[Common.ECookie.AuthCookieName.ToString()];
            if (hcc != null)
            {
                string strTicket = hcc.Value;
                if (!string.IsNullOrWhiteSpace(strTicket))
                {
                    //解密
                    string ticketInfo = Utils.Encrypt_.DESDecrypt(strTicket);
                    return Utils.Json_.GetObject<AuthenticationTicket>(ticketInfo);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
