using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace Zeje.Utils
{
    public class Cookie_
    {
        public static string AUTH_COOKIE_NAME = "Wyn88_TPL_Auth";
        private static string WebDomain = System.Configuration.ConfigurationManager.AppSettings["Web_Domain"];

        /// <summary>设置用户COOKIE
        /// </summary>
        /// <param name="LoginName">用户信息</param>
        /// <param name="isSueDate">时间</param>
        /// <param name="createPersistentCookie">是否持久化</param>
        public static void SetAuthCookie(string LoginName,DateTime isSueDate, bool createPersistentCookie = false)
        {
            var _authTicket = new AuthenticationTicket(LoginName, isSueDate, DateTime.Now.AddDays(15), createPersistentCookie);
            var _jsonTicket = DESEncrypt.Encrypt(_authTicket.ToString());
            var _authCookie = new HttpCookie(AUTH_COOKIE_NAME, _jsonTicket);
            //_authCookie.Domain = WebDomain;
            if (createPersistentCookie)
            {
                _authCookie.Expires = DateTime.Now.AddDays(15);
            }
            HttpContext.Current.Response.Cookies.Add(_authCookie);
        }

        /// <summary>清除用户Cookie
        /// </summary>
        public static void ClearAuthCookie()
        {
            var authCookie = HttpContext.Current.Response.Cookies[AUTH_COOKIE_NAME];
            if (authCookie != null)
            {
                authCookie.Expires = DateTime.Now.AddDays(-365);
                //authCookie.Domain = WebDomain;
            }
        }

        /// <summary>获取用户信息
        /// </summary>
        /// <returns></returns>
        public static AuthenticationTicket GetTicket()
        {
            var hcc = HttpContext.Current.Request.Cookies[AUTH_COOKIE_NAME];
            if (hcc != null)
            {
                string strTicket = hcc.Value;
                if (!string.IsNullOrWhiteSpace(strTicket))
                {
                    //解密
                    string ticketInfo = DESEncrypt.Decrypt(strTicket);
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<AuthenticationTicket>(ticketInfo);
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
