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

        //添加角色
        public async Task<int> addRole(sysRolesEntry role)
        {
            var db = DbContext.Instance;
            // 角色代码不能重复
            var count = await db.Queryable<sysRolesEntry>().Where(it => it.RoleCode == role.RoleCode).CountAsync();
            if (count > 0)
            {
                throw Oops.Oh("角色代码已存在");
            }
            return await db.Insertable(role).ExecuteCommandAsync();
        }
        //修改角色
        public async Task<int> updateRole(sysRolesEntry role)
        {
            var db = DbContext.Instance;
            // 角色代码不能重复
            var count = await db.Queryable<sysRolesEntry>().Where(it => it.RoleCode == role.RoleCode && it.Id != role.Id).CountAsync();
            if (count > 0)
            {
                throw Oops.Oh("角色代码已存在");
            }
            return await db.Updateable(role).ExecuteCommandAsync();
        }
        //删除角色
        public async Task<int> deleteRole(int roleId)
        {
            var db = DbContext.Instance;
            return await db.Updateable<sysRolesEntry>().SetColumns(it => new sysRolesEntry { Deleted = "1" }).Where(it => it.Id == roleId).ExecuteCommandAsync();
        }
        //添加角色菜单
        public async Task<int> addRoleMenu(sysRoleMenuEntry roleMenu)
        {
           // 开启事务，删除原有角色菜单，添加新菜单，关闭事务
                       var db = DbContext.Instance;
            var result = 0;
            db.Ado.BeginTran();
            try
            {
                await db.Deleteable<sysRoleMenuEntry>().Where(it => it.RoleId == roleMenu.RoleId).ExecuteCommandAsync();
                result = await db.Insertable(roleMenu).ExecuteCommandAsync();
                db.Ado.CommitTran();
            }
            catch (Exception ex)
            {
                db.Ado.RollbackTran();
                throw ex;
            }
            return result;
        }
    }
}
