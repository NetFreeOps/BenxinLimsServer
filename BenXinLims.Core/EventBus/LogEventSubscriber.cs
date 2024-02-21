using BenXinLims.Core.Entry;
using Furion.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Core.EventBus
{
    public class LogEventSubscriber: IEventSubscriber
    {
        /// 创建登录日志订阅事件
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [EventSubscribe("Create:Vislog")]
        public async Task<string> HandleEventAsync(EventHandlerContext context)
        {
            var db = DbContext.Instance;

            var log = (SysLoginLogEntry)context.Source.Payload;

            await db.Insertable(log).IgnoreColumns(ignoreNullColumn: true).ExecuteCommandAsync();

            return "success";
        }
    }
}
