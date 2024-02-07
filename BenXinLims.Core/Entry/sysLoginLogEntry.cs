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
    [SugarTable("sys_login_log")]
    public class SysLoginLogEntry
    {
        /// <summary>
        /// 主键 
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true)]
        public int Id { get; set; }
        /// <summary>
        /// 用户id,取工号 
        ///</summary>
        [SugarColumn(ColumnName = "userid")]
        public string Userid { get; set; }
        /// <summary>
        /// 用户姓名 
        ///</summary>
        [SugarColumn(ColumnName = "username")]
        public string Username { get; set; }
        /// <summary>
        /// 是否登录成功，成功为1 
        ///</summary>
        [SugarColumn(ColumnName = "success")]
        public string Success { get; set; }
        /// <summary>
        /// 登录消息 
        ///</summary>
        [SugarColumn(ColumnName = "message")]
        public string Message { get; set; }
        /// <summary>
        /// ip地址 
        ///</summary>
        [SugarColumn(ColumnName = "ip")]
        public string Ip { get; set; }
        /// <summary>
        /// 登录位置 
        ///</summary>
        [SugarColumn(ColumnName = "location")]
        public string Location { get; set; }
        /// <summary>
        /// 浏览器 
        ///</summary>
        [SugarColumn(ColumnName = "browser")]
        public string Browser { get; set; }
        /// <summary>
        /// 系统 
        ///</summary>
        [SugarColumn(ColumnName = "os")]
        public string Os { get; set; }
        /// <summary>
        /// 登录类型 
        ///</summary>
        [SugarColumn(ColumnName = "vis_type")]
        public string VisType { get; set; }
        /// <summary>
        /// 登录时间 
        ///</summary>
        [SugarColumn(ColumnName = "vis_time")]
        public DateTime? VisTime { get; set; }
        /// <summary>
        /// 0为未删除，1为已删除 
        ///</summary>
        [SugarColumn(ColumnName = "deleted")]
        public string Deleted { get; set; } = "0";
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "data_id")]
        public int? DataId { get; set; }
    }
}
