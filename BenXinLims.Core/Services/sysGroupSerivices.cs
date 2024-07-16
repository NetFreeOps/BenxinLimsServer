using BenXinLims.Core.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Core.Services
{
    /// <summary>
    /// 部门管理服务
    /// </summary>
    public class sysGroupServices : IDynamicApiController
    {
        /// <summary>
        /// 获取所有部门列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<List<SysGroupEntry>> GetGroupList([FromQuery] sysGroupQueryEntry query)
        {
            var db = DbContext.Instance;
            var lists = await db.Queryable<SysGroupEntry>()
                .WhereIF(!string.IsNullOrEmpty(query.Name), it => it.Name == query.Name)
                .WhereIF(!string.IsNullOrEmpty(query.Code), it => it.Code == query.Code)
                .WhereIF(!string.IsNullOrEmpty(query.AliasName), it => it.AliasName == query.AliasName)
                .WhereIF(!string.IsNullOrEmpty(query.WorkShop), it => it.WorkShop == query.WorkShop)

                .ToListAsync();
            return lists;
        }
        /// <summary>
        /// 更新部门信息
        /// </summary>
        /// <param name="sysGroup"></param>
        /// <returns></returns>
        public async Task<int> UpdateGroup(SysGroupEntry sysGroup)
        {
            var db = DbContext.Instance;
            // 检查是否重复
            if (await db.Queryable<SysGroupEntry>().Where(it => it.Name == sysGroup.Name || it.Code == sysGroup.Code).Where(it => it.Id != sysGroup.Id).AnyAsync())
            {
                throw Oops.Oh("部门名称或编码重复");
            }
            return await db.Updateable(sysGroup).IgnoreColumns(ignoreAllNullColumns:true). ExecuteCommandAsync();
        }
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="sysGroup"></param>
        /// <returns></returns>
        public async Task<int> AddGroup(SysGroupEntry sysGroup)
        {
            var db = DbContext.Instance;
            if (await db.Queryable<SysGroupEntry>().Where(it => it.Name == sysGroup.Name || it.Code == sysGroup.Code).AnyAsync())
            {
                throw Oops.Oh("部门名称或编码重复");
            }
            return await db.Insertable(sysGroup).ExecuteCommandAsync();
        }
        /// <summary>
        /// 逻辑删除部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteGroup(int id)
        {
            var db = DbContext.Instance;
            return await db.Updateable<SysGroupEntry>().SetColumns(it => new SysGroupEntry() { Deleted = "1" }).Where(it => it.Id == id).ExecuteCommandAsync();
        }

    }
}
