using BenXinLims.Core.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Application.ProcessUnit
{
    /// <summary>
    /// 装置实体类
    ///</summary>
    [SugarTable("process_unit")]
    public class ProcessUnitEntry:dbEntryBase
    {
        /// <summary>
        /// 自增主键 
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        /// <summary>
        /// 父装置ID，没有为0 
        ///</summary>
        [SugarColumn(ColumnName = "parent_id")]
        public int? ParentId { get; set; }
        /// <summary>
        /// 装置名 
        ///</summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// 装置代码 
        ///</summary>
        [SugarColumn(ColumnName = "code")]
        public string Code { get; set; }
        /// <summary>
        /// 是否激活 
        ///</summary>
        [SugarColumn(ColumnName = "active")]
        public int? Active { get; set; }
        /// <summary>
        /// 装置模板 
        ///</summary>
        [SugarColumn(ColumnName = "template")]
        public string Template { get; set; }
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
        /// 是否是末端装置 
        ///</summary>
        [SugarColumn(ColumnName = "is_end")]
        public int? IsEnd { get; set; }
       
    }
}
