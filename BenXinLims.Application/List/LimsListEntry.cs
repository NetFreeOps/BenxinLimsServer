using BenXinLims.Core.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Application.List
{
    /// <summary>
    /// 列表管理，等同于字典管理
    ///</summary>
    [SugarTable("lims_list")]
    public class LimsListEntry:dbEntryBase
    {
        /// <summary>
        /// 主键 
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true)]
        public int Id { get; set; }
        /// <summary>
        /// 列表名称 
        ///</summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// 列表描述 
        ///</summary>
        [SugarColumn(ColumnName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// 列表分类 
        ///</summary>
        [SugarColumn(ColumnName = "list_type")]
        public string ListType { get; set; }
        /// <summary>
        /// 组名 
        ///</summary>
        [SugarColumn(ColumnName = "group_name")]
        public string GroupName { get; set; }
      

    }

    public class LimsListEntryDto: PageEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ListType { get; set; }
        public string GroupName { get; set; }
    }
}
