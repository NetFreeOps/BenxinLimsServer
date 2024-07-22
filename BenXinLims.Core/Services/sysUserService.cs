﻿using BenXinLims.Core.Entry;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Core.Services
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class sysUserService : IDynamicApiController
    {
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<PageOutEntity> GetUserList([FromQuery] sysUserQueryEntry query)
        {
            var db = DbContext.Instance;
            RefAsync<int> total = 0; new RefAsync<int>();
            var list = await db.Queryable<sysUserEntry>()
                .WhereIF(!string.IsNullOrEmpty(query.UserId), it => it.UserId.Contains(query.UserId))
                .WhereIF(!string.IsNullOrEmpty(query.UserName), it => it.UserName.Contains(query.UserName))
                .WhereIF(!string.IsNullOrEmpty(query.UserGroup), it => it.UserGroup.Contains(query.UserGroup))
                .WhereIF(!string.IsNullOrEmpty(query.UserType), it => it.UserType.Contains(query.UserType))
                .WhereIF(!string.IsNullOrEmpty(query.Status), it => it.Status.Contains(query.Status))
                .WhereIF(!string.IsNullOrEmpty(query.LastLoginIp), it => it.LastLoginIp.Contains(query.LastLoginIp))
                .OrderBy(it => it.Id, OrderByType.Desc)
                .ToPageListAsync(query.PageIndex, query.PageSize, total);
            return new PageOutEntity
            {
                pageData = list,
                total = total.Value,
                PageIndex = query.PageIndex,
                PageSize = query.PageSize
            };

        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<string> AddUser([FromBody] sysUserEntry user)
        {
            var db = DbContext.Instance;
            var isExist = await db.Queryable<sysUserEntry>().AnyAsync(it => it.UserId == user.UserId);
            if (isExist)
            {
                return "用户id重复";
            }
            user.create();
            await db.Insertable(user).ExecuteCommandAsync();
            return "添加成功";
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="user"></param> 
        /// <returns></returns>
        public async Task<string> UpdateUser([FromBody] sysUserEntry user)
        {
            var db = DbContext.Instance;
            var isExist = await db.Queryable<sysUserEntry>().AnyAsync(it => it.UserId == user.UserId && it.Id != user.Id);
            if (isExist)
            {
                return "用户id重复";
            }
            user.change();
            await db.Updateable(user).ExecuteCommandAsync();
            return "更新成功";
        }
    }
}