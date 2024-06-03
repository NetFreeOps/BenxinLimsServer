using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Core.Entry
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("sys_user_workflow")]
    public class SysUserWorkflow:dbEntryBase
    {
        /// <summary>
        /// 主键 
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        /// <summary>
        /// 用户ID 
        ///</summary>
        [SugarColumn(ColumnName = "userid")]
        public int? Userid { get; set; }
        /// <summary>
        /// 配置JSON文件 
        ///</summary>
        [SugarColumn(ColumnName = "config_josn")]
        public string ConfigJosn { get; set; }
        /// <summary>
        /// 配置状态（-1待发布，0禁用，1启用 
        ///</summary>
        [SugarColumn(ColumnName = "config_status")]
        public string ConfigStatus { get; set; }
     
    }
}
