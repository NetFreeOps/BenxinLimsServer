using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Core.Entry
{
    /// <summary>
    /// 公司实体类
    ///</summary>
    [SugarTable("sys_work_shop")]
    public class SysWorkShopEntry:dbEntryBase
    {
        /// <summary>
        /// 自增主键 
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        /// <summary>
        /// 公司名称 
        ///</summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// 公司代码 
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
       
    }
}
