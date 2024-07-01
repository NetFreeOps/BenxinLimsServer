using BenXinLims.Core.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Application.Analysis
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("analysis")]
    public class AnalysisEntry: dbEntryBase
    {
        /// <summary>
        /// 自增主键 
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true)]
        public int Id { get; set; }
        /// <summary>
        /// 分析名称，不能重复 
        ///</summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// 版本，默认1 
        ///</summary>
        [SugarColumn(ColumnName = "version")]
        public string Version { get; set; }
        /// <summary>
        /// 组名 
        ///</summary>
        [SugarColumn(ColumnName = "group_name")]
        public string GroupName { get; set; }
        /// <summary>
        /// 实验室名 
        ///</summary>
        [SugarColumn(ColumnName = "lab_name")]
        public string LabName { get; set; }
        /// <summary>
        /// 是否激活 
        ///</summary>
        [SugarColumn(ColumnName = "active")]
        public int Active { get; set; }
        /// <summary>
        /// 报告名称 
        ///</summary>
        [SugarColumn(ColumnName = "report_name")]
        public string ReportName { get; set; }
        /// <summary>
        /// 通用名称 
        ///</summary>
        [SugarColumn(ColumnName = "common_name")]
        public string CommonName { get; set; }
        /// <summary>
        /// 分析类型 
        ///</summary>
        [SugarColumn(ColumnName = "analysis_type")]
        public string AnalysisType { get; set; }
        /// <summary>
        /// 描述信息 
        ///</summary>
        [SugarColumn(ColumnName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// 默认岗位 
        ///</summary>
        [SugarColumn(ColumnName = "default_post")]
        public string DefaultPost { get; set; }
        /// <summary>
        /// 分析标准 
        ///</summary>
        [SugarColumn(ColumnName = "standard")]
        public string Standard { get; set; }
        /// <summary>
        /// 关联文件 
        ///</summary>
        [SugarColumn(ColumnName = "file_link")]
        public string FileLink { get; set; }
      

    }
}
