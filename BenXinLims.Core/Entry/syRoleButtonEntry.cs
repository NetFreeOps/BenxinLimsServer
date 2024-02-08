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
    [SugarTable("sys_role_button")]
    public class syRoleButtonEntry
    {
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true)]
        public int Id { get; set; }
        /// <summary>
        /// 岗位ID 
        ///</summary>
        [SugarColumn(ColumnName = "role_id")]
        public int? RoleId { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "button_id")]
        public int? ButtonId { get; set; }
    }
}
