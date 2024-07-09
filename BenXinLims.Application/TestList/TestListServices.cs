using BenXinLims.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Application.TestList
{
    /// <summary>
    /// 检测单服务
    /// </summary>
    public class TestListServices : IDynamicApiController
    {
        /// <summary>
        /// 获取所有检测单列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<List<TestListEntry>> getAllTestList([FromQuery] TestListQueryDto query)
        {
            var db = DbContext.Instance;
            var list = await db.Queryable<TestListEntry>()
                .WhereIF(!string.IsNullOrEmpty(query.name), it => it.Name == query.name)
            .WhereIF(!string.IsNullOrEmpty(query.product_name), it => it.ProductName == query.product_name)
            .WhereIF(!string.IsNullOrEmpty(query.type), it => it.Type == query.type)
            .ToListAsync();
            return list;
        }
        /// <summary>
        /// 添加检测单
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public async Task<int> addTestList(TestListEntry entry)
        {
            var db = DbContext.Instance;
            var id = await db.Insertable(entry).ExecuteReturnIdentityAsync();
            return id;
        }
        /// <summary>
        /// 更新检测单
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public async Task<int> updateTestList(TestListEntry entry)
        {
            var db = DbContext.Instance;
            var id = await db.Updateable(entry).ExecuteCommandAsync();
            return id;
        }
        /// <summary>
        /// 删除检测单,同时删除检测单分项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> deleteTestList(int id)
        {
            var db = DbContext.Instance;

            try
            {
                await db.BeginTranAsync();
                await db.Deleteable<TestListEntry>().Where(it => it.Id == id).ExecuteCommandAsync();
                await db.Deleteable<TestListItemEntry>().Where(it => it.TestListId == id).ExecuteCommandAsync();
                await db.CommitTranAsync();
            }
            catch (Exception)
            {
                await db.RollbackTranAsync();
                return -1;
                throw;
            }


            return id;
        }
    }
}
