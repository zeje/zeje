//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zeje.Model.Sys
{
    using System;
    using System.Collections.Generic;
    
    public partial class SysField
    {
        public SysField()
        {
            this.SysField1 = new HashSet<SysField>();
        }
    
        public string Id { get; set; }
        public string MyTexts { get; set; }
        public string ParentId { get; set; }
        public string MyTables { get; set; }
        public string MyColums { get; set; }
        public Nullable<int> Sort { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string CreatePerson { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public string UpdatePerson { get; set; }
        public byte[] Version { get; set; }
    
        public virtual ICollection<SysField> SysField1 { get; set; }
        public virtual SysField SysField2 { get; set; }
    }
}
