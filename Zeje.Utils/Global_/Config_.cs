using System;
using System.Configuration;

namespace Zeje.Utils
{
    /// <summary>配置文件辅助类
    /// </summary>
    public sealed class Config_
    {
        /// <summary>获得配置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="isRefresh"></param>
        /// <returns></returns>
        public static string GetString(string key, bool isRefresh = false)
        {
            string strCacheKey = "AppSettings-" + key;
            object objCache = Cache_.GetCache(strCacheKey);
            if (objCache == null || isRefresh)
            {
                try
                {
                    objCache = ConfigurationManager.AppSettings[key];
                    if (objCache != null)
                    {
                        Cache_.SetCache(strCacheKey, objCache, DateTime.Now.AddMinutes(180.0), TimeSpan.Zero);
                    }
                }
                catch
                {
                }
            }
            return (objCache ?? "").ToString();
        }
        /// <summary>刷新所有配置的缓存
        /// </summary>
        /// <returns></returns>
        public static int Refresh()
        {
            foreach (var item in ConfigurationManager.AppSettings.AllKeys)
            {
                GetString(item, true);
            }
            return ConfigurationManager.AppSettings.Count;
        }
        /// <summary>获得整型配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int? GetInt(string key)
        {
            return GetString(key).ToNullable_<int>();
        }
        /// <summary>获得布尔型配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool? GetBool(string key)
        {
            return GetString(key).ToNullable_<bool>();
        }
        /// <summary>获得decimal型配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static decimal? GetDecimal(string key)
        {
            return GetString(key).ToNullable_<decimal>();
        }
    }
}
