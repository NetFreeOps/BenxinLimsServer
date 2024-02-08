using BenXinLims.Core.Entry;
using Furion.DynamicApiController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Core.Services
{
    /// <summary>
    /// 角色服务
    /// </summary>
    public class sysRoleService:IDynamicApiController
    {
        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        public async Task<List<sysRolesEntry>> getRoleList()
        {
            var db = DbContext.Instance;
            return await db.Queryable<sysRolesEntry>().Where(it => it.Deleted == "0").ToListAsync();
        }
        // 获取用户具有的角色
        public async Task<List<sysUserRoleEntry>> getUserRole(int userId)
        {
            var db = DbContext.Instance;
            return await db.Queryable<sysUserRoleEntry>().Where(it => it.UserId == userId).ToListAsync();
        }

        // 获取角色菜单
        public async Task<List<sysRoleMenuEntry>> getRoleMenu(int roleId)
        {
            var db = DbContext.Instance;
            return await db.Queryable<sysRoleMenuEntry>().Where(it => it.RoleId == roleId).ToListAsync();
        }
        // 获取角色按钮
        public async Task<List<syRoleButtonEntry>> getRoleButton(int roleId)
        {
            var db = DbContext.Instance;
            return await db.Queryable<syRoleButtonEntry>().Where(it => it.RoleId == roleId).ToListAsync();
        }
        // 获取角色数据权限
        public async Task<List<sysRoleDataEntry>> getRoleData(int roleId)
        {
            var db = DbContext.Instance;
            return await db.Queryable<sysRoleDataEntry>().Where(it => it.RoleId == roleId).ToListAsync();
        }
    }
}
