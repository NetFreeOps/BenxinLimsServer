using BenXinLims.Core.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Core.Services
{
    /// <summary>
    /// 公司管理服务
    /// </summary>
    public class sysWorkShopServices:IDynamicApiController
    {
        /// <summary>
        /// 获取所有公司列表
        /// </summary>
        /// <returns></returns>
       public async Task<List<SysWorkShopEntry>> GetWrokShopList()
        {
            var db = DbContext.Instance;

            return await db.Queryable<SysWorkShopEntry>().ToListAsync();
        }
        
        /// <summary>
        /// 更新公司信息
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public async Task<int> UpdateWrokShop(SysWorkShopEntry entry)
        {
            var db = DbContext.Instance;

            return await db.Updateable(entry).IgnoreColumns(ignoreAllNullColumns:true).ExecuteCommandAsync() ;
        }
        /// <summary>
        /// 插入一条公司记录
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public async Task<int> AddWrokShop(SysWorkShopEntry entry)
        {
            var db = DbContext.Instance;
            // 检查是否存在
            if(await db.Queryable<SysWorkShopEntry>().Where(it =>it.Name == entry.Name || it.Code == entry.Code).AnyAsync())
            {
                throw Oops.Oh("公司已经存在，不能重复添加");
            }

            return await db.Insertable(entry).ExecuteCommandAsync();
        }
       /// <summary>
       /// 逻辑删除公司信息-公司创建后原则上不允许删除
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public async Task<int> DeleteWrokShop(int id)
        {
            var db = DbContext.Instance;

            return await db.Updateable<SysWorkShopEntry>().SetColumns(it => new SysWorkShopEntry() { Deleted= "1"})
                .Where(it => it.Id == id).ExecuteCommandAsync() ;
        }
    }
}
