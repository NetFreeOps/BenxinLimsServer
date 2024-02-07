using Furion.FriendlyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Core.Enum
{
    [ErrorCodeType]
    public enum ErrorCode
    {
        /// <summary>
        /// 用户名或密码错误
        /// </summary>
        [ErrorCodeItemMetadata("用户名或密码错误")]
        D1000,

        /// <summary>
        /// 服务器错误
        /// </summary>
        [ErrorCodeItemMetadata("服务器错误")]
        D1001,

        /// <summary>
        /// 数据库错误
        /// </summary>
        [ErrorCodeItemMetadata("数据库错误")]
        D1002,

        /// <summary>
        /// 字段不全
        /// </summary>
        [ErrorCodeItemMetadata("字段不全")]
        D1003,

        /// <summary>
        /// 没有权限
        /// </summary>
        [ErrorCodeItemMetadata("没有权限")]
        D1004,

        [ErrorCodeItemMetadata("微信账号未绑定")]
        D1005,

        [ErrorCodeItemMetadata("绑定失败")]
        D1006,

        /// <summary>
        /// 类型错误
        /// </summary>
        [ErrorCodeItemMetadata("类型错误")]
        D1007,
    }
}
