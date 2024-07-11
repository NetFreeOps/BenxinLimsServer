using BenXinLims.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Application.ProcessUnit
{
    /// <summary>
    /// 装置层级管理-从最上级开始，逐级到最下级
    /// </summary>
    public class ProcessUnitServices:IDynamicApiController
    {
        /// <summary>
        /// 获取装置列表
        /// </summary>
        /// <param name="unitEntry"></param>
        /// <returns></returns>
        public async Task<List<ProcessUnitEntry>> GetProcessUnit([FromQuery] ProcessUnitEntry unitEntry)
        {
            var db = DbContext.Instance;
            var list = await db.Queryable<ProcessUnitEntry>()
                .WhereIF(!string.IsNullOrEmpty(unitEntry.Name), it => it.Name == unitEntry.Name)
                .WhereIF(!string.IsNullOrEmpty(unitEntry.AliasName), it => it.AliasName == unitEntry.AliasName)
                .ToListAsync();
            return list;
        }
        /// <summary>
        /// 添加装置
        /// </summary>
        /// <param name="unitEntry"></param>
        /// <returns></returns>
        public async Task<int> AddProcessUnit(ProcessUnitEntry unitEntry)
        {
            var db = DbContext.Instance;
            // 检查name不能重复
            if (await db.Queryable<ProcessUnitEntry>().Where(it => it.Name == unitEntry.Name).AnyAsync())
            {
                throw new Exception("装置名称不能重复");
            }
            return await db.Insertable(unitEntry).ExecuteReturnIdentityAsync();
        }
        /// <summary>
        /// 更新装置
        /// </summary>
        /// <param name="unitEntry"></param>
        /// <returns></returns>
        public async Task<int> UpdateProcessUnit(ProcessUnitEntry unitEntry)
        {
            var db = DbContext.Instance;
            if (await db.Queryable<ProcessUnitEntry>().Where(it => it.Name == unitEntry.Name && it.Id != unitEntry.Id ).AnyAsync())
            {
                throw new Exception("装置名称不能重复");
            }
            return await db.Updateable(unitEntry).IgnoreColumns(ignoreAllNullColumns: true). ExecuteCommandAsync();

        }
        /// <summary>
        /// 逻辑删除装置
        /// </summary>
        /// <param name="unitEntry"></param>
        /// <returns></returns>
        public async Task<int> DeleteProcessUnit(ProcessUnitEntry unitEntry)
        {
            var db = DbContext.Instance;
            return await db.Updateable(unitEntry).UpdateColumns(it => new { it.Deleted }).ExecuteCommandAsync();
        }

    }
}
