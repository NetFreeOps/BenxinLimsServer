using BenXinLims.Core.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Application.Product
{
    /// <summary>
    /// 产品实体类
    ///</summary>
    [SugarTable("product")]
    public class ProductEntry:dbEntryBase
    {
        /// <summary>
        /// 自增主键 
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        /// <summary>
        /// 产品名称 
        ///</summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// 别名 
        ///</summary>
        [SugarColumn(ColumnName = "alias_name")]
        public string AliasName { get; set; }
        /// <summary>
        /// 产品代码 
        ///</summary>
        [SugarColumn(ColumnName = "code")]
        public string Code { get; set; }
        /// <summary>
        /// 检测单名称 
        ///</summary>
        [SugarColumn(ColumnName = "test_list_name")]
        public string TestListName { get; set; }
        /// <summary>
        /// 是否激活 
        ///</summary>
        [SugarColumn(ColumnName = "active")]
        public int? Active { get; set; }
        /// <summary>
        /// 版本 
        ///</summary>
        [SugarColumn(ColumnName = "version")]
        public int? Version { get; set; }
        /// <summary>
        /// 描述信息 
        ///</summary>
        [SugarColumn(ColumnName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// 文件链接 
        ///</summary>
        [SugarColumn(ColumnName = "file_link")]
        public string FileLink { get; set; }
        /// <summary>
        /// 等级模板 
        ///</summary>
        [SugarColumn(ColumnName = "grade")]
        public string Grade { get; set; }
       
    }
}
