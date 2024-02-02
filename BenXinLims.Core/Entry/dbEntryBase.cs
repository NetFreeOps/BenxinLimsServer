using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace BenXinLims.Core.Entry
{
    public class dbEntryBase
    {
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "create_user")]
        public string CreateUser { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "change_user")]
        public string ChangeUser { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "change_time")]
        public DateTime? ChangeTime { get; set; }
        /// <summary>
        /// 0为未删除，1为已删除 
        ///</summary>
        [SugarColumn(ColumnName = "deleted")]
        public string Deleted { get; set; }
        /// <summary>
        /// 数据权限
        /// </summary>
        [SugarColumn(ColumnName ="data_id")]
        public string DataId { get; set; }
        public void create()
        {
            this.CreateTime = DateTime.Now;
            this.CreateUser = "admin";

        }

        public void change()
        {
            this.ChangeTime = DateTime.Now;
            this.ChangeUser = "admin";
        }
    }
}
