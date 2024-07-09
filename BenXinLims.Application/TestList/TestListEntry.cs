using BenXinLims.Core.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Application.TestList
{
    /// <summary>
    ///  检测单数据表
    ///</summary>
    [SugarTable("test_list")]
    public class TestListEntry:dbEntryBase
    {
        /// <summary>
        /// 自增主键 
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        /// <summary>
        /// 不可重复名称 
        ///</summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// 是否激活 
        /// 默认值: 1
        ///</summary>
        [SugarColumn(ColumnName = "active")]
        public int? Active { get; set; }
        /// <summary>
        /// 检测单类型，对应样品类型（产品类型） 
        ///</summary>
        [SugarColumn(ColumnName = "type")]
        public string Type { get; set; }
        /// <summary>
        /// 描述信息 
        ///</summary>
        [SugarColumn(ColumnName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// 产品名称 
        ///</summary>
        [SugarColumn(ColumnName = "product_name")]
        public string ProductName { get; set; }
       
    }
    /// <summary>
    /// 检测单查询实体类
    /// </summary>
    public class TestListQueryDto
    {
        public string name { get; set; }

        public string product_name { get;set;}

        public string type { get; set; }
    }
}
