using BenXinLims.Core;
using BenXinLims.Core.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Application.List
{
    /// <summary>
    /// 列表服务
    /// </summary>
    public class ListServices : IDynamicApiController
    {
        // 多条件分页查询
        public async Task<PageOutEntity> GetList([FromQuery] LimsListEntryDto listEntryDto)
        {

            var db = DbContext.Instance;

            RefAsync<int> total = new RefAsync<int>();

            List<LimsListEntry> list = await db.Queryable<LimsListEntry>()
                .WhereIF(listEntryDto.Name != null,it =>it.Name.Contains(listEntryDto.Name))
                .WhereIF(listEntryDto.ListType != null, it => it.ListType == listEntryDto.ListType)
                .ToPageListAsync(listEntryDto.PageIndex, listEntryDto.PageSize, total);

            PageOutEntity page = new PageOutEntity
            {
                PageIndex = listEntryDto.PageIndex,
                PageSize = listEntryDto.PageSize,
                total = total.Value,
                pageData = list
            };
            return page;
        }
        /// <summary>
        /// 添加列表
        /// </summary>
        /// <param name="listEntry"></param>
        /// <returns></returns>
        public async Task<int> AddList(LimsListEntry listEntry)
        {
            var db = DbContext.Instance;
            // 检查
            if (db.Queryable<LimsListEntry>().Where(x => x.Name == listEntry.Name).Count() > 0)
            {
                throw new Exception("列表名称重复");
            }

            int id = await db.Insertable(listEntry).ExecuteReturnIdentityAsync();
            return id;
        }

        /// <summary>
        /// 更新列表
        /// </summary>
        /// <param name="listEntry"></param>
        /// <returns></returns>
        public async Task<int> UpdateList(LimsListEntry listEntry)
        {
            var db = DbContext.Instance;
            int id = await db.Updateable(listEntry).IgnoreColumns(ignoreAllNullColumns:true). ExecuteCommandAsync();
            return id;
        }
        /// <summary>
        /// 删除列表，同时删除列表项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteList(int id)
        {
            var db = DbContext.Instance;
            db.Deleteable<LimsListItemEntry>().Where(x => x.ListId == id).ExecuteCommand();
            int result = await db.Deleteable<LimsListEntry>().Where(x => x.Id == id).ExecuteCommandAsync();
            return result;
        }
        /// <summary>
        /// 获取列表项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<LimsListItemEntry>> GetListItem(int id)
        {
            var db = DbContext.Instance;
            List<LimsListItemEntry> list = await db.Queryable<LimsListItemEntry>().Where(x => x.ListId == id).ToListAsync();
            return list;
        }
        /// <summary>
        /// 添加列表项
        /// </summary>
        /// <param name="listItemEntry"></param>
        /// <returns></returns>
        public async Task<int> AddListItem(LimsListItemEntry listItemEntry)
        {
            var db = DbContext.Instance;
            int id = await db.Insertable(listItemEntry).ExecuteReturnIdentityAsync();
            return id;
        }
        /// <summary>
        /// 更新列表项
        /// </summary>
        /// <param name="listItemEntry"></param>
        /// <returns></returns>
        public async Task<int> UpdateListItem(LimsListItemEntry listItemEntry)
        {
            var db = DbContext.Instance;
            int id = await db.Updateable(listItemEntry).IgnoreColumns(ignoreAllNullColumns:true). ExecuteCommandAsync();
            return id;
        }
        /// <summary>
        /// 删除列表项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteListItem(int id)
        {
            var db = DbContext.Instance;
            int result = await db.Deleteable<LimsListItemEntry>().Where(x => x.Id == id).ExecuteCommandAsync();
            return result;
        }


    }
}
