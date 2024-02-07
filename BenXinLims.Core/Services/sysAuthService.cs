﻿using BenXinLims.Core.Cache;
using BenXinLims.Core.Entry;
using BenXinLims.Core.Enum;
using Furion;
using Furion.DataEncryption;
using Furion.DynamicApiController;
using Furion.EventBus;
using Furion.FriendlyException;
using Microsoft.AspNetCore.Http;
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

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEventPublisher _eventPublisher;
        private readonly RedisCache _redisCache;

        public sysAuthService(IHttpContextAccessor httpContextAccessor, IEventPublisher eventPublisher, RedisCache redisCache)
        {
            _httpContextAccessor = httpContextAccessor;
            _eventPublisher = eventPublisher;
            _redisCache = redisCache;

        }
        // web登录
        public async Task<authEntry> webLogin(sysLoginModel user)
        {
            var db = DbContext.Instance;

           // var httpContext = App.GetService<IHttpContextAccessor>().HttpContext;


            //明文传入加密
            string en_password = MD5Encryption.Encrypt(user.PassWord);

            List<sysUserEntry> userlist = await db.Queryable<sysUserEntry>().Where(it => it.UserId == user.UserId && it.Password == en_password && it.Deleted == "0").ToListAsync();
            if (userlist.Count > 0)
            {
                //生成token
                var token = JWTEncryption.Encrypt(new Dictionary<string, object>
                {
                    {jwtEntry.CLAIM_USERID,user.UserId},
                    {jwtEntry.CLAIM_USERNAME,userlist[0].UserName },
                    {jwtEntry.CLAIM_USERTYPE,userlist[0].UserGroup },
                    {jwtEntry.CLAIM_DATAID,userlist[0].DataId }

                }, 1440);
                //设置swagger自动登录
                _httpContextAccessor.HttpContext.SigninToSwagger(token);

                //设置刷新token
                var refreshToken = JWTEncryption.GenerateRefreshToken(token, 43200);

                _httpContextAccessor.HttpContext.Response.Headers["x-access-token"] = refreshToken;

                // var clent = Parser.GetDefault().Parse(httpContext.Request.Headers["User-Agent"]);
                // 获取浏览器信息


                var clent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"];
                // user-Agent 获取浏览器信息
                var browser = clent.ToString().Split('/')[0];
                // 获取操作系统信息
                var os = clent.ToString().Split('/')[1];


                var ipv4 = _httpContextAccessor.HttpContext.GetRemoteIpAddressToIPv4();

                sysUserEntry loginLogModel = new sysUserEntry()
                {
                    LastLoginIp = ipv4,
                    LastLoginTime = DateTime.Now,

                };

                await db.Updateable(loginLogModel).IgnoreColumns(ignoreAllNullColumns: true).Where(it => it.UserId == user.UserId).ExecuteCommandAsync();

                await _eventPublisher.PublishAsync(new ChannelEventSource("Create:Vislog", new SysLoginLogEntry
                {
                    Userid = user.UserId,
                    Username = userlist[0].UserName,
                    Success = "1",
                    Message = "登录成功",
                    Ip = ipv4,
                    Browser = browser,
                    Os = os,
                    VisType = "1",
                    VisTime = DateTime.Now,

                }));

                authEntry authEntry = new authEntry
                {
                    userId = user.UserId,
                    userName = userlist[0].UserName,
                    userGroup = userlist[0].UserGroup,
                    dataId = userlist[0].DataId,
                    token = token,
                    refreshToken = refreshToken
                };

               

                return authEntry;
            }
            else
            {
                throw Oops.Oh(ErrorCode.D1000);

            }
        }
        // 查询用户角色列表
        public Task<string> getUserRoles(string username)
        {
            return Task.FromResult("getUserRoles");
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
