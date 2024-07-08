using BenXinLims.Core.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Application.TestList
{
    /// <summary>
    /// 检测单包含的分析表
    ///</summary>
    [SugarTable("test_list_item")]
    public class TestListItem:dbEntryBase
    {
        /// <summary>
        /// 自增主键 
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        /// <summary>
        /// 检测单id 
        ///</summary>
        [SugarColumn(ColumnName = "test_list_id")]
        public int? TestListId { get; set; }
        /// <summary>
        /// 检测单名称 
        ///</summary>
        [SugarColumn(ColumnName = "test_list_name")]
        public string TestListName { get; set; }
        /// <summary>
        /// 检测名称 
        ///</summary>
        [SugarColumn(ColumnName = "analysis_name")]
        public string AnalysisName { get; set; }
        
    }
}
