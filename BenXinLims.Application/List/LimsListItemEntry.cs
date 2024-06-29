using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Application.List
{
    /// <summary>
    /// 列表项实体类
    ///</summary>
    [SugarTable("lims_list_item")]
    public class LimsListItemEntry
    {
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true)]
        public int Id { get; set; }
        /// <summary>
        /// lims_list表的主键 
        ///</summary>
        [SugarColumn(ColumnName = "list_id")]
        public int ListId { get; set; }
        /// <summary>
        /// 显示值 
        ///</summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// 储存值 
        ///</summary>
        [SugarColumn(ColumnName = "value")]
        public string Value { get; set; }
        /// <summary>
        /// 排序 
        ///</summary>
        [SugarColumn(ColumnName = "order")]
        public string Order { get; set; }
    }
}
