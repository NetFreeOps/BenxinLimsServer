using BenXinLims.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Application.Post
{
    /// <summary>
    /// 用户-岗位对应关系添加服务
    /// </summary>
    public class PostServices:IDynamicApiController
    {
        /// <summary>
        /// 根据用户查询用户岗位
        /// </summary>
        /// <param name="userQuery"></param>
        /// <returns></returns>
        public async Task<List<UserPostEntry>> GetPostByUser([FromQuery] userQueryDto userQuery)
        {
            var db = DbContext.Instance;
            var list = await db.Queryable<UserPostEntry>()
                .WhereIF(userQuery.user_id != -1, it => it.UserId == userQuery.user_id)
                .WhereIF(!string.IsNullOrEmpty(userQuery.user_name), it => it.UserName == userQuery.user_name)
                .ToListAsync();
            return list;
        }
        /// <summary>
        /// 根据岗位查询岗位用户
        /// </summary>
        /// <param name="postQuery"></param>
        /// <returns></returns>
        public async Task<List<UserPostEntry>> GetUserByPost([FromQuery] postQueryDto postQuery)
        {
            var db = DbContext.Instance;
            var list = await db.Queryable<UserPostEntry>()
                .WhereIF(postQuery.post_id != -1, it => it.PostId == postQuery.post_id)
                .WhereIF(!string.IsNullOrEmpty(postQuery.post_name), it => it.PostName == postQuery.post_name)
                .ToListAsync();
            return list;
        }
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="userPost"></param>
        /// <returns></returns>
        public async Task<int> InsertUserPost(UserPostEntry userPost)
        {
            var db = DbContext.Instance;
            //检查该记录是否存在
            if(await db.Queryable<UserPostEntry>().Where(it =>it.UserId == userPost.UserId && it.PostId == userPost.PostId).AnyAsync())
            {
                Oops.Oh("该记录已存在");
            }
            return await db.Insertable(userPost).ExecuteCommandAsync();
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="userPost"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(UserPostEntry userPost)
        {
            var db = DbContext.Instance;
            return await db.Deleteable<UserPostEntry>().Where(it => it.UserId == userPost.UserId && it.PostId == userPost.PostId).ExecuteCommandAsync();
        }
    }
}
