using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Core.Entry
{

    /// <summary>
    /// 通用函数表
    ///</summary>
    [SugarTable("common_calc")]
    public class CommonCalc: dbEntryBase
    {
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true)]
        public int Id { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "version")]
        public int Version { get; set; } = 1;
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "source_code")]
        public string SourceCode { get; set; }
        
    }

    /// <summary>
    /// 分析计算函数表
    ///</summary>
    [SugarTable("analysis_calc")]
    public class AnalysisCalc:dbEntryBase
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
        /// 分析分项表主键 
        ///</summary>
        [SugarColumn(ColumnName = "analysis_item_id")]
        public int? AnalysisItemId { get; set; }
        /// <summary>
        /// 版本 
        ///</summary>
        [SugarColumn(ColumnName = "version")]
        public int Version { get; set; } = 1;
        /// <summary>
        /// 源码 
        ///</summary>
        [SugarColumn(ColumnName = "source_code")]
        public string SourceCode { get; set; }
      
    }
    /// <summary>
    /// 设置、更新函数实体类
    /// </summary>
   public class calcEntryDto
    {
        public int Id { get; set; }
        /// <summary>
        /// 类型,analysi或common
        /// </summary>
        public string type { get; set; }
        public string Name { get; set; }    

        public int AnalysisId { get; set; }

        public int AnalysisItemId { get; set; }

       
    }
}
