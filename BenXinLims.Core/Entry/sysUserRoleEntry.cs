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
    [SugarTable("sys_user_role")]
    public class sysUserRoleEntry
    {
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true)]
        public int Id { get; set; }
        /// <summary>
        /// 采用用户工号 
        ///</summary>
        [SugarColumn(ColumnName = "user_id")]
        public int? UserId { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "role_id")]
        public int? RoleId { get; set; }
    }
}
