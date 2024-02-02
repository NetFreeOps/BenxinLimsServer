using BenXinLims.Core.Entry;
using Furion.DataEncryption;
using Furion.DynamicApiController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Core.Services
{
    /// <summary>
    /// 认证服务
    /// </summary>
    public class sysAuthService:IDynamicApiController
    {
        // web登录
        public Task<string> webLogin(string userid,string password)
        {
            var db = DbContext.Instance;
            var user = db.Queryable<sysUserEntry>().Where(x => x.UserId == userid).First();
            if (user == null)
            {
                return Task.FromResult("用户不存在");
            }
            // MD5加密
            var en_password = MD5Encryption.Encrypt(password);
            if (user.Password != en_password)
            {
                return Task.FromResult("密码错误");
            }

            return Task.FromResult("success");
        }
        // app登录
        public Task<string> appLogin(string username, string password)
        {
            return Task.FromResult("appLogin");
        }
        // 微信登录
        public Task<string> wechatLogin(string username, string password)
        {
            return Task.FromResult("wechatLogin");
        }
        // 钉钉登录
        public Task<string> dingdingLogin(string username, string password)
        {
            return Task.FromResult("dingdingLogin");
        }
        // 第三方API对接登录
        public Task<string> apiLogin(string username, string password)
        {
            return Task.FromResult("apiLogin");
        }
        // web登出
        public Task<string> webLogout(string username)
        {
            return Task.FromResult("webLogout");
        }
        // app登出
        public Task<string> appLogout(string username)
        {
            return Task.FromResult("appLogout");
        }

    }
}
