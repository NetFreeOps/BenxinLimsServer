using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace BenXinLims.Core.Entry
{
    /// <summary>
    /// 系统用户表
    ///</summary>
    [SugarTable("sys_user")]
    public class sysUserEntry : dbEntryBase
    {
        /// <summary>
        /// 自增主键 
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        /// <summary>
        /// 用户ID,六位数,从100000开始 
        ///</summary>
        [SugarColumn(ColumnName = "user_id")]
        public string UserId { get; set; }
        /// <summary>
        /// 用户姓名 
        ///</summary>
        [SugarColumn(ColumnName = "user_name")]
        public string UserName { get; set; }
        /// <summary>
        /// 用户组，默认default 
        ///</summary>
        [SugarColumn(ColumnName = "user_group")]
        public string UserGroup { get; set; }
        /// <summary>
        /// 用户类型 
        ///</summary>
        [SugarColumn(ColumnName = "user_type")]
        public string UserType { get; set; }
        /// <summary>
        /// 头像地址 
        ///</summary>
        [SugarColumn(ColumnName = "avatar")]
        public string Avatar { get; set; }
        /// <summary>
        /// 加密后密码 
        ///</summary>
        [SugarColumn(ColumnName = "password")]
        public string Password { get; set; }
        /// <summary>
        /// 最后登录地址 
        ///</summary>
        [SugarColumn(ColumnName = "last_login_ip")]
        public string LastLoginIp { get; set; }
        /// <summary>
        /// 最后登录时间 
        ///</summary>
        [SugarColumn(ColumnName = "last_login_time")]
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 用户状态：在职、长假、产假、离职、调走 
        ///</summary>
        [SugarColumn(ColumnName = "status")]
        public string Status { get; set; }

    }
}
