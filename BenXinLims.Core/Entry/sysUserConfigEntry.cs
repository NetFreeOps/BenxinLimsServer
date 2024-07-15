using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace BenXinLims.Core.Entry
{
    /// <summary>
    /// 用户配置表
    ///</summary>
    [SugarTable("sys_user_config")]
    public class sysUserConfigEntry: dbEntryBase
    {
        /// <summary>
        /// 主键 
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        /// <summary>
        /// 用户工号，关联sys_user 
        ///</summary>
        [SugarColumn(ColumnName = "user_id")]
        public string UserId { get; set; }
        /// <summary>
        /// 配置类型 
        ///</summary>
        [SugarColumn(ColumnName = "config_type")]
        public string ConfigType { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        [SugarColumn(ColumnName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// 配置字段名 
        ///</summary>
        [SugarColumn(ColumnName = "config_field")]
        public string ConfigField { get; set; }
        /// <summary>
        /// 配置字段值 
        ///</summary>
        [SugarColumn(ColumnName = "config_value")]
        public string ConfigValue { get; set; }
        /// <summary>
        /// 状态 
        ///</summary>
        [SugarColumn(ColumnName = "status")]
        public string Status { get; set; }
    }
}
