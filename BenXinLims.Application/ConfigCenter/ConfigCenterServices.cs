using BenXinLims.Core;
using BenXinLims.Core.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Application.ConfigCenter
{
    /// <summary>
    /// 配置中心
    /// </summary>
    public class ConfigCenterServices : IDynamicApiController
    {
        /// <summary>
        /// 查找配置
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<List<sysUserConfigEntry>> GetConfig([FromQuery] UserConfigQueryModel query)
        {
            var db = DbContext.Instance;
            var list = await db.Queryable<sysUserConfigEntry>()
                .WhereIF(!string.IsNullOrEmpty(query.UserId), a => a.UserId == query.UserId)
                .WhereIF(!string.IsNullOrEmpty(query.ConfigType), a => a.ConfigType == query.ConfigType)
                .WhereIF(!string.IsNullOrEmpty(query.ConfigField), a => a.ConfigField == query.ConfigField)
                .ToListAsync();
            return list;
        }
        /// <summary>
        /// 更新配置项
        /// </summary>
        /// <param name="configs"></param>
        /// <returns></returns>
        public async Task<int> UpdateConfig(sysUserConfigEntry configs)
        {
            var db = DbContext.Instance;
            return await db.Updateable(configs).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();

        }
        /// <summary>
        /// 插入配置项
        /// </summary>
        /// <param name="configs"></param>
        /// <returns></returns>
        public async Task<int> InsertConfig(sysUserConfigEntry configs)
        {
            var db = DbContext.Instance;
            //检查配置项是否已存在
            if(await db.Queryable<sysUserConfigEntry>().Where(a => a.UserId == configs.UserId && a.ConfigType == configs.ConfigType && a.ConfigField == configs.ConfigField).AnyAsync())
            {
                throw Oops.Oh("配置项已存在");
            }
            return await db.Insertable(configs).ExecuteReturnIdentityAsync();
        }

        /// <summary>
        /// 删除配置项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteConfig(int id)
        {
            var db = DbContext.Instance;

            return await db.Deleteable<sysUserConfigEntry>().Where(it => it.Id == id).ExecuteCommandAsync();

        }
    }
}
