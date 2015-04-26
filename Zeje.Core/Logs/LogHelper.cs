
using System;
using System.IO;
using System.Reflection;
using log4net;

namespace Zeje.Core
{
    public class LogHelper
    {
        #region 全局设置
        public static void Init()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var xml = assembly.GetManifestResourceStream("Zeje.Core.Logs.Log4net.config");
            log4net.Config.XmlConfigurator.Configure(xml);
        }

        public static void Init(string path)
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(path));
        }

        public static void Init(Stream xml)
        {
            log4net.Config.XmlConfigurator.Configure(xml);
        }
        #endregion

        public static void Logger(ILog log, string function, Action tryHandle, ErrorHandle errorHandleType = ErrorHandle.Throw, Action<Exception> catchHandle = null, Action finallyHandle = null)
        {
            try
            {
                log.Debug(function);
                tryHandle();
            }
            catch (Exception ex)
            {
                log.Error(function + "失败", ex);

                if (catchHandle != null)
                    catchHandle(ex);

                if (errorHandleType == ErrorHandle.Throw)
                    throw ex;
            }
            finally
            {
                if (finallyHandle != null)
                    finallyHandle();
            }
        }
    }
}
