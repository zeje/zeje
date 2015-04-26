using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Zeje.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoDictGroup
    {
        /// <summary>字典类型键
        /// </summary>
        public string DictTypeKey { get; set; }
        /// <summary>字典类型名称
        /// </summary>
        public string DictTypeName { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class AutoDict
    {
        /// <summary>字典类型键
        /// </summary>
        public string DictTypeKey { get; set; }
        /// <summary>字典类型名称
        /// </summary>
        public string DictTypeName { get; set; }
        /// <summary>字典项键
        /// </summary>
        public string DictKey { get; set; }
        /// <summary>字典项名称
        /// </summary>
        public string DictName { get; set; }
        /// <summary>字典项值
        /// </summary>
        public int? DictValue { get; set; }
        /// <summary>字典排序号
        /// </summary>
        public string DictOrder { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class AutoDictManager
    {
        /// <summary>数据库连接字符串
        /// </summary>
        private const string strConnectionString = "server=localhost;database=Zeje.Sys;uid=sa;pwd=123456;";
        /// <summary>字典表数据
        /// </summary>
        private const string strDictSQL = @"SELECT * FROM [dbo].[SysDict]";

        /// <summary>获得数据连接
        /// </summary>
        /// <returns></returns>
        private SqlConnection GetConnection()
        {
            return new SqlConnection(strConnectionString);
        }
        /// <summary>释放连接
        /// </summary>
        /// <param name="con"></param>
        private void ReleaseConnection(SqlConnection con)
        {
            if (con != null)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        /// <summary>DataTable形式返回字典数据
        /// </summary>
        public DataTable GetDictData()
        {
            DataTable dt;
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = strDictSQL;
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dt = ds.Tables[0];
            }

            return dt;
        }
        /// <summary>List形式返回字典数据
        /// </summary>
        public List<AutoDict> GetList()
        {
            DataTable table = GetDictData();
            List<AutoDict> lstAutoDict = new List<AutoDict>();
            if (table != null && table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    AutoDict model = new AutoDict();
                    model.DictKey = row["DictKey"].ToString();
                    model.DictName = row["DictName"].ToString();
                    model.DictOrder = row["DictOrder"].ToString();
                    model.DictTypeKey = row["DictTypeKey"].ToString();
                    model.DictTypeName = row["DictTypeName"].ToString();
                    model.DictValue = row["DictValue"] as int?;
                    lstAutoDict.Add(model);
                }
            }
            return lstAutoDict;
        }
        /// <summary>以类型分组形式返回字典数据
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public IEnumerable<IGrouping<string, AutoDict>> GetlstGroup(List<AutoDict> lst)
        {
            return lst.GroupBy(it => it.DictTypeKey);
        }
        /// <summary>获得字典类型名称
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetDictTypeName(List<AutoDict> lst, string key)
        {
            return lst.Where(it => it.DictTypeKey == key).Select(it => it.DictTypeName).Distinct().SingleOrDefault();
        }
        /// <summary>输出结果
        /// </summary>
        public void Show()
        {
            List<AutoDict> lstAutoDict = GetList();
            var lst = GetlstGroup(lstAutoDict);
            foreach (var grp in lst)
            {
                Console.WriteLine("/// <summary>" + grp.Key);
                Console.WriteLine("/// </summary>");
                Console.WriteLine("public enum " + grp.Key);
                Console.WriteLine("{");
                foreach (var item in grp)
                {
                    Console.WriteLine("/// <summary>" + item.DictName);
                    Console.WriteLine("/// </summary>");
                    Console.WriteLine("{0} = {1}", item.DictKey, item.DictValue);
                    var dn = item.DictName;
                }
            }
        }
    }
}
