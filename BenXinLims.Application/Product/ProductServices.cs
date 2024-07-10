using BenXinLims.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Application.Product
{
    /// <summary>
    /// 产品管理服务
    /// </summary>
    public class ProductServices : IDynamicApiController
    {
        /// <summary>
        /// 获取所有产品列表
        /// </summary>
        /// <param name="productEntry"></param>
        /// <returns></returns>
        public async Task<List<ProductEntry>> getAllProduct([FromQuery] ProductEntry productEntry)
        {
            var db = DbContext.Instance;
            var list = await db.Queryable<ProductEntry>()
                .WhereIF(!string.IsNullOrEmpty(productEntry.Name), m => m.Name.Contains(productEntry.Name))
                .WhereIF(!string.IsNullOrEmpty(productEntry.Code), m => m.Code.Contains(productEntry.Code))
                .WhereIF(!string.IsNullOrEmpty(productEntry.AliasName), m => m.AliasName.Contains(productEntry.AliasName))
                .ToListAsync();
            return list;
        }
        /// <summary>
        /// 更新产品
        /// </summary>
        /// <param name="productEntry"></param>
        /// <returns></returns>
        public async Task<int> UpdateProduct(ProductEntry productEntry)
        {
            var db = DbContext.Instance;
            //分别检查产品名称、产品编码是否重复
            if(await db.Queryable<ProductEntry>().Where(it =>it.Name == productEntry.Name && it.Id != productEntry.Id).AnyAsync())
            {
                throw new Exception("产品名称重复");
            }
            if (await db.Queryable<ProductEntry>().Where(it => it.Code == productEntry.Code && it.Id != productEntry.Id).AnyAsync())
            {
                throw new Exception("产品编码重复");
            }
            return await db.Updateable(productEntry).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
        }
        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="productEntry"></param>
        /// <returns></returns>
        public async Task<int> InsertProduct(ProductEntry productEntry)
        {
            var db = DbContext.Instance;
            // 分别检查产品名称、编码是否重复
            if (await db.Queryable<ProductEntry>().Where(it=>it.Name == productEntry.Name).AnyAsync())
            {
                throw new Exception("产品名称不能重复");
            }
            if (await db.Queryable<ProductEntry>().Where(it => it.Code == productEntry.Code).AnyAsync())
            {
                throw new Exception("产品编码不能重复");
            }
            return await db.Insertable(productEntry).ExecuteCommandAsync();
        }
        /// <summary>
        /// 逻辑删除产品
        /// </summary>
        /// <param name="productEntry"></param>
        /// <returns></returns>
        public async Task<int> DeleteProduct(ProductEntry productEntry)
        {
            var db = DbContext.Instance;
            return await db.Updateable(productEntry).UpdateColumns(it => new { it.Deleted }).ExecuteCommandAsync();
        }
    }
}
