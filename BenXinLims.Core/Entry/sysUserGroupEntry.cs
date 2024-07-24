using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Core.Entry
{
    /// <summary>
    /// 用户部门实体类
    ///</summary>
    [SugarTable("sys_user_group")]
    public class SysUserGroupEntry
    {
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        /// <summary>
        /// 用工号 
        ///</summary>
        [SugarColumn(ColumnName = "user_id")]
        public string UserId { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "user_name")]
        public string UserName { get; set; }
        /// <summary>
        /// 用岗位代码 
        ///</summary>
        [SugarColumn(ColumnName = "group_id")]
        public string GroupId { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "group_name")]
        public string GroupName { get; set; }
    }
}
