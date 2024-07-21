using BenXinLims.Core;
using Microsoft.Extensions.Hosting;
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
        /// 获取所有岗位
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task<dynamic> GetPostsList(PostEntry post)
        {
            var db = DbContext.Instance;
            var list = await db.Queryable<PostEntry>().ToListAsync();
            return list;
        }
        /// <summary>
        /// 更新岗位信息
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task<int> UpdatePost(PostEntry post)
        {
            // 岗位代码不能重复
            var db = DbContext.Instance;
            if(await db.Queryable<PostEntry>().Where(it => it.PostCode == post.PostCode && it.Id != post.Id).AnyAsync())
            {
                throw Oops.Oh("岗位代码重复");
            }
            // 查询id对应的岗位名称
            var postName = await db.Queryable<PostEntry>().Where(it => it.Id == post.Id).Select(it => it.PostName).FirstAsync();
            // 根据岗位名称查询是否已经分配
            if (await db.Queryable<UserPostEntry>().Where(it => it.PostName == postName).AnyAsync())
            {
                throw Oops.Oh("该岗位已经使用，不允许更改");
            }
           
           
            // 岗位名称不能重复
            if (await db.Queryable<PostEntry>().Where(it => it.PostName == post.PostName && it.Id != post.Id).AnyAsync())
            {
                throw Oops.Oh("岗位名称重复");
            }
            return await db.Updateable(post).ExecuteCommandAsync();
        }
       /// <summary>
       /// 添加岗位
       /// </summary>
       /// <param name="post"></param>
       /// <returns></returns>
        public async Task<int> AddPost(PostEntry post)
        {
            var db = DbContext.Instance;
            // 检查岗位名称、代码是否存在
            if (await db.Queryable<PostEntry>().Where(a => a.PostName == post.PostName).AnyAsync())
            {
                throw Oops.Oh("岗位名称重复");
            }
            if (await db.Queryable<PostEntry>().Where(it => it.PostCode == post.PostCode).AnyAsync())
            {
                throw Oops.Oh("岗位代码重复");
            }
            return await db.Insertable(post).ExecuteReturnIdentityAsync();
        }

        /// <summary>
        /// 删除岗位
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task<int> DeletePost(PostEntry post)
        {
            var db = DbContext.Instance;
            //已经分配岗位不允许删除
            if (await db.Queryable<UserPostEntry>().Where(it => it.PostName == post.PostName).AnyAsync())
            {
                throw Oops.Oh("该岗位已经使用，不允许删除");
            }
            //删除岗位
            return await db.Deleteable<PostEntry>().Where(it => it.PostName == post.PostName).ExecuteCommandAsync();
        }

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
        /// 添加一条岗位-人员分配，postid取postcode，userid取userid
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
        /// 删除一条岗位-人员分配，postid取postcode，userid取userid
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
