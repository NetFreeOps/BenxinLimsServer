using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Application.Post
{
    /// <summary>
    /// 用户-岗位对应实体类
    ///</summary>
    [SugarTable("user_post")]
    public class UserPostEntry
    {
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "user_id")]
        public int? UserId { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "user_name")]
        public string UserName { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "post_id")]
        public int? PostId { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "post_name")]
        public string PostName { get; set; }
    }
    /// <summary>
    /// 根据用户查询岗位
    /// </summary>
    public class userQueryDto
    {
        public int? user_id { get; set; }

        public string? user_name { get; set; }
    }
    /// <summary>
    /// 根据岗位查询用户
    /// </summary>
    public class postQueryDto
    {
        public int? post_id { get; set; }

        public string? post_name { get; set; }
    }
}
