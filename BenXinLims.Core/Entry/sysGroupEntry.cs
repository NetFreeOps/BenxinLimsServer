using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Core.Entry
{
    /// <summary>
    /// 部门实体类
    ///</summary>
    [SugarTable("sys_group")]
    public class SysGroupEntry:dbEntryBase
    {
        /// <summary>
        /// 自增主键 
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        /// <summary>
        /// 上级部门ID，没有为0 
        ///</summary>
        [SugarColumn(ColumnName = "parent_id")]
        public int? ParentId { get; set; }
        /// <summary>
        /// 部门名称 
        ///</summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// 部门代码 
        ///</summary>
        [SugarColumn(ColumnName = "code")]
        public string Code { get; set; }
        /// <summary>
        /// 是否激活 
        ///</summary>
        [SugarColumn(ColumnName = "active")]
        public int? Active { get; set; }
        /// <summary>
        /// 别名 
        ///</summary>
        [SugarColumn(ColumnName = "alias_name")]
        public string AliasName { get; set; }
        /// <summary>
        /// 所属公司 
        ///</summary>
        [SugarColumn(ColumnName = "work_shop")]
        public string WorkShop { get; set; }
        /// <summary>
        /// 是否是末端部门 
        ///</summary>
        [SugarColumn(ColumnName = "is_end")]
        public int? IsEnd { get; set; }
        
    }
    /// <summary>
    /// 部门查询条件
    /// </summary>
    public class sysGroupQueryEntry
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string AliasName { get; set; }
        public string WorkShop { get; set; }

       
    }
}
