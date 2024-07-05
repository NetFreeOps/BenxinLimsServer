using BenXinLims.Core.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Application.Analysis
{
    /// <summary>
    /// 分析分项实体类
    ///</summary>
    [SugarTable("analysis_item")]
    public class AnalysisItemEntry:dbEntryBase
    {
        /// <summary>
        /// 主键 
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        /// <summary>
        /// 分析表主键 
        ///</summary>
        [SugarColumn(ColumnName = "analysis_id")]
        public int? AnalysisId { get; set; }
        /// <summary>
        /// 分析表分析名
        ///</summary>
        [SugarColumn(ColumnName = "analysis_name")]
        public string AnalysisName { get; set;}
        /// <summary>
        /// 名称 
        ///</summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// 版本 
        /// 默认值: 1
        ///</summary>
        [SugarColumn(ColumnName = "version")]
        public int? Version { get; set; }
        /// <summary>
        /// 排序 
        ///</summary>
        [SugarColumn(ColumnName = "order_number")]
        public int? OrderNumber { get; set; }
        /// <summary>
        /// 结果类型 
        ///</summary>
        [SugarColumn(ColumnName = "result_type")]
        public string ResultType { get; set; }
        /// <summary>
        /// 单位 
        ///</summary>
        [SugarColumn(ColumnName = "units")]
        public string Units { get; set; }
        /// <summary>
        /// 最小值，默认空 
        ///</summary>
        [SugarColumn(ColumnName = "min_value")]
        public int? MinValue { get; set; }
        /// <summary>
        /// 最大值，默认空 
        ///</summary>
        [SugarColumn(ColumnName = "max_value")]
        public int? MaxValue { get; set; }
        /// <summary>
        /// 重复数 
        ///</summary>
        [SugarColumn(ColumnName = "places")]
        public int? Places { get; set; }
        /// <summary>
        /// 自动计算 
        ///</summary>
        [SugarColumn(ColumnName = "auto_calc")]
        public int? AutoCalc { get; set; }
        /// <summary>
        /// 通用名 
        ///</summary>
        [SugarColumn(ColumnName = "common_name")]
        public string CommonName { get; set; }
        /// <summary>
        /// 可为空 
        ///</summary>
        [SugarColumn(ColumnName = "nullable")]
        public int? Nullable { get; set; }
        /// <summary>
        /// 可报告 
        ///</summary>
        [SugarColumn(ColumnName = "reportable")]
        public int? Reportable { get; set; }
        /// <summary>
        /// 列表型结果列表键 
        ///</summary>
        [SugarColumn(ColumnName = "list_key")]
        public string ListKey { get; set; }
        /// <summary>
        /// 计算规则，公式 
        ///</summary>
        [SugarColumn(ColumnName = "calc_rule")]
        public string CalcRule { get; set; }
        /// <summary>
        /// 通用计算规则，最后生效 
        ///</summary>
        [SugarColumn(ColumnName = "common_calc_rule")]
        public string CommonCalcRule { get; set; }
        /// <summary>
        /// 修约规则 
        ///</summary>
        [SugarColumn(ColumnName = "round_rule")]
        public string RoundRule { get; set; }
        /// <summary>
        /// 组名 
        ///</summary>
        [SugarColumn(ColumnName = "group_name")]
        public string GroupName { get; set; }
       
    }
}
