using System;
using System.Configuration;

namespace Zeje.Utils
{
    /// <summary>�����ļ�������
    /// </summary>
    public sealed class Config_
    {
        /// <summary>�������
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
        /// <summary>ˢ���������õĻ���
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
        /// <summary>�����������
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int? GetInt(string key)
        {
            return GetString(key).ToNullable_<int>();
        }
        /// <summary>��ò���������
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool? GetBool(string key)
        {
            return GetString(key).ToNullable_<bool>();
        }
        /// <summary>���decimal������
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static decimal? GetDecimal(string key)
        {
            return GetString(key).ToNullable_<decimal>();
        }
    }
}
