using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using Zeje.Model;

namespace Zeje.BLL
{
    /// <summary>winform主线程为单线程，不能用
    /// </summary>
    public class DbContextFactory
    {
        /// <summary>保证了线程内DbContext实例唯一
        /// </summary>
        /// <returns></returns>
        public static Model.Sys.SysEntities GetSysDbContext()
        {
            Model.Sys.SysEntities dbContext = CallContext.GetData("SysDbContext") as Model.Sys.SysEntities;
            if (dbContext == null)
            {
                dbContext = new Model.Sys.SysEntities();
                dbContext.Configuration.ProxyCreationEnabled = false;
                CallContext.SetData("SysDbContext", dbContext);
            }
            return dbContext;
        }

        public static void RefreshDbContext()
        {
            CallContext.SetData("SysDbContext", null);
        }
    }
}
